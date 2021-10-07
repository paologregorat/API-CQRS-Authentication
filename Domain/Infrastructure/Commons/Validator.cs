using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Infrastructure.Commons
{
    public class Validator<T> where T : EntityBase
    {
        public static bool CheckEntity(Func<T, bool> checkFuncion, T entity)
        {
            return checkFuncion(entity);
        }
    }
}