using System.IO;
using System.Threading.Tasks;

namespace ImageAndTextToDatabase.Converters
{
    internal class ImageToByte
    {
        public static async Task<byte[]> ImageToByteConverter(string filePath)
        {
            byte[] imageBytes;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                imageBytes = new byte[fileStream.Length];
                await fileStream.ReadAsync(imageBytes, 0, (int)fileStream.Length);
            }
            return imageBytes;
        }
    }
}