using System.Collections.Generic;

namespace InfermedicaAPI.Data
{
    public class InfermedicaRiskFactor
    {
        public readonly string Id;
        public readonly string Name;
        public readonly string Question;
        public readonly string Category;
        public readonly Dictionary<string, string> Extras;
        public readonly Sex Sex;
        public readonly string ImageUrl;
        public readonly string ImageSource;

        public InfermedicaRiskFactor(string id, string name, string question, string category, Dictionary<string, string> extras, Sex sex, string imageUrl, string imageSource)
        {
            Id = id;
            Name = name;
            Question = question;
            Category = category;
            Extras = extras;
            Sex = sex;
            ImageUrl = imageUrl;
            ImageSource = imageSource;
        }
    }
}