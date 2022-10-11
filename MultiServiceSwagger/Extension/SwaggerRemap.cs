using MultiServiceSwagger.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MultiServiceSwagger.Extension;

public static class SwaggerRemap
{
    public static Action<SwaggerUIOptions> SwaggerUiConfig(this SwaggerSettings settings, string baseUrl)
    {
        string urlToUse = string.IsNullOrEmpty(baseUrl) ? settings.BaseUrl : baseUrl;
        return new Action<SwaggerUIOptions>(o =>
        {
            foreach (var url in settings.Urls)
            {
                o.EnablePersistAuthorization();
                o.SwaggerEndpoint($"{urlToUse.Trim('/')}/{url.Trim('/')}", $"{url.Split('/')[0]}");
            }
        });
    }
}