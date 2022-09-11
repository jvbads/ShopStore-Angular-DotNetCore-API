using System.ComponentModel.DataAnnotations;

namespace ShopStore.Application.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceDiscount { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        //public CategoryDto Category { get; set; }

        //public int Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigtório.")]
        //public int Number { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigtório.")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigtório.")]
        //public double Price { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigtório.")]
        //public double PriceDiscount { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigtório.")]
        //public string Description { get; set; }

        //public int CategoryId { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigtório.")]
        //public CategoryDto Category { get; set; }

    }
}
