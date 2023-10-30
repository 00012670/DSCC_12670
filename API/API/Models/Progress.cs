using System;

namespace API.Models
{
    public class Progress
    {
        public Habit Habit { get; set; }
        public int ID { get; set; }
        public int HabitProgress { get; set; }
        public bool IsCompleted { get; set; }
        public string Note { get; set; }
        public DateTime EndDate { get; set; }
    }
}
