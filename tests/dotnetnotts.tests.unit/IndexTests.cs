using System;
using System.Linq;
using AngleSharp.Html.Dom;
using Bunit;
using Xunit;
using Index = dotnetnotts.Pages.Index;
using TestContext = Bunit.TestContext;

namespace dotnetnotts.tests.unit
{
    public class IndexTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<Index> _index;

        public IndexTests()
        {
            _context = new TestContext();
            _index = _context.RenderComponent<Index>();
        }

        [Fact]
        public void AboutUsTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">About Us</h2>", _index.Markup);
        }

        [Fact]
        public void TwitterLinkIsProvided()
        {
            AssertLinkExists("https://twitter.com/dotnetnotts");
        }

        [Fact]
        public void MeetupLinkIsProvided()
        {
            AssertLinkExists("https://www.meetup.com/dotnetnotts/");
        }


        [Fact]
        public void LinkedInLinkIsProvided()
        {
            AssertLinkExists("https://www.linkedin.com/company/dotnet-notts");
        }

        [Fact]
        public void YouTubeLinkIsProvided()
        {
            AssertLinkExists("https://www.youtube.com/channel/UC6N65W35hZMcVXeqq3Vi5Iw");
        }
        
        [Fact]
        public void UpcomingEventsTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Upcoming Events</h2>", _index.Markup);
        }

        [Fact]
        public void PastEventsTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Past Events</h2>", _index.Markup);
        }

        [Fact]
        public void OurSponsorsTitleIsDisplayed()
        {
            Assert.Contains("<h3 tabindex=\"0\">Our Sponsors</h3>", _index.Markup);
        }

        [Fact]
        public void JetBrainsLinkIsProvided()
        {
            AssertLinkExists("https://www.jetbrains.com/");
        }

        [Fact]
        public void PJGLinkIsProvided()
        {
            AssertLinkExists("https://www.pjgcreations.co.uk/");
        }
        
        [Fact]
        public void StkrsLinkIsProvided()
        {
            AssertLinkExists("https://stkrs.co.uk/");
        }

        private void AssertLinkExists(string link)
        {
            var linkExists = _index
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