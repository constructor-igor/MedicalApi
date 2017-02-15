using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace InfermedicaAPI.Client.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInfoSample();
//            //FirstRequestDemo_HttpClient();
//            FirstRequestDemo_WebRequest();
//            //FirstRequestDemo_Info_WebRequest();
        }

        static void GetInfoSample()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(appId, appKey);
            InfermedicaInfo info = infermedica.GetInfo();
            Console.WriteLine("Last update model: {0}, Conditions count: {1}", info.LastModelUpdate, info.ConditionsCount);
        }

        // https://developer.infermedica.com/docs/quickstart
        /*
         * curl "https://api.infermedica.com/v2/diagnosis" \
            -X "POST" \
            -H "App-Id: XXXXXXXX" -H "App-Key: XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" \
            -H "Content-Type: application/json" -d '{
                "sex": "male",
                "age": 30,
                "evidence": [
                    {"id": "s_1193", "choice_id": "present"},
                    {"id": "s_488", "choice_id": "present"},
                    {"id": "s_418", "choice_id": "present"}
                ]
            }'
         * */
        
        // http://stackoverflow.com/questions/7929013/making-a-curl-call-in-c-sharp
        static async void FirstRequestDemo_HttpClient()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];

            StringBuilder textValue = new StringBuilder();
            textValue
                .Append("'{")
                .Append("\"sex\": \"male\",")
                .Append("\"age\": \"30\",")
                    .Append("\"evidence\": [")
                    .Append("{\"id\": \"s_1193\", \"choice_id\": \"present\"},")
                    .Append("{\"id\": \"s_488\", \"choice_id\": \"present\"},")
                    .Append("{\"id\": \"s_418\", \"choice_id\": \"present\"},")
                .Append("]")
                .Append("}'");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // Create the HttpContent for the form to be posted.
            var requestContent = new FormUrlEncodedContent(new[] 
                { new KeyValuePair<string, string>("text", textValue.ToString())}
            );
            List<string> contentTypeItems = requestContent.Headers.GetValues("Content-Type").ToList();
            requestContent.Headers.Remove("Content-Type");
            requestContent.Headers.Add("Content-Type", "application/json");

            requestContent.Headers.Add("App-Id", appId);
            requestContent.Headers.Add("App-Key", appKey);

            //HttpResponseMessage response = await client.PostAsync("https://api.infermedica.com/v2/diagnosis", requestContent);
            HttpResponseMessage response = client.PostAsync("https://api.infermedica.com/v2/diagnosis", requestContent).Result;
            response.EnsureSuccessStatusCode();

            // Get the response content.
            HttpContent responseContent = response.Content;
            Console.WriteLine("received response... ");

            // Get the stream of the content.
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                Console.WriteLine(await reader.ReadToEndAsync());
            }
        }

        // http://stackoverflow.com/questions/21255725/webrequest-equivalent-to-curl-command
        static void FirstRequestDemo_WebRequest()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];

            StringBuilder jsonData = new StringBuilder();
            jsonData
                .Append("{")
                    .Append("\"sex\": \"male\",")
                    .Append("\"age\": \"30\",")
                    .Append("\"evidence\": ")
                        .Append("[")
                            .Append("{\"id\": \"s_1193\", \"choice_id\": \"present\"},")
                            .Append("{\"id\": \"s_488\", \"choice_id\": \"present\"},")
                            .Append("{\"id\": \"s_418\", \"choice_id\": \"present\"}")
                        .Append("]")
                .Append("}");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.infermedica.com/v2/diagnosis");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("App-Id", appId); 
            httpWebRequest.Headers.Add("App-Key", appKey);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonData.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                HttpWebResponse resp = (HttpWebResponse)httpWebRequest.GetResponse();
                Console.WriteLine("status code: {0}", resp.StatusCode);
                string respStr = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                Console.WriteLine("Response : " + respStr); // if you want see the output
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void FirstRequestDemo_Info_WebRequest()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];

            StringBuilder jsonData = new StringBuilder();
            jsonData
                .Append("'{")
                .Append("}'");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.infermedica.com/v2/info");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("App-Id", appId);
            httpWebRequest.Headers.Add("App-Key", appKey);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //streamWriter.Write(jsonData.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                HttpWebResponse resp = (HttpWebResponse)httpWebRequest.GetResponse();
                Console.WriteLine("status code: {0}", resp.StatusCode);
                string respStr = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                Console.WriteLine("Response : " + respStr); // if you want see the output
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
