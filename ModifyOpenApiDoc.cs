using System; 

using Microsoft.OpenApi.Models; 

using Microsoft.OpenApi.Readers; 

using System.IO; 

using Microsoft.OpenApi.Writers;

public class ModifyOpenApiDocument 

{ 

    public static void ModifyDocument()

    { 

        // Load the existing OpenAPI document from a YAML file 

        var filePath = "petstore.yaml"; 

        if (File.Exists(filePath)) 

        { 
            var document = ReadOpenApiDocumentFromYamlFile(filePath); 

            // Now you can modify the document as needed 

            // For example, let's add a new path 

            var newPetPath = new OpenApiPathItem 

            { 

                Operations = new Dictionary<OperationType, OpenApiOperation> 

                { 

                    [OperationType.Post] = new OpenApiOperation 

                    { 

                        Description = "Add a new pet", 

                        RequestBody = new OpenApiRequestBody 

                        { 

                            Content = new Dictionary<string, OpenApiMediaType> 

                            { 

                                ["application/json"] = new OpenApiMediaType 

                                { 

                                    Schema = new OpenApiSchema 

                                    {

                                        Type = "object", 

                                        Properties = new Dictionary<string, OpenApiSchema> 

                                        { 

                                            ["name"] = new OpenApiSchema { Type = "string" }, 

                                            ["category"] = new OpenApiSchema 

                                            { 

                                                Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "Category" } 

                                            } 

                                            // Add other properties as needed 

                                        }, 

                                    } 

                                } 

                            }, 

                             Required = true, // Indicates that the "name" property is required 
                        }, 

                        Responses = new OpenApiResponses 

                        { 

                            ["201"] = new OpenApiResponse 

                            { 

                                Description = "Pet created successfully" 

                            } 

                        } 

                    } 

                } 

            }; 

            // Add the new path to the document 

            document.Paths.Add("/pets/post", newPetPath); 

            // Serialize and save the modified OpenAPI document to a new file 

            SerializeOpenAPIDocument(document, "updated_petstore.yaml"); 

            Console.WriteLine("PetStore OpenAPI document updated."); 

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

    static void SerializeOpenAPIDocument(OpenApiDocument document, string filePath) 

    { 

        using (var streamWriter = new StreamWriter(filePath)) 

        {

            var writer = new OpenApiYamlWriter(streamWriter); 

            document.SerializeAsV3(writer); 

        } 

    } 

}