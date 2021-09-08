using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIO
{
    public class QueryIO
    {
        Connect mydb = new Connect();
        public Login checklogin(string us, string pass)
        {
            return mydb.Login.Where(c => c.username == us && c.pass == pass).FirstOrDefault();
        }
        //List
        public List<Login> CheckList()
        {
            return mydb.Login.ToList();
        }
        //them 1 user mới , viết dùng chung
        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }
        //xóa 1 user
        public void removebbb<T>(T obj)
        {
            mydb.Set(obj.GetType()).Remove(obj);
        }
        //doc user tu ID
        public Login getOBJ(string id)
        {
            return mydb.Login.Where(c => c.id == id).FirstOrDefault();
        }
        public void Save()
        {
            mydb.SaveChanges();
        }

    }
}