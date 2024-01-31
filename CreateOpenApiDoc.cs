using System; 

using Microsoft.OpenApi.Models; 

using Microsoft.OpenApi.Writers; 

using System.IO; 

 

public class CreateOpenApiDocument 

{ 

    public static void CreateDocument()

    { 

        // Create an OpenAPI document for the PetStore API 

        var document = new OpenApiDocument 

        { 

            Info = new OpenApiInfo 

            { 

                Title = "PetStore API", 

                Version = "1.0.0" 

            }, 

            Servers = new List<OpenApiServer> 

            { 

                new OpenApiServer { Url = "https://api.petstore.com" } 

            }, 

            Paths = new OpenApiPaths 

            { 

                ["/pets"] = new OpenApiPathItem 

                { 

                    Operations = new Dictionary<OperationType, OpenApiOperation> 

                    { 

                        [OperationType.Get] = new OpenApiOperation 

                        { 

                            Description = "Get all pets", 

                            Responses = new OpenApiResponses 

                            { 

                                ["200"] = new OpenApiResponse 

                                { 

                                    Description = "A list of pets", 

                                    Content = new Dictionary<string, OpenApiMediaType> 

                                    { 

                                        ["application/json"] = new OpenApiMediaType 

                                        { 

                                            Schema = new OpenApiSchema 

                                            { 

                                                Type = "array", 

                                                Items = new OpenApiSchema 

                                                { 

                                                    Reference = new OpenApiReference 

                                                    { 

                                                        Type = ReferenceType.Schema, 

                                                        Id = "Pet" 

                                                    } 

                                                } 

                                            } 

                                        } 

                                    } 

                                } 

                            } 

                        } 

                    } 

                } 

            } 

        }; 

 

        // Serialize the OpenAPI document to a YAML file 

        using (var streamWriter = new StreamWriter("petstore.yaml")) 

        { 

            var writer = new OpenApiYamlWriter(streamWriter); 

            document.SerializeAsV3(writer); 

        } 

 

        Console.WriteLine("PetStore OpenAPI document created and saved."); 
        Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

    } 

} 