namespace UI.Core.Interfaces
{
    public interface IPageInterface
    {
        string Title { get; }

        void PressOnKeyboard(string cssSelector, string key);
        void ClickOn(string cssSelector);

        void Wait(double seconds);
        void WaitUntilExists(string cssSelector);
        void WaitUntilVisible(string cssSelector);
        void WaitUntilNotVisible(string cssSelector);

        bool IsElementVisible(string cssSelector);
        bool IsElementContainsText(string cssSelector, string record);

        void InputText(string cssSelector, string text);
    }
}
