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
        public void HelloWorldTitleIsDisplayed()
        {
            Assert.Contains("<h2>Hello, world!</h2>", _index.Markup);
        }
        
        [Fact]
        public void WelcomeToYourNewAppIsDisplayed()
        {
            Assert.Contains("Welcome to your new app.", _index.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}