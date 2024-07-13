using ShopPro.Modules.Application.Dtos.Employees;
using ShopPro.Modules.Domain.Entities;

namespace ShopPro.Modules.Application.Extension
{
    public static class EmployeesExtensions
    {
        public static Employees ToEntity(this EmployeesRemoveDto dto)
        {
            return new Employees
            {
                Id = dto.empid,
                lastname = dto.lastname,
                firstname = dto.firstname,
                title = dto.title,
                titleofcourtesy = dto.titleofcourtesy,
                birthdate = dto.birthdate,
                hiredate = dto.hiredate,
                address = dto.address,
                city = dto.city,
                region = dto.region,
                postalcode = dto.postalcode,
                country = dto.country,
                phone = dto.phone,
                mgrid = dto.mgrid
            };
        }

        public static Employees ToEntity(this EmployeesSaveDto dto)
        {
            return new Employees
            {
                lastname = dto.lastname,
                firstname = dto.firstname,
                title = dto.title,
                titleofcourtesy = dto.titleofcourtesy,
                birthdate = dto.birthdate,
                hiredate = dto.hiredate,
                address = dto.address,
                city = dto.city,
                region = dto.region,
                postalcode = dto.postalcode,
                country = dto.country,
                phone = dto.phone
            };
        }

        public static void UpdateFromDto(this Employees employees, EmployeesUpdateDto dto)
        {
            employees.lastname = dto.lastname;
            employees.firstname = dto.firstname;
            employees.title = dto.title;
            employees.titleofcourtesy = dto.titleofcourtesy;
            employees.birthdate = dto.birthdate;
            employees.hiredate = dto.hiredate;
            employees.address = dto.address;
            employees.city = dto.city;
            employees.region = dto.region;
            employees.postalcode = dto.postalcode;
            employees.country = dto.country;
            employees.phone = dto.phone;
        }

    }
}
