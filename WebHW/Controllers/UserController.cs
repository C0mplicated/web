using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using WebHW.Models;
using BLL_Layer;
using DAL_Layer;
using System.Data;


namespace WebHW.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            //ViewBag.userName = user.userName;
            //ViewBag.email = user.email;
            //ViewBag.password = user.password;
            //ViewBag.confirm = user.confirmPass;

            if (ModelState.IsValid)
            {
                //if(user.file != null)
                //{
                //    string path = Path.Combine(Server.MapPath("~/imgFile"), Path.GetFileName(user.file.FileName));
                //    user.file.SaveAs(path);
                //    ViewBag.imageURL = path;
                //}
                List<Employee> employees = new List<Employee>();
                BLL_LayerClass bll = new BLL_LayerClass();
                DataSet ds = bll.GetEmployee_BLL();

                DataTable dt = ds.Tables[0];
                var query = from p in dt.AsEnumerable()
                            select new
                            {
                                ID = p.Field<int>("EmpID"),
                                Name = p.Field<string>("Name"),
                                Job = p.Field<string>("JOB"),
                                Salary = p.Field<decimal>("Salary")
                            };
                foreach(var item in query)
                {
                    var emp = new Employee
                    {
                        EmpId = item.ID,
                        Name = item.Name,
                        Job = item.Job,
                        Salary = item.Salary,
                    };
                    employees.Add(emp);
                }
                return View(employees);
            }

            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                DAL_Layer.Models.Employee e = new DAL_Layer.Models.Employee();
                e.Job = employee.Job;
                e.Name = employee.Name;
                e.Salary = employee.Salary;
                var result = new DAL_LayerClass().AddEmployee(e);
                return RedirectToAction("Index");
            }
            return View("UserData");
        }
    }
}