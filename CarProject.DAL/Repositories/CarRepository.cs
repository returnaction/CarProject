using CarProject.DAL.Interfaces;
using CarProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<Car> Get(int id)
        {
            return await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Car GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> Select()
        {
            return await  _db.Cars.ToListAsync();
        }
    }
}
