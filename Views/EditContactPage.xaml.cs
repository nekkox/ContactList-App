namespace AddressesApp.Views;
using System;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using Contact = AddressesApp.Models.Contact;
using AddressesApp.Models;
using System.Xml.Linq;
using Microsoft.Maui.ApplicationModel.Communication;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact _contact;
    public EditContactPage()
    {
        InitializeComponent();
        //DisplayAlert("xxx",$"{_contact.ContactId}", "xxx");
        
    }


    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    
    public string ContactId
    {
        set
        {
            _contact = ContactRepository.GetContactById(int.Parse(value));
            //lblName.Text = _contact.Email;
            if (_contact != null)
            {
                //nameEntry.Text = _contact.Name;
                contactCtrl.Name = _contact.Name;
                // emailEntry.Text = _contact.Email;
                contactCtrl.Email = _contact.Email;
                //colorEntry.Text = _contact.Color;
                contactCtrl.Color = _contact.Color;
            }
            //DisplayAlert("xxxx", $"{value}", "ok");
            
        }
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        //if (nameValidator.IsNotValid)
        //{
        //    await DisplayAlert("Error", "Name is required", "OK");
        //    return;
        //}

        //if (emailValidator.IsNotValid)
        //{
        //    foreach(var error in emailValidator.Errors)
        //    {
        //        await DisplayAlert("Error", error.ToString(), "OK");
        //    }
        //    return;
        //}

        //_contact.Name = nameEntry.Text;
        //_contact.Email = emailEntry.Text;
        // _contact.Color = colorEntry.Text;
        _contact.Name = contactCtrl.Name;
        _contact.Email = contactCtrl.Email;
        _contact.Color = contactCtrl.Color;
        ContactRepository.UpdateContact(_contact.ContactId, _contact);
        
        await Shell.Current.GoToAsync("..");
        
    }

    private void contactCtrl_onError(object sender, string e)
    {
        DisplayAlert("Error", e.ToString(), "ok");
    }
}