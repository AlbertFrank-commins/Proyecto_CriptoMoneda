using System;

public interface ICoinDescriptionView
{
    event EventHandler<string> OnRequestDescription;
    event EventHandler OnCancel;

    void ShowDescription(string description);
    void ShowMessage(string msg);
}

