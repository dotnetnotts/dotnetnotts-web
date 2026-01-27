using System;
using Bunit;
using dotnetnotts.Shared;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Index = dotnetnotts.Pages.Index;

namespace dotnetnotts.tests.unit
{
    public class InteractionTests : IDisposable
    {
        private readonly TestContext _context;

        public InteractionTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public void NavMenu_ButtonInteraction()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test hamburger button click interaction
            var hamburger = component.Find("button.hamburger");
            Assert.NotNull(hamburger);
            
            // Verify button is clickable (blazor:onclick attribute)
            Assert.Contains("blazor:onclick", component.Markup);
            
            // Test click functionality
            hamburger.Click();
            Assert.DoesNotContain("hide-menu", component.Markup);
        }

        [Fact]
        public void IndexPage_SocialMediaInteractions()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test social media links are clickable
            var meetupLink = component.Find("a[href='https://www.meetup.com/dotnetnotts/']");
            var linkedinLink = component.Find("a[href='https://www.linkedin.com/company/dotnet-notts']");
            var youtubeLink = component.Find("a[href='https://www.youtube.com/channel/UC6N65W35hZMcVXeqq3Vi5Iw']");
            
            Assert.NotNull(meetupLink);
            Assert.NotNull(linkedinLink);
            Assert.NotNull(youtubeLink);
        }

        [Fact]
        public void IndexPage_ButtonStylingForInteraction()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test buttons have proper styling for interaction
            Assert.Contains("class=\"btn btn-light px-5 rounded-pill shadow-sm\"", component.Markup);
            
            // Test buttons have proper spacing for touch targets
            Assert.Contains("px-5", component.Markup); // Padding for touch targets
            Assert.Contains("shadow-sm", component.Markup); // Visual feedback
        }

        [Fact]
        public void IndexPage_KeyboardNavigation()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test tabindex for keyboard navigation
            var tabIndexCount = System.Text.RegularExpressions.Regex.Matches(component.Markup, "tabindex=\"0\"").Count;
            Assert.True(tabIndexCount >= 5); // Multiple elements should be keyboard accessible
        }

        [Fact]
        public void NavMenu_TouchInteractionSupport()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test hamburger button is touch-friendly
            var hamburger = component.Find("button.hamburger");
            Assert.Contains("class=\"hamburger\"", hamburger.OuterHtml);
            
            // Test navigation links are touch-friendly
            Assert.Contains("class=\"nav-link\"", component.Markup);
        }

        [Fact]
        public void NavMenu_InteractionStates()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test initial state
            Assert.Contains("hide-menu", component.Markup);
            
            // Test expanded state
            var hamburger = component.Find("button.hamburger");
            hamburger.Click();
            Assert.DoesNotContain("hide-menu", component.Markup);
            
            // Test collapsed state
            hamburger.Click();
            Assert.Contains("hide-menu", component.Markup);
        }

        [Fact]
        public void IndexPage_InteractiveElements()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test all interactive elements have proper labels
            Assert.Contains("aria-label=\"GitHub repository (opens in new tab)\"", component.Markup);
            Assert.Contains("aria-label=\"YouTube Channel (opens in new tab)\"", component.Markup);
        }

        [Fact]
        public void IndexPage_VideoInteractions()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test YouTube link is interactive and properly labeled
            Assert.Contains("href=\"https://www.youtube.com/channel/UC6N65W35hZMcVXeqq3Vi5Iw\"", component.Markup);
            Assert.Contains("target=\"_blank\"", component.Markup);
            
            // Test video/media links are properly labeled
            Assert.Contains("aria-label=\"YouTube Channel (opens in new tab)\"", component.Markup);
            Assert.Contains("aria-label=\"YouTube (opens in new tab)\"", component.Markup);
        }

        [Fact]
        public void NavMenu_ResponsiveInteractions()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test responsive behavior through CSS classes
            Assert.Contains("class=\"main-nav-container\"", component.Markup);
            Assert.Contains("class=\"nav-menu nav-menu-links", component.Markup);
            
            // Test mobile-specific interactions
            Assert.Contains("class=\"hamburger\"", component.Markup);
            Assert.Contains("hide-menu", component.Markup);
        }

        [Fact]
        public void IndexPage_AccessibleInteractions()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test all interactive elements are accessible
            Assert.Contains("aria-label=\"Social media links\"", component.Markup);
            Assert.Contains("tabindex=\"0\"", component.Markup);
            
            // Test headings are focusable for screen readers
            Assert.Contains("id=\"about-heading\"", component.Markup);
            Assert.Contains("id=\"past-talks-heading\"", component.Markup);
            Assert.Contains("id=\"sponsors-heading\"", component.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}