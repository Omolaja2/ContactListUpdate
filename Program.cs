
    Dictionary<string, ContactTolist> contactList = new Dictionary<string, ContactTolist>();

        bool processing = true;
        while (processing)
        {
            Console.WriteLine("\n == Mamzy Contact Manager==");
            Console.WriteLine("1.  Add Contacts");
            Console.WriteLine("2.  Remove Contacts");
            Console.WriteLine("3.  List Contacts");
            Console.WriteLine("4.  Search Contact");
            Console.WriteLine("5.  Update Contact");
            Console.WriteLine("6.  Exit !!");
            Console.WriteLine("Choose An Option");

            string chooseContact = Console.ReadLine()!;

            switch (chooseContact)
            {
                case "1":
                    AddContact(contactList);
                    break;

                case "2":
                    RemoveContact(contactList);
                    break;

                case "3":
                    ListContacts(contactList);
                    break;

                case "4":
                    SearchContact(contactList);
                    break;

                case "5":
                    UpdatContact(contactList);  
                    break;

                case "6":
                    processing = false;
                    Console.WriteLine("Exiting......");
                    break;

                default:
                    Console.WriteLine("Bro, you entered an invalid option");
                    break;
            }
        }
    

    static void AddContact(Dictionary<string, ContactTolist> contactList)
    {
        Console.WriteLine("Enter Name:");
        string name = Console.ReadLine()!;

        if (contactList.ContainsKey(name))
        {
            Console.WriteLine("This contact already exists.");
            return;
        }

        Console.WriteLine("Enter Phone Number:");
        string phoneNumber = Console.ReadLine()!;

        Console.WriteLine("Enter Your Email:");
        string email = Console.ReadLine()!;

        contactList[name] = new ContactTolist(name, phoneNumber, email);
        Console.WriteLine("Contact added successfully!");
    }

    static void RemoveContact(Dictionary<string, ContactTolist> contactList)
    {
        Console.WriteLine("Enter the Name of the contact to be removed:");
        string name = Console.ReadLine()!;

        if (contactList.ContainsKey(name))
        {
            contactList.Remove(name); 
            Console.WriteLine("Contact removed successfully.");
        }
        else
        {
            Console.WriteLine("Contact not found!");
        }
    }

    static void ListContacts(Dictionary<string, ContactTolist> contactList)
    {
        if (contactList.Count == 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            Console.WriteLine("\n == Contact List == ");
            foreach (var contact in contactList)
            {
                Console.WriteLine(contact.Value);
            }
        }
    }

    static void SearchContact(Dictionary<string, ContactTolist> contactList)
    {
        Console.WriteLine("Enter the Name of the contact you want to search:");
        string name = Console.ReadLine()!;

        if (contactList.TryGetValue(name, out ContactTolist? contact))
        {
            Console.WriteLine(contact);  
        }
        else
        {
            Console.WriteLine("Contact not found!");
        }
    }

    
    static void UpdatContact(Dictionary<string, ContactTolist> contactList)
    {
        Console.WriteLine("Eter the Name of the contact you want to update:");
        string name = Console.ReadLine()!;

        if (contactList.ContainsKey(name))
        {
            Console.WriteLine("Contact Seen.... \n Enter New Phone Number You Want To Add ");
            string Telephone = Console.ReadLine()!;
            if (string.IsNullOrEmpty(Telephone))
            {
                Console.WriteLine(Telephone);
            }

            Console.WriteLine("Enter Your  new Email :");
            string email = Console.ReadLine()!;
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine(email);
            }

            
            contactList[name] = new ContactTolist(name, Telephone, email);
            Console.WriteLine(" Gbayi !! Contact updated successfully!");
        }
        else
        {
            Console.WriteLine(" Could  not find Contact o!");
        }
    }


public class ContactTolist
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public ContactTolist(string name, string phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}";
    }
}