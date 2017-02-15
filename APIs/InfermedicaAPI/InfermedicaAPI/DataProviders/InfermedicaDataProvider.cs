using System.IO;
using System.Net;
using InfermedicaAPI.Interfaces;

namespace InfermedicaAPI.DataProviders
{
    public class InfermedicaDataProvider: IInfermedicaDataProvider
    {
        private readonly string m_appId;
        private readonly string m_appKey;

        public InfermedicaDataProvider(string appId, string appKey)
        {
            m_appId = appId;
            m_appKey = appKey;
        }
        #region IInfermedicaDataProvider
        public string GetInfo()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.infermedica.com/v2/info");
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("App-Id", m_appId);
            httpWebRequest.Headers.Add("App-Key", m_appKey);

            string responseContent = GetResponse(httpWebRequest);
            return responseContent;            
        }
        #endregion
        private string GetResponse(HttpWebRequest httpWebRequest)
        {
            using (WebResponse response = httpWebRequest.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    string responseContent = streamReader.ReadToEnd();
                    return responseContent;
                }
            }
        }
    }
}