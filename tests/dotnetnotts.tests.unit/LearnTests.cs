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
        public void ResourcesTitleIsDisplayed()
        {
            Assert.Contains("<h1 tabindex=\"0\">Resources Page</h1>", _learn.Markup);
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

        [Fact]
        public void LearnDotNetTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Learn .NET</h2>", _learn.Markup);
        }

        [Fact]
        public void MicrosoftLearnLinkIsProvided()
        {
            AssertLinkExists("https://dotnet.microsoft.com/learn");
        }

        [Fact]
        public void CSharpFirstStepsLinkIsProvided()
        {
            AssertLinkExists("https://docs.microsoft.com/en-gb/learn/paths/csharp-first-steps/?WT.mc_id=cloudskills-stream-ajack");
        }

        [Fact]
        public void DotNetDocsLinkIsProvided()
        {
            AssertLinkExists("https://docs.microsoft.com/en-gb/dotnet/?WT.mc_id=cloudskills-stream-ajack");
        }

        [Fact]
        public void AspDocsLinkIsProvided()
        {
            AssertLinkExists("https://docs.microsoft.com/en-gb/aspnet/core/?view=aspnetcore-3.1&WT.mc_id=cloudskills-stream-ajack");
        }

        [Fact]
        public void CSharpDataLinkIsProvided()
        {
            AssertLinkExists("https://docs.microsoft.com/en-gb/learn/paths/csharp-data/?WT.mc_id=cloudskills-stream-ajack");
        }

        [Fact]
        public void LearnAzureTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"5\">Learn Azure</h2>", _learn.Markup);
        }

        [Fact]
        public void AzureDocumentationLinkIsProvided()
        {
            AssertLinkExists("https://docs.microsoft.com/en-gb/azure/?product=featured#languages-and-tools&WT.mc_id=cloudskills-stream-ajack");
        }

        [Fact]
        public void QuickstartLinkIsProvided()
        {
            AssertLinkExists("https://docs.microsoft.com/en-gb/azure/azure-functions/functions-create-first-azure-function-azure-cli?pivots=programming-language-csharp&tabs=bash%2Cbrowser&WT.mc_id=cloudskills-stream-ajack");
        }

        private void AssertLinkExists(string link)
        {
            var linkExists = _learn
                .FindAll("a")
                .Select(a => a as IHtmlAnchorElement)
                .Any(a => a?.Href == link);

            Assert.True(linkExists);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}