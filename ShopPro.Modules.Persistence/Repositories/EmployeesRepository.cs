using ShopPro.Modules.Application.Dtos.Employees;
using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Domain.Interfaces;
using ShopPro.Modules.Persistence.Context;
using ShopPro.Modules.Persistence.Exceptions;
using ShopPro.Modules.Persistence.Extentions;
using System.Linq.Expressions;

namespace ShopPro.Modules.Persistence.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ShopContext _shopContext;

        public EmployeesRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public bool Exists(Expression<Func<Employees, bool>> filter)
        {
            return _shopContext.Employees.Any(filter);
        }

        public List<Employees> GetAll()
        {
            return _shopContext.Employees.ToList();
        }

        public List<Employees> GetEmployeesById(int empid)
        {
            var employees = _shopContext.Employees.Find(empid);

            if (employees is null)
            {
                throw new EmployeesRepositoryException($"No se pudo encontrar el empleado con el id{empid}");
            }
            var employeesList = new List<Employees> { employees };

            return employeesList;
        }

        public Employees GetEntityByID(int Id)
        {
            var employees = _shopContext.Employees.Find(Id);
            if (employees == null)
            {
                throw new EmployeesRepositoryException($"ID no encontrado, {Id}");
            }

            return employees;
        }

        public void Remove(Employees entity)
        {
            var existingEmployees = _shopContext.Employees.Find(entity.Id);
            if (existingEmployees != null)
            {
                _shopContext.Employees.Remove(existingEmployees);
                _shopContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El empleado no existe.");
            }
        }

        public void Save(Employees entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }

                _shopContext.Employees.Add(entity);
                _shopContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new EmployeesRepositoryException("Error al guardar el empleado.");
            }
        }

        public void Update(Employees entity)
        {
            try
            {
                Employees employeesToUpdate = GetEntityByID(entity.Id);

                if (employeesToUpdate != null)
                {
                    UpdateEmployeesFields(employeesToUpdate,
                                     entity.lastname,
                                     entity.firstname,
                                     entity.title,
                                     entity.titleofcourtesy,
                                     entity.birthdate,
                                     entity.hiredate,
                                     entity.address,
                                     entity.city,
                                     entity.region,
                                     entity.postalcode,
                                     entity.country,
                                     entity.phone);

                    _shopContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }
            }
            catch (Exception)
            {
                throw new EmployeesRepositoryException("Error al actualizar el empleado.");
            }
        }
        private void UpdateEmployeesFields(Employees employeesToUpdate, string lastname, string firstname, string title, string titleofcourtesy, DateTime birthdate, DateTime hiredate, string address, string city, string? region, string? postalcode, string country, string phone)
        {
            employeesToUpdate.lastname = lastname;
            employeesToUpdate.firstname = firstname;
            employeesToUpdate.title = title;
            employeesToUpdate.titleofcourtesy = titleofcourtesy;
            employeesToUpdate.birthdate = birthdate;
            employeesToUpdate.hiredate = hiredate;
            employeesToUpdate.address = address;
            employeesToUpdate.city = city;
            employeesToUpdate.region = region;
            employeesToUpdate.postalcode = postalcode;
            employeesToUpdate.country = country;
            employeesToUpdate.phone = phone;
        }

        private Employees ValidateEmployeesExists(int empid)
        {
            var employees = _shopContext.Employees.Find(empid);
            return employees;
        }

    }
}
