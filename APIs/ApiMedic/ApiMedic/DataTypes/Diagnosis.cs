using System.Collections.Generic;

namespace ApiMedic.DataTypes
{
    public class Diagnosis
    {
        public class DiagnosisIssue
        {
            public readonly int ID;
            public readonly string Name;
            public readonly string ProfName;
            public readonly string Icd;
            public readonly string IcdName;
            public readonly double Accuracy;

            public DiagnosisIssue(int id, string name, string profName, string icd, string icdName, double accuracy)
            {
                ID = id;
                Name = name;
                ProfName = profName;
                Icd = icd;
                IcdName = icdName;
                Accuracy = accuracy;
            }
        }

        public class DiagnosisSpecialisation
        {
            public readonly int ID;
            public readonly string Name;
            public readonly int SpecialisationID;
        }

        public class DiagnosisCandidate
        {
            public readonly DiagnosisIssue DiagnosisIssue;
            public readonly DiagnosisSpecialisation DiagnosisSpecialisation;

            public DiagnosisCandidate(DiagnosisIssue diagnosisIssue, DiagnosisSpecialisation diagnosisSpecialisation)
            {
                DiagnosisIssue = diagnosisIssue;
                DiagnosisSpecialisation = diagnosisSpecialisation;
            }
        }

        public readonly List<DiagnosisCandidate> Candidates;

        public Diagnosis(List<DiagnosisCandidate> candidates)
        {
            Candidates = candidates;
        }
    }

    public class BodyLocation
    {
        public readonly int ID;
        public readonly string Name;

        public BodyLocation(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}