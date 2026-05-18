using System;
using System.Linq;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class LearnTests : IDisposable
    {
        private readonly BunitContext _context;
        private readonly IRenderedComponent<Learn> _learn;

        public LearnTests()
        {
            _context = new BunitContext();
            _learn = _context.Render<Learn>();
        }

        [Fact]
        public void ResourcesTitleIsDisplayed()
        {
            Assert.Contains("<h1 tabindex=\"0\">Resources Page</h1>", _learn.Markup);
        }

        [Fact]
        public void LearnDotNetTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Learn .NET</h2>", _learn.Markup);
        }

        [Fact]
        public void LearnAzureTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"5\">Learn Azure</h2>", _learn.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}