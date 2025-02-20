﻿namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession session)
        : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(username, cancellationToken);
            return basket is null ? throw new BasketNotFoundException(username) : basket;
        }
        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            session.Store(basket);
            await session.SaveChangesAsync(cancellationToken);
            return basket;
        }
        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCart>(username);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
