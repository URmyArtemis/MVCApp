using MVCLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult SucceedResult(string message = "Operation Succeed!", object data = null)
        {
            return Content(new JsonRes(ResultType.Success, message, data).ToJSON());
        }

        protected ActionResult ErrorResult(string message = "Operation Failed!", object data = null)
        {
            return Content(new JsonRes(ResultType.Error, message, data).ToJSON());
        }
        //通过AJAX请求相应数据的格式模型
        public class JsonRes
        {
            public JsonRes(ResultType resultType, string message, object data = null)
            {
                this.resultType = resultType;
                this.message = message;
                this.data = data;
            }

            public object resultType { get; set; }
            public string message { get; set; }
            public object data { get; set; }
        }

        public enum ResultType
        {
            Success = 1,
            Error = 2,
        }
    }
}