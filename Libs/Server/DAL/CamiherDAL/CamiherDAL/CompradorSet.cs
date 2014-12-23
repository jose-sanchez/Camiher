using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class CompradorSet
    {
        [Key]
        public String Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }

        public String TelefonoM { get; set; }

        public String TelefonoF { get; set; }
        public String Direccion { get; set; }
        public String Descripcion { get; set; }
        public String Email { get; set; }        
    }
}
