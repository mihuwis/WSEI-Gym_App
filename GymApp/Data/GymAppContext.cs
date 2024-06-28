using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymApp.Models;

namespace GymApp.Data
{
    public class GymAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gymapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add sample data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "mihu", Password = "mihu" },
                new User { UserId = 2, Username = "zosia", Password = "zosia" }
            );

            modelBuilder.Entity<Workout>().HasData(
                new Workout { WorkoutId = 1, Name = "Morning Workout", UserId = 1 },
                new Workout { WorkoutId = 2, Name = "Evening Workout", UserId = 2 }
            );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { ExerciseId = 1, Name = "Push-up", Repetitions = 10, Weight = 0, WorkoutId = 1 },
                new Exercise { ExerciseId = 2, Name = "Squat", Repetitions = 15, Weight = 80, WorkoutId = 1 },
                new Exercise { ExerciseId = 3, Name = "Bench Press", Repetitions = 8, Weight = 50, WorkoutId = 2 },
                new Exercise { ExerciseId = 4, Name = "Bench Press", Repetitions = 8, Weight = 50, WorkoutId = 2 },
                new Exercise { ExerciseId = 5, Name = "Bench Press", Repetitions = 10, Weight = 50, WorkoutId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
