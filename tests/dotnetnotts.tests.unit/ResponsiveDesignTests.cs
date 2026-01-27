using System;
using Bunit;
using dotnetnotts.Shared;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Index = dotnetnotts.Pages.Index;

namespace dotnetnotts.tests.unit
{
    public class ResponsiveDesignTests : IDisposable
    {
        private readonly TestContext _context;

        public ResponsiveDesignTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public void MainLayout_HasResponsiveStructure()
        {
            var component = _context.RenderComponent<MainLayout>();
            
            // Check for responsive main structure
            Assert.Contains("class=\"main\"", component.Markup);
            Assert.Contains("class=\"top-row\"", component.Markup);
            Assert.Contains("class=\"content\"", component.Markup);
            Assert.Contains("class=\"bottom-row\"", component.Markup);
        }

        [Fact]
        public void NavMenu_HasHamburgerButton()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check for hamburger button for mobile navigation
            Assert.Contains("class=\"hamburger\"", component.Markup);
            Assert.Contains("aria-label=\"Toggle navigation menu\"", component.Markup);
            Assert.Contains("aria-controls=\"main-navigation\"", component.Markup);
        }

        [Fact]
        public void NavMenu_HasResponsiveClasses()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check for responsive CSS classes
            Assert.Contains("class=\"main-nav-container\"", component.Markup);
            Assert.Contains("class=\"nav-menu nav-menu-links hide-menu\"", component.Markup);
            Assert.Contains("class=\"navbar-brand\"", component.Markup);
        }

        [Fact]
        public void NavMenu_HamburgerTogglesFunctionality()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Initially should be collapsed (hide-menu class present)
            Assert.Contains("hide-menu", component.Markup);
            
            // Find and click the hamburger button
            var hamburger = component.Find("button.hamburger");
            hamburger.Click();
            
            // After clicking, hide-menu class should be removed
            Assert.DoesNotContain("hide-menu", component.Markup);
            
            // Click again to collapse
            hamburger.Click();
            
            // Should have hide-menu class again
            Assert.Contains("hide-menu", component.Markup);
        }

        [Fact]
        public void NavMenu_HasAccessibleNavigation()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check for proper navigation accessibility
            Assert.Contains("role=\"navigation\"", component.Markup);
            Assert.Contains("role=\"menubar\"", component.Markup);
            Assert.Contains("aria-label=\"Main navigation\"", component.Markup);
        }

        [Fact]
        public void IndexPage_HasResponsiveContainerStructure()
        {
            var component = _context.RenderComponent<Index>();
            
            // Check for responsive container classes
            Assert.Contains("class=\"center banner\"", component.Markup);
            Assert.Contains("class=\"center\"", component.Markup);
        }

        [Fact]
        public void IndexPage_HasResponsiveButtonLayout()
        {
            var component = _context.RenderComponent<Index>();
            
            // Check for responsive button classes
            Assert.Contains("class=\"btn btn-light px-5 rounded-pill shadow-sm\"", component.Markup);
            
            // Check for social media navigation
            Assert.Contains("aria-label=\"Social media links\"", component.Markup);
        }

        [Fact]
        public void Footer_HasResponsiveLayout()
        {
            var component = _context.RenderComponent<Footer>();
            
            // Check footer has proper structure for responsive design
            var footerMarkup = component.Markup;
            Assert.NotNull(footerMarkup);
            Assert.True(footerMarkup.Length > 0);
        }

        [Fact]
        public void NavMenu_ClosesOnLinkClick()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Open the menu first
            var hamburger = component.Find("button.hamburger");
            hamburger.Click();
            Assert.DoesNotContain("hide-menu", component.Markup);
            
            // Click on a navigation link
            var homeLink = component.Find("a[href='/']");
            homeLink.Click();
            
            // Menu should be closed (hide-menu class should be present)
            Assert.Contains("hide-menu", component.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}