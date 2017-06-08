using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAnadll
{
    public class UserManager
    {
        public bool AddUser(User user)
        {
            string sql = string.Format("insert into user_manage values (0, '{0}',{1},'{2}','{3}','{4}','{5}','{6}', '{7}')",
            user.Name, user.RoleID, user.Password, user.Level, user.Department, user.Email, user.Telephone, user.Phone);
            if (MysqlDBAccess.getInstance().queryNoResponse(sql, false) == 1)
                return true;
            else
                return false;
        }


        public List<User> GetAllUsers()
        {
            string sql = "select * from user_manage";
            DataTable dt = null;
            List<User> list = new List<User>();
            if (MysqlDBAccess.getInstance().query(sql, ref dt) > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    User u = new User();
                    u.ID = (int)row[0];
                    u.Name = row[1].ToString();
                    u.RoleID = (int)row[2];
                    u.Password = row[3].ToString();
                    u.Level = row[4].ToString();
                    u.Department = row[5].ToString();
                    u.Email = row[6].ToString();
                    u.Telephone = row[7].ToString();
                    u.Phone = row[8].ToString();
                    list.Add(u);
                }
            }
            return list;
        }

        public bool UpdateUser(User user)
        {
            string sql = string.Format("update user_manage set name='{0}',role_type={1},password='{2}',level='{3}',department_name='{4}',email='{5}',telephone='{6}',phone='{7}' where id='{8}'",
            user.Name, user.RoleID, user.Password, user.Level, user.Department, user.Email, user.Telephone, user.Phone, user.ID);
            if (MysqlDBAccess.getInstance().queryNoResponse(sql, false) == 1)
                return true;
            else
                return false;
        }


        public bool DeleteUser(int userID)
        {
            string sql = string.Format("delete from user_manage where id ={0}", userID);
            if (MysqlDBAccess.getInstance().queryNoResponse(sql, false) == 1)
                return true;
            else
                return false;
        }
    }
}
