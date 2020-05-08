using SolutionE_RH_v1._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolutionE_RH_v1._5.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Loginuser()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loginuser(USER objUser)
        {
            if (ModelState.IsValid)
            {
                using (E_RHEntities1 db2 = new E_RHEntities1())
                {
                    var obj = db2.USERs.Where(a => a.LOGIN.Equals(objUser.LOGIN) && a.PASSWORD.Equals(objUser.PASSWORD)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID_USER.ToString();
                        Session["Matrecule"] = obj.MATRECULE.ToString();
                        var emp = db2.EMPLOYEEs.Where(a => a.MATRECULE.Equals(obj.MATRECULE.ToString())).FirstOrDefault();
                        Session["EmpName"] = emp.NOM.ToString();
                        Session["EmpPrenom"] = emp.PRENOM.ToString();
                        Session["EmpCIN"] = emp.NOM.ToString();
                        Session["employee"] = emp.DEPLACEMENTs;
                        if (obj.CATEG.Equals("admin"))
                            return RedirectToAction("AdmindasshBoard");
                        else if (obj.CATEG.Equals("emp"))
                            return View("EmpDashBoard");
                        else
                            return View("Loginuser");

                    }
                }
            }
            return View(objUser);
        }
        public ActionResult AdmindasshBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Loginuser");
            }
        }

        public ActionResult EmpDashBoard1()
        {
            List<DEPLACEMENT> deplist;
            if (Session["UserID"] != null)
            {
               deplist = (List<DEPLACEMENT>)Session["employee"];
                return View(deplist.ToList());
            }
            else
            {
                return RedirectToAction("Loginuser");
            }
        }



    }
}