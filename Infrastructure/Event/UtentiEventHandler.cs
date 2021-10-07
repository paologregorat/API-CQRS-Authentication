using System;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;

namespace WebAPI_CQRS.Infrastructure.Event
{
    public class UtentiEventHandler
    {
        public delegate void MyUtenteEventHandler(object source, MyEventArgs e);
        
        public class MyEventArgs : EventArgs
        {
            private Utente _eventInfo;
            private SunshineContext _context;

            public MyEventArgs(SunshineContext context, Utente utente) {
                _eventInfo = utente;
                _context = context;
            }

            public Utente GetInfo() {
                return _eventInfo;
            }
            
            public SunshineContext GetContext() {
                return _context;
            }
        }
    }
}