using UI.Models;
using UI.Repositories;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ExerciseDbContext();
            ExerciseRepository repository = new ExerciseRepository(context);

            UserInput userInput = new();
            userInput.GetInput();

        }
    }
}