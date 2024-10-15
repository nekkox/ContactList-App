using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressesApp.Models
{
    public static class ContactRepository
    {

        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact {ContactId = 1, Name = "Name1", Email = "name1@gmail.com", Color = "red" },
            new Contact {ContactId = 2, Name = "Name2", Email="name2@gmail.com" , Color = "blue"},
            new Contact {ContactId = 3, Name = "Name3", Email="name3@gmail.com", Color = "black"},
            new Contact {ContactId = 4, Name = "Name4", Email="name4@gmail.com", Color = "white"},
        };

        public static List<Contact> GetAllContacts()
        {
            return _contacts;
        }
        public static Contact GetContactById(int? contactId)
        {
            if (contactId is null)
            {
                throw new ArgumentNullException(nameof(contactId));
            }

            Contact contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return new Contact 
                { 
                    ContactId = contact.ContactId,
                    Name = contact.Name, 
                    Email = contact.Email, 
                    Color = contact.Color 
                };
            }
            return null;
        }

        public static bool UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId)
            {
                return false;
            }

            Contact? contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null) 
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Color = contact.Color;
                return true;
            }

               

            return false;
        }
    }
}
