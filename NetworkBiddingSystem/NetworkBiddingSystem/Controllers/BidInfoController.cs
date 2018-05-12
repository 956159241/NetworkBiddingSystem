using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetworkBiddingSystem.Models;

namespace NetworkBiddingSystem.Controllers
{
    public class BidInfoController : Controller
    {
        //
        // GET: /BidInfo/

        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = Dal.BidDal.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<Item> list = Dal.BidDal.GetPageEntityList(pageIndex, pageSize);
            ViewData["newInfoList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            ViewData["userInfoType"] = Request.Cookies["userInfoType"].Value.ToString();
            return View();
        }

        

        #region 显示详细信息
        public ActionResult GetItemInfoModel()
        {
            int id = int.Parse(Request["id"]);
            Item item = Dal.BidDal.GetItemInfo(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除数据
        public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            int b = Dal.BidDal.RemoveItem(id);
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
            Item item = Dal.BidDal.GetItemInfo(id);
            ViewData.Model = item;
            return View();
        }

        #endregion

    }
}
