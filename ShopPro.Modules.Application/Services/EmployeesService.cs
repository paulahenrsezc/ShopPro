using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Modules.Application.Core;
using ShopPro.Modules.Application.Dtos.Employees;
using ShopPro.Modules.Application.Extension;
using ShopPro.Modules.Application.Interfaces;
using ShopPro.Modules.Domain.Interfaces;
using static ShopPro.Modules.Application.Extension.Entity;

namespace ShopPro.Modules.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository employeesrepository;
        private readonly ILoggerService<EmployeesService> _logger;

        public EmployeesService(IEmployeesRepository employeesrepository, ILoggerService<EmployeesService> logger)
        {
            this.employeesrepository = employeesrepository;
            _logger = logger;

        }
        public ServiceResult GetEmployees()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = employeesrepository.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los empleados";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetEmployees(int id)
        {
            var result = new ServiceResult();

            try
            {
                result.Data = employeesrepository.GetEntityByID(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los empleados";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveEmployees(EmployeesRemoveDto employeesRemove)
        {
            var result = new ServiceResult();
            try
            {
                if (employeesRemove == null)
                {
                    result.Success = false;
                    result.Message = "Este campo es requerido. ";
                    return result;
                }

                var employees = employeesRemove.ToEntity();

                this.employeesrepository.Remove(employees);
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

        public ServiceResult SaveEmployees(EmployeesSaveDto employeesSave)
        {
            var result = new ServiceResult();

            try
            {
                result = EntityValidator<EmployeesSaveDto>.Validate(employeesSave);
                if (!result.Success)
                {
                    return result;
                }

                var employees = employeesSave.ToEntity();
                employeesrepository.Save(employees);
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

        public ServiceResult UpdateEmployees(EmployeesUpdateDto employeesUpdate)
        {
            var result = EntityValidator<EmployeesUpdateDto>.Validate(employeesUpdate);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                Domain.Entities.Employees employees = employeesrepository.GetEntityByID(employeesUpdate.empid);

                if (employees == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el empleado especificado.";
                    return result;
                }

                employees.UpdateFromDto(employeesUpdate);

                employeesrepository.Update(employees);
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
