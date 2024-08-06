namespace DefenseSim.Models
{
    public class Threat
    {
        public int Id { get; set; }
        public Location Origin { get; set; }
        public int OriginId { get; set; }
        public Location Destination { get; set; }
        public int DestinationId { get; set; }
        public DateTime LaunchTime { get; set; } = DateTime.Now;
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public int? ResponseId { get; set; }
        public Response? Response { get; set; }
    }
}
