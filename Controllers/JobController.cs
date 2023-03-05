using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using ToDoListAPI.Model;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [EnableCors(origins: "http://127.0.0.1:5500/", headers: "*", methods: "*")]
    public class JobController : ControllerBase
    {
        static Random random = new Random();
         static List<Job> listJob = new List<Job>()
        {
            new Job() {Id = random.Next(), Name = "Cycling", StartDate = DateTime.Now, EndDate = DateTime.Now, IsCompleted = false },
            new Job() {Id = random.Next(), Name = "Walk", StartDate = DateTime.Now, EndDate = DateTime.Now, IsCompleted = true },
            new Job() {Id = random.Next(), Name = "Swim", StartDate = DateTime.Now, EndDate = DateTime.Now, IsCompleted = false },
            new Job() {Id = random.Next(), Name = "Do Home Work", StartDate = DateTime.Now, EndDate = DateTime.Now, IsCompleted = false }
        };

        [HttpGet(Name = "GetJobs")]
        public List<Job> Get()
        {
            return listJob.ToList();

        }
        [HttpPost]
        public IActionResult Add(Job newJob)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            newJob.Id = random.Next();
            listJob.Add(newJob);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int idDel)
        {

            Job jobDel = listJob.FirstOrDefault(o => o.Id.Equals(idDel));
            if (jobDel == null)
                return BadRequest(NotFound(idDel));
            listJob.Remove(jobDel);
            return Ok();
        }  
        [HttpPost]
        public IActionResult Check(int id)
        {

            Job job = listJob.FirstOrDefault(o => o.Id.Equals(id));
            if (job == null)
                return BadRequest(NotFound(id));

            listJob.Remove(job);
            if (job.IsCompleted == true)
                job.IsCompleted = false;
            else job.IsCompleted = true;
            
            listJob.Add(job);
            return Ok();
        }
    }
}
