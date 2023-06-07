class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Customer(int id, string firstName, string lastName, string email, string address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
    }

    public override string ToString()
    {
        return $"ID: {this.Id}, Name: {this.FirstName} {this.LastName}, Email: {this.Email}, Address: {this.Address}";
    }
}