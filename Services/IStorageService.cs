using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pizzas.Entities;
using Pizzas.Models;

namespace Pizzas.Services
{
    public interface IStoreService
    {
        Task<(bool IsSuccess, Exception exception)> InsertPizzaAsync(Pizza pizza);
        Task<(bool IsSuccess, Exception exception, List<Models.PizzaWithoutAnything> pizza)> GetPizzaAsync();
        Task<(bool IsSuccess, Exception exception, Pizza pizzaResult)> GetPizzaAsync(Guid Id);
        Task<(bool IsSuccess, Exception exception, UpdatedPizza updatedPizza)> UpdatePizzaAsync(Guid id, UpdatedPizza pizza);
    }
}