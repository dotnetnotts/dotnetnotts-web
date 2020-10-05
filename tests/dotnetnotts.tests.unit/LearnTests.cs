using System;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class LearnTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<Learn> _learn;

        public LearnTests()
        {
            _context = new TestContext();
            _learn = _context.RenderComponent<Learn>();
        }

        [Fact]
        public void LearnTitleIsDisplayed()
        {
            Assert.Contains("<h1 tabindex=\"1\">Learn</h1>", _learn.Markup);
        }

        [Fact]
        public void HeadersForLearningSectionsAreDisplayed()
        {
            var learnCards = _learn.FindAll(".card");
            var cardHeaders = learnCards.Children(".card-header").ToList();

            Assert.Single(cardHeaders, header => header.ToMarkup().Contains("Learn .NET"));
            Assert.Single(cardHeaders, header => header.ToMarkup().Contains("Learn Azure"));
        }

        [Fact]
        public void AllLinksToLearningResourcesAreProvided()
        {
            var learnCards = _learn.FindAll(".card");
            var links = learnCards
                .Children(".list-group-item a")
                .Select(a => a as IHtmlAnchorElement);

            Assert.All(links, link => Uri.IsWellFormedUriString(link?.Href,
                UriKind.RelativeOrAbsolute));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}