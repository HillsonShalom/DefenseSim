namespace DefenseSim.Data.Service
{
    public class DefenseService : IDefenseService
    {
        private readonly AppDbContext _context;
        public DefenseService(AppDbContext context)
        {
            _context = context;
        }
    }
}
