using AddressesApp.Models;
using System.Collections.ObjectModel;

namespace AddressesApp.Views;
using Contact = AddressesApp.Models.Contact;


public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

        //List<Contact> contacts = ContactRepository.GetAllContacts();

        //nameList.ItemsSource = contacts;
       
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>(ContactRepository.GetAllContacts());

        nameList.ItemsSource = contacts;
    }

    private async void nameList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (nameList.SelectedItem != null)
        {

            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)nameList.SelectedItem).ContactId}");
        }

    }

    private void nameList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        // DisplayAlert("tapped", $"{((Contact)e.Item).Name} tapped", "ok");
        nameList.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}