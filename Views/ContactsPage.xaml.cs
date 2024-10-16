using AddressesApp.Models;
using CommunityToolkit.Maui.Core.Extensions;
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
        RefreshContactList();
       // ObservableCollection<Contact> contacts = new ObservableCollection<Contact>(ContactRepository.GetAllContacts());

       // nameList.ItemsSource = contacts;
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

    private void Delete_Clicked(object sender, EventArgs e)
    {
        MenuItem menuItem = (MenuItem)sender;
        Contact contact = (Contact)menuItem.CommandParameter;
        ContactRepository.DeleteContact(contact.ContactId);
        RefreshContactList();
        DisplayAlert("xxx", $"Contact {contact.ContactId} deleted successfully", "OK");
       
    }

    private void RefreshContactList()
    {
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>(ContactRepository.GetAllContacts());

        nameList.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = ((SearchBar)sender).Text;
        ObservableCollection<Contact> contacts = ContactRepository.SearchContacts(searchText).ToObservableCollection();
        nameList.ItemsSource = contacts;
    }
}