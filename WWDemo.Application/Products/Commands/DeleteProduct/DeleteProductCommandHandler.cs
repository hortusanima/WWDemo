using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Data.Products;
using WWDemo.Models;

namespace WWDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductRepresentation> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteProduct(request.SerialNumber);
          
            return new ProductRepresentation { SerialNumber = result.SerialNumber };
        }
    }
}
