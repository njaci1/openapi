using System;

namespace OpenApiDocumentTest
{
    class Program
    {
        static void Main(string[] args)
            {
    while (true)
    {
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Create OpenAPI Document");
        Console.WriteLine("2. Modify OpenAPI Document");
        Console.WriteLine("3. Convert OpenAPI Document");
        Console.WriteLine("4. Exit");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                CreateOpenApiDocument.CreateDocument();
                break;
            case "2":
                ModifyOpenApiDocument.ModifyDocument();
                break;
            case "3":
                ConvertOpenApiDocument.ConvertDocument();
                break;
            case "4":
                return; // Exit the application
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}
    }
}