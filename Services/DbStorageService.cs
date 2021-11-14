using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pizzas.Data;
using Pizzas.Entities;
using Pizzas.Mapper;
using Pizzas.Models;

namespace Pizzas.Services
{
    public class DbStoreService : IStoreService
    {
        private readonly ILogger<DbStoreService> _logger;
        private readonly PizzaDbContext _context;

        public DbStoreService(ILogger<DbStoreService> logger, PizzaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<(bool IsSuccess, Exception exception, List<PizzaWithoutAnything> pizza)> GetPizzaAsync()
        {
            try
            {
                var pizzas = await _context.Pizzas.Select(p => new PizzaWithoutAnything()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ShortName = p.ShortName,
                    Status = (Models.EPizzaStockStatus)p.Status,
                    Ingridients = p.Ingridients,
                    Price = p.Price
                }).ToListAsync();

                _logger.LogInformation("Pizzas get from DB");
                return (true, null, pizzas);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Getting pizzas from DB failed: {e.Message}", e);
                return (false, null, null);
            }
        }

        public async Task<(bool IsSuccess, Exception exception, Pizza pizzaResult)> GetPizzaAsync(Guid Id)
        {
            try
            {
                var pizzaResult = await _context.Pizzas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Id);

                if (pizzaResult is default(Pizza))
                {
                    return (false, null, null);
                }

                _logger.LogInformation($"Pizza get from DB: {Id}");
                return (true, null, pizzaResult);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Getting pizza from DB: {Id} failed");
                return (false, e, null);
            }
        }

        public async Task<(bool IsSuccess, Exception exception)> InsertPizzaAsync(Pizza pizza)
        {
            try
            {
                if (!await _context.Pizzas.AnyAsync(p => p.Id == pizza.Id))
                {
                    
                    await _context.Pizzas.AddAsync(pizza);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Pizza ordered in DB: {pizza.Id}");
                    return (true, null);
                }
                else
                {
                    return (false, new Exception());
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Ordering pizza in DB: {pizza.Id} failed");
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception exception, UpdatedPizza updatedPizza)> UpdatePizzaAsync(Guid id, UpdatedPizza updatedpizza)
        {

            try
            {
                if (await _context.Pizzas.AnyAsync(p => p.Id == id))
                {
                    _context.Pizzas.Update(updatedpizza.ToPizzaEntities());
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Pizza updated in DB: {id}");

                    return (true, null, updatedpizza);
                }
                else
                {
                    return (false, new Exception(), updatedpizza);
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Updating pizza in DB: {id} not found");
                return (false, e, null);
            }
        }
    }
}