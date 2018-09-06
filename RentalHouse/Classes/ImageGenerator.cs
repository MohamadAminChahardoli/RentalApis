using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RentalHouse.Classes
{
    public static class ImageGenerator
    {
        public static string ByteToImage(byte[] picture)
        {
            string imageName = "";
            string folderName = "Images/Houses";
            MemoryStream ms = new MemoryStream(picture, 0, picture.Length);
            imageName = GenearatePictureName() + ".jpg";
            FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/" + folderName + "/" + imageName), FileMode.Create);
            ms.WriteTo(fs);
            ms.Close();
            fs.Close();
            fs.Dispose();

            return imageName;
        }

        private static string GenearatePictureName()
        {
            string generatedName = Guid.NewGuid().ToString();
            generatedName = generatedName.Replace("+", "");
            generatedName = generatedName.Replace("/", "");
            generatedName = generatedName.Replace(@"\", "");
            generatedName = generatedName.Replace("-", "");

            return generatedName;
        }

    }
}