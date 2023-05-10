using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitals.Utilities
{
    public class ImageOperations
    {
        private readonly IWebHostEnvironment _environment;

        public ImageOperations(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string ImageUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                // No file was selected
                return null;
            }

            // Generate a unique filename for the image
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);

            // Set the path where the file will be saved
            string path = Path.Combine(_environment.WebRootPath, "Images", fileName);

            // Save the file to the target folder
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                return null;
            }

            // Return the filename of the uploaded image
            return fileName;
        }

    }
}
