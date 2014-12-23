using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiher.Libs.Server.DAL.CamiherDAL
{
    public class ClientSet
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneMain { get; set; }

        public string PhoneSecond { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }        
        public string Account { get; set; }
        public string PrivateDescription { get; set; }
    }
}
