namespace DefenseSim.Data.Service
{
    public class DefenseService : IDefenseService
    {
        private readonly AttackDbContext _context;
        public DefenseService(AttackDbContext context)
        {
            _context = context;
        }
    }
}
