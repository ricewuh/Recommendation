namespace RecommenderApp.Models
{
    public class CollaborativeRecommendation
    {
        public double UserId { get; set; }
        public double Rec1 { get; set; }
        public double Rec2 { get; set; }
        public double Rec3 { get; set; }
        public double Rec4 { get; set; }
        public double Rec5 { get; set; }

        public List<long> ToList()
        {
            return new List<long>
            {
                Convert.ToInt64(Rec1),
                Convert.ToInt64(Rec2),
                Convert.ToInt64(Rec3),
                Convert.ToInt64(Rec4),
                Convert.ToInt64(Rec5)
            };
        }
    }
}