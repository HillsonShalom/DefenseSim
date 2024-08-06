using DefenseSim.Data;

namespace DefenseSim.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public CounterMeasureType MeasureType { get; set; }
        public int Count { get; set; }
    }
}
