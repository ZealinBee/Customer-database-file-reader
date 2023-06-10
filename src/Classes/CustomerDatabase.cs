class CustomerDatabase
{
    private List<Customer> _customers;

    public CustomerDatabase(List<Customer> customers = null)
    {
        _customers = customers ?? new List<Customer>();
    }

    public void AddCustomer(Customer customer)
    {
        if (_customers.Find(c => c.Email == customer.Email) != null)
        {
            Console.WriteLine($"Failed to add email because {customer.Email} already exists");
        }
        else
        {
            _customers.Add(customer);
            Console.WriteLine($"Customer with the email of {customer.Email} added successfully");
        }
    }

    public List<Customer> GetCustomers()
    {
        return _customers;
    }

    public void UpdateCustomer(Customer customerToUpdate)
    {
        Customer existingCustomer = SearchCustomerById(customerToUpdate.Id);
        if (existingCustomer != null)
        {
            Customer updatedCustomer = new Customer(existingCustomer.Id, customerToUpdate.FirstName, customerToUpdate.LastName, customerToUpdate.Email, customerToUpdate.Address);
            int index = _customers.IndexOf(existingCustomer);
            _customers[index] = updatedCustomer;
            Console.WriteLine($"Customer with the Id of {customerToUpdate.Id} updated successfully");
        }
        else
        {
            Console.WriteLine("Failed to update, customer not found");
        }

    }

    public void DeleteCustomer(int id)
    {
        Customer customerToDelete = SearchCustomerById(id);
        if (customerToDelete != null)
        {
            _customers.Remove(customerToDelete);
        }
        else
        {
            Console.WriteLine("Delete failed, customer don't exist");
        }
    }

    public Customer SearchCustomerById(int id)
    {
        return _customers.Find(customer => customer.Id == id);
    }
}