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
    public class AddRemoveElementsTests : BaseTest
    {
        [SetUp]
        public async Task Setup()
        {
            await _page.GotoAsync(_baseURL);
        }

        [Test]
        public async Task AddRemoveElements_Should_AddAndRemoveElementsCorrectly()
        {
            // Arrange
            var welcomePage = new WelcomePage(_page);
            var addRemoveElementsPage = new AddRemoveElementsPage(_page);

            // Act
            await welcomePage.ClickExampleLinkAsync("Add/Remove Elements");
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Assert
            Assert.Multiple(async () =>
            {
                Assert.That(await addRemoveElementsPage.IsAddRemoveElementsHeaderVisible(), Is.True);
                Assert.That(await addRemoveElementsPage.IsAddElementButtonVisible(), Is.True);
                Assert.That(await addRemoveElementsPage.GetDeleteElementButtonsCountAsync(), Is.EqualTo(0));
                await addRemoveElementsPage.ClickAddElementButtonAsync();
                Assert.That(await addRemoveElementsPage.GetDeleteElementButtonsCountAsync(), Is.EqualTo(1));
                await addRemoveElementsPage.ClickAddElementButtonAsync();
                Assert.That(await addRemoveElementsPage.GetDeleteElementButtonsCountAsync(), Is.EqualTo(2));
                await addRemoveElementsPage.ClickDeleteButtonAsync();
                Assert.That(await addRemoveElementsPage.GetDeleteElementButtonsCountAsync(), Is.EqualTo(1));
                await addRemoveElementsPage.ClickDeleteButtonAsync();
                Assert.That(await addRemoveElementsPage.GetDeleteElementButtonsCountAsync(), Is.EqualTo(0));
                Assert.That(await addRemoveElementsPage.IsForkMeOnGitHubVisible(), Is.True);
                Assert.That(await addRemoveElementsPage.IsPoweredByElementalSeleniumVisibleAsync(), Is.True);
            });
        }

        [Test]
        public async Task AddRemoveElements_Should_NavigateToGitHub_When_ForkMeOnGitHubIsClicked()
        {
            // Arrange
            var welcomePage = new WelcomePage(_page);
            var addRemoveElementsPage = new AddRemoveElementsPage(_page);

            // Act
            await welcomePage.ClickExampleLinkAsync("Add/Remove Elements");
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await addRemoveElementsPage.ClickForkMeOnGitHubAsync();
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Assert
            Assert.That(_page.Url, Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        public async Task AddRemoveElements_Should_NavigateToElementalSelenium_When_PoweredByElementalSeleniumIsClicked()
        {
            // Arrange
            var welcomePage = new WelcomePage(_page);
            var addRemoveElementsPage = new AddRemoveElementsPage(_page);
            // Act
            await welcomePage.ClickExampleLinkAsync("Add/Remove Elements");
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Catch the new popup window opened by clicking the link
            var popup = await _page.RunAndWaitForPopupAsync(async () =>
            {
                await addRemoveElementsPage.ClickPoweredByElementalSeleniumAsync();
            });
            await popup.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Assert
            Assert.That(popup.Url, Is.EqualTo("https://elementalselenium.com/"));
        }
    }
}
