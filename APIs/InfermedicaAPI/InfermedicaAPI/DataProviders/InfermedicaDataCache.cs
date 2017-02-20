using System;
using System.IO;
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
        #endregion
    }
}