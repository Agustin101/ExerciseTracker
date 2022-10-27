using System.ComponentModel.DataAnnotations;
using UI.Repositories;

namespace UI
{
    internal class UserInput
    {
        public async Task GetInput()
        {
            Console.Clear();
            Console.WriteLine("Welcome to your exercise tracker!");
            Console.WriteLine("A - Add workout.");
            Console.WriteLine("S - See your workouts.");
            Console.WriteLine("U - Update a workout.");
            Console.WriteLine("D - Delete a workout.");
            Console.WriteLine("E - Exit.");
            string input = Console.ReadLine();

            if (InputValidator.IsValidString(input))
            {
                await ProcessOption(input);
            }
        }

        private async Task ProcessOption(string input)
        {
            switch (input.ToUpper())
            {
                case "A":
                    await ExerciseService.ProcessCreateExcercise();
                    await GetInput();
                    break;
                case "S":
                    await ExerciseService.ProcessShowExercises();
                    await GetInput();
                    break;
                case "U":
                    await ExerciseService.UpdateExercise();
                    await GetInput();
                    break;
                default:
                    break;
            }
        }
    }
}