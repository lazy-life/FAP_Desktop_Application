using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP_Attendance.Managers.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetbyId(Guid id);
        Task Create(T entity);
        void Update(T entity);
        Task Delete(Guid id);
        Task Save();
    }
}
