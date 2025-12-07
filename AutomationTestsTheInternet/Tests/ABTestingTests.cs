using AutomationTestsTheInternet.Pages;
using AutomationTestsTheInternet.Utilities;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTestsTheInternet.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class ABTestingTests : BaseTest
    {
        [SetUp]
        public async Task Setup()
        {
            await _page.GotoAsync(_baseURL);
        }

        [Test]
        public async Task ABTesting_Should_DisplayCorrectVariantElements()
        {
            // Arrange
            var welcomePage = new WelcomePage(_page);
            var abTestingPage = new ABTestingPage(_page);

            // Act
            await welcomePage.ClickExampleLinkAsync("A/B Testing");
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            var headerVariant = await abTestingPage.GetHeaderVariant();

            // Assert
            Assert.Multiple(async () =>
            {
                Assert.That(await abTestingPage.IsABTestHeaderVisible(), Is.True);
                Assert.That(await abTestingPage.IsSplitTestMessageVisible(), Is.True);
                Assert.That(await abTestingPage.IsForkMeOnGitHubVisible(), Is.True);
                Assert.That(await abTestingPage.IsPoweredByElementalSeleniumVisibleAsync(), Is.True); 
                var splitTestMessageText = await abTestingPage.GetSplitTestMessageText();
                Assert.That(splitTestMessageText, Does.Contain("Also known as split testing.")); 

                if (headerVariant == "A/B Test Control")
                {
                    Assert.That(headerVariant, Is.EqualTo("A/B Test Control"));
                }
                else if (headerVariant == "A/B Test Variation 1")
                {
                    Assert.That(headerVariant, Is.EqualTo("A/B Test Variation 1"));
                }
                else
                {
                    Assert.Fail("Unexpected header variant encountered.");
                }
            });
        }

        [Test]
        public async Task ABTesting_Should_NavigateToGitHub_When_ForkMeOnGitHubIsClicked()
        {
            // Arrange
            var welcomePage = new WelcomePage(_page);
            var abTestingPage = new ABTestingPage(_page);

            // Act
            await welcomePage.ClickExampleLinkAsync("A/B Testing");
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await abTestingPage.ClickForkMeOnGitHubAsync();

            // Assert
            Assert.That(_page.Url, Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public async Task ABTesting_Should_NavigateToElementalSelenium_When_PoweredByElementalSeleniumIsClicked()
        {
            // Arrange
            var welcomePage = new WelcomePage(_page);
            var abTestingPage = new Pages.ABTestingPage(_page);

            // Act
            await welcomePage.ClickExampleLinkAsync("A/B Testing");
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Catch the new popup window opened by clicking the link
            var popup = await _page.RunAndWaitForPopupAsync(async () =>
            {
                await abTestingPage.ClickPoweredByElementalSeleniumAsync();
            });
            await popup.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Assert
            Assert.That(popup.Url, Is.EqualTo("https://elementalselenium.com/"));
        }
    }
}
