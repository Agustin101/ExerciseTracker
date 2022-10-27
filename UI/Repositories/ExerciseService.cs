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

        internal static Task UpdateExercise()
        {
            throw new NotImplementedException();
        }
    }
}
