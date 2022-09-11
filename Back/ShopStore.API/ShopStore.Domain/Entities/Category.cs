using System.ComponentModel.DataAnnotations;

namespace ShopStore.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
