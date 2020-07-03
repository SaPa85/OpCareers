using OpCareers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpCareers.Controllers
{
    public class HomeController : Controller
    {
        private OptionisCareersEntities _db = new OptionisCareersEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                using (OptionisCareersEntities db = new OptionisCareersEntities())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", obj);
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Index(User objUser)
        {
            List<HomePage> _iHomePage = new List<HomePage>();
            HomePage _homePage = new HomePage();
            _homePage.jobs = _db.Jobs.ToList();
            _homePage.activeUser = objUser;

            _iHomePage.Add(_homePage);

            return View(_iHomePage);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Job jobToCreate)
        {
            if (!ModelState.IsValid)

                return View();

            _db.Jobs.Add(jobToCreate);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var jobToEdit = (from m in _db.Jobs

                               where m.JobID == id

                               select m).First();

            return View(jobToEdit);
        }

        

        

        [HttpPost]
        public ActionResult Edit(Job jobToEdit)
        {
            var originalJob = (from m in _db.Jobs

                               where m.JobID == jobToEdit.JobID

                                 select m).First();

            if (!ModelState.IsValid)
            { return View(originalJob); }

            _db.Jobs.Remove(originalJob);
            _db.Jobs.Add(jobToEdit);            

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            { return View(); }

            var _job = _db.Jobs.Where(e => e.JobID == id).First();

            _db.Jobs.Remove(_job);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}