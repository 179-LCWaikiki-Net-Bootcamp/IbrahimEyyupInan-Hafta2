using FluentValidation;
using IbrahimEyyupInan_Hafta2.Model;
using IbrahimEyyupInan_Hafta2.Model.Dto;

namespace IbrahimEyyupInan_Hafta2.Validator
{
    public class ProductCreationDtoValidator : AbstractValidator<ProductCreationDto>
    {
        // create işleminde bütün veriler günderilmek zorundadır.
        public ProductCreationDtoValidator()
        {
            RuleFor(prod => prod.Price).GreaterThan(0).WithMessage("price cannot be less than zero").NotNull()  ;
            RuleFor(prod => prod.categoryId).NotNull();
            RuleFor(prod=> prod.Name).NotNull();    
            RuleFor(prod => prod.sku).NotNull();

        }
        
    }
}
