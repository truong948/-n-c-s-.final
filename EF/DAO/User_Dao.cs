using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.EF;

namespace EF.DAO
{
    internal class User_Dao
    {
        ShoppingOnlineDbContext db = null;

        public User_Dao() 
        {
            db = new ShoppingOnlineDbContext();
        }   

        public User Add(User user) 
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            var us = db.Users.FirstOrDefault(x=>x.ID == user.ID);  
            us.Password = user.Password;    
            us.Email = user.Email;  
            us.Phone = user.Phone;  
            us.Address = user.Address;  
            us.UpdateBy = user.UpdateBy;    
            us.UpdateDate = user.UpdateDate;
            db.SaveChanges();
            return us;    
        }

        public int Login(string email, string pass)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                return -2; //Email không tồn tại
            }

            else
            {
                if (user.Status == false)
                {
                    return 0; //Vô hiệu hóa
                }

                else
                {
                    if (user.Password == pass)
                    {
                        return 1; //Đăng nhập thành công
                    }

                    else 
                    {
                        return -2; //Sai mật khẩu
                    }
                } 
                    
            }    

        }
    }
}
