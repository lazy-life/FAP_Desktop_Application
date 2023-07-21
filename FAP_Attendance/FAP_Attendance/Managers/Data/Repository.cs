using FAP_Attendance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Managers.Data
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {

        private readonly FapContext _context;
        private readonly DbSet<T> _entities;

        public Repository()
        {
        }

        public Repository(FapContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            T existing = await _entities.FindAsync(id);
            _entities.Remove(existing);
        }

        public IEnumerable<T> GetAll() => _entities.ToList();

        public async Task<T> GetbyId(Guid id) => await _entities.FindAsync(id);

        public async Task Save() => await _context.SaveChangesAsync();

        public async void Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
