using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using InfermedicaAPI.Data;
using InfermedicaAPI.DataProviders;
using InfermedicaAPI.Services;

namespace InfermedicaAPI.Client.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInfoSample();
            GetAllConditions();
            InfermedicaCondition condition = GetCondition("c_764");
            Console.WriteLine("get condition #{0} ({1})", condition.Id, condition.Name);
            GetAllLabTests();
            InfermedicaLabTest labTest = GetLabTest("lt_335");
            Console.WriteLine("get labTest #{0} ({1})", labTest.Id, labTest.Name);
            GetAllRiskFactors();
            InfermedicaRiskFactor riskFactor = GetRiskFactor("p_4");
            Console.WriteLine("get riskFactor #{0} ({1})", riskFactor.Id, riskFactor.Name);
            GetAllSymptoms();
            InfermedicaSymptom symptom = GetSymptom("s_277");
            Console.WriteLine("get symptom #{0} ({1})", symptom.Id, symptom.Name);

//            //FirstRequestDemo_HttpClient();
//            FirstRequestDemo_WebRequest();
//            //FirstRequestDemo_Info_WebRequest();
        }

        static void GetInfoSample()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            InfermedicaInfo info = infermedica.GetInfo();
            Console.WriteLine("Last update model: {0}, Conditions count: {1}", info.LastModelUpdate, info.ConditionsCount);
        }
        static void GetAllConditions()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            List<InfermedicaCondition> conditions = infermedica.GetConditions();
            Console.WriteLine("Conditions count: {0}", conditions.Count);
            InfermedicaExport.ToCsvFile(@"conditions.csv", conditions);
        }

        static InfermedicaCondition GetCondition(string conditionId)
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            InfermedicaCondition condition = infermedica.GetCondition(conditionId);
            return condition;
        }
        static void GetAllLabTests()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            List<InfermedicaLabTest> labTests = infermedica.GetLabTests();
            Console.WriteLine("Lab tests count: {0}", labTests.Count);
            InfermedicaExport.ToCsvFile(@"labTests.csv", labTests);
        }
        static InfermedicaLabTest GetLabTest(string labTestId)
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            InfermedicaLabTest labTest = infermedica.GetLabTest(labTestId);
            return labTest;
        }
        static void GetAllRiskFactors()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            List<InfermedicaRiskFactor> riskFactors = infermedica.GetRiskFactors();
            Console.WriteLine("Risk factors count: {0}", riskFactors.Count);
            InfermedicaExport.ToCsvFile(@"riskFactors.csv", riskFactors);
        }
        static InfermedicaRiskFactor GetRiskFactor(string riskFactorId)
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            InfermedicaRiskFactor riskFactor = infermedica.GetRiskFactor(riskFactorId);
            return riskFactor;
        }
        static void GetAllSymptoms()
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            List<InfermedicaSymptom> symptoms = infermedica.GetSymptoms();
            Console.WriteLine("Symptoms count: {0}", symptoms.Count);
            InfermedicaExport.ToCsvFile(@"symptoms.csv", symptoms);
        }
        static InfermedicaSymptom GetSymptom(string symptomId)
        {
            string appId = ConfigurationManager.AppSettings["App-Id"];
            string appKey = ConfigurationManager.AppSettings["App-Key"];
            Infermedica infermedica = new Infermedica(new InfermedicaDataCache(new InfermedicaDataProvider(appId, appKey), @"..\..\Cache"));
            InfermedicaSymptom symptom = infermedica.GetSymptom(symptomId);
            return symptom;
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
