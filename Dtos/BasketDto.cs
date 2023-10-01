using API.Entities;

namespace API.Dtos
{
    public class BasketDto
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new();
    }
}
