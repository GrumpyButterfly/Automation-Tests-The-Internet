using AutomationTestsTheInternet.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTestsTheInternet.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class DynamicControlsTests : BaseTest
    {
        [SetUp]
        public async Task Setup()
        {
            await _page.GotoAsync(_baseURL + "dynamic_controls");
        }

        [Test]
        public async Task DynamicControlsPage_Should_LoadAndDisplayAllVisibleElements()
        {
            // Arrange
            var dynamicControlsPage = new Pages.DynamicControlsPage(_page);

            // Act & Assert
            Assert.Multiple(async () =>
            {
                Assert.That(await dynamicControlsPage.IsDynamicControlsHeaderVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsDynamicControlsSubheaderVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsRemoveAddHeaderVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsCheckboxVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsCheckboxTextVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsRemoveButtonVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsEnableDisableHeaderVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsEnableButtonVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsInputFieldVisibleAsync(), Is.True);
                Assert.That(await dynamicControlsPage.IsForkMeOnGitHubVisible(), Is.True);
                Assert.That(await dynamicControlsPage.IsPoweredByElementalSeleniumVisibleAsync(), Is.True);
            });
        }

        [Test]
        public async Task DynamicControlsPage_Should_RemoveAndAddCheckbox_When_RemoveAndAddButtonsAreClicked()
        {
            // Arrange
            var dynamicControlsPage = new Pages.DynamicControlsPage(_page);

            // Act & Assert
            Assert.That(await dynamicControlsPage.IsCheckboxVisibleAsync(), Is.True);
            await dynamicControlsPage.ClickRemoveButtonAsync();
            await dynamicControlsPage.WaitForItsGoneTextAsync();
            Assert.That(await dynamicControlsPage.IsItsGoneTextVisibleAsync(), Is.True);
            Assert.That(await dynamicControlsPage.IsCheckboxVisibleAsync(), Is.False);
            await dynamicControlsPage.ClickAddButtonAsync();
            await dynamicControlsPage.WaitForItsBackTextAsync();
            Assert.That(await dynamicControlsPage.IsItsBackTextVisibleAsync(), Is.True);
            Assert.That(await dynamicControlsPage.IsCheckboxVisibleAsync(), Is.True);
        }

        [Test]
        public async Task DynamicControlsPage_Should_EnableAndDisableInputField_When_EnableAndDisableButtonsAreClicked()
        {
            // Arrange
            var dynamicControlsPage = new Pages.DynamicControlsPage(_page);

            // Act & Assert
            Assert.That(await dynamicControlsPage.IsInputFieldEnabledAsync(), Is.False);
            await dynamicControlsPage.ClickEnableButtonAsync();
            await dynamicControlsPage.WaitForItsEnabledTextAsync();
            Assert.That(await dynamicControlsPage.IsInputFieldEnabledAsync(), Is.True);
            Assert.That(await dynamicControlsPage.IsItsEnabledTextVisibleAsync(), Is.True);
            await dynamicControlsPage.ClickDisableButtonAsync();
            await dynamicControlsPage.WaitForItsDisabledTextAsync();
            Assert.That(await dynamicControlsPage.IsInputFieldEnabledAsync(), Is.False);
            Assert.That(await dynamicControlsPage.IsItsDisabledTextVisibleAsync(), Is.True);
        }

        [Test]
        public async Task DynamicControlsPage_Should_SelectCheckbox_When_Clicked()
        {
            // Arrange
            var dynamicControlsPage = new Pages.DynamicControlsPage(_page);

            // Act & Assert
            Assert.That(await dynamicControlsPage.IsCheckboxVisibleAsync(), Is.True);
            Assert.That(await dynamicControlsPage.IsCheckboxCheckedAsync(), Is.False);
            await dynamicControlsPage.ClickCheckboxAsync();
            Assert.That(await dynamicControlsPage.IsCheckboxCheckedAsync(), Is.True);
            await dynamicControlsPage.ClickCheckboxAsync();
            Assert.That(await dynamicControlsPage.IsCheckboxCheckedAsync(), Is.False);
        }

        [Test]
        public async Task DynamicControlsPage_Should_AllowTypingInput_When_TextboxIsEnabled()
        {
            // Arrange
            var dynamicControlsPage = new Pages.DynamicControlsPage(_page);
            var testInput = "Playwright Test Input";

            // Act & Assert
            Assert.That(await dynamicControlsPage.IsInputFieldEnabledAsync(), Is.False);
            await dynamicControlsPage.ClickEnableButtonAsync();
            await dynamicControlsPage.WaitForItsEnabledTextAsync();
            Assert.That(await dynamicControlsPage.IsItsEnabledTextVisibleAsync(), Is.True);
            Assert.That(await dynamicControlsPage.IsInputFieldEnabledAsync(), Is.True);
            await dynamicControlsPage.EnterTextInInputFieldAsync(testInput);
            var inputValue = await dynamicControlsPage.GetInputFieldTextAsync();
            Assert.That(inputValue, Is.EqualTo(testInput));
            await dynamicControlsPage.ClickDisableButtonAsync();
            await dynamicControlsPage.WaitForItsDisabledTextAsync();
            Assert.That(await dynamicControlsPage.IsItsDisabledTextVisibleAsync(), Is.True);
            Assert.That(await dynamicControlsPage.IsInputFieldEnabledAsync(), Is.False);
            var disabledInputValue = await dynamicControlsPage.GetInputFieldTextAsync();
            Assert.That(disabledInputValue, Is.EqualTo(testInput));
        }
    }
}
