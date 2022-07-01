using MVCEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogic
{
    public class LogicProduct
    {
        //获取商品列表
        public List<Product> GetProductList(string keyWord)
        {
            //实例化数据库上下文类
            JooleEntity jooleEntity = new JooleEntity();
            //查询需要的数据
            var data = jooleEntity.Product.ToList();
            //如果keyword不空进行模糊查询
            if (!string.IsNullOrEmpty(keyWord))
            {
                data = data.Where(p => p.ProductName.Contains(keyWord)).ToList();
            }
            return data;
        }
        //删除
        public bool DeleteProduct(int ID)
        {
            JooleEntity jooleEntity = new JooleEntity();
            //根据id找，再删
            var data = jooleEntity.Product.Where(p => p.ID == ID).FirstOrDefault();//id主键unique
            //如果data不null进行删除
            if (data != null) 
            {
                jooleEntity.Product.Remove(data);
                //保存操作  
                jooleEntity.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }      
        }
        //修改
        public void UpdateProduct(Product product)
        {
            //用对象进行数据接收再根据id查询此条数据再重赋值
            JooleEntity jooleEntity = new JooleEntity();
            var data = jooleEntity.Product.Where(p => p.ID == product.ID).FirstOrDefault();
            data.ProductName = product.ProductName;
            data.ProductPrice = product.ProductPrice;
            data.ProductManu = product.ProductManu;
            data.ProductYear = product.ProductYear;

            jooleEntity.SaveChanges();
        }
        //新增
        public void InsertProduct(Product product)
        {
            JooleEntity jooleEntity = new JooleEntity();
            jooleEntity.Product.Add(product);
            jooleEntity.SaveChanges();
        }
        //查单项
        public Product GetSingleProduct(int iD)
        {
            JooleEntity jooleEntity = new JooleEntity();
            var data = jooleEntity.Product.Where(p => p.ID == iD).FirstOrDefault();
            return data;
        }
    }
}
