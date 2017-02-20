using System.Collections.Generic;

namespace InfermedicaAPI.Data
{
    public class InfermedicaSearchResponseItem
    {
        public readonly string Id;
        public readonly List<string> Labels;

        public InfermedicaSearchResponseItem(string id, List<string> labels)
        {
            Id = id;
            Labels = labels;
        }
    }
}