using Student_Managment_system.Models;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication44.Controllers
{
    public class LoginController : Controller
    {

        student_dbEntities1 db = new student_dbEntities1();


        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objchk)
        {


            if (ModelState.IsValid)
            {
                using (student_dbEntities1 db = new student_dbEntities1())
                {

                    var obj = db.Users.Where(a => a.user_name.Equals(objchk.user_name) && a.püassword.Equals(objchk.püassword)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.user_name.ToString();
                        return RedirectToAction("Index", "Home");


                    }

                    else
                    {

                        ModelState.AddModelError("", "The UserName or Password Incorrect");



                    }


                }


            }

            return View(objchk);
        }


        public ActionResult Logout()
        {

            Session.Clear();
            return RedirectToAction("Index", "Login");



        }











    }
}