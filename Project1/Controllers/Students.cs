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
    }
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }
        private static  StudentWorks[] StudentWork = new[]
        {
            new StudentWorks
            {
                id=1,
                title="sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
                body="quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto",
            },
            new StudentWorks
            {
                id=2,
                title="qui est esse",
                body="est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla",
            }
        };
        private static Student[] Students = new[]
            {
            new Student
            {
                id=1,
                name="Leanne Graham",
                username="Bret"
            },
            new Student
            {
                id=2,
                name="Ervin Howell",
                username="Antonette",
            },
            };
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        [HttpPost]
        public ActionResult SimplePost(int? id)
        { 
            return Json(Students);
        }
        [HttpPost]
        public ActionResult GetCouseWord(int id=2)
        {
            string jsonString;

            using (StreamReader reader = new StreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                jsonString = reader.ReadToEnd();
            }
            var deserialize = JsonSerializer.Deserialize<int>(jsonString);
            for (int i=0;i<StudentWork.Length;i++)
            {
                if (StudentWork[i].id == deserialize)
                {
                    StudentWorks[] result = new StudentWorks[1];
                    result[0] = StudentWork[i];
                    // Я не знаю, как сделать это адекватно.Если я буду просто возращать students[0], то это будет просто объектом [],а мне в Students.js нужна конструкция [].
                    //return Json(JsonSerializer.Serialize(StudentWork[i]));
                    return Json(result);
                }
            }
            return Json(0);
        }
    }
}

