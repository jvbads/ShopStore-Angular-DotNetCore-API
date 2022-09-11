using System.ComponentModel.DataAnnotations;

namespace ShopStore.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceDiscount { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}
