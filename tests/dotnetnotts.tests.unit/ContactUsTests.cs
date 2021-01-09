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
        public void ThePeteGallagherTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\" class=\"font-weight-light\">Pete Gallagher</h2>", _contactUs.Markup);
        }

        [Fact]
        public void PeteTwitterLinkIsProvided()
        {
            AssertLinkExists("https://twitter.com/pete_codes");
        }

        [Fact]
        public void PeteLinkedInLinkIsProvided()
        {
            AssertLinkExists("https://www.linkedin.com/in/pjgcreations/");
        }

        [Fact]
        public void TheJessicaWhiteTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\" class=\"font-weight-light\">Jessica White</h2>", _contactUs.Markup);
        }

        [Fact]
        public void JessicaTwitterLinkIsProvided()
        {
            AssertLinkExists("https://twitter.com/JessPWhite");
        }

        [Fact]
        public void JessicaLinkedInLinkIsProvided()
        {
            AssertLinkExists("https://www.linkedin.com/in/jessica-white-67917883/");
        }

        [Fact]
        public void TheGeneralInformationTitleIsDisplayed()
        {
            Assert.Contains("<h1 tabindex=\"0\" class=\"text-center\">General Meetup contact details</h1>", _contactUs.Markup);
        }

        [Fact]
        public void GeneralMeetupLinkIsProvided()
        {
            AssertLinkExists("https://www.meetup.com/dotnetnotts");
        }

        [Fact]
        public void GeneralTwitterLinkIsProvided()
        {
            AssertLinkExists("https://twitter.com/dotnetnotts");
        }

        [Fact]
        public void GeneralLinkedInLinkIsProvided()
        {
            AssertLinkExists("https://www.linkedin.com/company/dotnet-notts/");
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