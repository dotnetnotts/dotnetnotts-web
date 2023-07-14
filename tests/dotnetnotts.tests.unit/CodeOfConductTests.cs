using System;
using Bunit;
using dotnetnotts.Pages;
using Xunit;

namespace dotnetnotts.tests.unit
{
    public class CodeOfConductTests : IDisposable
    {
        private readonly TestContext _context;
        private readonly IRenderedComponent<CodeOfConduct> _systemUnderTest;

        public CodeOfConductTests()
        {
            _context = new TestContext();
            _systemUnderTest = _context.RenderComponent<CodeOfConduct>();
        }

        [Fact]
        public void QuickVersionSectionExists()
        {
            var quickVersionSection = _systemUnderTest.Find("#quick-version");
            Assert.NotNull(quickVersionSection);
        }

        [Fact]
        public void FullVersionSectionExists()
        {
            var quickVersionSection = _systemUnderTest.Find("#full-version");
            Assert.NotNull(quickVersionSection);
        }

        [Fact]
        public void ReportingCodeOfConductSectionExists()
        {
            var quickVersionSection = _systemUnderTest.Find("#reporting-coc");
            Assert.NotNull(quickVersionSection);
        }
               
        [Fact]
        public void RecruitmentSectionExists()
        {
            var quickVersionSection = _systemUnderTest.Find("#recruitment");
            Assert.NotNull(quickVersionSection);
        }        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}