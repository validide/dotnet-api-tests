using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace API.SERVICE
{
    public class SecretApiFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (!swaggerDoc.Info.Title.Contains("secret", StringComparison.OrdinalIgnoreCase))
            {
                var paths = swaggerDoc.Paths.Keys;
                foreach (var item in paths)
                {
                    if (
                        item.StartsWith("/shared", StringComparison.InvariantCultureIgnoreCase)
                        || item.StartsWith("/public", StringComparison.InvariantCultureIgnoreCase)
                        )
                    {
                        continue;
                    }

                    // Remove all paths that are not shared or public 
                    swaggerDoc.Paths.Remove(item);
                }
            }
        }
    }
}
