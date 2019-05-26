using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capgemini.Models;
using Capgemini.ViewModel;

namespace Capgemini.Controllers
{
    public class TasksController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            return View(db.tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,taskName")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,taskName")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.tasks.Find(id);
            db.tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

  
        public ActionResult Manage()
        {
            var tasks = db.tasks.Where(t => t.user == null).ToList();
            var users = db.users.ToList();
            var userTasks = new List<Task>();
            var viewModel = new TasksUsersViewModel
            {
                tasks = tasks,
                users = users
                

            };
            return View(viewModel);
        }
    
        public ActionResult Assign(int? idTask,int? idUser)
        {
            if (idTask == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (idUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.tasks.Find(idTask);
            if (task == null)
            {
                return HttpNotFound();
            }
            User user = db.users.Find(idUser);
            if (task == null)
            {
                return HttpNotFound();
            }
            task.user = user;
            db.SaveChanges();

            var tasks = db.tasks.Where(t => t.user == null).ToList();
            var users = db.users.ToList();
            var userTasks = new List<Task>();
            var viewModel = new TasksUsersViewModel
            {
                tasks = tasks,
                users = users
                
               
            };
            

            return View("Manage", viewModel);
        }
    }
}
