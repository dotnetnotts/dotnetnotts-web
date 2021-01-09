using System;
using System.Linq;
using AngleSharp.Html.Dom;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class SpeakerInfoTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<SpeakerInfo> _speakerInfo;

        public SpeakerInfoTests()
        {
            _context = new TestContext();
            _speakerInfo = _context.RenderComponent<SpeakerInfo>();
        }

        [Fact]
        public void SpeakerInformationTitleIsDisplayed()
        {
            Assert.Contains("<h1 tabindex=\"0\">Speaker Information</h1>", _speakerInfo.Markup);
        }

        [Fact]
        public void ForAllEventsTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">For All Events</h2>", _speakerInfo.Markup);
        }

        [Fact]
        public void CodeOfConductTitleIsDisplayed()
        {
            Assert.Contains("<h3 tabindex=\"0\">Code Of Conduct</h3>", _speakerInfo.Markup);
        }

        [Fact]
        public void CodeOfConductLinkIsCorrect()
        {
            var codeOfConductLink = _speakerInfo.Find("#code-of-conduct-link");
            Assert.NotNull(codeOfConductLink);
        }

        [Fact]
        public void VirtualMeetupsTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Virtual Meetups</h2>", _speakerInfo.Markup);
        }

        [Fact]
        public void VirtualMeetupsSectionExists()
        {
            var section = _speakerInfo.Find("#virtual-events");
            Assert.NotNull(section);
        }

        [Fact]
        public void RoughScheduleTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Rough Schedule</h2>", _speakerInfo.Markup);
        }

        [Fact]
        public void ScheduleSectionExists()
        {
            var section = _speakerInfo.Find("#schedule");
            Assert.NotNull(section);
        }

        [Fact]
        public void SocialMediaTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Social Media</h2>", _speakerInfo.Markup);
        }
               
        [Fact]
        public void SocialMediaSectionExists()
        {
            var section = _speakerInfo.Find("#social-media");
            Assert.NotNull(section);
        }        
        
        [Fact]
        public void TwitterLinkForDotNetNottsIsProvided()
        {
            AssertLinkExists("https://twitter.com/dotnetnotts");
        }
        
        [Fact]
        public void TwitterLinkForJessIsProvided()
        {
            AssertLinkExists("https://twitter.com/dotnetnotts");
        }
        
        [Fact]
        public void EmailLinkForPeteIsProvided()
        {
            AssertLinkExists("mailto:pete@pjgcreations.co.uk");
        }

        [Fact]
        public void EmailLinkForJessIsProvided()
        {
            AssertLinkExists("mailto:me@jesswhite.co.uk");
        }
        
        private void AssertLinkExists(string link)
        {
            var linkExists = _speakerInfo
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