using System.Configuration;
using System.Web;


namespace MgRequeteClients.API
{
    public class clsDeclaration
    {
        #region REGIONS FICHIERS
        //public static HttpPostedFile DOCUMENT_FICHIER = null;
        public static IFormFile[] DOCUMENT_FICHIER = null;
        public static string DOCUMENT_NOMFICHIER = "";
        //public static string[] DOCUMENT_NOMFICHIER = null;
        public static string[] DOCUMENT_EXTENTIONFICHIER = null;
        public static string[] AG_CODEAGENCE = null;
        public static string[] RQ_CODEREQUETE = null;
        public static string[] AT_INDEXETAPE = null;
        public static string[] RE_CODEETAPE = null;
        public static string[] AT_DATEFINTRAITEMENTETAPE = null;
        public static string[] AT_OBSERVATION = null;
        public static string[] CT_CODEREQUETECONTENTIEUX = null;
        public static string DOCUMENT_FilePathold = "";
        public static string DOCUMENT_FilePathnew = "";
        public static string[] DOCS_FICHIERS = null;

        #endregion
    }
}
