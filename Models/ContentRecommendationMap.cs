using CsvHelper.Configuration;

namespace RecommenderApp.Models
{
    public class ContentRecommendationMap : ClassMap<ContentRecommendation>
    {
        public ContentRecommendationMap()
        {
            Map(m => m.LikedId).Name("If you liked (ID)");
            Map(m => m.Rec1).Name("Recommendation 1 (ID)");
            Map(m => m.Rec2).Name("Recommendation 2 (ID)");
            Map(m => m.Rec3).Name("Recommendation 3 (ID)");
            Map(m => m.Rec4).Name("Recommendation 4 (ID)");
            Map(m => m.Rec5).Name("Recommendation 5 (ID)");
        }
    }
}