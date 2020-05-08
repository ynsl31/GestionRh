using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolutionE_RH_v1._5.Models;

namespace SolutionE_RH_v1._5.Controllers
{
    public class PRIMEsController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: PRIMEs
        public ActionResult Index()
        {
            var pRIMEs = db.PRIMEs.Include(p => p.EMPLOYEE);
            return View(pRIMEs.ToList());
        }

        // GET: PRIMEs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIME pRIME = db.PRIMEs.Find(id);
            if (pRIME == null)
            {
                return HttpNotFound();
            }
            return View(pRIME);
        }

        // GET: PRIMEs/Create
        public ActionResult Create()
        {
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN");
            return View();
        }

        // POST: PRIMEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRIME,MATRECULE,MOTIF,MONTANT,DATE")] PRIME pRIME)
        {
            if (ModelState.IsValid)
            {
                db.PRIMEs.Add(pRIME);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", pRIME.MATRECULE);
            return View(pRIME);
        }

        // GET: PRIMEs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIME pRIME = db.PRIMEs.Find(id);
            if (pRIME == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", pRIME.MATRECULE);
            return View(pRIME);
        }

        // POST: PRIMEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRIME,MATRECULE,MOTIF,MONTANT,DATE")] PRIME pRIME)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRIME).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", pRIME.MATRECULE);
            return View(pRIME);
        }

        // GET: PRIMEs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIME pRIME = db.PRIMEs.Find(id);
            if (pRIME == null)
            {
                return HttpNotFound();
            }
            return View(pRIME);
        }

        // POST: PRIMEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            PRIME pRIME = db.PRIMEs.Find(id);
            db.PRIMEs.Remove(pRIME);
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
