using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetworkBiddingSystem.Models;

namespace NetworkBiddingSystem.Dal
{
    public class BidDal
    {
        public static int GetPageCount(int pageSize)
        {
            int recordCount = GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        private static int GetRecordCount()
        {
            try
            {
                using (var entity = new BidingSystemDBEntities())
                {
                    var item = entity.Item.ToList();
                    if (item != null)
                    {
                        return item.Count();
                    }
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }

        // 获取公司信息列表
        public static List<Item> GetPageEntityList(int pageIndex, int pageSize)
        {
            using (var entity = new BidingSystemDBEntities())
            {
                return entity.Item.OrderBy(x => x.Status).ThenBy(x => x.StartTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static Item GetItemInfo(int id)
        {
            using (var entity = new BidingSystemDBEntities())
            {
                return entity.Item.Where(x => x.ItemId == id).FirstOrDefault();
            }
        }

        public static int RemoveItem(int id)
        {
            using (var entity = new BidingSystemDBEntities())
            {
                var item = entity.Item.Where(x => x.ItemId == id).FirstOrDefault();
                entity.Item.Remove(item);
                return entity.SaveChanges();
            }
        }
    }
}