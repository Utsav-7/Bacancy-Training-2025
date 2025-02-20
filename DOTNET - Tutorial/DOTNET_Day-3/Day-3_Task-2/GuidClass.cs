namespace Day_3_Task_2
{
    public interface IGuid1
    {
        Guid GetGuid();
    }

    public interface IGuid2
    {
        Guid GetGuid();
    }

    public interface IGuid3
    {
        Guid GetGuid();
    }

    public class GuidClass : IGuid1, IGuid2, IGuid3
    {

        private readonly Guid _guid;
        public GuidClass()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
