using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InfermedicaAPI.Interfaces;

namespace InfermedicaAPI.DataProviders
{
    public class InfermedicaDataCache : IInfermedicaDataProvider
    {
        private readonly string m_cacheFolder;
        private readonly IInfermedicaDataProvider m_actualProvider;

        public InfermedicaDataCache(IInfermedicaDataProvider actualProvider, string cacheRootFolder)
        {
            m_actualProvider = actualProvider;
            m_cacheFolder = cacheRootFolder;
            Directory.CreateDirectory(m_cacheFolder);
        }
        #region IInfermedicaDataProvider
        public string GetRequest(string mainName)
        {
            string infoFile = Path.Combine(m_cacheFolder, String.Format("{0}.json", mainName));
            if (File.Exists(infoFile))
                return File.ReadAllText(infoFile);
            string infoContent = m_actualProvider.GetRequest(mainName);
            File.WriteAllText(infoFile, infoContent);
            return infoContent;
        }
        public string GetRequest(string mainName, string secondName)
        {
            string infoFile = Path.Combine(m_cacheFolder, String.Format("{0}-{1}.json", mainName, secondName));
            if (File.Exists(infoFile))
                return File.ReadAllText(infoFile);
            string infoContent = m_actualProvider.GetRequest(mainName, secondName);
            File.WriteAllText(infoFile, infoContent);
            return infoContent;
        }
        public string GetRequest(string mainName, Dictionary<string, string> arguments)
        {
            string argumentsContainer = String.Join("&", arguments.Select(a => String.Format("{0}={1}", a.Key, a.Value)));
            string infoFile = Path.Combine(m_cacheFolder, String.Format("{0}-{1}.json", mainName, argumentsContainer));
            if (File.Exists(infoFile))
                return File.ReadAllText(infoFile);
            string infoContent = m_actualProvider.GetRequest(mainName, arguments);
            File.WriteAllText(infoFile, infoContent);
            return infoContent;
        }
        #endregion
    }
}