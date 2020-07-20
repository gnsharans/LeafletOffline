using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Files.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                string file = this.Request.RequestUri.ToString();
                string data = file.Split('?').Last();
                string value = data.Replace('/', '\\');
                String filePath = @"D:\Office\kk\out\" + value;
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                Image image = Image.FromStream(fileStream);
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                result.Content = new ByteArrayContent(memoryStream.ToArray());
                fileStream.Close();
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                return result;
            }
            catch
            {
                return null;
            }

        }

        // GET: api/Files/5
        public Image Get(string id)
        {
            string val = id.Replace('/', '\\');
            id = val;
            return Image.FromFile(@"D:\Office\tacsim\out\0\0\0.jpg");
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
