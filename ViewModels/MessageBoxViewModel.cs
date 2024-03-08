namespace MessageBox.ViewModels;

public class MessageBoxViewModel : ViewModelBase
{
    private string _title;
    private string _message;

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public string Message
    {
        get => _message;
        set => _message = value;
    }
}
