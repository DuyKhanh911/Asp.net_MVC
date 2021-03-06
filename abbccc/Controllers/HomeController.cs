using DataIO;
using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace abbccc.Controllers
{
    public class HomeController : Controller
    {
        Connect mydb = new Connect();
        public ActionResult Index()
        {
            QueryIO qr = new QueryIO();
            List<Login> list = qr.CheckList();

            return View(list);
        }
        [HttpPost]
        //them 1 user moi
        public JsonResult crete(FormCollection data)
        {
            string username = data["username"];
            string pass = data["pass"];
            string fullname = data["fullname"];
            JsonResult js = new JsonResult();
            //kiểm tra có rỗng k
            if (string.IsNullOrEmpty(username) ||
                 string.IsNullOrEmpty(pass) ||
                 string.IsNullOrEmpty(fullname))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "khong de trong"
                };

            }
            else
            {
                QueryIO add = new QueryIO();
                Login lg = new Login();
                lg.id = Guid.NewGuid().ToString();
                lg.username = username;
                lg.pass = pass;
                lg.fullname = fullname;

                add.AddObject(lg);
                add.Save();
                js.Data = new
                {
                    status = "OK"
                };
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        //delete
        [HttpPost]
        public JsonResult deleted(FormCollection data)
        {
            string id = data["id"];
            ///
            JsonResult js = new JsonResult();
            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "Lỗi"

                };

            }
            else
            {
                QueryIO QR = new QueryIO();
                Login lg = QR.getOBJ(id);
                if (lg == null)
                {
                    js.Data = new
                    {
                        status = "ER2",
                        message = "dữ liệu không tồn tại"
                    };
                }
                else
                {
                    QR.removebbb(lg);
                    QR.Save();

                    js.Data = new
                    {
                        status = "OK",
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        //update
        [HttpPost]
        public JsonResult resave(FormCollection data)
        {
            string id = data["id"];
            string username = data["username"];
            string pass = data["pass"];
            string fullname = data["fullname"];
            //
            JsonResult js = new JsonResult();
            if (string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(fullname))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "lỗi rồi!"
                };
            }
            else
            {
                QueryIO qr = new QueryIO();
                Login lg = qr.getOBJ(id);
                if (lg != null)
                {
                    lg.username = username;
                    lg.fullname = fullname;
                    qr.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
               
            }
           return Json(js, JsonRequestBehavior.AllowGet);
        }
    }
}