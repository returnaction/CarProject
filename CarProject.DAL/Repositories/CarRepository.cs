using CarProject.DAL.Interfaces;
using CarProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public bool Create(Car car)
        {
            if (car is null)
                return false;

            _db.Cars.Add(car);
            _db.SaveChangesAsync();
            return true;
        }

        public bool Delete(Car entity)
        {
            if (entity is null)
            {
                return false;
            }

            _db.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public async Task<Car> Get(int id)
        {
            return await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _db.Cars.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Car>> Select()
        {
            return await  _db.Cars.ToListAsync();
        }
    }
}
