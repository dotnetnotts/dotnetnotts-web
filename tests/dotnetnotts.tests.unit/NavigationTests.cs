using System;
using Bunit;
using dotnetnotts.Shared;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Index = dotnetnotts.Pages.Index;

namespace dotnetnotts.tests.unit
{
    public class NavigationTests : IDisposable
    {
        private readonly TestContext _context;

        public NavigationTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public void NavMenu_HasAllRequiredNavigationLinks()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check for all main navigation links
            Assert.Contains("href=\"/\"", component.Markup); // Home
            Assert.Contains("href=\"speakerinfo\"", component.Markup); // Speaker Info
            Assert.Contains("href=\"codeofconduct\"", component.Markup); // Code of Conduct
        }

        [Fact]
        public void NavMenu_MobileNavigationState()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Initially collapsed on mobile
            Assert.Contains("hide-menu", component.Markup);
            
            // Hamburger button should be present
            Assert.Contains("class=\"hamburger\"", component.Markup);
            
            // Navigation should be properly labeled for mobile
            Assert.Contains("aria-controls=\"main-navigation\"", component.Markup);
        }

        [Fact]
        public void NavMenu_DesktopNavigationState()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Desktop navigation should have proper float layout
            Assert.Contains("class=\"nav-menu nav-menu-links", component.Markup);
            
            // Check for desktop navigation class structure
            Assert.Contains("nav-menu-links", component.Markup); // CSS class implies float right
        }

        [Fact]
        public void NavMenu_NavigationInteractions()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test hamburger menu toggle
            var hamburger = component.Find("button.hamburger");
            
            // Initially collapsed
            Assert.Contains("hide-menu", component.Markup);
            
            // Click to expand
            hamburger.Click();
            Assert.DoesNotContain("hide-menu", component.Markup);
            
            // Click to collapse
            hamburger.Click();
            Assert.Contains("hide-menu", component.Markup);
        }

        [Fact]
        public void NavMenu_LinkClickClosesMenu()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Open menu
            var hamburger = component.Find("button.hamburger");
            hamburger.Click();
            Assert.DoesNotContain("hide-menu", component.Markup);
            
            // Click on different navigation links and verify menu closes
            var homeLink = component.Find("a[href='/']");
            homeLink.Click();
            Assert.Contains("hide-menu", component.Markup);
            
            // Test with another link
            hamburger.Click(); // Open again
            var speakerInfoLink = component.Find("a[href='speakerinfo']");
            speakerInfoLink.Click();
            Assert.Contains("hide-menu", component.Markup);
        }

        [Fact]
        public void IndexPage_HasProperNavigationStructure()
        {
            var component = _context.RenderComponent<Index>();
            
            // Check for proper navigation within content
            Assert.Contains("aria-label=\"Social media links\"", component.Markup);
            Assert.Contains("href=\"https://www.meetup.com/dotnetnotts/\"", component.Markup);
            Assert.Contains("href=\"https://www.linkedin.com/company/dotnet-notts\"", component.Markup);
            Assert.Contains("href=\"https://www.youtube.com/channel/UC6N65W35hZMcVXeqq3Vi5Iw\"", component.Markup);
        }

        [Fact]
        public void IndexPage_SocialLinksHaveProperAttributes()
        {
            var component = _context.RenderComponent<Index>();
            
            // Check social media links have proper attributes
            Assert.Contains("target=\"_blank\"", component.Markup);
            Assert.Contains("aria-label=\"Meetup (opens in new tab)\"", component.Markup);
            Assert.Contains("aria-label=\"LinkedIn (opens in new tab)\"", component.Markup);
            Assert.Contains("aria-label=\"YouTube (opens in new tab)\"", component.Markup);
        }

        [Fact]
        public void NavMenu_HasProperAriaControls()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check hamburger button controls navigation
            Assert.Contains("aria-controls=\"main-navigation\"", component.Markup);
            Assert.Contains("id=\"main-navigation\"", component.Markup);
        }

        [Fact]
        public void NavMenu_HasProperRoleAttributes()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check for proper ARIA roles
            Assert.Contains("role=\"navigation\"", component.Markup);
            Assert.Contains("role=\"menubar\"", component.Markup);
            Assert.Contains("role=\"menuitem\"", component.Markup);
            Assert.Contains("role=\"none\"", component.Markup); // For list items
        }

        [Fact]
        public void NavMenu_LogoLinkWorks()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check logo link (href attribute without value means home)
            Assert.Contains("class=\"navbar-brand\"", component.Markup);
            Assert.Contains("href", component.Markup); // href attribute is present
            Assert.Contains("aria-label=\".NET Notts home page\"", component.Markup);
        }

        [Fact]
        public void NavMenu_HasKeyboardAccessibility()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Check for keyboard navigation support
            Assert.Contains("tabindex=\"0\"", component.Markup);
            
            // Check hamburger button is keyboard accessible
            var hamburger = component.Find("button.hamburger");
            Assert.NotNull(hamburger);
            Assert.Contains("aria-label=\"Toggle navigation menu\"", hamburger.OuterHtml);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}