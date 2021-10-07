using System;
using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Infrastructure;

namespace WebAPI_CQRS.Infrastructure.Event
{
    public class EventsHandler
    {
        private static EventsHandler _instance;
        public UtentiCalendariCorsiBusiness _ucc;

        private EventsHandler() { }
        public static void RegisterEvents()
        {
            try
            {
                if (_instance == null) {  
                    _instance = new EventsHandler();  
                }  
                _instance._ucc = new UtentiCalendariCorsiBusiness();
                _instance._ucc.OnUtentePartecipaAlCorso += new UtentiEventHandler.MyUtenteEventHandler(MovimentiBusiness.ContabilizzaPartecipazioneCorso);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public static EventsHandler GetInstance()
        {
            if (_instance == null) {  
                _instance = new EventsHandler();  
            }  
            return _instance;  
        }
        
        
    }
}