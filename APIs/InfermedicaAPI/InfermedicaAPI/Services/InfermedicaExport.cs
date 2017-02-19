using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InfermedicaAPI.Data;

namespace InfermedicaAPI.Services
{
    public class InfermedicaExport
    {
        public static void ToCsvFile(string targetCsvFile, IEnumerable<InfermedicaCondition> conditions)
        {
            File.Delete(targetCsvFile);

            IEnumerable<string> allExtraKeys = conditions.SelectMany(condition => condition.Extras.Keys).Distinct();
            List<string> header = new List<string>{ "Id", "Name", "Categories", "Prevalence", "Acuteness", "Severity", "Sex" };
            header.AddRange(allExtraKeys);

            string headerLine = String.Join("\t", header.ToArray());
            File.AppendAllLines(targetCsvFile, new List<string>{headerLine});
            foreach (InfermedicaCondition condition in conditions)
            {
                List<string> body = new List<string>(){condition.Id, condition.Name, String.Join(";", condition.Categories), 
                    condition.Prevalence.ToString(), condition.Acuteness.ToString(), condition.Severity.ToString(), condition.Sex.ToString()};
                body.AddRange(allExtraKeys.Select(extraKey =>
                {
                    string keyValue = condition.Extras.ContainsKey(extraKey) ? condition.Extras[extraKey] : "";
                    return keyValue;
                }));
                string bodyLine = String.Join("\t", body.ToArray());
                File.AppendAllLines(targetCsvFile, new List<string>{bodyLine});
            }
        }

        public static void ToCsvFile(string targetCsvFile, IEnumerable<InfermedicaLabTest> labTests)
        {
            File.Delete(targetCsvFile);

            List<string> header = new List<string> { "Id", "Name", "Category", "ResultItems" };
            string headerLine = String.Join("\t", header.ToArray());
            File.AppendAllLines(targetCsvFile, new List<string> { headerLine });
            foreach (InfermedicaLabTest labTest in labTests)
            {
                List<string> body = new List<string>(){labTest.Id, labTest.Name, labTest.Category, String.Join(",", labTest.ResultItems.Select(ri=>String.Format("id:{0}, type:{1}", ri.Id, ri.Type)))};
                string bodyLine = String.Join("\t", body.ToArray());
                File.AppendAllLines(targetCsvFile, new List<string> { bodyLine });
            }
        }
    }
}