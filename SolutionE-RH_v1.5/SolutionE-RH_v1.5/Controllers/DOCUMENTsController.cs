using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolutionE_RH_v1._5.Models;

namespace SolutionE_RH_v1._5.Controllers
{
    public class DOCUMENTsController : Controller
    {
        private E_RHEntities1 db = new E_RHEntities1();

        // GET: DOCUMENTs
        public ActionResult Index()
        {
            return View(db.DOCUMENTs.ToList());
        }

        // GET: DOCUMENTs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // GET: DOCUMENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DOCUMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DOC,LB_DOC,FICH_DOC,DESC_DOC")] DOCUMENT dOCUMENT, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
               //if(file != null)
               // {
               //     var fileName = Path.GetFileName(file.FileName);
                   
               //     var path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
               //     file.SaveAs(path);
               //     dOCUMENT.FICH_DOC = fileName;
               //     db.DOCUMENTs.Add(dOCUMENT);
                    db.SaveChanges();
                    return RedirectToAction("Index"); }
            

            return View(dOCUMENT);
        }

        // GET: DOCUMENTs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // POST: DOCUMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DOC,LB_DOC,FICH_DOC,DESC_DOC")] DOCUMENT dOCUMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOCUMENT);
        }

        // GET: DOCUMENTs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // POST: DOCUMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            db.DOCUMENTs.Remove(dOCUMENT);
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
