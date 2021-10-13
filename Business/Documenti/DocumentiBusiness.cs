using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Business.GenerazioneDocumenti.Concrete;
using WebAPI_CQRS.Business.GenerazioneDocumenti.Directors;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Infrastructure.Commons;
using WebAPI_CQRS.Domain.Queries.Serializer.Documenti;
using WebAPI_CQRS.Domain.Queries.Serializer.Movimenti;
using WebAPI_CQRS.Infrastructure.Event;

//using System.Data.Entity;

namespace WebAPI_CQRS.Business.Documenti
{
    public class DocumentiBusiness: IDocumentiBusiness
    {
        private DocumentoSerializer _serializer;
        private SunshineContext _context;

        public DocumentiBusiness(SunshineContext context, IMovimentoSerializer serializer)
        {
            _serializer = (DocumentoSerializer)serializer;
            _context = context;
        }
        
        public DocumentoMovimentiUtenteDTO GetDocumentoMovimentiUtente(Guid utenteID)
        {
            var director = new DirectorDocumento();
            var builder = new ConcreteBuilderDocumentoRiepilogoMovimentiUtente(_context, utenteID);
            director.Builder = builder;
            
            director.GeneraDocumentoCompleto();
            var doc = director.GetDocumento();
            
            return _serializer.SerializeDocumentoMovimentiUtente(doc);
        }
        
        public DocumentoRiepilogoPresenzaLezioniUtenteDTO GetDocumentoRiepilogoPresenzaLezioni(Guid utenteID)
        {
            var director = new DirectorDocumento();
            var builder = new ConcreteBuilderDocumentoRiepilogoPresenzaLezioniUtente(_context, utenteID);
            director.Builder = builder;
            
            director.GeneraDocumentoCompleto();
            var doc = director.GetDocumento();
            
            return _serializer.SerializeDocumentoRiepilogoPresenzaLezioniUtente(doc);
        }

        
    }
}
