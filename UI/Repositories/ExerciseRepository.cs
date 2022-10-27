using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Repositories
{
    public class ExerciseRepository : IRepository<Exercise, int>
    {
        private ExerciseDbContext _context;

        public ExerciseRepository(ExerciseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetById(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise> Insert(Exercise entity)
        {
            await _context.Exercises.AddAsync(entity);
            return entity;
        }

        public async Task Remove(int id)
        {
            var ex = await _context.Exercises.FirstOrDefaultAsync(ex => ex.Id == id);
            if(ex is not null)
            {
                _context.Remove(ex);
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Exercise> Update(Exercise entity, int id)
        {
            var ex = await _context.Exercises.FirstOrDefaultAsync(ex => ex.Id == id);
            if(ex is not null)
            {
                ex.endDate = entity.endDate;
                ex.startDate = entity.startDate;
                ex.Duration = entity.Duration;
                ex.Comments = entity.Comments;
                _context.Update(ex);
            }

            return ex;
        }
    }
}
