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
    public class BasicAuthTests : BaseTest
    {
        [SetUp]
        public async Task Setup()
        {
            await _page.GotoAsync(_baseURL);
        }

        [Test]
        [TestCase("admin", "admin")]
        public async Task BasicAuth_Should_AccessProtectedPage_WithValidCredentials(string username, string password)
        {
            // Arrange
            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = username,
                    Password = password
                }
            });

            var page = await context.NewPageAsync();
            await page.GotoAsync(_baseURL);

            var welcomePage = new WelcomePage(page);
            await welcomePage.ClickExampleLinkAsync("Basic Auth");

            // Act
            var basicAuthPage = new BasicAuthPage(page);

            // Assert
            Assert.That(page.Url, Is.EqualTo(_baseURL + "basic_auth"));
            Assert.That(await basicAuthPage.IsBasicAuthHeaderVisible(), Is.True);
            Assert.That(await basicAuthPage.IsCongratulationsMessageVisible(), Is.True);
            Assert.That(await basicAuthPage.IsForkMeOnGitHubVisible(), Is.True);
            Assert.That(await basicAuthPage.IsPoweredByElementalSeleniumVisibleAsync(), Is.True);
            var content = await page.TextContentAsync("div.example p");
            Assert.That(content, Does.Contain("Congratulations! You must have the proper credentials."));

            await page.CloseAsync();
            await context.CloseAsync();
        }

        [Test]
        [TestCase("invalidUser", "invalidPass")]
        public async Task BasicAuth_Should_DenyAccess_WithInvalidCredentials(string username, string password)
        {
            // Arrange
            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = username,
                    Password = password
                }
            });
            var page = await context.NewPageAsync();
            await page.GotoAsync(_baseURL);
            var welcomePage = new WelcomePage(page);
            await welcomePage.ClickExampleLinkAsync("Basic Auth");

            // Act
            var basicAuthPage = new BasicAuthPage(page);

            // Assert
            Assert.That(await basicAuthPage.IsNotAuthorizedVisible(), Is.True);
            await page.CloseAsync();
            await context.CloseAsync();
        }

        [Test]
        [TestCase("admin", "admin")]
        public async Task BasicAuthPage_Should_NavigateToGitHub_When_ForkMeOnGitHubIsClicked(string username, string password)
        {
            // Arrange
            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = username,
                    Password = password
                }
            });

            var page = await context.NewPageAsync();
            await page.GotoAsync(_baseURL);

            var welcomePage = new WelcomePage(page);
            await welcomePage.ClickExampleLinkAsync("Basic Auth");

            // Act
            var basicAuthPage = new BasicAuthPage(page);
            await basicAuthPage.ClickForkMeOnGitHubAsync();

            // Assert
            Assert.That(page.Url, Is.EqualTo("https://github.com/saucelabs/the-internet"));
        }

        [Test]
        [TestCase("admin", "admin")]
        public async Task BasicAuthPage_Should_NavigateToElementalSelenium_When_PoweredByElementalSeleniumIsClicked(string username, string password)
        {
            // Arrange
            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = username,
                    Password = password
                }
            });

            var page = await context.NewPageAsync();
            await page.GotoAsync(_baseURL);

            var welcomePage = new WelcomePage(page);
            await welcomePage.ClickExampleLinkAsync("Basic Auth");

            // Act
            var basicAuthPage = new BasicAuthPage(page);

            // Catch the new popup window opened by clicking the link
            var popup = await page.RunAndWaitForPopupAsync(async () =>
            {
                await basicAuthPage.ClickPoweredByElementalSeleniumAsync();
            });
            await popup.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Assert
            Assert.That(popup.Url, Is.EqualTo("https://elementalselenium.com/"));
        }
    }
}
