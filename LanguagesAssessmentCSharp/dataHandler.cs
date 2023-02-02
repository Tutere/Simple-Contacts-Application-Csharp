using System;
using System.IO;

namespace LanguagesAssessmentCSharp
{
    public class dataHandler
    {
        private List<Contact> contacts = new List<Contact>();

        public dataHandler()
        {

        }

        public void ReadData()
        {
            contacts.Clear();
            String line;
            try
            {
                StreamReader sr = new StreamReader("/Users/tuteredurie/Projects/LanguagesAssessmentCSharp/LanguagesAssessmentCSharp/contacts.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split('|');
                    string name = parts[0];
                    string phoneNumber = parts[1];
                    string email = parts[2];
                    Contact contact = new Contact(name, phoneNumber, email);
                    contacts.Add(contact);

                    //Read the next line
                    line = sr.ReadLine();

                }
                //close the file
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }


        public void WriteData()
        {
            try
            {
                StreamWriter sw = new StreamWriter("/Users/tuteredurie/Projects/LanguagesAssessmentCSharp/LanguagesAssessmentCSharp/contacts.txt");
           
                foreach (Contact contact in contacts)
                {
                    sw.WriteLine(contact.Name + "|" + contact.PhoneNumber + "|" + contact.Email);
                }
                
                sw.Close();

                }
                catch (Exception e)
                {
                Console.WriteLine("Exception: " + e.Message);
                }
        }


        public List<Contact> GetAll()
         {
            ReadData();
            return contacts;
         }


        public void AddContact(Contact contact)
        {
            ReadData();
            contacts.Add(contact);
            WriteData();

        }


        public Contact GetSpecificContact (string searchName)
        {

            ReadData();
            Contact contact = null;

            foreach (Contact c in contacts)
            {
                if (c.Name.Trim().ToLower() == searchName.Trim().ToLower())
                {
                    return c;
                }
            }

            return contact;
        }


        public string CheckIfNameExists (string name)
        {
            return ""; //no longer needed
        }

        public void DeleteContact (int selection)
        {
            contacts.RemoveAt(selection);
            WriteData();
        }

        public void UpdateContact (int selection, Contact contact)
        {
            Contact contactToUpdate = contacts[selection];
            contactToUpdate.Name = contact.Name;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
            contactToUpdate.Email = contact.Email;

            WriteData();

        }


    }
}


