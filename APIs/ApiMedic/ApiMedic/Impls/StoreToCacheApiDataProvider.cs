using System.IO;
using ApiMedic.Interfaces;

namespace ApiMedic.Impls
{
    public class StoreToCacheApiDataProvider : IMedicalApiDataProvider
    {
        private readonly IMedicalApiDataProvider m_actualProvider;

        public StoreToCacheApiDataProvider(IMedicalApiDataProvider actualProvider)
        {
            m_actualProvider = actualProvider;
            Directory.CreateDirectory(@"..\..\cache");
        }
        #region IMedicalApiDataProvider
        public string GetSymptoms()
        {
            string symptomsResponse = m_actualProvider.GetSymptoms();
            File.WriteAllText(@"..\..\cache\symptomsResponse.json", symptomsResponse);
            return symptomsResponse;            
        }
        public string GetIssues()
        {
            string issuesResponse = m_actualProvider.GetIssues();
            File.WriteAllText(@"..\..\cache\issuesResponse.json", issuesResponse);
            return issuesResponse;
        }
        #endregion
    }
}