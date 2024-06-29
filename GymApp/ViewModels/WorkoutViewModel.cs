using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.ViewModels
{
    public class WorkoutViewModel
    {
        public DateTime StartTime { get; set; }
        public string Name { get; set; }
        public int ExercisesCount { get; set; }
        public double TotalWeight { get; set; }
    }
}
