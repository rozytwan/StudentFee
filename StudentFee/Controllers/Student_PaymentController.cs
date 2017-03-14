using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentFee.Models;

namespace StudentFee.Controllers
{
    public class Student_PaymentController : Controller
    {
        private StudentRecordEntities2 db = new StudentRecordEntities2();

        // GET: Student_Payment
        public ActionResult Index()
        {
            return View(db.Student_Payment.ToList());
        }

        // GET: Student_Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Payment student_Payment = db.Student_Payment.Find(id);
            if (student_Payment == null)
            {
                return HttpNotFound();
            }
            return View(student_Payment);
        }

        // GET: Student_Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student_Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Student_Id,Subject_Id,First_Installment,Second_Installment,Status")] Student_Payment student_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Student_Payment.Add(student_Payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_Payment);
        }

        // GET: Student_Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Payment student_Payment = db.Student_Payment.Find(id);
            if (student_Payment == null)
            {
                return HttpNotFound();
            }
            return View(student_Payment);
        }

        // POST: Student_Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Student_Id,Subject_Id,First_Installment,Second_Installment,Status")] Student_Payment student_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_Payment);
        }

        // GET: Student_Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Payment student_Payment = db.Student_Payment.Find(id);
            if (student_Payment == null)
            {
                return HttpNotFound();
            }
            return View(student_Payment);
        }

        // POST: Student_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Payment student_Payment = db.Student_Payment.Find(id);
            db.Student_Payment.Remove(student_Payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
