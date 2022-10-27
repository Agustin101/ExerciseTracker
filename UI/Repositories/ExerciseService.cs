using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Controllers;
using UI.Models;

namespace UI.Repositories
{
    public static class ExerciseService
    {
        private static ExerciseController _controller;
        static ExerciseService()
        {
            var context = new ExerciseDbContext();
            ExerciseRepository repository = new ExerciseRepository(context);
            _controller = new ExerciseController(repository);
        }

        public async static Task ProcessCreateExcercise()
        {
            Exercise exercise = CreateExercise();
            await _controller.Insert(exercise);
        }

        private static Exercise CreateExercise()
        {
            Console.WriteLine("Please enter the start time (yyyy/MM/dd hh:mm format) : ");
            DateTime start = Helpers.GetDate();
            Console.WriteLine("Please enter the end time (yyyy/MM/dd hh:mm format) : ");
            DateTime end = Helpers.GetDate();
            Console.WriteLine("Enter the details about the workout:");
            string details = Helpers.GetString();

            return new Exercise() { startDate = start, endDate = end, Comments = details, Duration = end - start };
        }

        internal static async Task ProcessShowExercises()
        {
            await ShowExercises();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

        private static async Task ShowExercises()
        {
            var excercise = await _controller.GetAll();
            var sortedList = excercise.OrderBy(x => x.startDate).ToList();
            TableVisualization.ShowTable(sortedList);
        }

        internal static async Task ProcessUpdateExercise()
        {
            await ShowExercises();
            int id = Helpers.GetId("update.");
            var excercise = await _controller.GetAll();

            if (excercise.Any(x => x.Id == id))
            {
                Exercise exercise = CreateExercise();
                await UpdateExercise(exercise, id);
            }
            else
                Console.WriteLine("The selected id doesnt match any record. Press any key to go back.");

            Console.ReadKey();
        }

        private async static Task UpdateExercise(Exercise exercise, int id)
        {
            await _controller.Update(exercise, id);
            Console.WriteLine("Exercise updated without problems. Press any key to go back.");
        }

        internal async static Task ProcessDeleteExercise()
        {
            await ShowExercises();
            int id = Helpers.GetId("delete.");
            var excercise = await _controller.GetAll();

            if (excercise.Any(x => x.Id == id))
            {
                await _controller.Remove(id);
                Console.WriteLine("Record deleted sucesfully, press any key to go back.");
            }
            else
                Console.WriteLine("The selected id doesnt match any record. Press any key to go back.");

            Console.ReadKey();
        }
    }
}
