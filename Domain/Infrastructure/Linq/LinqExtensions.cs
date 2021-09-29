using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace WebAPI_CQRS.Domain.Infrastructure.Linq
{
    public enum FilterTypeEnum
    {
        StringEqual,
        StringArrayEqual,
        IntEqual,
        IntArrayEqual,
        DateEqual,
        GuidEqual,
        GuidArrayEqual,
        StringStartWith,
        StringEndWith,
        StringContains,
        DateGreaterEqualThan,
        DateLessEqualThan,
        DateGreaterThan,
        DateLessThan,
        IntGreaterEqualThan,
        IntLessEqualThan,
        IntGreaterThan,
        IntLessThan,
        BoolEqual
    }
    public class FilterAttribute: Attribute
    {
        public FilterTypeEnum Type { get; set; }
    }
    public static class LinqExtensions 
    {
        
        private static PropertyInfo GetPropertyInfo(Type objType, string name)
        {
            var properties = objType.GetProperties();
            var matchedProperty = properties.FirstOrDefault (p => p.Name == name);
            if (matchedProperty == null)
            {
                var textError = "GetPropertyInfo error, property not found: " + name;
                throw new Exception(textError, new Exception(textError));
            }

            return matchedProperty;
        }
        private static LambdaExpression GetOrderExpression(Type objType, PropertyInfo pi)
        {
            var paramExpr = Expression.Parameter(objType);
            var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
            var expr = Expression.Lambda(propAccess, paramExpr);
            return expr;
        }
        

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return query;
            }

            PropertyInfo propInfo = null;
            MethodInfo method = null;
            LambdaExpression expr = null;
            
            if (name.StartsWith("-"))
            {
                name = name.Substring(1);
                propInfo = GetPropertyInfo(typeof(T), name);
                expr = GetOrderExpression(typeof(T), propInfo);
                method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);
            }
            else
            {
                propInfo = GetPropertyInfo(typeof(T), name);
                expr = GetOrderExpression(typeof(T), propInfo);
                method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
            }
            
            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);     
            return (IEnumerable<T>) genericMethod.Invoke(null, new object[] { query, expr.Compile() });
        }

        
        
        public static IEnumerable<T> TakeNullable<T>(this IEnumerable<T> query, int? limit)
        {
            if (limit != default && limit.Value > 0)
            {
                return query.Take(limit.Value);
            }
            return query;
        }
        
        public static IEnumerable<T> SkipNullable<T>(this IEnumerable<T> query, int? offset)
        {
            if (offset != default && offset.Value > 0)
            {
                return query.Skip(offset.Value);
            }
            return query;
        }
        
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> query, dynamic request)
        {
            if (request == null)
            {
                return query;
            }

            Type type = request.GetType();

            foreach(var field in type.GetProperties())
            {
                object[] attribute = field.GetCustomAttributes(typeof(FilterAttribute), true);
                if (attribute.Length > 0)
                {
                    FilterAttribute myAttribute = (FilterAttribute)attribute[0];
                    FilterTypeEnum propertyValue = myAttribute.Type;
                    
                    switch (propertyValue)
                    {
                        case FilterTypeEnum.StringEqual:
                            string? valueString = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueString != null)
                            {
                                query = query.Where(r => r.GetType().GetProperty(field.Name).GetValue(r).ToString().ToUpper() == valueString.ToUpper()).ToList();
                            }
                            break;
                        case FilterTypeEnum.IntEqual:
                            int? valueInt = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueInt != null)
                            {
                                query = query.Where(r => (int?)r.GetType().GetProperty(field.Name).GetValue(r) == valueInt).ToList();
                            }
                            break;
                        case FilterTypeEnum.DateEqual:
                            string? varStrDE  = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            DateTime? valueDate = null;
                            if (!String.IsNullOrEmpty(varStrDE))
                            {
                                valueDate = Convert.ToDateTime(varStrDE);
                            }
                            if (valueDate != null)
                            {
                                query = query.Where(r => (DateTime?)r.GetType().GetProperty(field.Name).GetValue(r) == valueDate).ToList();
                            }
                            break;
                        case FilterTypeEnum.GuidEqual:
                            string? varStrG  = request.GetType().GetProperty(field.Name).GetValue(request, null) != null ?  request.GetType().GetProperty(field.Name).GetValue(request, null).ToString() : null;
                            if (!string.IsNullOrEmpty(varStrG))
                            {
                                Guid? valueGuid = null;
                                valueGuid = new Guid(varStrG.ToString());
                                if (valueGuid != null)
                                {
                                    query = query.Where(r => (Guid?)r.GetType().GetProperty(field.Name).GetValue(r) == valueGuid).ToList();
                                }
                            }
                            
                            break;
                        case FilterTypeEnum.StringArrayEqual:
                            string? valueStringArray = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueStringArray != null)
                            {
                                query = query.Where(r => ((string[])r.GetType().GetProperty(field.Name).GetValue(r)).Contains(valueStringArray)).ToList();
                            }
                            break;
                        case FilterTypeEnum.IntArrayEqual:
                            int? valueIntArray = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueIntArray != null)
                            {
                                query = query.Where(r => ((int?[])r.GetType().GetProperty(field.Name).GetValue(r)).Contains(valueIntArray)).ToList();
                            }
                            break;
                        //case FilterTypeEnum.GuidArrayEqual:
                        //    string? varStrGA  = request.GetType().GetProperty(field.Name).GetValue(request, null).ToString();
                        //    Guid? valueGuidArray = null;
                        //    Guid? valueGuid = null;
                        //    if (!String.IsNullOrEmpty(varStrGA))
                        //    {
                        //        valueGuid = new Guid(varStrGA);
                        //    }
                        //    if (valueGuidArray != null)
                        //    {
                        //        query = query.Where(r => ((Guid?[])r.GetType().GetProperty(field.Name).GetValue(r)).Contains(valueGuidArray)).ToList();
                        //    }
                        //    break;
                        case FilterTypeEnum.StringStartWith:
                            string? valueStringStartWith = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueStringStartWith != null)
                            {
                                query = query.Where(r => r.GetType().GetProperty(field.Name).GetValue(r).ToString().ToUpper().StartsWith(valueStringStartWith.ToUpper())).ToList();
                            }
                            break;
                        case FilterTypeEnum.StringEndWith:
                            string? valueStringEndWith = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueStringEndWith != null)
                            {
                                query = query.Where(r => r.GetType().GetProperty(field.Name).GetValue(r).ToString().ToUpper().EndsWith(valueStringEndWith.ToUpper())).ToList();
                            }
                            break;
                        case FilterTypeEnum.StringContains:
                            string? valueStringContains = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueStringContains != null)
                            {
                                query = query.Where(r => r.GetType().GetProperty(field.Name).GetValue(r).ToString().ToUpper().Contains(valueStringContains.ToUpper())).ToList();
                            }
                            break;
                        case FilterTypeEnum.DateGreaterEqualThan:
                            string? varStrDGEQ  = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            DateTime? valueDateGreaterEqualThan = null;
                            if (!String.IsNullOrEmpty(varStrDGEQ))
                            {
                                valueDateGreaterEqualThan = Convert.ToDateTime(varStrDGEQ);
                            }
                            if (valueDateGreaterEqualThan != null)
                            {
                                query = query.Where(r => (DateTime?)r.GetType().GetProperty(field.Name).GetValue(r) >= valueDateGreaterEqualThan).ToList();
                            }
                            break;
                        case FilterTypeEnum.DateLessEqualThan:
                            string? varStrDLEQ  = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            DateTime? valueDateLessEqualThan = null;
                            if (!String.IsNullOrEmpty(varStrDLEQ))
                            {
                                valueDateLessEqualThan = Convert.ToDateTime(varStrDLEQ);
                            }
                            if (valueDateLessEqualThan != null)
                            {
                                query = query.Where(r => (DateTime?)r.GetType().GetProperty(field.Name).GetValue(r) <= valueDateLessEqualThan).ToList();
                            }
                            break;
                        case FilterTypeEnum.DateGreaterThan:
                            string? varStrGQ  = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            DateTime? valueDateGreaterThan = null;
                            if (!String.IsNullOrEmpty(varStrGQ))
                            {
                                valueDateGreaterThan = Convert.ToDateTime(varStrGQ);
                            }
                            if (valueDateGreaterThan != null)
                            {
                                query = query.Where(r => (DateTime?)r.GetType().GetProperty(field.Name).GetValue(r) > valueDateGreaterThan).ToList();
                            }
                            break;
                        case FilterTypeEnum.DateLessThan:
                            
                            DateTime? valueDateLessThan = request.GetType().GetProperty(field.Name).GetValue(request, null);;
                            
                            if (valueDateLessThan != null)
                            {
                                var query1 = query.Where(r => r.GetType().GetProperty(field.Name).GetValue(r) == null).ToList();
                                var query2 = query.Where(r => r.GetType().GetProperty(field.Name).GetValue(r) != null).ToList();
                                var query3 = query2.Where(r => ((DateTime?) r.GetType().GetProperty(field.Name).GetValue(r)).Value < valueDateLessThan).ToList();
                                query = query1.Concat(query3).ToList();
                            }
                            break;
                        case FilterTypeEnum.IntGreaterEqualThan:
                            int? valueIntGreaterEqualThan = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueIntGreaterEqualThan != null)
                            {
                                query = query.Where(r => (int?)r.GetType().GetProperty(field.Name).GetValue(r) >= valueIntGreaterEqualThan).ToList();
                            }
                            break;
                        case FilterTypeEnum.IntLessEqualThan:
                            int? intDateLessEqualThan = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (intDateLessEqualThan != null)
                            {
                                query = query.Where(r => (int?)r.GetType().GetProperty(field.Name).GetValue(r) <= intDateLessEqualThan).ToList();
                            }
                            break;
                        case FilterTypeEnum.IntGreaterThan:
                            int? valueIntGreaterThan = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueIntGreaterThan != null)
                            {
                                query = query.Where(r => (int?)r.GetType().GetProperty(field.Name).GetValue(r) > valueIntGreaterThan).ToList();
                            }
                            break;
                        case FilterTypeEnum.IntLessThan:
                            int? valueIntLessThan = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            if (valueIntLessThan != null)
                            {
                                query = query.Where(r => (int?)r.GetType().GetProperty(field.Name).GetValue(r) < valueIntLessThan).ToList();
                            }
                            break;
                        case FilterTypeEnum.BoolEqual:
                            string? varStr  = request.GetType().GetProperty(field.Name).GetValue(request, null);
                            bool? valueBoolEqual = null;
                            if (!String.IsNullOrEmpty(varStr))
                            {
                                valueBoolEqual = Convert.ToBoolean(varStr);
                            }
                            if (valueBoolEqual != null)
                            {
                                query = query.Where(r => (bool?)r.GetType().GetProperty(field.Name).GetValue(r) == valueBoolEqual).ToList();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return query;
        }
        
        
        public static Expression<Func<T, bool>> OrTheseFiltersTogether<T>(
            this IEnumerable<Expression<Func<T, bool>>> filters)
        {
            Expression<Func<T, bool>> firstFilter = filters.FirstOrDefault();
            if (firstFilter == null)
            {
                Expression<Func<T, bool>> alwaysTrue = x => true;
                return alwaysTrue;
            }

            var body = firstFilter.Body;
            var param = firstFilter.Parameters.ToArray();
            foreach (var nextFilter in filters.Skip(1))
            {
                var nextBody = Expression.Invoke(nextFilter, param);
                body = Expression.OrElse(body, nextBody);
            }
            Expression<Func<T, bool>> result = Expression.Lambda<Func<T, bool>>(body, param);
            return result;
        }
        
    }
}