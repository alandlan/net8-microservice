﻿
namespace Basket.API.Data
{
    public class BasketRepository : IBasketRepository
    {
        public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
