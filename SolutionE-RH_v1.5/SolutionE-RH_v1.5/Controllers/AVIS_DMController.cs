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
    public class AVIS_DMController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: AVIS_DM
        public ActionResult Index()
        {
            var aVIS_DM = db.AVIS_DM.Include(a => a.DEMANDE_CONGE);
            return View(aVIS_DM.ToList());
        }

        // GET: AVIS_DM/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVIS_DM aVIS_DM = db.AVIS_DM.Find(id);
            if (aVIS_DM == null)
            {
                return HttpNotFound();
            }
            return View(aVIS_DM);
        }

        // GET: AVIS_DM/Create
        public ActionResult Create()
        {
            ViewBag.ID_DEMANDE = new SelectList(db.DEMANDE_CONGE, "ID_DEMANDE", "MATRECULE");
            return View();
        }

        // POST: AVIS_DM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEMANDE,ID_AVIS,AVIS,RAIS_AVIS,DATE_AVIS")] AVIS_DM aVIS_DM)
        {
            if (ModelState.IsValid)
            {
                db.AVIS_DM.Add(aVIS_DM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DEMANDE = new SelectList(db.DEMANDE_CONGE, "ID_DEMANDE", "MATRECULE", aVIS_DM.ID_DEMANDE);
            return View(aVIS_DM);
        }

        // GET: AVIS_DM/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVIS_DM aVIS_DM = db.AVIS_DM.Find(id);
            if (aVIS_DM == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DEMANDE = new SelectList(db.DEMANDE_CONGE, "ID_DEMANDE", "MATRECULE", aVIS_DM.ID_DEMANDE);
            return View(aVIS_DM);
        }

        // POST: AVIS_DM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEMANDE,ID_AVIS,AVIS,RAIS_AVIS,DATE_AVIS")] AVIS_DM aVIS_DM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aVIS_DM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DEMANDE = new SelectList(db.DEMANDE_CONGE, "ID_DEMANDE", "MATRECULE", aVIS_DM.ID_DEMANDE);
            return View(aVIS_DM);
        }

        // GET: AVIS_DM/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVIS_DM aVIS_DM = db.AVIS_DM.Find(id);
            if (aVIS_DM == null)
            {
                return HttpNotFound();
            }
            return View(aVIS_DM);
        }

        // POST: AVIS_DM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            AVIS_DM aVIS_DM = db.AVIS_DM.Find(id);
            db.AVIS_DM.Remove(aVIS_DM);
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
