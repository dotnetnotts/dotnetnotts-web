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
            Assert.Contains("<h3>Events</h3>", _events.Markup);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}