using AddressesApp.Models;

namespace AddressesApp.Views;
using Contact = AddressesApp.Models.Contact;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");

    }

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {
        Contact newContact = new Contact()
        {
            Name = contactCtrl.Name, Color = contactCtrl.Color, Email = contactCtrl.Email
        };
        
        ContactRepository.AddContact(newContact);
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {

    }

    private void contactCtrl_onError(object sender, string e)
    {
        DisplayAlert("Error", e.ToString(), "OK");
    }
}