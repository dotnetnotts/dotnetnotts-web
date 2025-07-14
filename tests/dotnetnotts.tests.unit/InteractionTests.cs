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
        public void NavMenu_LinkInteractions()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test all navigation links are clickable
            var homeLink = component.Find("a[href='/']");
            var speakerInfoLink = component.Find("a[href='speakerinfo']");
            var contactLink = component.Find("a[href='contactus']");
            var codeOfConductLink = component.Find("a[href='codeofconduct']");
            
            Assert.NotNull(homeLink);
            Assert.NotNull(speakerInfoLink);
            Assert.NotNull(contactLink);
            Assert.NotNull(codeOfConductLink);
            
            // Test link click closes menu
            var hamburger = component.Find("button.hamburger");
            hamburger.Click(); // Open menu
            homeLink.Click(); // Click link
            Assert.Contains("hide-menu", component.Markup); // Menu should close
        }

        [Fact]
        public void IndexPage_SocialMediaInteractions()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test social media links are clickable
            var twitterLink = component.Find("a[href='https://twitter.com/dotnetnotts']");
            var meetupLink = component.Find("a[href='https://www.meetup.com/dotnetnotts/']");
            var linkedinLink = component.Find("a[href='https://www.linkedin.com/company/dotnet-notts']");
            var youtubeLink = component.Find("a[href='https://www.youtube.com/channel/UC6N65W35hZMcVXeqq3Vi5Iw']");
            
            Assert.NotNull(twitterLink);
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
        public void NavMenu_KeyboardInteraction()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test keyboard navigation support
            Assert.Contains("tabindex=\"0\"", component.Markup);
            
            // Test hamburger button keyboard accessibility
            var hamburger = component.Find("button.hamburger");
            Assert.Contains("aria-label=\"Toggle navigation menu\"", hamburger.OuterHtml);
            
            // Test navigation links are keyboard accessible
            var links = component.FindAll("a.nav-link");
            Assert.True(links.Count >= 4); // At least 4 internal navigation links
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
        public void IndexPage_TouchFriendlyButtons()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test social media buttons are touch-friendly
            var socialButtons = component.FindAll("a.btn");
            Assert.True(socialButtons.Count >= 4); // At least 4 social media buttons
            
            // Test buttons have proper padding for touch targets
            foreach (var button in socialButtons)
            {
                Assert.Contains("px-5", button.OuterHtml); // Proper touch target size
            }
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
            Assert.Contains("aria-label=\"Twitter (opens in new tab)\"", component.Markup);
            Assert.Contains("aria-label=\"YouTube Channel (opens in new tab)\"", component.Markup);
        }

        [Fact]
        public void NavMenu_ExternalLinkInteractions()
        {
            var component = _context.RenderComponent<NavMenu>();
            
            // Test external links open in new tab
            var externalLinks = component.FindAll("a[target='_blank']");
            Assert.True(externalLinks.Count >= 2); // At least 2 external links
            
            // Test external links have proper security attributes
            Assert.Contains("rel=\"noopener\"", component.Markup);
        }

        [Fact]
        public void IndexPage_VideoInteractions()
        {
            var component = _context.RenderComponent<Index>();
            
            // Test video embeds are interactive
            Assert.Contains("allowfullscreen", component.Markup);
            Assert.Contains("frameborder='0'", component.Markup);
            
            // Test video containers are properly labeled
            Assert.Contains("title=\"", component.Markup);
            Assert.Contains("aria-labelledby=\"", component.Markup);
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