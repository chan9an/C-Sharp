using First_WebAPI_Demo.Models;
using First_WebAPI_Demo.Models.Repo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace First_WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        StudentRepos sRepo = null;
        public StudentsController()
        {
            sRepo = new StudentRepos();
            
        }
        //There can be only one Get , like with same Parameter

        // GET: api/<StudentsController>
        //[HttpGet]
        //[Route("GetAll")]
        //public string Get1()
        //{
        //    return "hello";
        //}

        public IEnumerable<Student> Get()
        {
            return sRepo.GetAll();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
           return sRepo.Get(id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
