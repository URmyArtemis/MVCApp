using MVCEntity;
using MVCLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : BaseController
    {
        LogicUser logicUser = new LogicUser();
        LogicProduct logicProduct = new LogicProduct(); 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]

        public ActionResult Login(string username, string password )
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return ErrorResult("User name or password is empty!");
            }
            else
            {
                //调用用户登录方法
                var data = logicUser.CheckLogin(username, password);
                if(data != null)
                {
                    return SucceedResult("Login Success!");
                }
                else
                {
                    return ErrorResult("Login Error!");
                }
            }
        }

        public ActionResult ProductList()
        {
            return View();
        }
        //获取product列表
        public string GetProductList(string keyWord)
        {
            var data = logicProduct.GetProductList(keyWord);
            return data.ToJSON();
        }

        public ActionResult DeleteProduct(int ID) 
        {
            bool b = logicProduct.DeleteProduct(ID);
            if (true)
            {
                return SucceedResult("Delete success!");
            }
            else
            {
                //return ErrorResult("Delete failed!");
            }
        }

        public ActionResult ProductDetail()
        {
            return View();
        }
        //修改接口
        public ActionResult UpdateSingleProduct(Product product)
        {
            logicProduct.UpdateProduct(product);
            return SucceedResult("Update success!");
        }
        //查询单项
        public string GetSingleProduct(int ID)
        {
            var data = logicProduct.GetSingleProduct(ID);
            return data.ToJSON();
        }

        public ActionResult InsertSingleProduct(Product product)
        {
            logicProduct.InsertProduct(product);
            return SucceedResult("Insert success!");
        }

    }
}