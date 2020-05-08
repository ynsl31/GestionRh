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
    public class BULLETIN_DE_PAIEController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: BULLETIN_DE_PAIE
        public ActionResult Index()
        {
            var bULLETIN_DE_PAIE = db.BULLETIN_DE_PAIE.Include(b => b.EMPLOYEE);
            return View(bULLETIN_DE_PAIE.ToList());
        }

        // GET: BULLETIN_DE_PAIE/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BULLETIN_DE_PAIE bULLETIN_DE_PAIE = db.BULLETIN_DE_PAIE.Find(id);
            if (bULLETIN_DE_PAIE == null)
            {
                return HttpNotFound();
            }
            return View(bULLETIN_DE_PAIE);
        }

        // GET: BULLETIN_DE_PAIE/Create
        public ActionResult Create()
        {
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN");
            return View();
        }

        // POST: BULLETIN_DE_PAIE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REF_BULL,MATRECULE,SALAIRE_BASE,SALARE_BRUT,NET_APAYER,DATE_ENTRE,STATUS")] BULLETIN_DE_PAIE bULLETIN_DE_PAIE)
        {
            if (ModelState.IsValid)
            {
                db.BULLETIN_DE_PAIE.Add(bULLETIN_DE_PAIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", bULLETIN_DE_PAIE.MATRECULE);
            return View(bULLETIN_DE_PAIE);
        }

        // GET: BULLETIN_DE_PAIE/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BULLETIN_DE_PAIE bULLETIN_DE_PAIE = db.BULLETIN_DE_PAIE.Find(id);
            if (bULLETIN_DE_PAIE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", bULLETIN_DE_PAIE.MATRECULE);
            return View(bULLETIN_DE_PAIE);
        }

        // POST: BULLETIN_DE_PAIE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REF_BULL,MATRECULE,SALAIRE_BASE,SALARE_BRUT,NET_APAYER,DATE_ENTRE,STATUS")] BULLETIN_DE_PAIE bULLETIN_DE_PAIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bULLETIN_DE_PAIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATRECULE = new SelectList(db.EMPLOYEEs, "MATRECULE", "CIN", bULLETIN_DE_PAIE.MATRECULE);
            return View(bULLETIN_DE_PAIE);
        }

        // GET: BULLETIN_DE_PAIE/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BULLETIN_DE_PAIE bULLETIN_DE_PAIE = db.BULLETIN_DE_PAIE.Find(id);
            if (bULLETIN_DE_PAIE == null)
            {
                return HttpNotFound();
            }
            return View(bULLETIN_DE_PAIE);
        }

        // POST: BULLETIN_DE_PAIE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BULLETIN_DE_PAIE bULLETIN_DE_PAIE = db.BULLETIN_DE_PAIE.Find(id);
            db.BULLETIN_DE_PAIE.Remove(bULLETIN_DE_PAIE);
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
