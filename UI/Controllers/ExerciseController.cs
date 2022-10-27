using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using UI.Repositories;

namespace UI.Controllers
{
    public class ExerciseController
    {
        IRepository<Exercise,int> _repository;

        public ExerciseController(IRepository<Exercise,int> repository)
        {
            _repository = repository;
        }

        public async Task Insert(Exercise exercise)
        {
            await _repository.Insert(exercise);
            await _repository.Save();
        } 

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Update(Exercise exercise, int id)
        {
            await _repository.Update(exercise,id);
            await _repository.Save();
        }

        public async Task Remove(int id)
        {
            await _repository.Remove(id);
            await _repository.Save();
        }
    }
}
