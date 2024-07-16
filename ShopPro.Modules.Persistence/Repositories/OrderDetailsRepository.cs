using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Domain.Interfaces;
using ShopPro.Modules.Persistence.Context;
using ShopPro.Modules.Persistence.Exceptions;
using ShopPro.Modules.Persistence.Extentions;
using System.Linq.Expressions;

namespace ShopPro.Modules.Persistence.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ShopContext _shopContext;

        public OrderDetailsRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public bool Exists(Expression<Func<OrderDetails, bool>> filter)
        {
            return _shopContext.OrderDetails.Any(filter);
        }

        public List<OrderDetails> GetAll()
        {
            return _shopContext.OrderDetails.ToList();
        }

        public OrderDetails GetEntityByID(int Id)
        {
            var orderdetails = _shopContext.ValidateOrderDetailsExists(Id);
            if (orderdetails == null)
            {
                throw new OrderDetailsRepositoryException($"ID no encontrado, {Id}");
            }

            return orderdetails;
        }

        public List<OrderDetails> GetOrderDetailsById(int orderid)
        {
            var orderdetails = _shopContext.ValidateOrderDetailsExists(orderid);

            if (orderdetails is null)
            {
                throw new OrderDetailsRepositoryException($"No se pudo encontrar el empleado con el id{orderid}");
            }
            var orderdetailsList = new List<OrderDetails> { orderdetails };

            return orderdetailsList;
        }

        public void Remove(OrderDetails entity)
        {
            var existingOrderDetails = _shopContext.ValidateOrderDetailsExists(entity.Id);
            if (existingOrderDetails != null)
            {
                _shopContext.OrderDetails.Remove(existingOrderDetails);
                _shopContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El detalle de la orden no existe.");
            }
        }

        public void Save(OrderDetails entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }

                _shopContext.OrderDetails.Add(entity);
                _shopContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new OrderDetailsRepositoryException("Error al guardar los detalles de la orden.");
            }
        }

        public void Update(OrderDetails entity)
        {
            try
            {
                OrderDetails orderdetailsToUpdate = GetEntityByID(entity.Id);

                if (orderdetailsToUpdate != null)
                {
                    orderdetailsToUpdate.UpdateFromEntity(entity);
                    _shopContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }
            }
            catch (Exception)
            {
                throw new OrderDetailsRepositoryException("Error al actualizar la orden de detalles.");
            }
        }

    }
}