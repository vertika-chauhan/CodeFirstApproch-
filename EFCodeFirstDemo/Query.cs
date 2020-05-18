using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    public class Query
    {
        private DatabaseContext _context;

        Query()
        {
            _context = new DatabaseContext();
        }




        //To get List of employee with 3 table join 
        //Sql query :  select es.Name,ds.DepartmentName,ls.LevelName from [Employees] as es ,Departments as ds ,LevelAsPerDepartments as ls
        //where es.DepartmentId=ds.DepartmentId and es.LevelAsPerDepartmentId= ls.LevelAsPerDepartmentId
        //and ds.DepartmentId= ls.LevelAsPerDepartmentId
        public void getAllEmployee()
        {
            //without groubBy  Inner Join
             var query =
                    from es in _context.Employees
                    from ls in _context.LevelAsPerDepartments
                    where
                      es.LevelAsPerDepartmentId == ls.LevelAsPerDepartmentId &&
                      es.Department.DepartmentId == ls.LevelAsPerDepartmentId
                    select new
                    {
                        es.Name,
                        es.Department.DepartmentName,
                        ls.LevelName
                    };




            //with group by 

            var query1 = from es in _context.Employees
                         from ls in _context.LevelAsPerDepartments
                         where
                           es.LevelAsPerDepartmentId == ls.LevelAsPerDepartmentId &&
                           es.Department.DepartmentId == ls.LevelAsPerDepartmentId
                         group new { es, es.Department, ls } by new
                         {
                             es.Name,
                             es.Department.DepartmentName,
                             ls.LevelName
                         } into g
                         select new
                         {
                             g.Key.Name,
                             g.Key.DepartmentName,
                             g.Key.LevelName
                         };




            //Where clause 

            var query2 = from es in _context.Employees
                         from ls in _context.LevelAsPerDepartments
                         where
                           es.LevelAsPerDepartmentId == ls.LevelAsPerDepartmentId &&
                           es.Department.DepartmentId == ls.LevelAsPerDepartmentId &&
                           es.Department.DepartmentId == 2
                         select new
                         {
                             es.Name,
                             es.Department.DepartmentName,
                             ls.LevelName
                         };
        }


        //Sql Left Join 
//        select es.Name, ds.DepartmentName, ls.LevelName from [Employees] as es left  join LevelAsPerDepartments
//  as ls on ls.LevelAsPerDepartmentId= es.LevelAsPerDepartmentId left join Departments as ds on es.DepartmentId= ds.DepartmentId

//and ls.LevelAsPerDepartmentId= ds.DepartmentId

        public void getAllEmployee1()
        {
            var query1 = from es in _context.Employees
                         join ls in _context.LevelAsPerDepartments on es.LevelAsPerDepartmentId equals ls.LevelAsPerDepartmentId into ls_join
                         from ls in ls_join.DefaultIfEmpty()
                         join ds in _context.Departments
                               on new { es.DepartmentId, ls.LevelAsPerDepartmentId }
                           equals new { ds.DepartmentId, LevelAsPerDepartmentId = ds.DepartmentId } into ds_join
                         from ds in ds_join.DefaultIfEmpty()
                         select new
                         {
                             es.Name,
                             DepartmentName = ds.DepartmentName,
                             LevelName = ls.LevelName
                         };
        }

        //Max department value from employee table and next record enter with one increment



        public void tofindMaxDepartment()
        {
            int Id = 2;
            int MaxdeparmentIdforlevel = _context.LevelAsPerDepartments.Where(c => c.DepartmentId == Id).Max(x => (int?)x.DepartmentId) ?? 0;

        }
















    }
}
