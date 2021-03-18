using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
namespace WebApplication1.Controllers
{
    public class Student
        {
            public int id { get; set; }
            public string name { get; set; }
            public string username { get; set; }
        }
    public class StudentWorks
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
    }
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        [HttpPost]
        public ActionResult SimplePost(int? id)
        {
            string jsonString;
            using(StreamReader reader=new StreamReader(@"Models/students.json"))
            {
                jsonString = reader.ReadToEnd();
            }
            var studentsList = JsonSerializer.Deserialize<List<Student>>(jsonString);
            return Json(studentsList);
        }
        [HttpPost]
        public ActionResult GetCouseWord(int id)
        {
            string jsonString;
            string IdStudent;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                IdStudent = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(@"Models/studentsWorks.json"))
            {
                jsonString = reader.ReadToEnd();
            }
            var СouseWorksList = JsonSerializer.Deserialize<List<StudentWorks>>(jsonString);
            var deserialize = JsonSerializer.Deserialize<int>(IdStudent);
            List<StudentWorks> result = new List<StudentWorks>();
            for (int i=0;i< СouseWorksList.Count;i++)
            {
                if (СouseWorksList[i].userId == deserialize)
                {
                    result.Add(СouseWorksList[i]);
                }
            }
            return Json(result);
        }
        public ActionResult NewCourseWork()
        {
            string jsonString;
            string newInfo;
            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                newInfo = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(@"Models/studentsWorks.json"))
            {
                jsonString = reader.ReadToEnd();
            }
            var СouseWorksList = JsonSerializer.Deserialize<List<StudentWorks>>(jsonString);
            СouseWorksList.Add(JsonSerializer.Deserialize<StudentWorks>(newInfo));
            System.IO.File.WriteAllText(@"Models/studentsWorks.json", JsonSerializer.Serialize(СouseWorksList));
            return Json(0);
        }
    }
}

