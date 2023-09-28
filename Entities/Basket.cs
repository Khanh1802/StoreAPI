using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Basket")]
    public class Basket
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Product product, int quantity)
        {
            if (Items.All(x => x.ProductId != product.Id))
            {
                Items.Add(new BasketItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            var exist = Items.FirstOrDefault(x => x.ProductId == product.Id);
            if (exist != null)
            {
                exist.Quantity += quantity;
            }
        }
        public void DeleteItem(Guid productId, int quantity)
        {
            var basketItem = Items.FirstOrDefault(x => x.ProductId == productId);
            if (basketItem != null)
            {
                basketItem.Quantity -= quantity;
                if(basketItem.Quantity == 0)
                {
                    Items.Remove(basketItem);
                }
            }
        }
    }
}
