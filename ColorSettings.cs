using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiffConverter
{
    class ColorSettings
    {
        private string _device;
        private string _compression;

        public void InitSettings(string outputColor)
        {
            switch (outputColor)
            {
                case "Color":
                    _device = "tiff24nc";
                    _compression = "lzw";
                    break;
                case "Grayscale":
                    _device = "tiffgray";
                    _compression = "lzw";
                    break;
                case "Black/White":
                    _device = "tiffg4";
                    _compression = "g4";
                    break;
                default:
                    _device = "tiff24nc";
                    _compression = "lzw";
                    break;
            }
        }

        public string Device
        {
            get { return _device; }

        }

        public string Compression
        {
            get { return _compression; }
        }
    }
}
