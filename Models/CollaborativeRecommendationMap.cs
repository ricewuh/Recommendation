using CsvHelper.Configuration;

namespace RecommenderApp.Models
{
    public class CollaborativeRecommendationMap : ClassMap<CollaborativeRecommendation>
    {
        public CollaborativeRecommendationMap()
        {
            Map(m => m.UserId).Name("UserId");
            Map(m => m.Rec1).Name("Rec1");
            Map(m => m.Rec2).Name("Rec2");
            Map(m => m.Rec3).Name("Rec3");
            Map(m => m.Rec4).Name("Rec4");
            Map(m => m.Rec5).Name("Rec5");
        }
    }
}