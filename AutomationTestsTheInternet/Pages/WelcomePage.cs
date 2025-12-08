using AutomationTestsTheInternet.Utilities;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace AutomationTestsTheInternet.Pages
{
    internal class WelcomePage : BaseTest
    {
        private readonly IPage _page;
        private ILocator _welcomeBanner => _page.GetByRole(AriaRole.Heading, new() { Name = "Welcome to the-internet" });
        private ILocator _availableExamples => _page.GetByRole(AriaRole.Heading, new() { Name = "Available Examples" });
        private ILocator _allExampleLinks => _page.Locator("ul li a");
        private ILocator _forkMeOnGitHub => _page.GetByRole(AriaRole.Img, new() { Name = "Fork me on GitHub" });
        private ILocator _poweredByElementalSelenium => _page.Locator("div#page-footer div div");

        public WelcomePage(IPage page)
        {
            _page = page;
        }

        public async Task<bool> IsWelcomeBannerVisible()
        {
            return await _welcomeBanner.IsVisibleAsync();
        }

        public async Task<bool> IsAvailableExamplesVisible()
        {
            return await _availableExamples.IsVisibleAsync();
        }

        public async Task<int> GetAllExampleLinksCount()
        {
            return await _allExampleLinks.CountAsync();
        }

        public async Task<IReadOnlyList<bool>> GetExampleLinkVisibilitiesAsync()
        {
            int count = GetAllExampleLinksCount().Result;
            var visibleList = new List<bool>();

            for (int i = 0; i < count; i++)
            {
                visibleList.Add(await _allExampleLinks.Nth(i).IsVisibleAsync());
            }

            return visibleList;
        }

        public async Task ClickExampleLinkAsync(string linkText)
        {
            var linkLocator = _allExampleLinks.Filter(new() { HasTextString = linkText });
            if (await linkLocator.CountAsync() == 0)
            {
                throw new Exception($"Link with text '{linkText}' not found on the Welcome Page.");
            } else if (linkLocator.CountAsync().Result > 1)
            {
                linkLocator = linkLocator.Nth(0);
            }
                await linkLocator.ClickAsync();
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
