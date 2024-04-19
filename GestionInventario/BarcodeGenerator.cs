using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Common;
using ZXing;

namespace GestionInventario
{
    public class BarcodeGenerator
    {
        public Bitmap GenerateBarcode(string contenido)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128, //Se puede cambiar el formato según dr requiera
                Options = new EncodingOptions
                {
                    Width = 500,
                    Height = 180
                }
            };
            return writer.Write(contenido);
        }
    }
}
