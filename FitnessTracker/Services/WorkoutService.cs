using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services
{
    public class WorkoutService
    {
        private readonly FitnessContext _context;

        public WorkoutService(FitnessContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutModel>> GetAllWorkoutsAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task AddWorkoutAsync(WorkoutModel workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkoutAsync(WorkoutModel workout)
        {
            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkoutAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
        }
    }
}