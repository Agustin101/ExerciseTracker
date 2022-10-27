using UI.Models;
using UI.Repositories;

namespace UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UserInput userInput = new();
            await userInput.GetInput();
        }
    }
}