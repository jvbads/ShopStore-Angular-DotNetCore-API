using System.ComponentModel.DataAnnotations;

namespace ShopStore.Application.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo 50 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Codigo do Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public int Number { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public double Price { get; set; }

        [Display(Name = "Preço Promocional")]
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public double PriceDiscount { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo 200 caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public int CategoryId { get; set; }
    }
}
