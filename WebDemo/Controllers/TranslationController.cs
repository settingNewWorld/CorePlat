using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebDemo.Controllers
{
    public class TranslationController : ApiController
    {
        [HttpPost]
        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            BasicClass bc = new BasicClass();
            string str= "";
            if (!string.IsNullOrEmpty(value))
            {
                //转换大小写
                str = bc.ConvertInitials(value);
                //去除空格
                str = bc.GoToSpace(value);
            }

            return str;
        }

      

    }
}