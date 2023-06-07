class FileHelper
{
    private const string path = "../customers.csv";

    public static List<string[]> ReadFromFile(string path)
    {
        try
        {
            List<string[]> rows = new List<string[]>();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    rows.Add(values);
                }
            }
            return rows;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read from CSV file: {ex.Message}");
            return null;
        }
    }
    public static void WriteFile(string filePath, List<string[]> rows)
    {
        try
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var row in rows)
                {
                    string line = string.Join(",", row);
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Write to file successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write to CSV file: {ex.Message}");
        }
    }
}