using System;

class Program
{
    static CustomerDatabase customerDatabase;
    private const string path = "customers.csv";

    static void Main()
    {
        List<Customer> customerData = FileHelper.ReadFromFile(path);
        if (customerData == null)
        {
            customerDatabase = new CustomerDatabase();
        }
        else
        {
            customerDatabase = new CustomerDatabase(customerData);
        }
        Console.WriteLine("Welcome to the Customer Database!");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a customer");
            Console.WriteLine("2. Update a customer");
            Console.WriteLine("3. Delete a customer");
            Console.WriteLine("4. Show all customers");
            Console.WriteLine("5. Undo");
            Console.WriteLine("6. Redo");
            Console.WriteLine("7. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    UpdateCustomer();
                    break;
                case "3":
                    DeleteCustomer();
                    break;
                case "4":
                    ShowAllCustomers();
                    break;
                case "5":
                    Undo();
                    break;
                case "6":
                    Redo();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddCustomer()
    {
        Console.WriteLine("Enter customer details:");

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();
        Customer newCustomer = new Customer(id, firstName, lastName, email, address);
        customerDatabase.AddCustomer(newCustomer);
    }

    static void UpdateCustomer()
    {
        Console.WriteLine("Enter the ID of the customer to update:");
        int id = int.Parse(Console.ReadLine());

        Customer existingCustomer = customerDatabase.SearchCustomerById(id);
        if (existingCustomer != null)
        {
            Console.WriteLine("Enter updated customer details:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();
            Customer updatedCustomer = new Customer(id, firstName, lastName, email, address);
            customerDatabase.UpdateCustomer(updatedCustomer);
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    static void DeleteCustomer()
    {
        Console.WriteLine("Enter the ID of the customer to delete:");
        int id = int.Parse(Console.ReadLine());

        customerDatabase.DeleteCustomer(id);
    }

    static void ShowAllCustomers()
    {
        Console.WriteLine("All Customers:");

        var customers = customerDatabase.GetCustomers();

        if (customers.Count == 0)
        {
            Console.WriteLine("No customers found.");
        }
        else
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Address: {customer.Address}");
            }
        }
    }

    static void Undo()
    {
        customerDatabase.Undo();
    }

    static void Redo()
    {
        customerDatabase.Redo();
    }
}
