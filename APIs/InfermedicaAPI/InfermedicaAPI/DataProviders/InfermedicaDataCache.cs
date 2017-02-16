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
        public string GetRequest(string getName)
        {
            string infoFile = Path.Combine(m_cacheFolder, String.Format("{0}.json", getName));
            if (File.Exists(infoFile))
                return File.ReadAllText(infoFile);
            string infoContent = m_actualProvider.GetRequest(getName);
            File.WriteAllText(infoFile, infoContent);
            return infoContent;
        }
        #endregion
    }
}