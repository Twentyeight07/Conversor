using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Linq;

namespace Conversor.Services
{
    internal class WebScraper
    {
        private readonly HttpClient _httpClient;

        public WebScraper()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler);
        }

        public async Task<string> ScrapeWebsite(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string htmlContent = await response.Content.ReadAsStringAsync();

                // Create an HTMLDocument and load the HTML content
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);

                // Web Scrapping
                var div = htmlDocument.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("id", "").Contains("dolar"))
                    .FirstOrDefault();

                if(div != null)
                {
                    string divContent = div.InnerHtml;

                    var filteredContent = new HtmlDocument();
                    filteredContent.LoadHtml(divContent);
                    var filteredElements = filteredContent.DocumentNode.Descendants("strong").FirstOrDefault();

                    string change = filteredElements.InnerHtml;

                    return change;
                }
                else
                {
                    return "No se encontró el elemento div deseado.";
                }

            }
            else
            {
                throw new Exception($"Error al realizar la solicitud: {response.StatusCode}");
            }

        }


    }
}
