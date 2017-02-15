namespace InfermedicaAPI.Data
{
    public class InfermedicaInfo
    {
        public readonly string LastModelUpdate;
        public readonly int ConditionsCount;
        public readonly int SymptomsCount;
        public readonly int RiskFactorsCount;
        public readonly int LabTestsCount;

        public InfermedicaInfo(string lastModelUpdate, int conditionsCount, int symptomsCount, int riskFactorsCount, int labTestsCount)
        {
            LastModelUpdate = lastModelUpdate;
            ConditionsCount = conditionsCount;
            SymptomsCount = symptomsCount;
            RiskFactorsCount = riskFactorsCount;
            LabTestsCount = labTestsCount;
        }
    }
}