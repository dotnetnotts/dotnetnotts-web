using System;
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
        public void PastEventsTitleIsDisplayed()
        {
            Assert.Contains("<h2 id=\"past-talks-heading\" tabindex=\"0\">Past Events</h2>", _index.Markup);
        }

        [Fact]
        public void OurSponsorsTitleIsDisplayed()
        {
            Assert.Contains("<h3 id=\"sponsors-heading\" tabindex=\"0\">Our Sponsors</h3>", _index.Markup);
        }

        [Fact]
        public void PastEventsSectionHasProperAriaLabel()
        {
            Assert.Contains("<section id=\"past-talks\" aria-labelledby=\"past-talks-heading\">", _index.Markup);
        }

        [Fact]
        public void SponsorsSectionHasProperAriaLabel()
        {
            Assert.Contains("<section class=\"sponsors\" aria-labelledby=\"sponsors-heading\">", _index.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
