using Microsoft.AspNetCore.Mvc;
using RecommenderApp.Models;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace RecommenderApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<CollaborativeRecommendation> _collab;
        private readonly List<ContentRecommendation> _content;

        public HomeController()
        {
            _collab = LoadCollaborative("collaborative_recommendations.csv");
            _content = LoadContent("recommendations.csv");
        }

        public IActionResult Index()
        {
            return View(new RecommendationViewModel());
        }

        [HttpPost]
       
        public IActionResult Index(RecommendationViewModel model)
        {
            // ✅ 1. Content Filtering — Based on entered ItemId
            model.ContentRecommendations = _content
                    .FirstOrDefault(x => x.LikedId == model.ItemId)
                is ContentRecommendation cr
                ? new List<int> { cr.Rec1, cr.Rec2, cr.Rec3, cr.Rec4, cr.Rec5 }
                : new List<int>();

            // ✅ 2. Collaborative Filtering — Use first available UserId from CSV
            var knownUser = _collab.FirstOrDefault();
            model.CollaborativeRecommendations = knownUser?.ToList() ?? new List<long>();

            return View(model);
        }


        private List<CollaborativeRecommendation> LoadCollaborative(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<CollaborativeRecommendationMap>();
            return csv.GetRecords<CollaborativeRecommendation>().ToList();
        }

        private List<ContentRecommendation> LoadContent(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ContentRecommendationMap>();
            return csv.GetRecords<ContentRecommendation>().ToList();
        }
    }
}
