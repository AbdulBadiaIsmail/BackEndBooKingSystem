using Booking_System.Migrations;
using Booking_System.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace Booking_System.Represent
{
    public static class UploadFile
    {


        public static string getPath(IFormFile file)
        {
            try
            {
                string ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/image/";

              
                string fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
                string FinalImagePath = Path.Combine(ImagePath, fileName);

                using (var stree = new FileStream(FinalImagePath, FileMode.Create))
                {
                    file.CopyTo(stree);
                }
               
                return "https://localhost:44383/image/" + fileName;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string RemoveFile(string file)
        {
            try
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/image/" + file))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/image/" + file);
                }
                return file;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }
        

    }
}
