using DefenseSim.Data;

namespace DefenseSim.ModelsDefense
{
    public class Inventory
    {
        public int Id { get; set; }
        public CounterMeasureType MeasureType { get; set; }
        public int Count { get; set; }
    }
}
