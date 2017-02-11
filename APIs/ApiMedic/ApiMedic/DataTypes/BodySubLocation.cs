namespace ApiMedic.DataTypes
{
    public class BodySubLocation
    {
        public readonly int ID;
        public readonly string Name;

        public BodySubLocation(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}