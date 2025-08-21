public interface ICoinDescriptionView
{
    event EventHandler<string> OnRequestDescription;
    event EventHandler OnCancel;

    void ShowMessage(string message);
    void ShowDescription(string description);
    void UpdateProgress(int value);
    void ToggleLoading(bool isLoading);
}




