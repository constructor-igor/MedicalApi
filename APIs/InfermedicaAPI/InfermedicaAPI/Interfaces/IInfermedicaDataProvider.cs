namespace InfermedicaAPI.Interfaces
{
    public interface IInfermedicaDataProvider
    {
        string GetRequest(string mainName);
        string GetRequest(string mainName, string secondName);
    }
}