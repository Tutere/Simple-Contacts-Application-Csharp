// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;
using LanguagesAssessmentCSharp;
using static System.Collections.Specialized.BitVector32;

internal class UI
{

    public static List<Contact> contacts = new List<Contact>();
    public static dataHandler dataHandler = new dataHandler();


    private static int MenuSelection ()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Welcome to the contact list menu, what would you like to do?");
        Console.WriteLine();

        Console.WriteLine("1: View full list of contacts");
        Console.WriteLine("2: Add new contact");
        Console.WriteLine("3: Delete a contact");
        Console.WriteLine("4: Update a contact");
        Console.WriteLine("5: Search for a contact");
        Console.WriteLine("6: Quit the application");
        Console.WriteLine();



        while (true)
        {
            Console.WriteLine("Enter a number corresponding to the above menu and then press ENTER");
            Console.WriteLine();
            string selection = Console.ReadLine();
            Console.WriteLine();

            try
            {
                int selectionToInt = Convert.ToInt32(selection);

                if (selectionToInt < 7 && selectionToInt > 0)
                {
                    return selectionToInt;
                }
                
                else
                {
                    Console.WriteLine("Sorry that number does not exist in the above menu, please choose again");
                    Console.WriteLine();
                }                   
            }  
            catch (Exception e)
            {
                Console.WriteLine("Sorry, " + selection + " is not a number. Please choose a number from the menu");
                Console.WriteLine("Exception: " + e.Message);
            } 
        }
    }



    public static void ViewAllContacts ()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Full contacts list");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();

        contacts = dataHandler.GetAll();

        if (contacts.Count != 0)
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
                
        else
        {
            Console.WriteLine("You do not have any contacts yet!");
            Console.WriteLine();
        }
        Console.WriteLine();
    }


    public static void AddNewContact ()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Add a new contact");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();

        string name;
        while (true)
        {
            Console.WriteLine("please enter a name and then press the ENTER key to submit");
            name = Console.ReadLine();
            Console.WriteLine();


            if (name.Length != 0)
            {
                break;
            } else
            {
                Console.WriteLine("Sorry, no name was entered, please enter a name of at least one character");
                Console.WriteLine();
            }
        }
        Console.WriteLine("Now please enter a phone number.");
        Console.WriteLine("If you wish to leave the phone number empty, just press ENTER");
        string phoneNumber = Console.ReadLine();


        Console.WriteLine();
        Console.WriteLine("Now please enter an email address.");
        Console.WriteLine("If you wish to leave the email address empty, just press ENTER");
        string email = Console.ReadLine();
        Console.WriteLine();

        Contact contact;

        if (email =="" && phoneNumber =="")
        {
            contact = new Contact(name, "no number supplied", "no email supplied");
        } else if (email == "" && phoneNumber != "")
         {
            contact = new Contact(name, phoneNumber, "no email supplied");
        }
        else if (email != "" && phoneNumber == "")
        {
            contact = new Contact(name, "no number supplied", email);
        } else
        {
            contact = new Contact(name, phoneNumber, email);
        }

        dataHandler.AddContact(contact);

    }


    public static void DeleteContact ()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Delete a contact");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();

        contacts = dataHandler.GetAll();

        for (int i = 0; i<contacts.Count; i++)
        {
            Console.WriteLine(i+": " + contacts[i].ToString());
        }

        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Select the number of the contact you would like to delete and press ENTER");
        Console.WriteLine();

        string inputString = Console.ReadLine();
        int selection = Convert.ToInt32(inputString);

        if (selection >=0 && selection <= contacts.Count)
        {
            Console.WriteLine("contact: " + contacts[selection].Name + " has been deleted");
            dataHandler.DeleteContact(selection);
            Console.WriteLine();
        } else
        {
            Console.WriteLine("selection invalid, no contacts have been deleted");
            Console.WriteLine();
        }

    }

    public static void UpdateContact ()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Update a contact");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();

        contacts = dataHandler.GetAll();

        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine(i + ": " + contacts[i].ToString());
        }

        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Select the number of the contact you would like to update and press ENTER");
        Console.WriteLine();

        while (true)
        {
            string inputString = Console.ReadLine();
            int selection = Convert.ToInt32(inputString);

            if (selection >= 0 && selection <= contacts.Count)
            {

                Contact contact = contacts[selection];
                Console.WriteLine("contact to update is:");
                Console.WriteLine(contact);
                Console.WriteLine();

                Console.WriteLine("Please enter a new name and press the ENTER key to submit");
                Console.WriteLine("If you don't wish to change the name, just press ENTER");
                Console.WriteLine();
                string name = Console.ReadLine();
                Console.WriteLine();

                if (name.Length == 0)
                {
                    Console.WriteLine("Ok, name will not be changed");
                    Console.WriteLine();
                } else
                {
                    Console.WriteLine("Thanks, name will be changed to: " + name);
                    Console.WriteLine();
                    contact.Name = name;
                }

                Console.WriteLine("Now please enter a phone number.");
                Console.WriteLine("If you wish to leave the phone number empty, just press ENTER");
                Console.WriteLine();
                string phoneNumber = Console.ReadLine();
                Console.WriteLine();

                if (phoneNumber.Length == 0)
                {
                    Console.WriteLine("Ok, phone number will not be changed");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Thanks, phone number will be changed to: " + phoneNumber);
                    Console.WriteLine();
                    contact.PhoneNumber = phoneNumber;
                }

                Console.WriteLine("Now please enter an email address.");
                Console.WriteLine("If you wish to leave the email address empty, just press ENTER\"");
                Console.WriteLine();
                string email = Console.ReadLine();
                Console.WriteLine();

                if (email.Length == 0)
                {
                    Console.WriteLine("Ok, email will not be changed");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Thanks, email will be changed to: " + email);
                    Console.WriteLine();
                    contact.Email = email;
                }


                dataHandler.UpdateContact(selection, contact);
                break;

            } else
            {
                Console.WriteLine("selection invalid, please re-enter");
                Console.WriteLine();
            }
        }
    }


    public static void SearchForContact()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Search for a contact");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Please enter a name to search for");
        Console.WriteLine();
        string inputName = Console.ReadLine();
        Console.WriteLine();

        Contact contact = dataHandler.GetSpecificContact(inputName);

        if (contact is null)
        {
            Console.WriteLine("Sorry, no contacts exist with that name");
            Console.WriteLine();
        } else
        {
            Console.WriteLine("Contact found! Here are their details:");
            Console.WriteLine(contact.ToString());
            Console.WriteLine();
        }

    }




    static void Main(string[] args)
    {
        bool session = true;


        while (session)
        {
            int selection = MenuSelection();

            switch (selection)
            {
                case 1:
                    ViewAllContacts();
                    break;
                case 2:
                    AddNewContact();
                    break;
                case 3:
                    DeleteContact();
                    break;
                case 4:
                    UpdateContact();
                    break;
                case 5:
                    SearchForContact();
                    break;
                case 6:
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine("Thanks for using the contacts viewer, goodbye :)");
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine();
                    session = false;
                    break;
            }
        }




    }


}

