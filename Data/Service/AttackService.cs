namespace DefenseSim.Data.Service
{
    public class AttackService : IAttackService
    {
        private readonly AttackDbContext _context;
        public AttackService(AttackDbContext context)
        {
            _context = context;
        }

        public string[] GetLocationsName()
        {
            return _context.locations.Select(x => x.Name).ToArray();
        }
    }
}
