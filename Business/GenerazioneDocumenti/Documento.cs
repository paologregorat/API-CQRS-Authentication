using System.Collections.Generic;

namespace WebAPI_CQRS.Business.GenerazioneDocumenti
{
    public class Documento
    {
        public Documento()
        {
            _righeDocumento = new List<RigaDocumento>();
        }
        class RigaDocumento
        {
            public string TestoRiga { get; set; }
            public double TotaleRiga { get; set; }
        }
        private string _testata;
        private List<RigaDocumento> _righeDocumento;
        private double _totaleDocumento;

        public void SetTestata(string testata)
        {
            _testata = testata;
        }

        public void AddRigaDocumento(string testo, double totaleRiga)
        {
            var riga = new RigaDocumento();
            riga.TestoRiga = testo;
            riga.TotaleRiga = totaleRiga;
            _righeDocumento.Add(riga);
        }

        public void CalcolaTotaleDocumento()
        {
            double totale = 0;
            foreach(var riga in _righeDocumento)
            {
                totale += riga.TotaleRiga;
            }
            _totaleDocumento = totale;
        }

    }
}