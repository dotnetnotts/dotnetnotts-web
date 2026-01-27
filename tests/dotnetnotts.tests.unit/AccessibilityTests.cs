using System;
using Bunit;
using dotnetnotts.Shared;
using Xunit;
using Index = dotnetnotts.Pages.Index;

namespace dotnetnotts.tests.unit
{
    public class AccessibilityTests : IDisposable
    {
        private readonly TestContext _context;

        public AccessibilityTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public void MainLayout_HasProperSemanticStructure()
        {
            var component = _context.RenderComponent<MainLayout>();
            
            // Check for semantic HTML elements
            Assert.Contains("<header class=\"top-row\"", component.Markup);
            Assert.Contains("<main id=\"main-content\" class=\"content\" role=\"main\"", component.Markup);
            Assert.Contains("<footer class=\"bottom-row\" role=\"contentinfo\"", component.Markup);
        }

        [Fact]
        public void MainLayout_HasSkipLink()
        {
            var component = _context.RenderComponent<MainLayout>();
            Assert.Contains("<a href=\"#main-content\" class=\"skip-link\">Skip to main content</a>", component.Markup);
        }

        [Fact]
        public void NavMenu_HasProperAriaAttributes()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check for proper navigation structure
            Assert.Contains("role=\"navigation\"", component.Markup);
            Assert.Contains("aria-label=\"Main navigation\"", component.Markup);
            Assert.Contains("role=\"menubar\"", component.Markup);
            Assert.Contains("aria-controls=\"main-navigation\"", component.Markup);
        }

        [Fact]
        public void IndexPage_HasProperSectionLabels()
        {
            var component = _context.RenderComponent<Index>();
            
            // Check for proper section labeling
            Assert.Contains("aria-labelledby=\"about-heading\"", component.Markup);
            Assert.Contains("aria-labelledby=\"past-talks-heading\"", component.Markup);
            Assert.Contains("aria-labelledby=\"sponsors-heading\"", component.Markup);
        }

        [Fact]
        public void IndexPage_HasProperImageAltText()
        {
            var component = _context.RenderComponent<Index>();
            
            // Check for proper image alt text
            Assert.Contains("alt=\"CGI logo\"", component.Markup);
            Assert.Contains("alt=\"Rebel Recruiters logo\"", component.Markup);
        }

        [Fact]
        public void IndexPage_HasProperLinkLabels()
        {
            var component = _context.RenderComponent<Index>();
            
            // Check for proper link labels
            Assert.Contains("aria-label=\"YouTube (opens in new tab)\"", component.Markup);
            Assert.Contains("aria-label=\"GitHub repository (opens in new tab)\"", component.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}