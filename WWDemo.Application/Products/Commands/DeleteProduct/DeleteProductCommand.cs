using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ProductRepresentation>
    {
        public string? SerialNumber { get; set; }
    }
}
