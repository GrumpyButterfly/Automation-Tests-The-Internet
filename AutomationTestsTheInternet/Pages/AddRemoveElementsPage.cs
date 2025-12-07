using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTestsTheInternet.Pages
{
    public class AddRemoveElementsPage
    {
        private readonly IPage _page;
        private ILocator addRemoveElementsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Add/Remove Elements" });
        private ILocator addElementButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add Element" });
        private ILocator deleteElementButton => _page.GetByRole(AriaRole.Button, new() { Name = "Delete" });
        private ILocator _forkMeOnGitHub => _page.GetByRole(AriaRole.Img, new() { Name = "Fork me on GitHub" });
        private ILocator _poweredByElementalSelenium => _page.GetByRole(AriaRole.Link, new() { Name = "Elemental Selenium" });

        public AddRemoveElementsPage(IPage page)
        {
            _page = page;
        }

        public async Task<bool> IsAddRemoveElementsHeaderVisible()
        {
            return await addRemoveElementsHeader.IsVisibleAsync();
        }

        public async Task<bool> IsAddElementButtonVisible()
        {
            return await addElementButton.IsVisibleAsync();
        }

        public async Task ClickAddElementButtonAsync()
        {
            await addElementButton.ClickAsync();
        }

        public async Task<bool> IsDeleteButtonVisible()
        {
            return await deleteElementButton.IsVisibleAsync();

        }

        public async Task<int> GetDeleteElementButtonsCountAsync()
        {
            return await deleteElementButton.CountAsync();
        }

        public async Task ClickDeleteButtonAsync()
        {
            if (deleteElementButton.CountAsync().Result > 1)
            {
                await deleteElementButton.First.ClickAsync();
            }
            else
            {
                await deleteElementButton.ClickAsync();
            }
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
