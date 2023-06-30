using Shelter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelter.Domain.Entities
{
    public static class DataWorker
    {

      
        public static List<Goods> GetAllGoods()
        {
            using (ComentDbContext db = new ComentDbContext())
            {
                var result = db.Goods.ToList();
                return result;
            }
        }
        
    
        public static string CreateGoods(string Name, int kind , int price)
        {
            string result = "Вже є";
            using (ComentDbContext db = new ComentDbContext())
            {
                
                bool checkIsExist = db.Goods.Any(el => el.Name == Name && el.NameKind == kind && el.Price == price);
                if (!checkIsExist)
                {
                    Goods newUser = new Goods
                    {
                        Name = Name,
                        NameKind = kind,
                        Price = price
                    };
                    db.Goods.Add(newUser);
                    db.SaveChanges();
                    result = "Успішна Операція!";
                }
                return result;
            }
        }
      
        public static string DeleteGoods(Goods goods)
        {
            string result = "Його не існує";
            using (ComentDbContext db = new ComentDbContext())
            {
                db.Goods.Remove(goods);
                db.SaveChanges();
                result = "Операція успішна!  " + goods.Name + " видалений";
            }
            return result;
        }
     
      
        public static string EditGoods(Goods oldGoods, string newName,int newNameKind,int newPrice)
        {
            string result = "Його не існує";
            using (ComentDbContext db = new ComentDbContext())
            {
                Goods _goods = db.Goods.FirstOrDefault(d => d.Id == oldGoods.Id);
                _goods.Name = newName;
                _goods.NameKind = newNameKind;
                _goods.Price = newPrice;
                db.SaveChanges();
                result = "Змінено товар " + _goods.Name ;
            }
            return result;
        }
   

   
        public static Goods GetGoodsId(int id)
        {
            using (ComentDbContext db = new ComentDbContext())
            {
                Goods pos = db.Goods.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }
       
    }
}
