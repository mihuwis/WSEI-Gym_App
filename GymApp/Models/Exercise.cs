using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Repetitions { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}
