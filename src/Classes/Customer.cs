class Customer
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _address;

    public int Id
    {
        get { return _id; }
    }

    public string FirstName
    {
        get { return _firstName; }
    }

    public string LastName
    {
        get { return _lastName; }
    }

    public string Email
    {
        get { return _email; }
    }

    public string Address
    {
        get { return _address; }
    }

    public Customer(int id, string firstName, string lastName, string email, string address)
    {
        _id = id;
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _address = address;
    }

    public override string ToString()
    {
        return $"ID: {this.Id}, Name: {this.FirstName} {this.LastName}, Email: {this.Email}, Address: {this.Address}";
    }
}