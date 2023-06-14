class Customer
{
    readonly int _id;
    readonly string? _firstName;
    readonly string? _lastName;
    readonly string? _email;
    readonly string? _address;

    public int Id
    {
        get { return _id; }
    }

    public string? FirstName
    {
        get { return _firstName; }
    }

    public string? LastName
    {
        get { return _lastName; }
    }

    public string? Email
    {
        get { return _email; }
    }

    public string? Address
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