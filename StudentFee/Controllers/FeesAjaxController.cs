using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentFee.Models;

namespace StudentFee.Controllers
{
    public class FeesAjaxController : Controller
    {
        private StudentRecordEntities2 db = new StudentRecordEntities2();

        // GET: FeesAjax
        public async Task<ActionResult> Index()
        {
            var fees = db.Fees.Include(f => f.Subject);
            return View(await fees.ToListAsync());
        }

        // GET: FeesAjax/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee fee = await db.Fees.FindAsync(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return PartialView(fee);
        }
   
        public ActionResult Create()
        {
            ViewBag.Subject_Id = new SelectList(db.Subjects, "Id", "Subject_Name");
            return PartialView();
        }

        // POST: FeesAjax/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,First_Installment,Second_Installment,Total_Payment,Subject_Id")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Fees.Add(fee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Subject_Id = new SelectList(db.Subjects, "Id", "Subject_Name", fee.Subject_Id);
            return PartialView(fee);
        }

        // GET: FeesAjax/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee fee = await db.Fees.FindAsync(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject_Id = new SelectList(db.Subjects, "Id", "Subject_Name", fee.Subject_Id);
            return PartialView(fee);
        }

        // POST: FeesAjax/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,First_Installment,Second_Installment,Total_Payment,Subject_Id")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Subject_Id = new SelectList(db.Subjects, "Id", "Subject_Name", fee.Subject_Id);
            return PartialView(fee);
        }

        // GET: FeesAjax/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee fee = await db.Fees.FindAsync(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return PartialView(fee);
        }

        // POST: FeesAjax/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fee fee = await db.Fees.FindAsync(id);
            db.Fees.Remove(fee);
            await db.SaveChangesAsync();
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
