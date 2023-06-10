class FileHelper
{
    public static List<Customer> ReadFromFile(string path)
    {
        try
        {
            List<Customer> customers = new List<Customer>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    int id = int.Parse(values[0]);
                    string firstName = values[1];
                    string lastName = values[2];
                    string email = values[3];
                    string address = values[4];
                    Customer customer = new Customer(id, firstName, lastName, email, address);
                    customers.Add(customer);
                }
            }
            return customers;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read from CSV file: {ex.Message}");
            return null;
        }
    }
    public static void WriteFile(string filePath, List<Customer> customers)
    {
        try
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var customer in customers)
                {
                    writer.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write to CSV file: {ex.Message}");
        }
    }
}