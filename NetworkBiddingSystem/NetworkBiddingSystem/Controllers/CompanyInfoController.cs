using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetworkBiddingSystem.Models;

namespace NetworkBiddingSystem.Controllers
{
    public class CompanyInfoController : Controller
    {
        //
        // GET: /CompanyInfo/

        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = Dal.UserDal.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<User> list = Dal.UserDal.GetPageEntityList(pageIndex, pageSize);
            ViewData["newInfoList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }

        #region 显示详细信息
        public ActionResult GetNewInfoModel()
        {
            int id = int.Parse(Request["id"]);
            User user = Dal.UserDal.GetUserInfo(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除数据
        public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            int b = Dal.UserDal.RemoveUser(id);
            if (b == 1)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 展示要修改的数据
        public ActionResult ShowEdit()
        {
            int id = int.Parse(Request["id"]);
            User user = Dal.UserDal.GetUserInfo(id);
            ViewData.Model = user;
            return View();
        }

        #endregion

    }
}
