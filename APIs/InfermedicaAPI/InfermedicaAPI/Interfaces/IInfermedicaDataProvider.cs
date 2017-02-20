using System.Collections.Generic;

namespace InfermedicaAPI.Interfaces
{
    public interface IInfermedicaDataProvider
    {
        string GetRequest(string mainName);
        string GetRequest(string mainName, string secondName);
        string GetRequest(string mainName, Dictionary<string, string> arguments);
    }
}