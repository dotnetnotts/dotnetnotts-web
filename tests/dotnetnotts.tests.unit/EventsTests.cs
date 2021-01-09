using System;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class EventsTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<Events> _events;

        public EventsTests()
        {
            _context = new TestContext();
            _events = _context.RenderComponent<Events>();
        }

        [Fact]
        public void TheEventsTitleIsDisplayed()
        {
            Assert.Contains("<h1 tabindex=\"0\">Events</h1>", _events.Markup);
        }

        [Fact]
        public void TheUpcomingTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Upcoming</h2>", _events.Markup);
        }

        [Fact]
        public void ThePastSpeakersTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Past Speakers</h2>", _events.Markup);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}