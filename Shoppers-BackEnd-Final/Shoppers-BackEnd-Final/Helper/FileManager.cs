using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Helper
{
    public class FileManager
    {
        public static string Save(string rootpath, string folder, IFormFile formFile)
        {
            string filename = formFile.FileName;
            if (filename.Length > 64)
            {
                filename = filename.Substring(filename.Length - 64, 64);
            };
            string newfilename = Guid.NewGuid().ToString() + filename;
            string path = Path.Combine(rootpath, folder, newfilename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            return newfilename;
        }
        public static bool Delete(string rootpath, string folder, string filename)
        {
            string path = Path.Combine(rootpath, folder, filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
