using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entidades
{
    public class TAPedido : TAPedidoDetalle
    {
        public int ClienteId { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}
