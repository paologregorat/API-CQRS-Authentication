using WebAPI_CQRS.Business.GenerazioneDocumenti.Abstract;

namespace WebAPI_CQRS.Business.GenerazioneDocumenti.Directors
{
    public class DirectorDocumento
    {
        private IBuilderDocumento _builder;

        public IBuilderDocumento Builder
        {
            set { _builder = value; }
        }
        
        public void AggiungiTestata()
        {
            this._builder.BuildTestata();
        }

        public void AggiungiRighe()
        {
            this._builder.BuidlDettaglio();
        }
        
        public void AggiungiTotale()
        {
            this._builder.BuildTotale();
        }
        
        public void GeneraDocumentoCompleto()
        {
            this._builder.BuildTestata();
            this._builder.BuidlDettaglio();
            this._builder.BuildTotale();
        }

        public Documento GetDocumento()
        {
            return this._builder.GetDocumentoIntero();
        }
        
    }
}