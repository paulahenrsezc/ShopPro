using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Modules.Application.Core;
using ShopPro.Modules.Application.Dtos.OrderDetails;
using ShopPro.Modules.Application.Extension;
using ShopPro.Modules.Application.Interfaces;
using ShopPro.Modules.Domain.Interfaces;
using static ShopPro.Modules.Application.Extension.Entity;

namespace ShopPro.Modules.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository orderdetailsrepository;
        private readonly ILoggerService<OrderDetailsService> _logger;

        public OrderDetailsService(IOrderDetailsRepository orderdetailsrepository, ILoggerService<OrderDetailsService> logger)
        {
            this.orderdetailsrepository = orderdetailsrepository;
            _logger = logger;

        }
        public ServiceResult GetOrderDetails()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = orderdetailsrepository.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los detalles de las ordenes";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetOrderDetails(int id)
        {
            var result = new ServiceResult();

            try
            {
                result.Data = orderdetailsrepository.GetEntityByID(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los detalles de las ordenes";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveOrderDetails(OrderDetailsRemoveDto orderDetailsRemove)
        {
            var result = new ServiceResult();
            try
            {
                if (orderDetailsRemove == null)
                {
                    result.Success = false;
                    result.Message = "Este campo es requerido. ";
                    return result;
                }

                var orderdetails = orderDetailsRemove.ToEntity();

                this.orderdetailsrepository.Remove(orderdetails);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveOrderDetails(OrderDetailsSaveDto orderDetailsSave)
        {
            var result = new ServiceResult();

            try
            {
                result = EntityValidator<OrderDetailsSaveDto>.Validate(orderDetailsSave);
                if (!result.Success)
                {
                    return result;
                }

                var orderDetails = orderDetailsSave.ToEntity();

                orderdetailsrepository.Save(orderDetails);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos";
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult UpdateOrderDetails(OrderDetailsUpdateDto orderDetailsUpdate)
        {
            var result = EntityValidator<OrderDetailsUpdateDto>.Validate(orderDetailsUpdate);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                Domain.Entities.OrderDetails orderdetails = orderdetailsrepository.GetEntityByID(orderDetailsUpdate.orderid);

                if (orderdetails == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró la orden de detalles especificada.";
                    return result;
                }

                orderdetails.UpdateFromDto(orderDetailsUpdate);

                orderdetailsrepository.Update(orderdetails);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando los datos.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
