using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using System.IO;

namespace TVM_bài_hướng_dẫn_1
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Các action khác ở đây...

        //Action trả về một View là một trang html và nó có thể truyền tham số hoặc model
        public ViewResult TestViewResult()
        {
            return View();
        }

        //Action trả về một PartialView
        public PartialViewResult TestPartialViewResult()
        {
            return PartialView();
        }

        //Action trả về một EmptyResult
        public EmptyResult TestEmptyResult()
        {
            return new EmptyResult();
        }

        //Action trả về một RedirectResult
        public RedirectResult TestRedirectResult()
        {
            return Redirect("Index");
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string ClassName { get; set; }
        }

        //Action trả về một JsonResult
        public JsonResult TestJsonResult()
        {
            List<Student> listStudent = new List<Student>
            {
                new Student { ID = 001, Name = "Nguyễn Quang Huy", ClassName = "C1311L" },
                new Student { ID = 002, Name = "Nguyễn Duy Huân", ClassName = "C1311T" },
                new Student { ID = 003, Name = "Vũ Minh Trịnh", ClassName = "C1311M" }
            };

            return Json(listStudent, JsonRequestBehavior.AllowGet);
        }

        //Action trả về một JavaScriptResult
        public JavaScriptResult TestJavaScriptResult()
        {
            string js = "function checkEMail() { var btloc = /^([\\w-]+(?:.[\\w-]+)*)@((?:[\\w-]+.) *\\w[\\w-]{0,66}).([a-z]{2,6}(?:.[a-z]{2})?)$/; if (btloc.test(mail)) { kq = true; } else { alert('Email address invalid'); kq = false; } return kq; }";
            return JavaScript(js);
        }

        //Action trả về một ContentResult dạng văn bản
        public ContentResult TestContentResult()
        {
            XElement contentXML = new XElement("Students",
                new XElement("Student",
                    new XElement("ID", "001"),
                    new XElement("FullName", "Nguyễn Viết Nam"),
                    new XElement("ClassName", "C1308H")),
                new XElement("Student",
                    new XElement("ID", "002"),
                    new XElement("FullName", "Nguyễn Hoàng Anh"),
                    new XElement("ClassName", "C1411P")),
                new XElement("Student",
                    new XElement("ID", "003"),
                    new XElement("FullName", "Phạm Ngọc Anh"),
                    new XElement("ClassName", "C1411L")),
                new XElement("Student",
                    new XElement("ID", "004"),
                    new XElement("FullName", "Trần Ngọc Linh"),
                    new XElement("ClassName", "C1411H")),
                new XElement("Student",
                    new XElement("ID", "005"),
                    new XElement("FullName", "Nguyễn Hồng Anh"),
                    new XElement("ClassName", "C1411L")));

            return Content(contentXML.ToString(), "text/xml", Encoding.UTF8);
        }
        public FileContentResult TestFileContentResult()
        {
            byte[] fileBytes =
                System.IO.File.ReadAllBytes(Server.MapPath("~/Content/demovideo.mp4"));
            string fileName = "demovideo.mp4";

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public FileStreamResult TestFileStreamResult()
        {
            string pathFile = Server.MapPath("~/Content/vonsong.docx");
            string fileName = "vonsong.docx";
            return File(new FileStream(pathFile, FileMode.Open), "text/doc", fileName);
        }

        public FilePathResult TestFilePathResult()
        {
            string pathFile = Server.MapPath("~/Content/vonsong.docx");
            string fileName = "vonsong.docx";
            return File(pathFile, "text/doc", fileName);
        }
    }
  }
