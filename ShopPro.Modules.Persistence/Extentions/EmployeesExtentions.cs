using ShopPro.Modules.Application.Dtos.Employees;
using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Persistence.Context;
using ShopPro.Modules.Persistence.Exceptions;

namespace ShopPro.Modules.Persistence.Extentions
{
    public static class EmployeesExtentions
    {
        public static EmployeesBaseDto ConvertEmpEntityEmployeesDto(this Employees employees)
        {
            EmployeesBaseDto employeesDto = new EmployeesBaseDto()
            {
                lastname = employees.lastname,
                firstname = employees.firstname,
                title = employees.title,
                titleofcourtesy = employees.titleofcourtesy,
                birthdate = employees.birthdate,
                hiredate = employees.hiredate,
                address = employees.address,
                city = employees.city,
                region = employees.region,
                postalcode = employees.postalcode,
                country = employees.country,
                phone = employees.phone,
                mgrid = employees.mgrid
            };

            return employeesDto;
        }

        public static Employees ValidateEmployeesExists(this ShopContext context, int empid)
        {
            var employees = context.Employees.Find(empid);
            if (employees == null)
            {
                throw new EmployeesRepositoryException("El empleado fue encontrado");
            }
            return employees;
        }

        public static void UpdateFromDtos(this Employees employees, EmployeesUpdateDto employeesUpdate)
        {
            employeesUpdate.empid = employeesUpdate.empid;
            employeesUpdate.lastname = employeesUpdate.lastname;
            employeesUpdate.firstname = employeesUpdate.firstname;
            employeesUpdate.title = employeesUpdate.title;
            employeesUpdate.titleofcourtesy = employeesUpdate.titleofcourtesy;
            employeesUpdate.birthdate = employeesUpdate.birthdate;
            employeesUpdate.hiredate = employeesUpdate.hiredate;
            employeesUpdate.address = employeesUpdate.address;
            employeesUpdate.city = employeesUpdate.city;
            employeesUpdate.region = employeesUpdate.region;
            employeesUpdate.postalcode = employeesUpdate.postalcode;
            employeesUpdate.country = employeesUpdate.country;
            employeesUpdate.phone = employeesUpdate.phone;
            employeesUpdate.mgrid = employeesUpdate.mgrid;

        }

    }
}
