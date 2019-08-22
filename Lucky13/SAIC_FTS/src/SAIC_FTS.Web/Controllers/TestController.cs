//using System.Web.Http;
//using System.Web.Http.Results;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Mvc;

namespace SAIC_FTS.Web.Controllers
{
    public class TestController : SAIC_FTSControllerBase
    {
        [HttpPost]
        public JsonResult SavePerson(Models.BinaryFile bfile)//(Models.Customer person)
        {
            //TODO: save new person to database and return new person's id
            //System.Diagnostics.Debug.WriteLine("Hello, does this work? Please say yes!");
            //System.Diagnostics.Debug.WriteLine("Here is text: " + bfile.FileBinary + "End text");

            //string sourcepath = @"C:\Users\kingd\source\repos\Lucky13\SAIC_FTS\src\Tests\source.pdf";
            //byte[] theFile = System.IO.File.ReadAllBytes(sourcepath);

            var strArr = bfile.FileBinary.Split(new char[] { ',' }, 2);
            byte[] bytes  = System.Convert.FromBase64String(strArr[1]);//bfile.FileBinary);




            //string filepath = @"C:\Users\kingd\source\repos\Lucky13\SAIC_FTS\src\Tests\file.pdf";
            string filepath = System.Web.HttpContext.Current.Server.MapPath("~") + @"\BINARYFILES\file." + bfile.Extension;
            //var result = bfile.FileBinary;//ObjectToByteArray(bfile.FileBinary);
            System.IO.File.WriteAllBytes(filepath, bytes);

            return Json(new { Extension = bfile.Extension });
        }

        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

    }

}
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAIC_FTS.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCustomers()
        {
            List<Models.Customer> customers = new List<Models.Customer>();
            //Add First Customer to Our Collection
            customers.Add(new Models.Customer()
            {
                Id = 1,
                CompanyName = "Volvo",
                ContactNo = "123-0123-0001",
                ContactPerson = "Gustav Larson",
                Description = "Volvo Car Corporation, or Volvo Personvagnar AB, is a Scandinavian automobile manufacturer founded in 1927"
            });

            //Add Second Customer to Our Collection
            customers.Add(new Models.Customer()
            {
                Id = 2,
                CompanyName = "BMW",
                ContactNo = "999-9876-9898",
                ContactPerson = "Franz Josef Popp",
                Description = "Bayerische Motoren Werke AG,  (BMW; English: Bavarian Motor Works) is a " +
                                      "German automobile, motorcycle and engine manufacturing company founded in 1917. "
            });

            //Add Third Customer to Our Collection
            customers.Add(new Models.Customer()
            {
                Id = 3,
                CompanyName = "Audi",
                ContactNo = "983-2222-1212",
                ContactPerson = "Karl Benz",
                Description = " is a multinational division of the German manufacturer Daimler AG,"
            });

            return View(customers);

    }




}
*/
