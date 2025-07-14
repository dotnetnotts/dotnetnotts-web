using System;
using System.Linq;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class ContactUsTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<ContactUs> _contactUs;

        public ContactUsTests()
        {
            _context = new TestContext();
            _contactUs = _context.RenderComponent<ContactUs>();
        }

        [Fact]
        public void ThePeteGallagherTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\" class=\"font-weight-light\">Pete Gallagher</h2>", _contactUs.Markup);
        }

        [Fact]
        public void TheJessicaBrentnallTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\" class=\"font-weight-light\">Jessica Brentnall</h2>", _contactUs.Markup);
        }

        [Fact]
        public void TheGeneralInformationTitleIsDisplayed()
        {
            Assert.Contains("<h1 id=\"contact-heading\" tabindex=\"0\" class=\"text-center\">General Meetup contact details</h1>", _contactUs.Markup);
        }

        [Fact]
        public void ContactSectionHasProperAriaLabel()
        {
            Assert.Contains("<section aria-labelledby=\"contact-heading\">", _contactUs.Markup);
        }

        [Fact]
        public void OrganisersSectionHasProperAriaLabel()
        {
            Assert.Contains("<section aria-labelledby=\"organisers-heading\"", _contactUs.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}