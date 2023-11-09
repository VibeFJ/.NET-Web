using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entidades
{
    public class TACliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set;}
        public string ApellidoMaterno { get; set; }
    }
}
