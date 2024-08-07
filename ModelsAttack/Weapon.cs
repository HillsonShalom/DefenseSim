using DefenseSim.Data;

namespace DefenseSim.ModelsAttack
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
