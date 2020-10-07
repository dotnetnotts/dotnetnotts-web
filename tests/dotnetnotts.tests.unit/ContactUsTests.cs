using System;
using System.Linq;
using AngleSharp.Html.Dom;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class ContactUsTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<ContactUs> _contactUs;

        public ContactUsTests()
        {
            _context = new TestContext();
            _contactUs = _context.RenderComponent<ContactUs>();
        }

        [Fact]
        public void ContactTeamSectionExists()
        {
            var contactTeamSection = _contactUs.Find("#contactusteam");
            Assert.NotNull(contactTeamSection);
        }
        
        [Fact]
        public void QuickLinkToContactTeamIsProvided()
        {
            // bUnit seems to prefix relative links like this
            AssertLinkExists("about:///contactus/#contactusteam");
        }

        [Fact]
        public void MeetupLinkIsProvided()
        {
            AssertLinkExists("https://www.meetup.com/dotnetnotts");
        }

        [Fact]
        public void TwitterLinkIsProvided()
        {
            AssertLinkExists("https://twitter.com/dotnetnotts");
        }

        [Fact]
        public void LinkedInLinkIsProvided()
        {
            AssertLinkExists("https://www.linkedin.com/company/dotnet-notts");
        }

        private void AssertLinkExists(string link)
        {
            var linkExists = _contactUs
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