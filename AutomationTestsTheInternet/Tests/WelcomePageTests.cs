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
            await _page.GotoAsync(_baseURL);
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
                Assert.That(await welcomePage.IsPoweredByElementalSeleniumVisibleAsync(), Is.True);
                var linkVisibilities = await welcomePage.GetExampleLinkVisibilitiesAsync();
                foreach (var isVisible in linkVisibilities)
                {
                    Assert.That(isVisible, Is.True);
                }
            });
        }

        [Test] 
        [TestCaseSource(typeof(WelcomePageLinksTestData), nameof(WelcomePageLinksTestData.LinkTestCases))]
        public async Task WelcomePage_Should_NavigateToExamplePage_When_ExampleLinkIsClicked(string linkText, string expectedRelativePath)
        {
            //Arrange
            var welcomePage = new Pages.WelcomePage(_page);

            //Act
            await welcomePage.ClickExampleLinkAsync(linkText);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            //Assert
            Assert.That(_page.Url, Is.EqualTo(_baseURL + expectedRelativePath));
        }

        [Test]
        public async Task WelcomePage_Should_NavigateToGitHub_When_ForkMeOnGitHubIsClicked()
        {
            //Arrange
            var welcomePage = new Pages.WelcomePage(_page);

            //Act
            await welcomePage.ClickForkMeOnGitHubAsync();
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            //Assert
            Assert.That(_page.Url, Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public async Task WelcomePage_Should_NavigateToElementalSelenium_When_PoweredByElementalSeleniumIsClicked()
        {
            //Arrange
            var welcomePage = new Pages.WelcomePage(_page);

            //Act
            //Catch the new popup window opened by clicking the link
            var popup = await _page.RunAndWaitForPopupAsync(async () =>
            {
                await welcomePage.ClickPoweredByElementalSeleniumAsync();
            });
            await popup.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            //Assert
            Assert.That(popup.Url, Is.EqualTo("https://elementalselenium.com/"));
        }
    }
}
