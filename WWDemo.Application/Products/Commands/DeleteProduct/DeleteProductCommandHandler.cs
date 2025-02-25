using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<ProductRepresentation> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
          
            var result =  _productRepository.DeleteProductBySerialNumber(request.SerialNumber);
            return new ProductRepresentation { SerialNumber = result.Result.SerialNumber};
        }
    }
}
