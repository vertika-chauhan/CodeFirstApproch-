using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int Id = 2;

            var context = new DatabaseContext();
            int MaxdeparmentIdforlevel = context.LevelAsPerDepartments.Where(c => c.DepartmentId == Id).Max(x => (int?)x.DepartmentId) ?? 0;

            context.LevelAsPerDepartments.Add(new LevelAsPerDepartment()
            {
                LevelAsPerDepartmentId = MaxdeparmentIdforlevel + 1,
                DepartmentId = Id,
                LevelName = "Associate"

            });

            context.SaveChanges();


            int maxNumber = context.Employees.Where(c => c.DepartmentId == Id).Max(x => (int?)x.DepartmentId) ?? 0;


            context.Employees.Add(new Employee()
            {


                EmployeesId = maxNumber + 1,
                Name = "Ram",
                DepartmentId = Id,
                LevelAsPerDepartmentId = 2
            });


            context.SaveChanges();



        }
                  
    }
}
