using System;
using Bunit;
using Xunit;
using dotnetnotts.Shared;
using TestContext = Bunit.TestContext;

namespace dotnetnotts.tests.unit
{
    public class FooterTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<Footer> _footer;

        public FooterTests()
        {
            _context = new TestContext();
            _footer = _context.RenderComponent<Footer>();
        }

        [Fact]
        public void MeetupLinkIsDisplayed()
        {
            Assert.Contains("https://www.meetup.com/dotnetnotts", _footer.Markup);
        }

        [Fact]
        public void LinkedInLinkIsDisplayed()
        {
            Assert.Contains("https://www.linkedin.com/company/dotnet-notts", _footer.Markup);
        }

        [Fact]
        public void GitHubOrganizationLinkIsDisplayed()
        {
            Assert.Contains("https://github.com/dotnetnotts", _footer.Markup);
        }

        [Fact]
        public void GitHubRepositoryLinkIsNotDisplayed()
        {
            Assert.DoesNotContain("https://github.com/dotnetnotts/dotnetnotts-web", _footer.Markup);
        }

        [Fact]
        public void CodeOfConductLinkIsDisplayed()
        {
            Assert.Contains("href=\"codeofconduct\"", _footer.Markup);
            Assert.Contains("Code Of Conduct", _footer.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}