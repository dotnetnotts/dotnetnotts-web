using System;
using System.Linq;
using AngleSharp.Html.Dom;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class SpeakTests : IDisposable
    {
        private readonly TestContext _context;
        private IRenderedComponent<Speak> _speak;

        public SpeakTests()
        {
            _context = new TestContext();
            _speak = _context.RenderComponent<Speak>();
        }

        [Fact]
        public void SpeakTitleIsDisplayed()
        {
            Assert.Contains("<h1>Speak</h1>", _speak.Markup);
        }

        [Fact]
        public void RequestToSpeakFormIsProvided()
        {
            var formExists = _speak.FindAll("a")
                .Select(a => a as IHtmlAnchorElement)
                .Any(a => a?.Href is "https://forms.gle/XXjdqUd4e4efYxKQ8");
            
            Assert.True(formExists);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}