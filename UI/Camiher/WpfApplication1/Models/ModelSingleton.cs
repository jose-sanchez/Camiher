using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.UI.AdministrationCenter.Models
{
     class ModelSingleton
    {
        private static CamiherContext _contexDC;
         public ModelSingleton(){}

         public CamiherContext ContexDC
        {
            get { return _contexDC; }
            set { _contexDC = value; }
        }
         static public CamiherContext getDataDC
         {
            get
            {
                if (_contexDC == null)
                {
                    _contexDC = new CamiherContext();
                    
                } 
                return _contexDC;
            }

        }
            
    }
}
