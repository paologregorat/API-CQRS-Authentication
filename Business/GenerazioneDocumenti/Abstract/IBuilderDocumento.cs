namespace WebAPI_CQRS.Business.GenerazioneDocumenti.Abstract
{
    public interface IBuilderDocumento
    {
        void BuildTestata();

        void BuidlDettaglio();

        void BuildTotale();

        Documento GetDocumentoIntero();
    }
}