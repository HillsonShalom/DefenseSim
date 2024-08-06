using DefenseSim.Data;

namespace DefenseSim.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public WeaponType Type { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public CounterMeasureType CounterMeasure { get; set; }
    }
}
