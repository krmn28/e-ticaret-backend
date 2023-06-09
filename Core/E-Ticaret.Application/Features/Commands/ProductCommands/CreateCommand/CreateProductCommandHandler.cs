using E_Ticaret.Application.Repositories.Products;
using MediatR;

namespace E_Ticaret.Application.Features.Commands.ProductCommands.CreateCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
         private readonly IProductWriteRepository _productWriteRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
           var result =  await _productWriteRepository.AddAsync(new(){
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                UnitsInStock = request.UnitsInStock
            });
             await _productWriteRepository.SaveAsync();
            return result ? new("Ürün başarıyla kayıt edildi", true) : new("Ürün kayıt edilirken bir hata oluştu", false);
        }
   
   
   
   }
}