namespace UI.Core.Interfaces
{
    public interface IPageInterface
    {
        void ClickOn(string cssSelector);
        void WaitUntilVisible(string cssSelector);
        bool IsElementVisible(string cssSelector);
        string GetText(string cssSelector);
    }
}
