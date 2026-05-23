using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace SmartShoppingAssistant.Api
{
    public class JwtSecuritySchemeFilter : IOpenApiDocumentTransformer
    {
        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            document.Components ??= new OpenApiComponents();

            if (document.Components.SecuritySchemes == null)
            {
                document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>();
            }

            var jwtScheme = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "Introdu token-ul JWT aici"
            };

            document.Components.SecuritySchemes["Bearer"] = jwtScheme;

            if (document.Paths != null)
            {
                foreach (var path in document.Paths.Values)
                {
                    if (path.Operations != null)
                    {
                        foreach (var operation in path.Operations.Values)
                        {
                            operation.Security ??= new List<OpenApiSecurityRequirement>();

                            operation.Security.Add(new OpenApiSecurityRequirement
                            {
                                {
                                    new OpenApiSecuritySchemeReference("Bearer", document),
                                    new List<string>()
                                }
                            });
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}