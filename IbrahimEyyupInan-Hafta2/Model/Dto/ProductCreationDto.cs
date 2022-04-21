namespace IbrahimEyyupInan_Hafta2.Model.Dto
{
    public class ProductCreationDto
    {
        //Product üretileceği zaman dışarıdan alınacak veriyi belirler.
        public string Name { get; set; }
        public string sku { get; set; }
        public double? Price { get; set; }
        public int? categoryId { get; set; }
    }
}
