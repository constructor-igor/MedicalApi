**http://apimedic.com/**
![image](https://cloud.githubusercontent.com/assets/1849690/22407188/6a6a6370-e66a-11e6-9c4f-29fb99879bc6.png)

![image](https://cloud.githubusercontent.com/assets/1849690/22407517/833e35e2-e670-11e6-818c-e3b54c507f90.png)
![image](https://cloud.githubusercontent.com/assets/1849690/22407518/89af0f3c-e670-11e6-8ba9-f8d1363a1e28.png)

GET|description
----|-------------
/symptoms | Symptoms can be either called to receive the full list of symptoms or a subset of symptoms (e.g. all symptoms of a body sublocation).
/issues | Issues can be either called to receive the full list of issues or a subset of issues (e.g. all issues of a diagnosis).
/issues/104/info | Issue info can be called to receive all information about a health issue. The short description gives a short overview. A longer information can consist of "Description", "MedicalCondition", "TreatmentDescription".
/diagnosis | The diagnosis is the core function of the symptom-checker to compute the potential health issues based on a set of symptoms, gender and age.
/specialisations | The diagnosis is the core function of the symptom-checker to compute the potential health issues based on a set of symptoms, gender and age, but instead of getting computed diagnosis, you can also get list of suggested specialisations for calulated diseases
/symptom/proposed | The proposed symptoms can be called to request additional symptoms which can be related to the given symptoms in order to refine the diagnosis.
/body/locations | Body locations can be called to receive all the body locations
/body/locations/16 | Body sublocations can be called to receive all the body sub locations from a body location.
/symptoms/0/man | Symptoms in body sublocations can be called to receive all the symptoms in a body sub location.
/redflag | Red flag texts are recommendations to the patient for a higher urgency or severeness of the possible symptoms. As an example a patient with pain in the breast might have a heart attack and therefore the patient should be warned about the urgency and severeness of the matter.
------------


https://apimedic.net/mysymptomchecker/kb/sandbox-healthservice/

Domain:

* Symptom
* Issue (Illness)
* Diagnosis (list of "issues" with accuracy)  [symptoms, age, gender] ==> Diagnosis
  * Includes ICD ([International Classification of Diseases](https://en.wikipedia.org/wiki/International_Statistical_Classification_of_Diseases_and_Related_Health_Problems))
* Specialisation (~wide list of potential diagnosis with accuracy)
* Body location
* Body sublocation

API:

* Symptoms in body sublocations: ("man|woman|boy|girl"(MWBG) x "sublocation id" ==> list of symptoms, including "red flag")
* Issue info: Issue Id ==> description, list of possible symptoms
* Proposed symptoms: symptoms, gender, age ==> list of symptoms
* Red Flag text: symptom => red flag text (important/urgent message)
* Get specialisation: symptoms x gender x age => list of specialisation

>The diagnosis is the core function of the symptom-checker to compute the potential health issues based on a set of symptoms, gender and >age, but instead of getting computed diagnosis, you can also get list of suggested specialisations for calulated diseases

```c#
    public class Symptom
    {
        public readonly int ID;
        public readonly string Name;

        public Symptom(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
```

```c#
    public class Issue
    {
        public readonly int ID;
        public readonly string Name;

        public Issue(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
```
```c#
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
```

```c#
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

        public readonly DiagnosisIssue Issue;

        public Diagnosis(DiagnosisIssue issue)
        {
            Issue = issue;
        }
    }
```
