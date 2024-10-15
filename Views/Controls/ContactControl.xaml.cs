namespace AddressesApp.Views.Controls;

public partial class ContactControl : ContentView
{
    public event EventHandler<string> onError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

    public ContactControl()
    {
        InitializeComponent();
    }

    public string Name
    {
        get
        {
            return nameEntry.Text;
        }

        set
        {
            nameEntry.Text = value;
        }
    }

    public string Email
    {
        get
        {
            return emailEntry.Text;
        }

        set
        {
            emailEntry.Text = value;
        }
    }

    public string Color
    {
        get
        {
            return colorEntry.Text;
        }

        set
        {
            colorEntry.Text = value;
        }
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            onError?.Invoke(sender, "Name is required");
            //await DisplayAlert("Error", "Name is required", "OK");
 
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                onError?.Invoke(sender, error.ToString());
                //await DisplayAlert("Error", error.ToString(), "OK");
            }
            return;
        }

        OnSave?.Invoke(sender, e);
    }


    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}