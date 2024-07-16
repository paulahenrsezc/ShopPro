using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Persistence.Context;

namespace ShopPro.Modules.Persistence.Extentions
{
    public static class EmployeesExtentions
    {
        public static void UpdateFromEntity(this Employees employeesToUpdate, Employees entity)
        {
            employeesToUpdate.lastname = entity.lastname;
            employeesToUpdate.firstname = entity.firstname;
            employeesToUpdate.title = entity.title;
            employeesToUpdate.titleofcourtesy = entity.titleofcourtesy;
            employeesToUpdate.birthdate = entity.birthdate;
            employeesToUpdate.hiredate = entity.hiredate;
            employeesToUpdate.address = entity.address;
            employeesToUpdate.city = entity.city;
            employeesToUpdate.region = entity.region;
            employeesToUpdate.postalcode = entity.postalcode;
            employeesToUpdate.country = entity.country;
            employeesToUpdate.phone = entity.phone;
        }

        public static Employees ValidateEmployeesExists(this ShopContext context, int empid)
        {
            var employees = context.Employees.Find(empid);
            return employees;
        }

    }
}