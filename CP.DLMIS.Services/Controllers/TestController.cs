using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CP.DLMIS.Services.Controllers
{
    public class TestController : Controller
    {
        // 
        // GET: /Test/
        //IActionResult (or a class derived from ActionResult)
        public IActionResult Index()
        {
            return View();//视图模板.如果默认不写参数，则会查找对应的方法名称视图
        }


        // GET: /Test/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        //http://localhost:xxxx/HelloWorld/Welcome?name=Rick&numtimes=4 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        // GET: /Test/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        //http://localhost:xxx/HelloWorld/Welcome/3?name=Rick
        //由于在Start里的配置格式为：{controller=Home}/{action=Index}/{id?}，所以Id是可以这样对应
        public string WelcomeId(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}
