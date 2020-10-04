using System;
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
        public void SpeakerInfoTitleIsDisplayed()
        {
            Assert.Contains("<h3>Speaker Info</h3>", _speakerInfo.Markup);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}