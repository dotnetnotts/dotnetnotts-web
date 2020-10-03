using Bunit;
using dotnetnotts.Pages;
using NUnit.Framework;
using TestContext = Bunit.TestContext;

namespace dotnetnotts.tests.unit
{
    [TestFixture]
    public class IndexTests
    {
        private TestContext _context;
        private IRenderedComponent<Index> _index;

        [SetUp]
        public void IndexPageIsRendered()
        {
            _context = new TestContext();
            _index = _context.RenderComponent<Index>();
        }
        
        [Test]
        public void HelloWorldTitleIsDisplayed()
        {
            var helloWorldTitle = _index.Find("h2");
            helloWorldTitle.MarkupMatches("<h2>Hello, world!</h2>");
        }
        
        [Test]
        public void WelcomeToYourNewAppIsDisplayed()
        {
            Assert.That(_index.Markup.Contains("Welcome to your new app."));
        }

        [TearDown]
        public void CleanUp()
        {
            _context.Dispose();
        }
    }
}