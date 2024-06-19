using Microsoft.AspNetCore.Mvc;
using STUDTEACHAPI.Models;
using STUDTEACHAPI.Services;
using System.Collections.Generic;

namespace STUDTEACHAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly DataService _dataService;

        public TeachersController()
        {
            _dataService = new DataService();
        }

        [HttpGet]
        public ActionResult<List<Teacher>> Get()
        {
            var teachers = _dataService.LoadTeachers();
            return Ok(teachers);
        }

        [HttpPost]
        public ActionResult<List<Teacher>> Post([FromBody] Teacher teacher)
        {
            var teachers = _dataService.LoadTeachers();
            teacher.Id = teachers.Count > 0 ? teachers[^1].Id + 1 : 1;
            teachers.Add(teacher);
            _dataService.SaveTeachers(teachers);
            return Ok(teachers);
        }
    }
}
