using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ///Get records of interviews from database, convert to view model and render view
            var model = new Applicants();
            var appicantslist = new List<Applicant>();
            using (var ctx = new TestTaskDBEntities())
            {
                var interview = ctx.INTERVIEW.ToList();
                foreach (var rec in interview)
                {
                    var item = new Applicant()
                    {
                        Id = rec.Id,
                        Name = rec.FIO,
                        PhoneNumber = rec.PHONE_NUMBER,
                        Position = ctx.POSITIONS.Where(x => x.Id == rec.POSITION).ToList().FirstOrDefault()?.POSITION,
                        Employee = ctx.EMPLOYEES.Where(x => x.Id == rec.EMPLOYEE).ToList().FirstOrDefault()?.FIO,
                        EmployeePosition = ctx.POSITIONS.Where(x => x.Id == rec.EMPLOYEE_POSITION).ToList().FirstOrDefault()?.POSITION,
                        InterviewDate = rec.DATE.Value == null ? new DateTime() : rec.DATE.Value,
                        TestTaskEndDate = rec.TEST_TASK_END_DATE.Value == null ? new DateTime() : rec.TEST_TASK_END_DATE.Value,
                    };
                    appicantslist.Add(item);
                }
            }
            model.ApplicantsList = appicantslist;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            ///Get positions and employees from database for dropdowns
            ///if id == -1 - then new record and view rendered with default view model
            ///else get record from database by id and pass it to the view
            using (var ctx = new TestTaskDBEntities())
            {
                ViewBag.Employees = new SelectList(ctx.EMPLOYEES.ToList(), "Id", "FIO");
                ViewBag.Positions = new SelectList(ctx.POSITIONS.ToList(), "Id", "POSITION");
                if (id == -1) return View("Edit", new Applicant());
                {
                    var rec = ctx.INTERVIEW.Where(x => x.Id == id).FirstOrDefault();
                    if (rec == null) return View("Error", new ErrorModel() { ErrorMessage = "Some error occured. Please retry" });
                    {
                        return View("Edit", new Applicant()
                        {
                            Id = rec.Id,
                            Name = rec.FIO,
                            PhoneNumber = rec.PHONE_NUMBER,
                            Position = ctx.POSITIONS.Where(x => x.Id == rec.POSITION).ToList().FirstOrDefault()?.POSITION,
                            Employee = ctx.EMPLOYEES.Where(x => x.Id == rec.EMPLOYEE).ToList().FirstOrDefault()?.FIO,
                            EmployeePosition = ctx.POSITIONS.Where(x => x.Id == rec.EMPLOYEE_POSITION).ToList().FirstOrDefault()?.POSITION,
                            InterviewDate = rec.DATE.Value == null ? new DateTime() : rec.DATE.Value,
                            TestTaskEndDate = rec.TEST_TASK_END_DATE.Value == null ? new DateTime() : rec.TEST_TASK_END_DATE.Value,
                        });
                    }
                }
            }
        }

        
        [HttpPost]
        public ActionResult SaveRecord(Applicant model)
        {
            ///save edited record
            ///if new record - add new object to table entities
            ///else find object in table entity by id and edit in
            ///save changes after
            using (var ctx = new TestTaskDBEntities())
            {
                var interview = new INTERVIEW();
                if (model.Id == -1) 
                {
                    interview.FIO = model.Name;
                    interview.PHONE_NUMBER = model.PhoneNumber;
                    interview.POSITION = int.Parse(model.Position);
                    interview.EMPLOYEE = int.Parse(model.Employee);
                    interview.EMPLOYEE_POSITION = int.Parse(model.EmployeePosition);
                    interview.DATE = model.InterviewDate;
                    interview.TEST_TASK_END_DATE = model.TestTaskEndDate;

                    ctx.INTERVIEW.Add(interview);
                } else
                {
                    interview = ctx.INTERVIEW.Where(x => x.Id == model.Id).SingleOrDefault();
                    interview.FIO = model.Name;
                    interview.PHONE_NUMBER = model.PhoneNumber;
                    interview.POSITION = int.Parse(model.Position);
                    interview.EMPLOYEE = int.Parse(model.Employee);
                    interview.EMPLOYEE_POSITION = int.Parse(model.EmployeePosition);
                    interview.DATE = model.InterviewDate;
                    interview.TEST_TASK_END_DATE = model.TestTaskEndDate;
                }
                ctx.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}