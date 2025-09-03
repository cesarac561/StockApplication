using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.CasosUso.AdministrarProductos.RegistrarProductos
{
    public  class RegistrarProductosValidator: AbstractValidator<RegistrarProductosRequest>
    {
        public RegistrarProductosValidator() {
            RuleFor(item => item.IdProducto).GreaterThan(0).WithMessage("El id producto debe ser mayor a 0");
            RuleFor(item => item.Nombre).NotEmpty().WithMessage("El nombre no puede ser vacío");
            RuleFor(item => item.Stock).GreaterThan(0).WithMessage("El stock debe ser mayor a 0");
            RuleFor(item => item.StockMinimo).GreaterThan(0).WithMessage("El stock minimo debe ser mayor a 0");
            RuleFor(item => item.StockMinimo).GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0");
        }
    }
}
