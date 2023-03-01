using Sales.Shared.Entites;

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
                _contex.Countries.Add(new Country 
                {
                    Name = "Colombia", 
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Medellín"},
                                new City() { Name = "Itagui"},
                                new City() { Name = "Envigado"},
                                new City() { Name = "Bello"},
                                new City() { Name = "Rionegro"},
                            }
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities= new List<City>()
                            {
                                new City() { Name = "Usaquen" },
                                new City() { Name = "Chapinero" },
                                new City() { Name = "Santa fe" },
                                new City() { Name = "Usme" },
                                new City() { Name = "Bosa" },
                            }
                        },
                    }

                });

                _contex.Countries.Add(new Country 
                { 
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Orlando"},
                                new City() { Name = "Miami"},
                                new City() { Name = "Tampa"},
                                new City() { Name = "Fort Lauderdale"},
                                new City() { Name = "Key West"},
                            }
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities= new List<City>()
                            {
                                new City() { Name = "Houston"},
                                new City() { Name = "San Antonio"},
                                new City() { Name = "Dallas"},
                                new City() { Name = "Austin"},
                                new City() { Name = "El paso"},
                            }
                        },
                    }
                
                });
                _contex.Countries.Add(new Country 
                { 
                    Name = "México",
                    States= new List<State>()
                    {
                        new State() { Name = "Ciudad de México"},
                        new State() { Name = "Chihuahua"},
                        new State() { Name = "Monterrey"},
                        new State() { Name = "Cancun"},
                    },
                
                });


                await _contex.SaveChangesAsync();
            }
        }
        private async Task CheckCategoriesAsync()
        {
            if (!_contex.Categories.Any())
            {
                _contex.Categories.Add(new Category { Name = "Ropa" });
                _contex.Categories.Add(new Category { Name = "Accesorios" });
                _contex.Categories.Add(new Category { Name = "Electrodomesticos" });
                await _contex.SaveChangesAsync();
            }
        }
    }
}
