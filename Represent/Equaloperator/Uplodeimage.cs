namespace Booking_System.Represent.Equaloperator
{
    public class Uplodeimage
    {
        private readonly IWebHostEnvironment webHost;
        public Uplodeimage(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }


        public string getImage(IFormFile file)
        {
            string wwwrootPath = webHost.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            //string image = Guid.NewGuid() + fileName;
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;

            string filepath = Path.Combine(wwwrootPath, "/image/", fileName);
            using (var filestream = new FileStream(filepath, FileMode.Create))
            {

                file.CopyTo(filestream);
            }
            return filepath;

        }
    }
}
