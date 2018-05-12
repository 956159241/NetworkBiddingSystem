using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetworkBiddingSystem.Models;

namespace NetworkBiddingSystem.Dal
{
    public class UserDal
    {
        public static int Validate(string userName, string passwrod)
        {
            using (var entity = new BidingSystemDBEntities())
            {
                var user = entity.User.Where(x => x.CompanyName == userName && x.Password == passwrod).FirstOrDefault();
                if (user == null)
                {
                    return -1;
                }
                else if (user != null)
                {
                    if (user.Type == 1)
                    {
                        return 1;
                    }
                    else if (user.Type == 0)
                    {
                        return 0;
                    }
                    else
                        return -1;
                }
                else
                    return -1;
            }
        }

        public static User GetUserInfoInLogin(string userName, string passwrod)
        {
            using (var entity = new BidingSystemDBEntities())
            {
                var user = entity.User.Where(x => x.CompanyName == userName && x.Password == passwrod).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                return user;
            }
        }
        //获取公司信息分页
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
                    var user = entity.User.ToList();
                    if (user != null)
                    {
                        return user.Count();
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
        public static List<User> GetPageEntityList(int pageIndex, int pageSize)
        { 
            using(var entity = new BidingSystemDBEntities())
            {
                return entity.User.OrderBy(x => x.CompanyId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static User GetUserInfo(int id)
        { 
            using(var entity = new BidingSystemDBEntities())
            {
                return entity.User.Where(x => x.CompanyId == id).FirstOrDefault();
            }
        }

        public static int RemoveUser(int id)
        {
            using (var entity = new BidingSystemDBEntities())
            {
                var user = entity.User.Where(x => x.CompanyId == id).FirstOrDefault();
                entity.User.Remove(user);
                return entity.SaveChanges();
            }
        }
    }
}