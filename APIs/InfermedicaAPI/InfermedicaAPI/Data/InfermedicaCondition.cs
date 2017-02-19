using System.Collections.Generic;

namespace InfermedicaAPI.Data
{
    public enum Prevalence { NULL, VeryRare, Rare, Moderate, Common}
    public enum Acuteness { NULL, Chronic, ChronicWithExacerbations, AcutePotentiallyChronic, Acute }
    public enum Severity { NULL, Mild, Moderate, Severe }
    public enum Sex { Both, Male, Female }

    public class InfermedicaCondition
    {
        public readonly string Id;
        public readonly string Name;
        public readonly List<string> Categories;
        public readonly Prevalence Prevalence;
        public readonly Acuteness Acuteness;
        public readonly Severity Severity;
        public readonly Sex Sex;
        public readonly Dictionary<string, string> Extras;

        public InfermedicaCondition(string id, string name, List<string> categories, Prevalence prevalence, Acuteness acuteness, Severity severity, Sex sex, Dictionary<string, string> extras)
        {
            Id = id;
            Name = name;
            Categories = categories;
            Prevalence = prevalence;
            Acuteness = acuteness;
            Severity = severity;
            Sex = sex;
            Extras = extras;
        }
    }
}