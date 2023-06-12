class CustomerDatabase
{
    private List<Customer> _customers;
    static string path = "customers.csv";
    private static Stack<Action> _redoStack = new Stack<Action>();
    private static Stack<Action> _undoStack = new Stack<Action>();

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
            Action addAction = new Action(() =>
            {
                _customers.Remove(customer);
                FileHelper.WriteFile(path, _customers);
                Console.WriteLine($"Undo: Customer with the email {customer.Email} removed");
            });
            _undoStack.Push(addAction);
            _redoStack.Clear();
            _customers.Add(customer);
            FileHelper.WriteFile(path, _customers);
            Console.WriteLine($"Customer with the email {customer.Email} added successfully");
        }
    }

    public List<Customer> GetCustomers()
    {
        return _customers;
    }

    public void UpdateCustomer(Customer customerToUpdate)
    {
        // Basically first gets the ID of the customer, then find the existing customer by ID, then update the customer based on the input.
        Customer existingCustomer = SearchCustomerById(customerToUpdate.Id);
        if (existingCustomer != null)
        {
            Customer updatedCustomer = new Customer(existingCustomer.Id, customerToUpdate.FirstName, customerToUpdate.LastName, customerToUpdate.Email, customerToUpdate.Address);
            Action updateAction = new Action(() =>
            {
                this.UpdateCustomer(existingCustomer);
                Console.WriteLine($"Undo: Customer with the {existingCustomer.Id} was reverted back");
            });
            _undoStack.Push(updateAction);
            _redoStack.Clear();
            int index = _customers.IndexOf(existingCustomer);
            _customers[index] = updatedCustomer;
            FileHelper.WriteFile(path, _customers);
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
            Action deleteAction = new Action(() =>
            {
                _customers.Add(customerToDelete);
                FileHelper.WriteFile(path, _customers);
                Console.WriteLine($"Undo: Customer with the email {customerToDelete.Email} added back");
            });
            _undoStack.Push(deleteAction);
            _redoStack.Clear();
            _customers.Remove(customerToDelete);
            FileHelper.WriteFile(path, _customers);
            Console.WriteLine($"Customer with the email {customerToDelete.Email} deleted successfully");

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

    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            Action lastAction = _undoStack.Pop();
            lastAction.Invoke();
            _redoStack.Push(lastAction);
        }
        else
        {
            Console.WriteLine("Nothing to undo");
        }
    }

    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            Action lastUndoneAction = _redoStack.Pop();
            lastUndoneAction.Invoke();
            _undoStack.Push(lastUndoneAction);
        }
        else
        {
            Console.WriteLine("Nothing to redo");
        }
    }
}