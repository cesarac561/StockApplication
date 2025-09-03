using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Application.Common;

namespace Stock.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class ConsultarProductosRequest: IRequest<IResult>
    {
        public int FiltroPorId { get; set; }
        public string FiltroPorNombre { get; set; } 
    }
}
