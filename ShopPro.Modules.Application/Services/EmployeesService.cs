using Microsoft.Extensions.Logging;
using ShopPro.Infraestructure.Logger.Interfaces;
using ShopPro.Modules.Application.Core;
using ShopPro.Modules.Application.Dtos.Employees;
using ShopPro.Modules.Application.Dtos.OrderDetails;
using ShopPro.Modules.Application.Interfaces;
using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Domain.Interfaces;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
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

                var employees = new Employees
                {
                    Id = employeesRemove.empid,
                    lastname = employeesRemove.lastname,
                    firstname = employeesRemove.firstname,
                    title = employeesRemove.title,
                    titleofcourtesy = employeesRemove.titleofcourtesy,
                    birthdate = employeesRemove.birthdate,
                    hiredate = employeesRemove.hiredate,
                    address = employeesRemove.address,
                    city = employeesRemove.city,
                    region = employeesRemove.region,
                    postalcode = employeesRemove.postalcode,
                    country = employeesRemove.country,
                    phone = employeesRemove.phone,
                    mgrid = employeesRemove.mgrid
                };

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

                var employees = new Employees
                {
                    lastname = employeesSave.lastname,
                    firstname = employeesSave.firstname,
                    title = employeesSave.title,
                    titleofcourtesy = employeesSave.titleofcourtesy,
                    birthdate = employeesSave.birthdate,
                    hiredate = employeesSave.hiredate,
                    address = employeesSave.address,
                    city = employeesSave.city,
                    region = employeesSave.region,
                    postalcode = employeesSave.postalcode,
                    country = employeesSave.country,
                    phone = employeesSave.phone
                };

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

                employees.lastname = employeesUpdate.lastname;
                employees.firstname = employeesUpdate.firstname;
                employees.title = employeesUpdate.title;
                employees.titleofcourtesy = employeesUpdate.titleofcourtesy;
                employees.birthdate = employeesUpdate.birthdate;
                employees.hiredate = employeesUpdate.hiredate;
                employees.address = employeesUpdate.address;
                employees.city = employeesUpdate.city;
                employees.region = employeesUpdate.region;
                employees.postalcode = employeesUpdate.postalcode;
                employees.country = employeesUpdate.country;
                employees.phone = employeesUpdate.phone;

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
