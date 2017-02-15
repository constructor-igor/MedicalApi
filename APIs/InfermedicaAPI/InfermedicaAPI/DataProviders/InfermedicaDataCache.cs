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
        public string GetInfo()
        {
            string infoFile = Path.Combine(m_cacheFolder, "info.json");
            if (File.Exists(infoFile))
                return File.ReadAllText(infoFile);
            string infoContent = m_actualProvider.GetInfo();
            File.WriteAllText(infoFile, infoContent);
            return infoContent;
        }
        #endregion
    }
}