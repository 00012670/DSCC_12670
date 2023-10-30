using API.DAL;
using API.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly HabitTrackerContext _dbContext;
        public ProgressRepository(HabitTrackerContext dbContext)
        {
            _dbContext = dbContext;
        }

        private Progress FindProgressById(int progressId)
        {
            return _dbContext.Progresses.Find(progressId);
        }


        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public void DeleteProgress(int progressId)
        {
            var progress = FindProgressById(progressId);
            _dbContext.Progresses.Remove(progress);
            Save();
        }

        public IEnumerable<Progress> GetProgresses()
        {
            return _dbContext.Progresses.Include(s => s.Habit).ToList();

        }

        public Progress GetProgressById(int Id)
        {
            var progress = FindProgressById(Id);
            _dbContext.Entry(progress).Reference(s => s.Habit).Load();

            return progress;
        }

        public void InsertProgress(Progress progress)
        {
            if (progress.Habit != null)
            {
                progress.Habit = _dbContext.Habits.FirstOrDefault(h => h.ID == progress.Habit.ID);
            }
            _dbContext.Add(progress);
            Save();
        }

        public void UpdateProgress(Progress progress)
        {
            var existingProgress = _dbContext.Progresses.Find(progress.ID);
           // existingProgress.Habit.ID = progress.Habit.ID;
            existingProgress.HabitProgress = progress.HabitProgress;
            existingProgress.IsCompleted = progress.IsCompleted;
            existingProgress.Note = progress.Note;
            existingProgress.EndDate = progress.EndDate;
            Save();
        }

    }
}
