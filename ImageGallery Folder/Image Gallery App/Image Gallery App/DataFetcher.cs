using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Reflection;

namespace Image_Gallery_App
{
    class DataFetcher
    {

        async Task<string> GetDatafromService(string searchstring)
        {
            string readText = null;
            try
            {
                               
                var azure = @"https://imagefetcher20200529182038.azurewebsites.net";
                string url = azure + @"/api/fetch_images?query=" + searchstring + "&max_count=5";
                using (HttpClient c = new HttpClient())
                {
                  readText = await c.GetStringAsync(url);
                }
               
            }
            catch
            {
                //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"sampleData.json");
                
                readText = File.ReadAllText(@"C:\Users\Deepanshu\Desktop\Grapecity Assignment\Installer and Working Guide\sampleData.json");
            }
            return readText;
        }


        public async Task<List<ImageItem>> GetImageData(string search)
        {
            string data = await GetDatafromService(search);
            return JsonConvert.DeserializeObject<List<ImageItem>>(data);
        }




    }
}
