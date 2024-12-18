﻿using BodegaVinos.Data.Entities;
using BodegaVinos.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace BodegaVinos.Data.Repository
{
    public class WineRepository : IWineRepository
    {
        private readonly BodegaDbContext _context;

        public WineRepository(BodegaDbContext context)
        {
            _context = context;
        }

        public List<Wine> GetWines()
        {
            return _context.Wines.ToList();
        }

        public void UpdateWine(Wine wine)
        {
            _context.Wines.Update(wine);
            _context.SaveChanges();
        }

        public void CreateWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
        }
        public Wine GetWineById(int id)
        {
            return _context.Wines.FirstOrDefault(w => w.Id == id);
        }
        public List<Wine> GetWinesByVariety(string variety)
        {
            return _context.Wines.Where(w => w.Variety == variety).ToList();
        }
    }
}





//Wines = new List<Wine>()
//            {
  //              new Wine { Id = 1, Name = "Vino 1", Variety = "Cabernet Sauvignon", Year = 2010, Region = "Mendoza", Stock = 10, CreatedAt = new DateTime(2021,01,01) },
    //            new Wine { Id = 2, Name = "Vino 2", Variety = "Malbec", Year = 2012, Region = "La Rioja", Stock = 20, CreatedAt = new DateTime(2022,02,02)},
      //          new Wine { Id = 3, Name = "Vino 3", Variety = "Merlot", Year = 2015, Region = "Mendoza", Stock = 30, CreatedAt = new DateTime(2023,03,03)},
        //        new Wine { Id = 4, Name = "Vino 4", Variety = "Syrah", Year = 2018, Region = "La Rioja", Stock = 40, CreatedAt = new DateTime(2024,04,04)},
          //  };