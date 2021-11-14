using Pizzas.Entities;
using Pizzas.Models;

namespace Pizzas.Mapper
{
    public static class ModelEntityPizzaMapper
    {
        public static Pizza ToPizzaEntities(this NewPizza newPizza)
        {
            return new Pizza(
                title: newPizza.Title,
                shortName: newPizza.ShortName,
                status: newPizza.Status.ToEntitiesStockStatus(),
                ingridients: newPizza.Ingridients,
                price: newPizza.Price
            );
        }
        public static Pizza ToPizzaEntities(this UpdatedPizza updatedPizza)
        {
            return new Pizza(
                title: updatedPizza.Title,
                shortName: updatedPizza.ShortName,
                status: updatedPizza.Status.ToEntitiesStockStatus(),
                ingridients: updatedPizza.Ingridients,
                price: updatedPizza.Price
            );
        }
        public static Entities.EPizzaStockStatus ToEntitiesStockStatus(this Models.EPizzaStockStatus stockStatus)
        {
            return stockStatus switch
            {
                Models.EPizzaStockStatus.In => Entities.EPizzaStockStatus.In,
                _ => Entities.EPizzaStockStatus.Out
            };
        }
    }
}