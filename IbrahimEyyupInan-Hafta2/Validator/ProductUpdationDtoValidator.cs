using FluentValidation;
using IbrahimEyyupInan_Hafta2.Model.Dto;

namespace IbrahimEyyupInan_Hafta2.Validator
{
    public class ProductUpdationDtoValidator : AbstractValidator<ProductUpdationDto>
    {
        // update işleminde sadece id değeri null olamaz geriye kalan bütün veriler null olabilir 
        // null olan veriler update edilmeyecektir sadece null olmayan veriler database'ye yazılır.
        public ProductUpdationDtoValidator()
        {
            
            RuleFor(prod => prod.Id).NotNull();

        }
    }
}
