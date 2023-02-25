﻿using Sales.Shared.Entites;

namespace Sales.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _contex;

        public SeedDb(DataContext contex)
        {
            _contex = contex;
        }

        public async Task SeedAsync()
        {
            await _contex.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_contex.Countries.Any())
            {
                _contex.Countries.Add(new Country { Name = "Colombia" });
                _contex.Countries.Add(new Country { Name = "Peú" });
                _contex.Countries.Add(new Country { Name = "México" });
                await _contex.SaveChangesAsync();
            }
        }
        private async Task CheckCategoriesAsync()
        {
            if (!_contex.Countries.Any())
            {
                _contex.Countries.Add(new Country { Name = "Ropa" });
                _contex.Countries.Add(new Country { Name = "Accesorios" });
                _contex.Countries.Add(new Country { Name = "Electrodomesticos" });
                await _contex.SaveChangesAsync();
            }
        }
    }
}