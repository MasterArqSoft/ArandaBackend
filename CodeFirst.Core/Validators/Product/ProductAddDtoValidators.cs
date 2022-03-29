using CodeFirst.Core.DTOs.Product.Requests;
using CodeFirst.Core.Interfaces.Repositories;
using FluentValidation;
using System.Threading.Tasks;

namespace CodeFirst.Core.Validators.Product
{
    public class ProductAddDtoValidators : AbstractValidator<ProductAddDtoRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductAddDtoValidators(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Name)
                  .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.")
                  .NotNull().WithMessage("El campo {PropertyName}  es requerido.")
                  .MinimumLength(2).WithMessage("El campo {PropertyName} debe  tener minimo 3 caracteres.")
                  .MaximumLength(50).WithMessage("El campo {PropertyName} debe  tener un maximo de caracteres de 50.")
                  .MustAsync(async (x, cancellation) => await NameExistsAsync(x))
                            .WithMessage("El campo {PropertyName} que incluye el valor {PropertyValue} ya existe en el sistemas.")
                  ;
            RuleFor(x => x.Description)
                  .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.")
                  .NotNull().WithMessage("El campo {PropertyName}  es requerido.")
                  .MinimumLength(2).WithMessage("El campo {PropertyName} debe  tener minimo 2 caracteres.")
                  .MaximumLength(50).WithMessage("El campo {PropertyName} debe  tener un maximo de caracteres de 50.")
                  ;
            RuleFor(x => x.Category)
                  .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.")
                  .NotNull().WithMessage("El campo {PropertyName}  es requerido.")
                  .MinimumLength(2).WithMessage("El campo {PropertyName} debe  tener minimo 2 caracteres.")
                  .MaximumLength(50).WithMessage("El campo {PropertyName} debe  tener un maximo de caracteres de 50.")
                  ;
            RuleFor(x => x.Images)
                  .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.")
                  .NotNull().WithMessage("El campo {PropertyName}  es requerido.")
                  .MinimumLength(2).WithMessage("El campo {PropertyName} debe  tener minimo 2 caracteres.")
                  ;
        }
        public async Task<bool> NameExistsAsync(string name) => !await _unitOfWork.ProductRepositoryAsync
                              .GetExistsAsync(x => x.Name.Trim().ToUpper()
                                                            .Equals(name.Trim().ToUpper())
                                         );
    }
}
