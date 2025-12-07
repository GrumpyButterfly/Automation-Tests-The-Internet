using AutomationTestsTheInternet.Utilities;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AutomationTestsTheInternet.Tests
{
    public class Tests : BaseTest
    {
        [SetUp]
        public async Task Setup()
        {
            await _page.GotoAsync("https://the-internet.herokuapp.com/");
        }

        [Test]
        public async Task WelcomePage_Should_LoadAndDisplayAllVisibleElements()
        {
            //Arrange
            var welcomePage = new Pages.WelcomePage(_page);

            //Act & Assert
            Assert.Multiple(async () =>
            {
                Assert.That(await welcomePage.IsWelcomeBannerVisible(), Is.True);
                Assert.That(await welcomePage.IsAvailableExamplesVisible(), Is.True);
                Assert.That(await welcomePage.GetAllExampleLinksCount(), Is.EqualTo(44));
                Assert.That(await welcomePage.IsForkMeOnGitHubVisible(), Is.True);
                var linkVisibilities = await welcomePage.GetExampleLinkVisibilitiesAsync();
                foreach (var isVisible in linkVisibilities)
                {
                    Assert.That(isVisible, Is.True);
                }
            });
        }
    }
}
