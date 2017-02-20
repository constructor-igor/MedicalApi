using System.Collections.Generic;

namespace InfermedicaAPI.Data
{
    public enum ParentRelation { NULL, Base, Duration, Severity, Character, ExacerbatingFactor, DiminishingFactor, Location, Radiation }
    public class InfermedicaSymptom
    {
        public readonly string Id;
        public readonly string Name;
        public readonly string Question;
        public readonly string Category;
        public readonly Dictionary<string, string> Extras;
        public readonly List<string> Children;
        public readonly Sex Sex;
        public readonly string ImageUrl;
        public readonly string ImageSource;
        public readonly string ParentId;
        public readonly ParentRelation ParentRelation;

        public InfermedicaSymptom(string id, string name, string question, string category, Dictionary<string, string> extras, List<string> children, Sex sex, string imageUrl, string imageSource, string parentId, ParentRelation parentRelation)
        {
            Id = id;
            Name = name;
            Question = question;
            Category = category;
            Extras = extras;
            Children = children;
            Sex = sex;
            ImageUrl = imageUrl;
            ImageSource = imageSource;
            ParentId = parentId;
            ParentRelation = parentRelation;
        }
    }
}