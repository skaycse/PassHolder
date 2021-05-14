using Microsoft.AspNetCore.Hosting;
using passholder.Models;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace passholder.Services
{
    public interface IWebsitesService
    {
        Websites[] GetWebsiteJson();
    }

    public class WebsitesService : IWebsitesService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public WebsitesService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public Websites[] GetWebsiteJson()
        {
            using StreamReader stream = File.OpenText(_hostingEnvironment.ContentRootPath + "/Custom/Websites.json");
            JsonSerializer serializer = new();
            return (Websites[])serializer.Deserialize(stream, typeof(Websites[]));
        }
    }

}
