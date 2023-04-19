using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSystem.Models
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var message = $"{DateTime.UtcNow} - Exception: {exception.Message}\r\nStackTrace: {exception.StackTrace}\r\n";
            // Write the exception details to a text file
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errorlog.txt");
            using (var writer = new StreamWriter(path, append: true))
            {
                writer.Write(message);
            }
        }
    }
}
