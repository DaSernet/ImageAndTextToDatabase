using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAndTextToDatabase.Functions
{
    internal class ImageToByte
    {
        //gets our photo string
        private byte[] GetPhoto(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, (int)fs.Length);
            fs.Close();

            return data;
        }

        private string ByteArrayToString(string path)
        {
            byte[] bytes = GetPhoto(path);
            string result = "0x";

            result += BitConverter.ToString(bytes).Replace("-", String.Empty);

            return result;
        }
    }
}