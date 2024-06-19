using Microsoft.AspNetCore.Mvc;
using STUDTEACHAPI.Models;
using STUDTEACHAPI.Services;
using System.Collections.Generic;

namespace STUDTEACHAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly DataService _dataService;

        public StudentsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<List<Studenttype>> Get()
        {
            var students = _dataService.LoadStudents();
            return Ok(students);
        }

        [HttpPost]
        public ActionResult<List<Studenttype>> Post([FromBody] Studenttype student)
        {
            var students = _dataService.LoadStudents();
            student.Id = students.Count > 0 ? students[^1].Id + 1 : 1;
            students.Add(student);
            _dataService.SaveStudents(students);
            return Ok(students);
        }
    }
}
