using System; 

using Microsoft.OpenApi.Models; 

using Microsoft.OpenApi.Readers; 

using System.IO; 

using Microsoft.OpenApi.Writers; 

public class ConvertOpenApiDocument 

{ 

    public static void ConvertDocument()

    { 

        // Load the existing OpenAPI document from a YAML file 

        var filePath = "updated_petstore.yaml"; 

        if (File.Exists(filePath)) 

        { 

            var document = ReadOpenApiDocumentFromYamlFile(filePath); 

            // Convert the document to JSON 

            var jsonOpenApi = ConvertToJSON(document); 

            // Save the JSON OpenAPI document to a new file 

            SaveJsonDocumentToFile(jsonOpenApi, "updated_petstore.json"); 

            Console.WriteLine("OpenAPI document converted from YAML to JSON."); 

        } 

        else 

        { 

            Console.WriteLine($"File '{filePath}' not found."); 

        } 

    } 

    static OpenApiDocument ReadOpenApiDocumentFromYamlFile(string filePath) 

    { 

        using (var streamReader = new StreamReader(filePath)) 

        { 

            var reader = new OpenApiStreamReader(); 

            return reader.Read(streamReader.BaseStream, out var diagnostic); 

        } 

    } 

    static string ConvertToJSON(OpenApiDocument document) 

    { 

        using (var stringWriter = new StringWriter()) 

        { 

            var writer = new OpenApiJsonWriter(stringWriter); 

            document.SerializeAsV3(writer); 

            return stringWriter.ToString(); 

        } 

    } 

    static void SaveJsonDocumentToFile(string jsonDocument, string filePath) 

    { 

        File.WriteAllText(filePath, jsonDocument); 

    } 

} 