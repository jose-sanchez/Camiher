using Camiher.Libs.Server.DAL.CamiherLocalDAL;

namespace Camiher.UI.AdministrationCenter.Models
{
     class ModelSingleton
    {
        private static Model1Container _contexDC;
         public ModelSingleton(){}

        public Model1Container ContexDC
        {
            get { return _contexDC; }
            set { _contexDC = value; }
        }
        static public Model1Container getDataDC {
            get
            {
                if (_contexDC == null)
                {
                    _contexDC = new Model1Container();
                    
                } 
                return _contexDC;
            }

        }
            
    }
}
