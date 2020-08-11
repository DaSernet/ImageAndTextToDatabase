using System;
using System.IO;

namespace ImageAndTextToDatabase.Functions
{
    internal static class ImageToByte
    {
        //gets our photo string
        public static byte[] GetPhoto(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, (int)fs.Length);
            fs.Close();

            return data;
        }

        public static string ByteArrayToString(string path)
        {
            byte[] bytes = GetPhoto(path);
            string result = "0x";

            result += BitConverter.ToString(bytes).Replace("-", String.Empty);

            return result;
        }
    }
}