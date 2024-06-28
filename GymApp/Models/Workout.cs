﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public List<Exercise> Exercises { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
