using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FC.Entities;

namespace SIMS.Controllers
{
    public class SIMS_EmployeeController : Controller
    {
        private FcEntities db = new FcEntities();

        // GET: SIMS_Employee
        public async Task<ActionResult> Index()
        {
            var sIMS_Employee = db.SIMS_Employee.Include(s => s.FC_Users_CreatedBy).Include(s => s.FC_Users_UpdatedBy).Include(s => s.SIMS_Department_SIMS_Employee).Include(s => s.SIMS_Designation_SIMS_Employee).Include(s => s.SIMS_EmployeeType_SIMS_Employee);
            return View(await sIMS_Employee.ToListAsync());
        }

        // GET: SIMS_Employee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIMS_Employee sIMS_Employee = await db.SIMS_Employee.FindAsync(id);
            if (sIMS_Employee == null)
            {
                return HttpNotFound();
            }
            return View(sIMS_Employee);
        }

        // GET: SIMS_Employee/Create
        public ActionResult Create()
        {
            //ViewBag.CreatedBy = new SelectList(db.FC_Users, "Id", "Password");
            //ViewBag.UpdatedBy = new SelectList(db.FC_Users, "Id", "Password");
            ViewBag.DepartmentId = new SelectList(db.SIMS_Department, "Id", "Name");
            ViewBag.DesignationId = new SelectList(db.SIMS_Designation, "Id", "Name");
            ViewBag.EmployeeTypeId = new SelectList(db.SIMS_EmployeeType, "Id", "Name");
            return View();
        }

        // POST: SIMS_Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DepartmentId,DesignationId,Experience,Qualification,EmployeeTypeId,ContactNumber,EmailId,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,Name,IsDeleted")] SIMS_Employee sIMS_Employee)
        {
            if (ModelState.IsValid)
            {
                sIMS_Employee.CreatedBy = Session["UserId"] != null ? (int)Session["UserId"] : 1;
               
                sIMS_Employee.CreatedOn = System.DateTime.UtcNow;

                sIMS_Employee.UpdatedBy = Session["UserId"] != null ? (int)Session["UserId"] : 1;
                sIMS_Employee.UpdatedOn = System.DateTime.UtcNow;
                sIMS_Employee.IsDeleted = false;
                db.SIMS_Employee.Add(sIMS_Employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.CreatedBy = new SelectList(db.FC_Users, "Id", "Password", sIMS_Employee.CreatedBy);
            //ViewBag.UpdatedBy = new SelectList(db.FC_Users, "Id", "Password", sIMS_Employee.UpdatedBy);
            ViewBag.DepartmentId = new SelectList(db.SIMS_Department, "Id", "Name", sIMS_Employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.SIMS_Designation, "Id", "Name", sIMS_Employee.DesignationId);
            ViewBag.EmployeeTypeId = new SelectList(db.SIMS_EmployeeType, "Id", "Name", sIMS_Employee.EmployeeTypeId);
            return View(sIMS_Employee);
        }

        // GET: SIMS_Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIMS_Employee sIMS_Employee = await db.SIMS_Employee.FindAsync(id);
            if (sIMS_Employee == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CreatedBy = new SelectList(db.FC_Users, "Id", "Password", sIMS_Employee.CreatedBy);
            //ViewBag.UpdatedBy = new SelectList(db.FC_Users, "Id", "Password", sIMS_Employee.UpdatedBy);
            ViewBag.DepartmentId = new SelectList(db.SIMS_Department, "Id", "Name", sIMS_Employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.SIMS_Designation, "Id", "Name", sIMS_Employee.DesignationId);
            ViewBag.EmployeeTypeId = new SelectList(db.SIMS_EmployeeType, "Id", "Name", sIMS_Employee.EmployeeTypeId);
            return View(sIMS_Employee);
        }

        // POST: SIMS_Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DepartmentId,DesignationId,Experience,Qualification,EmployeeTypeId,ContactNumber,EmailId,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,Name,IsDeleted")] SIMS_Employee sIMS_Employee)
        {
            if (ModelState.IsValid)
            {
                sIMS_Employee.UpdatedBy = Session["UserId"] != null ? (int)Session["UserId"] : 1;
                sIMS_Employee.UpdatedOn = System.DateTime.UtcNow;
                sIMS_Employee.IsDeleted = false;
                db.Entry(sIMS_Employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.CreatedBy = new SelectList(db.FC_Users, "Id", "Password", sIMS_Employee.CreatedBy);
            //ViewBag.UpdatedBy = new SelectList(db.FC_Users, "Id", "Password", sIMS_Employee.UpdatedBy);
            ViewBag.DepartmentId = new SelectList(db.SIMS_Department, "Id", "Name", sIMS_Employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.SIMS_Designation, "Id", "Name", sIMS_Employee.DesignationId);
            ViewBag.EmployeeTypeId = new SelectList(db.SIMS_EmployeeType, "Id", "Name", sIMS_Employee.EmployeeTypeId);
            return View(sIMS_Employee);
        }

        // GET: SIMS_Employee/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIMS_Employee sIMS_Employee = await db.SIMS_Employee.FindAsync(id);
            if (sIMS_Employee == null)
            {
                return HttpNotFound();
            }
            return View(sIMS_Employee);
        }

        // POST: SIMS_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SIMS_Employee sIMS_Employee = await db.SIMS_Employee.FindAsync(id);
            db.SIMS_Employee.Remove(sIMS_Employee);
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
