public class ExceptionHandler : Exception
{
    private string _message;
    private int _errorCode;

    public ExceptionHandler(string message, int errorCode)
    {
        _message = message;
        _errorCode = errorCode;
    }

    public static ExceptionHandler FileException(string? message)
    {
        return new ExceptionHandler(message ?? "There was error when processing the file", 500);
    }

    public static ExceptionHandler FetchDataException(string? message)
    {
        return new ExceptionHandler(message ?? "Could read data from the file", 500);
    }

    public static ExceptionHandler UpdateDataException(string? message)
    {
        return new ExceptionHandler(message ?? "Could update data from the file", 500);

    }
}