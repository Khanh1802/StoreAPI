using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly StoreContext _storeContext;

        public BasketController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket()
        {
            var basket = RetrieveBasket();

            if (basket == null)
            {
                return NotFound();
            }
            return basket;
        }

        [HttpPost]
        public async Task<ActionResult> PostItemToBasket(Guid productId, int quantity)
        {
            //Get basket
            var basket = RetrieveBasket();
            //Get product || if not basket Create basket
            var product = await _storeContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            if (basket == null)
            {
                basket = await CreateBasketAsync();
            }
            //Add item
            basket.AddItem(product, quantity);
            //Save change 
            var result = await _storeContext.SaveChangesAsync() > 0;
            if (result)
            {
                return StatusCode(201);
            }
            return BadRequest(new ProblemDetails()
            {
                Title = "Problem saving item to basket"
            });
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteBasketItem(Guid productId, int quantity)
        {
            //Get basket
            //Remove basket or reduce quantity
            //Save change
            return Ok();
        }

        private Basket RetrieveBasket()
        {
            return _storeContext.Baskets
                .Include(x => x.Items)
                .ThenInclude(k => k.Product)
                .FirstOrDefault(x => x.BuyerId.ToString() == Request.Cookies["buyerId"]);
        }
        private async Task<Basket> CreateBasketAsync()
        {
            //Create buyerId
            var buyerId = Guid.NewGuid();
            //Create Coockie
            var coockieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1),
                IsEssential = true,
            };
            //because we're inside a controller, we have access to the Http response we're going to send back
            Response.Cookies.Append("buyerId", buyerId.ToString());
            var basket = new Basket()
            {
                BuyerId = buyerId
            };
            await _storeContext.Baskets.AddAsync(basket);
            return basket;
        }
    }
}
