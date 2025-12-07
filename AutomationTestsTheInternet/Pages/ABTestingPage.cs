using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTestsTheInternet.Pages
{
    public class ABTestingPage
    {
        private readonly IPage _page;
        private ILocator abTestHeader => _page.GetByRole(AriaRole.Heading);
        private ILocator splitTestMessage => _page.GetByText("Also known as split testing.");
        private ILocator _forkMeOnGitHub => _page.GetByRole(AriaRole.Img, new() { Name = "Fork me on GitHub" });
        private ILocator _poweredByElementalSelenium => _page.GetByRole(AriaRole.Link, new() { Name = "Elemental Selenium" });

        public ABTestingPage(IPage page)
        {
            _page = page;
        }

        public async Task<string> GetHeaderVariant()
        {
            var header = await abTestHeader.InnerTextAsync();
            return header.Trim();
        }

        public async Task<bool> IsABTestHeaderVisible()
        {
            return await abTestHeader.IsVisibleAsync();
        }

        public async Task<bool> IsSplitTestMessageVisible()
        {
            return await splitTestMessage.IsVisibleAsync();
        }
        public async Task<string> GetSplitTestMessageText()
        {
            return await splitTestMessage.InnerTextAsync();
        }

        public async Task<bool> IsForkMeOnGitHubVisible()
        {
            return await _forkMeOnGitHub.IsVisibleAsync();
        }

        public async Task ClickForkMeOnGitHubAsync()
        {
            await _forkMeOnGitHub.ClickAsync();
        }

        public async Task<bool> IsPoweredByElementalSeleniumVisibleAsync()
        {
            return await _poweredByElementalSelenium.IsVisibleAsync();
        }

        public async Task ClickPoweredByElementalSeleniumAsync()
        {
            await _poweredByElementalSelenium.ClickAsync();
        }
    }
}
