using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationTestsTheInternet.Pages
{
    public class DynamicControlsPage
    {
        #region Locators
        private readonly IPage _page;
        private ILocator _dynamicControlsHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Dynamic Controls" });
        private ILocator _dynamicControlsSubheader => _page.GetByText("This example demonstrates");
        private ILocator _removeAddHeader => _page.GetByRole(AriaRole.Heading, new () { Name = "Remove/add" });
        private ILocator _checkbox => _page.GetByRole(AriaRole.Checkbox);
        private ILocator _checkboxText => _page.GetByText("A checkbox");
        private ILocator _removeButton => _page.GetByRole(AriaRole.Button, new() { Name = "Remove" });
        private ILocator _waitingText => _page.GetByText("Wait for it...");
        private ILocator _itsGoneText => _page.GetByText("It's gone!");
        private ILocator _itsBackText => _page.GetByText("It's back!");
        private ILocator _addButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add" });
        private ILocator _enableDisableHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Enable/disable" });
        private ILocator _enableButton => _page.GetByRole(AriaRole.Button, new() { Name = "Enable" });
        private ILocator _disableButton => _page.GetByRole(AriaRole.Button, new() { Name = "Disable" });
        private ILocator _itsEnabledText => _page.GetByText("It's enabled!");
        private ILocator _itsDisabledText => _page.GetByText("It's disabled!");
        private ILocator _inputField => _page.GetByRole(AriaRole.Textbox);
        private ILocator _forkMeOnGitHub => _page.GetByRole(AriaRole.Img, new() { Name = "Fork me on GitHub" });
        private ILocator _poweredByElementalSelenium => _page.Locator("div#page-footer div div");
        #endregion

        public DynamicControlsPage(IPage page)
        {
            _page = page;
        }

        #region Visibility Methods
        public async Task<bool> IsDynamicControlsHeaderVisibleAsync()
        {
            return await _dynamicControlsHeader.IsVisibleAsync();
        }

        public async Task<bool> IsDynamicControlsSubheaderVisibleAsync()
        {
            return await _dynamicControlsSubheader.IsVisibleAsync();
        }

        public async Task<bool> IsRemoveAddHeaderVisibleAsync()
        {
            return await _removeAddHeader.IsVisibleAsync();
        }

        public async Task<bool> IsCheckboxVisibleAsync()
        {
            return await _checkbox.IsVisibleAsync();
        }

        public async Task<bool> IsCheckboxTextVisibleAsync()
        {
            return await _checkboxText.IsVisibleAsync();
        }

        public async Task<bool> IsRemoveButtonVisibleAsync()
        {
            return await _removeButton.IsVisibleAsync();
        }

        public async Task<bool> IsWaitingTextVisibleAsync()
        {
            return await _waitingText.IsVisibleAsync();
        }

        public async Task<bool> IsItsGoneTextVisibleAsync()
        {
            return await _itsGoneText.IsVisibleAsync();
        }

        public async Task<bool> IsAddButtonVisibleAsync()
        {
            return await _addButton.IsVisibleAsync();
        }

        public async Task<bool> IsItsBackTextVisibleAsync()
        {
            return await _itsBackText.IsVisibleAsync();
        }

        public async Task<bool> IsEnableDisableHeaderVisibleAsync()
        {
            return await _enableDisableHeader.IsVisibleAsync();
        }

        public async Task<bool> IsEnableButtonVisibleAsync()
        {
            return await _enableButton.IsVisibleAsync();
        }

        public async Task<bool> IsItsEnabledTextVisibleAsync()
        {
            return await _itsEnabledText.IsVisibleAsync();
        }

        public async Task<bool> IsDisableButtonVisibleAsync()
        {
            return await _enableButton.IsVisibleAsync();
        }

        public async Task<bool> IsItsDisabledTextVisibleAsync()
        {
            return await _itsDisabledText.IsVisibleAsync();
        }

        public async Task<bool> IsInputFieldVisibleAsync()
        {
            return await _inputField.IsVisibleAsync();
        }

        public async Task<bool> IsForkMeOnGitHubVisible()
        {
            return await _forkMeOnGitHub.IsVisibleAsync();
        }

        public async Task<bool> IsPoweredByElementalSeleniumVisibleAsync()
        {
            return await _poweredByElementalSelenium.IsVisibleAsync();
        }
        #endregion

        #region Click Methods
        public async Task ClickRemoveButtonAsync()
        {
            await _removeButton.ClickAsync();
        }

        public async Task ClickAddButtonAsync()
        {
            await _addButton.ClickAsync();
        }

        public async Task ClickCheckboxAsync()
        {
            await _checkbox.ClickAsync();
        }

        public async Task ClickEnableButtonAsync()
        {
            await _enableButton.ClickAsync();
        }

        public async Task ClickDisableButtonAsync()
        {
            await _disableButton.ClickAsync();
        }

        public async Task ClickForkMeOnGitHubAsync()
        {
            await _forkMeOnGitHub.ClickAsync();
        }

        public async Task ClickPoweredByElementalSeleniumAsync()
        {
            await _poweredByElementalSelenium.ClickAsync();
        }
        #endregion

        #region Enabled Methods
        public async Task<bool> IsInputFieldEnabledAsync()
        {
            return await _inputField.IsEnabledAsync();
        }

        public async Task<bool> IsInputFieldDisabledAsync()
        {
            return !await _inputField.IsEnabledAsync();
        }

        public async Task<bool> IsCheckboxCheckedAsync()
        {
            return await _checkbox.IsCheckedAsync();
        }
        #endregion

        #region Enter Text Methods
        public async Task EnterTextInInputFieldAsync(string text)
        {
            await _inputField.FillAsync(text);
        }

        public async Task<string> GetInputFieldTextAsync()
        {
            return await _inputField.InputValueAsync();
        }
        #endregion

        #region Wait Methods

        public async Task WaitForItsGoneTextAsync()
        {
            await _itsGoneText.WaitForAsync();
        }

        public async Task WaitForItsBackTextAsync()
        {
            await _itsBackText.WaitForAsync();
        }

        public async Task WaitForItsEnabledTextAsync()
        {
            await _itsEnabledText.WaitForAsync();
        }

        public async Task WaitForItsDisabledTextAsync()
        {
            await _itsDisabledText.WaitForAsync();
        }

        #endregion
    }
}
