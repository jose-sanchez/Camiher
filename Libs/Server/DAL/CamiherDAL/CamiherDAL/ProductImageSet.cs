using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class ProductImageSet
    {
        [Key]
        public String ImageID { get; set; }
        public String ProductID { get; set; }
        public String Path { get; set; }

        public String Name { get; set; }

        public Int32 Description { get; set; }
        public Int32 Order { get; set; }
        public Boolean Email { get; set; }
        public String Data { get; set; }
      
    }
}
