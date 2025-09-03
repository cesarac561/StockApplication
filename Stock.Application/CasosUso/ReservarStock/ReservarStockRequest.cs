using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Application.Common;

namespace Stock.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class ReservarStockRequest : IRequest<IResult>
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; } 
    }
}
