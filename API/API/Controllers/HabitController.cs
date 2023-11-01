using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitRepository _habitRepository;
        public HabitController(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        private ActionResult HandleSuccessfulOperation(object result)
        {
            using var scope = new TransactionScope();
            scope.Complete();
            return Ok(result);
        }

        // GET: api/<HabitController>
        [HttpGet]
        public IActionResult Get()
        {
            var habits = _habitRepository.GetHabits();
            return new OkObjectResult(habits);
        }

        // GET api/<HabitController>/5
        [HttpGet, Route("{id}", Name = "GetHabitByID")]
        public IActionResult Get(int id)
        {
            var habit = _habitRepository.GetHabitById(id);
            return new OkObjectResult(habit);
        }

        // POST api/<HabitController>
        [HttpPost]
        public ActionResult Post([FromBody] Habit habit)
        {
            _habitRepository.InsertHabit(habit);
            return HandleSuccessfulOperation(habit);
        }

        // PUT api/<HabitController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Habit habit)
        {
            var existingHabits = _habitRepository.GetHabitById(id);
            if (existingHabits != null)
            {
                _habitRepository.UpdateHabit(habit);
                return HandleSuccessfulOperation(null);
            }
            return NotFound();
        }

        // DELETE api/<HabitController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _habitRepository.DeleteHabit(id);
            return HandleSuccessfulOperation(null);
        }
    }
}
