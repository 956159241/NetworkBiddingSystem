using NetworkBiddingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetworkBiddingSystem.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckLogin()
        {
            string validateCode = Session["validateCode"] == null ? string.Empty : Session["validateCode"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!");
            }
            Session["validateCode"] = null;
            string requestCode = Request["vCode"];
            if (!requestCode.Equals(validateCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            //BLL.UserInfoService UserInfoService = new BLL.UserInfoService();
            //T_UserInfo userInfo = UserInfoService.GetUserInfoModel(userName, userPwd);
            //if (userInfo != null)
            //{
            //    return Content("ok:登录成功!!");
            //}
            //else
            //{
            //    return Content("no:用户名密码错误");
            //}

            return Content("ok:登录成功!!");

        }

        public ActionResult ValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["validateCode"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }

    }
}
