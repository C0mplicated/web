using DAL_Layer;
using DAL_Layer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Layer
{
    public class BLL_LayerClass
    {
        public List<Employee> GetEmployee_BLL()
        {
            //return new DAL_LayerClass().GetEmployees();
            ProductDBEntities productDBEntities = new ProductDBEntities();
            var emp = productDBEntities.Employees.ToList();
            return emp;
        }

        public int AddEmployee_BLL(string name, string job, Nullable<decimal> salary)
        {
            ProductDBEntities productDBEntities = new ProductDBEntities();
            var res = productDBEntities.addEmployee(name, job, salary);
            return res;
        }

    }
}
