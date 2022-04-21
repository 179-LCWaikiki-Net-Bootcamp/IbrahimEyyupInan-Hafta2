namespace IbrahimEyyupInan_Hafta2.Model.Dto
{
    public class ProductUpdationDto:ProductCreationDto
    {
        // bu class put metodunda ekstradan id parametresi olabilmesi için ve 
        // create ve update işlemlerinde kullanılacak olan validation işlemlerini birbirinden ayırmak için kullanılıyor.
        // bu ayrımın yapılmasının nedeni create işleminde eksiksiz veri gönderilmesinin gerekmesi ancak güncelleme işleminde
        // sadece güncellenecek alanların gönderilebilir olmasını sağlamaktır.
        public int? Id { get; set; }
    }
}
