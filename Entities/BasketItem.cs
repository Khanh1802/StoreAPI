using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("BasketItems")]
    public class BasketItem
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        //navigation properties.
        public Product Product { get; set; }
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public Basket Basket { get; set; }
        [ForeignKey("BasketId")]
        public Guid BasketId { get; set; }
    }
}