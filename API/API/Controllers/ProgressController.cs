using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _progressRepository;
        public ProgressController(IProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }

        private ActionResult HandleSuccessfulOperation(object result)
        {
            using (var scope = new TransactionScope())
            {
                scope.Complete();
                return Ok(result);
            }
        }

        // GET: api/<ProgressController>
        [HttpGet]
        public IActionResult Get()
        {
            var progress = _progressRepository.GetProgresses();
            return new OkObjectResult(progress);
        }

        // GET api/<ProgressController>/5
        [HttpGet("{id}", Name = "GetP")]
        public IActionResult Get(int id)
        {
            var progress = _progressRepository.GetProgressById(id);
            return new OkObjectResult(progress);
        }

        // POST api/<ProgressController>
        [HttpPost]
        public ActionResult Post([FromBody] Progress progress)
        {

            _progressRepository.InsertProgress(progress);
            return HandleSuccessfulOperation(progress);
        }

        // PUT api/<ProgressController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Progress progress)
        {
            var existingProgress = _progressRepository.GetProgressById(id);
            if (existingProgress != null)
            {
                _progressRepository.UpdateProgress(progress);
                return HandleSuccessfulOperation(null);
            }
            return NotFound();
        }

        // DELETE api/<ProgressController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _progressRepository.DeleteProgress(id);
            return HandleSuccessfulOperation(null);
        }
    }
}
