using Microsoft.EntityFrameworkCore;
using Sales.API.Helpers;
using Sales.API.Services;
using Sales.Shared.Entites;
using Sales.Shared.Enums;
using Sales.Shared.Responses;

namespace Sales.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IApiService apiService, IUserHelper userHelper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Andres", "Velez", "avelez@yopmail.com", "3145777162", "Calle luna Carrera Sol", UserType.Admin);
        }
        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "Accesorios" });
                _context.Categories.Add(new Category { Name = "Televisores" });
                _context.Categories.Add(new Category { Name = "Mercado" });
                _context.Categories.Add(new Category { Name = "Celulares" });
                _context.Categories.Add(new Category { Name = "Computadores" });
                _context.Categories.Add(new Category { Name = "Lavadoras" });
                _context.Categories.Add(new Category { Name = "Colchones" });
                _context.Categories.Add(new Category { Name = "Horno" });
                _context.Categories.Add(new Category { Name = "Gimnasio" });
                _context.Categories.Add(new Category { Name = "Juguetes" });
                _context.Categories.Add(new Category { Name = "Licores" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Consolas" });
                _context.Categories.Add(new Category { Name = "Comedores" });
                _context.Categories.Add(new Category { Name = "Escritorios" });
                _context.Categories.Add(new Category { Name = "Accesorios de Baño" });
                _context.Categories.Add(new Category { Name = "Accesorios de Cocina" });
                _context.Categories.Add(new Category { Name = "Moda para mujeres" });
                _context.Categories.Add(new Category { Name = "Moda para hombres" });
                _context.Categories.Add(new Category { Name = "Moda para niños" });
                _context.Categories.Add(new Category { Name = "Ropa de bebé" });
                _context.Categories.Add(new Category { Name = "Ropa de maternidad" });
                _context.Categories.Add(new Category { Name = "Zapatos para mujeres" });
                _context.Categories.Add(new Category { Name = "Zapatos para hombres" });
                _context.Categories.Add(new Category { Name = "Zapatos para niños" });
                _context.Categories.Add(new Category { Name = "Joyería" });
                _context.Categories.Add(new Category { Name = "Relojes" });
                _context.Categories.Add(new Category { Name = "Accesorios para cabello" });
                _context.Categories.Add(new Category { Name = "Bolsos y carteras" });
                _context.Categories.Add(new Category { Name = "Lentes de sol" });
                _context.Categories.Add(new Category { Name = "Ropa de baño para mujeres" });
                _context.Categories.Add(new Category { Name = "Ropa de baño para hombres" });
                _context.Categories.Add(new Category { Name = "Ropa deportiva para mujeres" });
                _context.Categories.Add(new Category { Name = "Ropa deportiva para hombres" });
                _context.Categories.Add(new Category { Name = "Ropa deportiva para niños" });
                _context.Categories.Add(new Category { Name = "Ropa interior para mujeres" });
                _context.Categories.Add(new Category { Name = "Ropa interior para hombres" });
                _context.Categories.Add(new Category { Name = "Ropa interior para niños" });
                _context.Categories.Add(new Category { Name = "Trajes de baño para niños" });
                _context.Categories.Add(new Category { Name = "Ropa de dormir para mujeres" });
                _context.Categories.Add(new Category { Name = "Ropa de dormir para hombres" });
                _context.Categories.Add(new Category { Name = "Ropa de dormir para niños" });
                _context.Categories.Add(new Category { Name = "Trajes de noche para mujeres" });
                _context.Categories.Add(new Category { Name = "Trajes de noche para hombres" });
                _context.Categories.Add(new Category { Name = "Vestidos para mujeres" });
                _context.Categories.Add(new Category { Name = "Trajes para hombres" });
                _context.Categories.Add(new Category { Name = "Trajes para mujeres" });
                _context.Categories.Add(new Category { Name = "Trajes para niños" });
                _context.Categories.Add(new Category { Name = "Vestidos para niñas" });
                _context.Categories.Add(new Category { Name = "Pantalones para mujeres" });
                _context.Categories.Add(new Category { Name = "Pantalones para hombres" });
                _context.Categories.Add(new Category { Name = "Pantalones para niños" });
                _context.Categories.Add(new Category { Name = "Faldas para mujeres" });
                _context.Categories.Add(new Category { Name = "Faldas para niñas" });
                _context.Categories.Add(new Category { Name = "Camisas para mujeres" });
                _context.Categories.Add(new Category { Name = "Camisas para hombres" });
                _context.Categories.Add(new Category { Name = "Camisas para niños" });
                _context.Categories.Add(new Category { Name = "Sudaderas con capucha para mujeres" });
                _context.Categories.Add(new Category { Name = "Sudaderas con capucha para hombres" });
                _context.Categories.Add(new Category { Name = "Sudaderas con capucha para niños" });
                _context.Categories.Add(new Category { Name = "Chaquetas para mujeres" });
                _context.Categories.Add(new Category { Name = "Chaquetas para hombres" });
                _context.Categories.Add(new Category { Name = "Chaquetas para niños" });
                _context.Categories.Add(new Category { Name = "Abrigos para mujeres" });
                _context.Categories.Add(new Category { Name = "Abrigos para hombres" });
                _context.Categories.Add(new Category { Name = "Abrigos para niños" });
                _context.Categories.Add(new Category { Name = "Calcetines para mujeres" });
                _context.Categories.Add(new Category { Name = "Calcetines para hombres" });
                _context.Categories.Add(new Category { Name = "Calcetines para niños" });
                _context.Categories.Add(new Category { Name = "Ropa de tallas grandes para mujeres" });
                _context.Categories.Add(new Category { Name = "Ropa de tallas grandes para hombres" });
                _context.Categories.Add(new Category { Name = "Ropa de tallas grandes para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para personas con discapacidad" });
                _context.Categories.Add(new Category { Name = "Trajes de baño para personas con discapacidad" });
                _context.Categories.Add(new Category { Name = "Ropa de seguridad para trabajadores" });
                _context.Categories.Add(new Category { Name = "Ropa para actividades al aire libre" });
                _context.Categories.Add(new Category { Name = "Ropa para deportes de invierno" });
                _context.Categories.Add(new Category { Name = "Ropa para deportes acuáticos" });
                _context.Categories.Add(new Category { Name = "Ropa para correr" });
                _context.Categories.Add(new Category { Name = "Ropa para yoga" });
                _context.Categories.Add(new Category { Name = "Ropa para ciclismo" });
                _context.Categories.Add(new Category { Name = "Ropa para escalada" });
                _context.Categories.Add(new Category { Name = "Ropa para pesca" });
                _context.Categories.Add(new Category { Name = "Ropa para caza" });
                _context.Categories.Add(new Category { Name = "Ropa para golf" });
                _context.Categories.Add(new Category { Name = "Ropa para tenis" });
                _context.Categories.Add(new Category { Name = "Ropa para natación" });
                _context.Categories.Add(new Category { Name = "Ropa para esquí" });
                _context.Categories.Add(new Category { Name = "Ropa para snowboard" });
                _context.Categories.Add(new Category { Name = "Ropa para patinaje" });
                _context.Categories.Add(new Category { Name = "Ropa para skateboarding" });
                _context.Categories.Add(new Category { Name = "Ropa para deportes de equipo" });
                _context.Categories.Add(new Category { Name = "Ropa para actividades al aire libre para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para deportes de invierno para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para deportes acuáticos para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para correr para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para yoga para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para ciclismo para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para escalada para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para pesca para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para caza para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para golf para niños" });
                _context.Categories.Add(new Category { Name = "Ropa para tenis para niños" });
                _context.Categories.Add(new Category { Name = "Electrónica" });
                _context.Categories.Add(new Category { Name = "Computadoras y accesorios" });
                _context.Categories.Add(new Category { Name = "Teléfonos móviles y accesorios" });
                _context.Categories.Add(new Category { Name = "Hogar y jardín" });
                _context.Categories.Add(new Category { Name = "Ropa y accesorios de moda" });
                _context.Categories.Add(new Category { Name = "Zapatos y accesorios" });
                _context.Categories.Add(new Category { Name = "Joyería y relojes" });
                _context.Categories.Add(new Category { Name = "Salud y belleza" });
                _context.Categories.Add(new Category { Name = "Juguetes y juegos" });
                _context.Categories.Add(new Category { Name = "Automóviles y motocicletas" });
                _context.Categories.Add(new Category { Name = "Deportes y entretenimiento" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "Alimentos y bebidas" });
                _context.Categories.Add(new Category { Name = "Arte y artesanía" });
                _context.Categories.Add(new Category { Name = "Muebles y decoración del hogar" });
                _context.Categories.Add(new Category { Name = "Libros y revistas" });
                _context.Categories.Add(new Category { Name = "Instrumentos musicales" });
                _context.Categories.Add(new Category { Name = "Cámaras y fotografía" });
                _context.Categories.Add(new Category { Name = "Equipos de oficina" });
                _context.Categories.Add(new Category { Name = "Suministros de oficina" });
                _context.Categories.Add(new Category { Name = "Cuidado personal y productos de higiene" });
                _context.Categories.Add(new Category { Name = "Suministros de limpieza y mantenimiento del hogar" });
                _context.Categories.Add(new Category { Name = "Suministros médicos" });
                _context.Categories.Add(new Category { Name = "Suministros de arte y dibujo" });
                _context.Categories.Add(new Category { Name = "Suministros de manualidades" });
                _context.Categories.Add(new Category { Name = "Suministros para fiestas y eventos" });
                _context.Categories.Add(new Category { Name = "Suministros para mascotas" });
                _context.Categories.Add(new Category { Name = "Suministros para acuarios y terrarios" });
                _context.Categories.Add(new Category { Name = "Suministros para jardinería" });
                _context.Categories.Add(new Category { Name = "Suministros para bricolaje" });
                _context.Categories.Add(new Category { Name = "Suministros para impresoras y cartuchos de tinta" });
                _context.Categories.Add(new Category { Name = "Suministros para muebles y reparación del hogar" });
                _context.Categories.Add(new Category { Name = "Suministros para construcción y herramientas" });
                _context.Categories.Add(new Category { Name = "Suministros para iluminación y electricidad" });
                _context.Categories.Add(new Category { Name = "Suministros para baño y cocina" });
                _context.Categories.Add(new Category { Name = "Suministros para camping y senderismo" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes acuáticos" });
                _context.Categories.Add(new Category { Name = "Suministros para pesca" });
                _context.Categories.Add(new Category { Name = "Suministros para caza" });
                _context.Categories.Add(new Category { Name = "Suministros para equitación" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes de nieve" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes de invierno" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes de raqueta" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes de pelota" });
                _context.Categories.Add(new Category { Name = "Suministros para artes marciales" });
                _context.Categories.Add(new Category { Name = "Suministros para gimnasia y entrenamiento" });
                _context.Categories.Add(new Category { Name = "Suministros para yoga y pilates" });
                _context.Categories.Add(new Category { Name = "Suministros para fitness y musculación" });
                _context.Categories.Add(new Category { Name = "Suministros para carreras y maratones" });
                _context.Categories.Add(new Category { Name = "Suministros para golf" });
                _context.Categories.Add(new Category { Name = "Suministros para ciclismo" });
                _context.Categories.Add(new Category { Name = "Suministros para patinaje" });
                _context.Categories.Add(new Category { Name = "Suministros para skateboarding" });
                _context.Categories.Add(new Category { Name = "Suministros para surf y bodyboard" });
                _context.Categories.Add(new Category { Name = "Suministros para windsurf y kitesurf" });
                _context.Categories.Add(new Category { Name = "Suministros para buceo y submarinismo" });
                _context.Categories.Add(new Category { Name = "Suministros para esquí acuático y wakeboarding" });
                _context.Categories.Add(new Category { Name = "Suministros para parapente y ala delta" });
                _context.Categories.Add(new Category { Name = "Suministros para vuelo libre y paracaidismo" });
                _context.Categories.Add(new Category { Name = "Suministros para escalada y senderismo en montaña" });
                _context.Categories.Add(new Category { Name = "Suministros para camping y actividades al aire libre" });
                _context.Categories.Add(new Category { Name = "Suministros para equipos y uniformes deportivos" });
                _context.Categories.Add(new Category { Name = "Suministros para entrenamiento de fuerza y resistencia" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes de contacto" });
                _context.Categories.Add(new Category { Name = "Suministros para entrenamiento de artes marciales" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes de precisión" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes de tiro" });
                _context.Categories.Add(new Category { Name = "Suministros para deportes acuáticos de velocidad" });


                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                Response responseCountries = await _apiService.GetListAsync<CountryResponse>("/v1", "/countries");
                if (responseCountries.IsSuccess)
                {
                    List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result!;
                    foreach (CountryResponse countryResponse in countries)
                    {
                        Country country = await _context.Countries!.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                        if (country == null)
                        {
                            country = new() { Name = countryResponse.Name!, States = new List<State>() };
                            Response responseStates = await _apiService.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                            if (responseStates.IsSuccess)
                            {
                                List<StateResponse> states = (List<StateResponse>)responseStates.Result!;
                                foreach (StateResponse stateResponse in states!)
                                {
                                    State state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                    if (state == null)
                                    {
                                        state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                        Response responseCities = await _apiService.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                        if (responseCities.IsSuccess)
                                        {
                                            List<CityResponse> cities = (List<CityResponse>)responseCities.Result!;
                                            foreach (CityResponse cityResponse in cities)
                                            {
                                                if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                {
                                                    continue;
                                                }
                                                City city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                                if (city == null)
                                                {
                                                    state.Cities.Add(new City() { Name = cityResponse.Name! });
                                                }
                                            }
                                        }
                                        if (state.CitiesNumber > 0)
                                        {
                                            country.States.Add(state);
                                        }
                                    }
                                }
                            }
                            if (country.StatesNumber > 0)
                            {
                                _context.Countries.Add(country);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
        }
    }
}
