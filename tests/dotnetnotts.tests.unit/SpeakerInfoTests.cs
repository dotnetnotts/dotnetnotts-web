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
        private readonly IRenderedComponent<SpeakerInfo> _systemUnderTest;

        public SpeakerInfoTests()
        {
            _context = new TestContext();
            _systemUnderTest = _context.RenderComponent<SpeakerInfo>();
        }

        [Fact]
        public void CodeOfConductSectionExists()
        {
            var codeOfConduct = _systemUnderTest.Find("#code-of-conduct");
            Assert.NotNull(codeOfConduct);
        }

        [Fact]
        public void CodeOfConductLinkIsCorrect()
        {
            var codeOfConductLink = _systemUnderTest.Find("#code-of-conduct-link");
            Assert.NotNull(codeOfConductLink);
        }

        [Fact]
        public void VirtualMeetupsSectionExists()
        {
            var section = _systemUnderTest.Find("#virtual-meetups");
            Assert.NotNull(section);
        }

        [Fact]
        public void ScheduleSectionExists()
        {
            var section = _systemUnderTest.Find("#schedule");
            Assert.NotNull(section);
        }
               
        [Fact]
        public void SocialMediaSectionExists()
        {
            var section = _systemUnderTest.Find("#social-media");
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
            var linkExists = _systemUnderTest
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