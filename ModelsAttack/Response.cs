using DefenseSim.Data;

namespace DefenseSim.ModelsAttack
{
    public class Response
    {
        public int Id { get; set; }
        public DateTime LaunchTime { get; set; } = DateTime.Now;
        public DateTime? InterceptTime { get; set; }
        public CounterMeasureType ResponseType { get; set; }
        public ResponseStatus status { get; set; }
    }
}
