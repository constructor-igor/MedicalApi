namespace InfermedicaAPI.Data
{
    public class InfermedicaCondition
    {
        public readonly string Id;
        public readonly string Name;

        public InfermedicaCondition(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}