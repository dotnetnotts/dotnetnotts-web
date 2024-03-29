﻿using System;
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
        public void PastEventsTitleIsDisplayed()
        {
            Assert.Contains("<h2 tabindex=\"0\">Past Events</h2>", _index.Markup);
        }

        [Fact]
        public void OurSponsorsTitleIsDisplayed()
        {
            Assert.Contains("<h3 tabindex=\"0\">Our Sponsors</h3>", _index.Markup);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
