namespace RecommenderApp.Models
{
    public class RecommendationViewModel
    {
        public long ItemId { get; set; }
        public List<long> CollaborativeRecommendations { get; set; } = new();
        public List<int> ContentRecommendations { get; set; } = new();
    }
}