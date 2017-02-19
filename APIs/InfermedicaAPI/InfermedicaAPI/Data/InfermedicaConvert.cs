using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace InfermedicaAPI.Data
{
    public class InfermedicaConvert
    {
        private static readonly Dictionary<string, Prevalence> prevalenceList = new Dictionary<string, Prevalence>()
        {
            {"very_rare", Prevalence.VeryRare},
            {"rare", Prevalence.Rare},
            {"moderate", Prevalence.Moderate},
            {"common", Prevalence.Common}
        };
        private static readonly Dictionary<string, Acuteness> acutenessList = new Dictionary<string, Acuteness>()
        {
            {"chronic", Acuteness.Chronic},
            {"chronic_with_exacerbations", Acuteness.ChronicWithExacerbations},
            {"acute_potentially_chronic", Acuteness.AcutePotentiallyChronic},
            {"acute", Acuteness.Acute}
        };
        private static readonly Dictionary<string, Severity> severityList = new Dictionary<string, Severity>()
        {
            {"mild", Severity.Mild},
            {"moderate", Severity.Moderate},
            {"severe", Severity.Severe}
        };
        private static readonly Dictionary<string, Sex> sexList = new Dictionary<string, Sex>()
        {
            {"both", Sex.Both},
            {"male", Sex.Male},
            {"female", Sex.Female}
        };

        public static Prevalence ToPrevalence(string text)
        {
            return ConvertTo(text, prevalenceList);
        }
        public static Prevalence ToPrevalence(JToken text)
        {
            return text!=null ? ToPrevalence(Convert.ToString(text.Value<string>())) : Prevalence.NULL;
        }
        public static Acuteness ToAcuteness(string text)
        {
            return ConvertTo(text, acutenessList);
        }
        public static Acuteness ToAcuteness(JToken text)
        {
            return text != null ? ToAcuteness(Convert.ToString(text.Value<string>())) : Acuteness.NULL;
        }
        public static Severity ToSeverity(string text)
        {
            return ConvertTo(text, severityList);
        }
        public static Severity ToSeverity(JToken text)
        {
            return text != null ? ToSeverity(Convert.ToString(text.Value<string>())) : Severity.NULL;
        }
        public static Sex ToSex(string text)
        {
            return ConvertTo(text, sexList);
        }
        public static Sex ToSex(JToken text)
        {
            return ToSex(Convert.ToString(text));
        }

        public static T ConvertTo<T>(string text, Dictionary<string, T> allValues)
        {
            if (allValues.ContainsKey(text))
                return allValues[text];
            throw new ArgumentException(String.Format("Unexpected value ({0}) of {1}", text, typeof(T).Name));
        }
    }
}