using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class ProductsSet
    {
        [Key]
        public string Id { get; set; }

        public string Producto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }



        public Int32 Año { get; set; }

        public Int32 Potencia { get; set; }
        public Int32 Peso { get; set; }
        public string Descripcion { get; set; }
        public Int32 Precio { get; set; }
        public Int32 Cantidad { get; set; }
        public string Enventa { get; set; }        
        public string Enbusca { get; set; }
        public string Proveedor_ID { get; set; }
        public Int32 Kilometer { get; set; }
        public Int32 Hours { get; set; }
        public string PrivateDescription { get; set; }

        [NotMapped]
        public string ImageMain { get; set; }
    }
}
