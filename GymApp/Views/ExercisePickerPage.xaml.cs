using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GymApp.Views
{
    public partial class ExercisePickerPage : ContentPage
    {

        public ExercisePickerPage()
        {
            InitializeComponent();

            exerciseListView.ItemsSource = new List<string>
            {
                "Dumbbell Curl",
                "Barbell Curl",
                "Dumbbell Tricep Extension",
                "Tricep Dips",
                "Barbell Tricep Extension",
                "Front Squats",
                "Back Squats",
                "Flat Benchpress",
                "Incline Benchpress",
                "Decline Benchpress",
                "Overhead Press",
                "Front Barbell Raise",
                "Lateral Raise"
          };
        }

        public ListView ExerciseType
        {
            get { return exerciseListView; }
        }
    }
}
