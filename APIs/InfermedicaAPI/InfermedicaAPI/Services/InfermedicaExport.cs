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
                List<string> body = new List<string>{condition.Id, condition.Name, String.Join(";", condition.Categories), 
                    condition.Prevalence.ToString(), condition.Acuteness.ToString(), condition.Severity.ToString(), condition.Sex.ToString()};
                body.AddRange(allExtraKeys.Select(extraKey => condition.Extras.ContainsKey(extraKey) ? condition.Extras[extraKey] : ""));
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
                List<string> body = new List<string>{labTest.Id, labTest.Name, labTest.Category, String.Join(",", labTest.ResultItems.Select(ri=>String.Format("id:{0}, type:{1}", ri.Id, ri.Type)))};
                string bodyLine = String.Join("\t", body.ToArray());
                File.AppendAllLines(targetCsvFile, new List<string> { bodyLine });
            }
        }

        public static void ToCsvFile(string targetCsvFile, IEnumerable<InfermedicaRiskFactor> riskFactors)
        {
            File.Delete(targetCsvFile);

            IEnumerable<string> allExtraKeys = riskFactors.SelectMany(condition => condition.Extras.Keys).Distinct();
            List<string> header = new List<string> { "Id", "Name", "Question", "Category", "Sex", "ImageUrl", "ImageSource" };
            header.AddRange(allExtraKeys);
            string headerLine = String.Join("\t", header.ToArray());
            File.AppendAllLines(targetCsvFile, new List<string> { headerLine });
            foreach (InfermedicaRiskFactor riskFactor in riskFactors)
            {
                List<string> body = new List<string> { riskFactor.Id, riskFactor.Name, riskFactor.Question, riskFactor.Category, riskFactor.Sex.ToString(), riskFactor.ImageUrl, riskFactor.ImageSource };
                body.AddRange(allExtraKeys.Select(extraKey => riskFactor.Extras.ContainsKey(extraKey) ? riskFactor.Extras[extraKey] : ""));
                string bodyLine = String.Join("\t", body.ToArray());
                File.AppendAllLines(targetCsvFile, new List<string> { bodyLine });
            }
        }

        public static void ToCsvFile(string targetCsvFile, List<InfermedicaSymptom> symptoms)
        {
            File.Delete(targetCsvFile);

            IEnumerable<string> allExtraKeys = symptoms.SelectMany(condition => condition.Extras.Keys).Distinct();
            List<string> header = new List<string> { "Id", "Name", "Question", "Category", "Sex", "ImageUrl", "ImageSource", "ParentID", "ParentRelation" };
            header.AddRange(allExtraKeys);
            string headerLine = String.Join("\t", header.ToArray());
            File.AppendAllLines(targetCsvFile, new List<string> { headerLine });
            foreach (InfermedicaSymptom symptom in symptoms)
            {
                List<string> body = new List<string> { symptom.Id, symptom.Name, symptom.Question, symptom.Category, symptom.Sex.ToString(), symptom.ImageUrl, symptom.ImageSource, symptom.ParentId, symptom.ParentRelation==ParentRelation.NULL?"":symptom.ParentRelation.ToString() };
                body.AddRange(allExtraKeys.Select(extraKey => symptom.Extras.ContainsKey(extraKey) ? symptom.Extras[extraKey] : ""));
                string bodyLine = String.Join("\t", body.ToArray());
                File.AppendAllLines(targetCsvFile, new List<string> { bodyLine });
            }
        }
    }
}