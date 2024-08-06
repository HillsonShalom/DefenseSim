using DefenseSim.Models;

namespace DefenseSim.Data
{
    public class Seed
    {
        private readonly AppDbContext _context;
        public Seed(AppDbContext context)
        {
            _context = context;
        }

        public async Task Go()
        {
            // מכניס לטבלת הנשקים שלש שורות
            Weapon rocket = new()
            {
                Type = WeaponType.Rocket,
                Speed = 880,
                Range = 40,
                CounterMeasure = CounterMeasureType.InterceptorMissile
            };
            Weapon drone = new()
            {
                Type = WeaponType.Drone,
                Speed = 300,
                Range = 400,
                CounterMeasure = CounterMeasureType.ElectronicJamming
            };
            Weapon ballisticMissile = new()
            {
                Type = WeaponType.BallisticMissile,
                Speed = 18000,
                Range = 2000,
                CounterMeasure = CounterMeasureType.AntiAirSystem
            };
            _context.weapons.Add(rocket);
            _context.weapons.Add(drone);
            _context.weapons.Add(ballisticMissile);
            _context.SaveChanges();

            // מכניס קווארדינטות למספר מיקומים
            Location jerusalem = new Location
            {
                Name = "Jerusalem",
                Latitude = 31.7683,
                Longitude = 35.2137,
            };
            Location eilat = new Location
            {
                Name = "Eilat",
                Latitude = 29.5581,
                Longitude = 34.9482,
            };
            Location haifa = new Location
            {
                Name = "Haifa",
                Latitude = 32.7940,
                Longitude = 34.9896,
            };
            Location telAviv = new Location
            {
                Name = "TelAviv",
                Latitude = 32.0853,
                Longitude = 34.7818,
            };
            Location iran = new Location
            {
                Name = "Iran",
                Latitude = 35.6892,
                Longitude = 51.3890,
            };
            Location lebanon = new Location
            {
                Name = "Lebanon",
                Latitude = 33.8938,
                Longitude = 35.5018,
            };
            Location syria = new Location
            {
                Name = "Syria",
                Latitude = 33.5138,
                Longitude = 36.2765,
            };
            Location yemen = new Location
            {
                Name = "Yemen",
                Latitude = 15.3694,
                Longitude = 44.1910,
            };
            Location gaza = new Location
            {
                Name = "Gaza",
                Latitude = 31.5017,
                Longitude = 34.4668,
            };
            _context.locations.Add(jerusalem);
            _context.locations.Add(eilat);
            _context.locations.Add(haifa);
            _context.locations.Add(telAviv);
            _context.locations.Add(iran);
            _context.locations.Add(lebanon);
            _context.locations.Add(syria);
            _context.locations.Add(yemen);
            _context.locations.Add(gaza);
            _context.SaveChanges();

        }
    }
}
