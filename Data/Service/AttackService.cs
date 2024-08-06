namespace DefenseSim.Data.Service
{
    public class AttackService : IAttackService
    {
        private readonly AppDbContext _context;
        public AttackService(AppDbContext context)
        {
            _context = context;
        }

        public string[] GetLocationsName()
        {
            return _context.locations.Select(x => x.Name).ToArray();
        }
    }
}
