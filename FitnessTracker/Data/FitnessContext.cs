using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data;
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options) { }

        public DbSet<WorkoutModel> Workouts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<NutritionModel> Nutritions { get; set; }
    }
