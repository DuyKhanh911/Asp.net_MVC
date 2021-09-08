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
                    status = "er",
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
                    message = "khong dc để trống"

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
                        status = "ER",
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
        ////update
        [HttpPost]
        public JsonResult SaveEdit(FormCollection data)
        {
            var uid = data["id"];
            var username = data["username"];
            var pass = data["pass"];
            var fullname = data["fullname"];

            JsonResult js = new JsonResult();
            if (string.IsNullOrEmpty(uid) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(fullname))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không dc để trống dữ liệu trừ pass"
                };
            }
            else
            {
                QueryIO qr = new QueryIO();
                Login lg = qr.getOBJ(uid);
                if (lg == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "dữ liệu không tồn tại"
                    };
                }
                else
                {
                    lg.username = username;
                    if (!string.IsNullOrEmpty(pass))
                    {
                        lg.pass = pass;
                    }
                    lg.fullname = fullname;

                    //gọi lưu lại
                    qr.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
            //test
        }
    }
}