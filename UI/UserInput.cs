using System.ComponentModel.DataAnnotations;
using UI.Repositories;

namespace UI
{
    internal class UserInput
    {
        internal void GetInput()
        {
            Console.WriteLine("Welcome to your exercise tracker!");
            Console.WriteLine("A - Add workout.");
            Console.WriteLine("S - See your workouts.");
            Console.WriteLine("U - Update a workout.");
            Console.WriteLine("D - Delete a workout.");
            Console.WriteLine("E - Exit.");
            string input = Console.ReadLine();

            if (InputValidator.IsValidString(input))
            {
                ProcessOption(input);
            }
        }

        private void ProcessOption(string input)
        {
            switch (input.ToUpper())
            {
                case "A":
                    ExerciseService.CreateExcercise();
                    break;
                default:
                    break;
            }
        }
    }
}