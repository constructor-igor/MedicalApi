using System.Collections.Generic;

namespace ApiMedic.DataTypes
{
    public class IssueInfo
    {
        public readonly string Description;
        public readonly string DescriptionShort;
        public readonly string MedicalCondition;
        public readonly string Name;
        public readonly List<string> PossibleSymptoms;
        public readonly string ProfName;
        public readonly string Synonyms;
        public readonly string TreatmentDescription;

        public IssueInfo(string description, string descriptionShort, string medicalCondition, string name, List<string> possibleSymptoms, string profName, string synonyms, string treatmentDescription)
        {
            Description = description;
            DescriptionShort = descriptionShort;
            MedicalCondition = medicalCondition;
            Name = name;
            PossibleSymptoms = possibleSymptoms;
            ProfName = profName;
            Synonyms = synonyms;
            TreatmentDescription = treatmentDescription;
        }
    }
}