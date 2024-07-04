using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class AyudanteImagen
    {
        public static Bitmap TextoAImagen(string texto, Font fuente, Color colorTexto, Color colorFondo)
        {
            // Crear un bitmap en blanco para dibujar el texto
            Bitmap bitmap = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            SizeF tamañoTexto = graphics.MeasureString(texto, fuente);

            // Crear una nueva imagen con el tamaño del texto
            bitmap = new Bitmap((int)tamañoTexto.Width, (int)tamañoTexto.Height);
            graphics = Graphics.FromImage(bitmap);

            // Dibujar el texto en la imagen
            graphics.Clear(colorFondo);
            graphics.DrawString(texto, fuente, new SolidBrush(colorTexto), new PointF(0, 0));

            return bitmap;
        }

        public static Bitmap CombinarImagenes(Bitmap imagen1, Bitmap imagen2)
        {
            int ancho = Math.Max(imagen1.Width, imagen2.Width);
            int altura = imagen1.Height + imagen2.Height;

            Bitmap imagenCombinada = new Bitmap(ancho, altura);
            using (Graphics g = Graphics.FromImage(imagenCombinada))
            {
                g.DrawImage(imagen1, (ancho - imagen1.Width) / 2, 0);
                g.DrawImage(imagen2, (ancho - imagen2.Width) / 2, imagen1.Height);
            }

            return imagenCombinada;

        }
            
    }
    
}
