using System.Drawing;
using System.IO;

namespace Api
{
    public static class Extensions
    {
        public static byte[] GetBytes(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
