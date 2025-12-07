using AutomationTestsTheInternet.Pages;
using AutomationTestsTheInternet.Utilities;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationTestsTheInternet.Pages
{
    internal class BasicAuthPage : BaseTest
    {
        private readonly IPage _page;
        private ILocator _basicAuthHeader => _page.GetByText("Basic Auth");
        private ILocator _congratulationsMessage => _page.GetByText("Congratulations! You must");
        private ILocator _forkMeOnGitHub => _page.GetByRole(AriaRole.Img, new() { Name = "Fork me on GitHub" });
        private ILocator _poweredByElementalSelenium => _page.Locator("div#page-footer div div");
        private ILocator _notAuthorized => _page.GetByText("Not authorized");

        public BasicAuthPage(IPage page)
        {
            _page = page;
        }

        public async Task<bool> IsBasicAuthHeaderVisible()
        {
            return await _basicAuthHeader.IsVisibleAsync();
        }

        public async Task<bool> IsCongratulationsMessageVisible()
        {
            return await _congratulationsMessage.IsVisibleAsync();
        }

        public async Task<bool> IsForkMeOnGitHubVisible()
        {
            return await _forkMeOnGitHub.IsVisibleAsync();
        }

        public async Task<bool> IsPoweredByElementalSeleniumVisibleAsync()
        {
            return await _poweredByElementalSelenium.IsVisibleAsync();
        }

        public async Task<bool> IsNotAuthorizedVisible()
        {
            return await _notAuthorized.IsVisibleAsync();
        }

        public async Task ClickForkMeOnGitHubAsync()
        {
            await _forkMeOnGitHub.ClickAsync();
        }

        public async Task ClickPoweredByElementalSeleniumAsync()
        {
            await _poweredByElementalSelenium.ClickAsync();
        }
    }
}
