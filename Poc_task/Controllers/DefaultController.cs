using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poc_task.Models;

namespace Poc_task.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee emp)
        { 
        //{  if(ModelState.IsValid)
        //    {
                
        //        return Content(emp.FirstName);
        //    }
        //    return View("Index");
            try
            {
                if (ModelState.IsValid)
                {
                   EmployeeDBContext EmpRepo = new EmployeeDBContext();

                    if (EmpRepo.AddEmployee(emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Bootstrap()
        {
            return View();
        }
        public ActionResult ViewRecords()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> obj = db.GetEmployees();

            return View(obj);

        }
        public ActionResult CreateRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRecord(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeDBContext EmpRepo = new EmployeeDBContext();

                    if (EmpRepo.AddEmployee(emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult DeleteRecord(string empcode)
        {
          //  EmployeeDBContext EmpRepo = new EmployeeDBContext();
           // var row = EmpRepo.GetEmployees().Find(model => model.EmpCode == empcode);
           return RedirectToAction("");
            
        }
        [HttpPost]
        public ActionResult DeleteRecord(String empcode,Employee emp)
        {
            EmployeeDBContext EmpRepo = new EmployeeDBContext();
            bool check = EmpRepo.DeleteEmployee(empcode);
            if(check==true)
            {
                TempData["DeleteMessage"] = "Data Has Been Deleted Successfully";
                ModelState.Clear();
                return RedirectToAction("CreateRecord");

            }
            return View();



        }
        public ActionResult Delete()
        {
            return View();
        }

    }
}