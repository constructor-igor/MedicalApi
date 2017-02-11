namespace ApiMedic.DataTypes
{
    public class Issue
    {
        public readonly int ID;
        public readonly string Name;

        public Issue(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}