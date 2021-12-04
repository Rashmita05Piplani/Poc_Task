﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Poc_task.Models;
using System.IO;

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
        public ActionResult CreateRecord(Employee emp,HttpPostedFileBase UploadFile)
        {
            try
            {   if ( UploadFile.ContentLength>0)
                {
                    string FileName = Path.GetFileName(UploadFile.FileName);

                    string path = Server.MapPath("~/App_Start/File Uploads");
                    
                    string fullPath = Path.Combine(path, FileName);
                    UploadFile.SaveAs(fullPath);
                }
            }
            catch
            {
                ViewBag.Message = "File upload failed";
                return View();
            }

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

                return View(ViewBag.Message);
            }
            catch
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult DeleteRecord(string empcode)
        {
              //EmployeeDBContext EmpRepo = new EmployeeDBContext();
            // var row = EmpRepo.GetEmployees().Find(model => model.EmpCode == empcode);
            try
            {
                EmployeeDBContext EmpRepo = new EmployeeDBContext();
                if(EmpRepo.DeleteEmployee(empcode))
                {
                    ViewBag.AlertMsg = "Employees Details Deleted Successfully";
                }
                return RedirectToAction("ViewRecords");
            }
            catch
            {
                return View();
            }
           return RedirectToAction("");
            
        }
        [HttpPost]
        //public ActionResult DeleteRecord(String empcode,Employee emp)
        //{
        //    EmployeeDBContext EmpRepo = new EmployeeDBContext();
        //    bool check = EmpRepo.DeleteEmployee(empcode);
        //    if(check==true)
        //    {
        //        TempData["DeleteMessage"] = "Data Has Been Deleted Successfully";
        //        ModelState.Clear();
        //        return RedirectToAction("CreateRecord");

        //    }
        //    return View();



        //}
        public ActionResult Delete()
        {
            return View();
        }
        // from start
        public ActionResult InsertRecord()
        {
            return View();
        }
        //public ActionResult FileUpload()
        //{
        //    ret
        //}

    }
}