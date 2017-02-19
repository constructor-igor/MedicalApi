using System.Collections.Generic;

namespace InfermedicaAPI.Data
{
    public class InfermedicaLabTest
    {
        public enum ItemType {  VeryLow, Low, Normal, High, VeryHigh, Absent, Present} 
        public class ResultItem
        {
            public readonly string Id;
            public readonly ItemType Type;

            public ResultItem(string id, ItemType type)
            {
                Id = id;
                Type = type;
            }
        }
        public readonly string Id;
        public readonly string Name;
        public readonly string Category;
        public readonly List<ResultItem> ResultItems;

        public InfermedicaLabTest(string id, string name, string category, List<ResultItem> resultItems)
        {
            Id = id;
            Name = name;
            Category = category;
            ResultItems = resultItems;
        }
    }
}