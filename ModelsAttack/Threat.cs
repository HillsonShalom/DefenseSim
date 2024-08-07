namespace DefenseSim.ModelsAttack
{
    public class Threat
    {
        public int Id { get; set; }
        public Location Origin { get; set; }
        public int OriginId { get; set; }
        public Location Destination { get; set; }
        public int DestinationId { get; set; }
        public DateTime? LaunchTime { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public int BarrageSize { get; set; } = 1;
        public int BarrageCount { get; set; } = 1;
        public int BarrageDelay { get; set; } = 0;
        public bool IsActive { get; set; } = false;

        public int? ResponseId { get; set; }
        public Response? Response { get; set; }
    }
}
