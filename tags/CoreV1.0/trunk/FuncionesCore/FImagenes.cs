using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace FuncionesCore
{

    /// <summary>
    ///         ''' Clase utilizada para manipular imágenes. Utilizar ResizeImageSTD/MakeThumbnail + SaveJPGWithCompressionSetting para redimensionar y guardar imágenes o sus thumbnails
    ///         ''' </summary>
    ///         ''' <remarks></remarks>
    public class FImagenes
    {
        public const int COMPRESION  = 60;
        public const int WIDTH = 800;
        public const int WIDTH_TH  = 160;

        enum Dimensions
        {
            Width,
            Height
        }

        enum AnchorPosition
        {
            Top,
            Center,
            Bottom,
            Left,
            Right
        }


        private static void GetDimensionsForAspectRatio(ref int w2, ref int h2, Image imgPhoto, eFormatoDimensionimagen enuFormatoDimensionimagen)
        {
            double dRelacionDeSalida = ValorDecimalFormatoDimensionimagen(enuFormatoDimensionimagen); // Por ejemplo = 4/3= 1,33333...

            int w = imgPhoto.Width;
            int h = imgPhoto.Height;

            if (w / (double)h > dRelacionDeSalida)
            {
                h2 = h;
                w2 = Convert.ToInt32(Math.Floor(Convert.ToInt32(h2) * dRelacionDeSalida));
            }
            else if (w / (double)h < dRelacionDeSalida)
            {
                w2 = w;
                h2 = Convert.ToInt32(Math.Floor(Convert.ToInt32(w2) / dRelacionDeSalida));
            }
            else
            {
                w2 = w;
                h2 = h;
            }
        }

        private static Image Crop(Image imgPhoto, int Width, int Height, AnchorPosition Anchor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            double nPercent = 0;
            double nPercentW = 0;
            double nPercentH = 0;

            nPercentW = (Convert.ToSingle(Width) / (double)Convert.ToSingle(sourceWidth));
            nPercentH = (Convert.ToSingle(Height) / (double)Convert.ToSingle(sourceHeight));

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;
                switch (Anchor)
                {
                    case AnchorPosition.Top:
                        {
                            destY = 0;
                            break;
                        }

                    case AnchorPosition.Bottom:
                        {
                            destY = Convert.ToInt32((Height - (sourceHeight * nPercent)));
                            break;
                        }

                    default:
                        {
                            destY = Convert.ToInt32(((Height - (sourceHeight * nPercent)) / 2));
                            break;
                        }
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (Anchor)
                {
                    case AnchorPosition.Left:
                        {
                            destX = 0;
                            break;
                        }

                    case AnchorPosition.Right:
                        {
                            destX = Convert.ToInt32((Width - (sourceWidth * nPercent)));
                            break;
                        }

                    default:
                        {
                            destX = Convert.ToInt32(((Width - (sourceWidth * nPercent)) / 2));
                            break;
                        }
                }
            }

            int destWidth = Convert.ToInt32((sourceWidth * nPercent));
            int destHeight = Convert.ToInt32((sourceHeight * nPercent));

            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;


            grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private static Image ScaleByPercent(Image imgPhoto, int Percent)
        {
            double nPercent = (Convert.ToSingle(Percent) / (double)100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = Convert.ToInt32((sourceWidth * nPercent));
            int destHeight = Convert.ToInt32((sourceHeight * nPercent));

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;

            grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private static Image FixedSize(Image imgPhoto, int Width, int Height, Color cColor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            double nPercent = 0;
            double nPercentW = 0;
            double nPercentH = 0;

            nPercentW = (Convert.ToSingle(Width) / (double)Convert.ToSingle(sourceWidth));
            nPercentH = (Convert.ToSingle(Height) / (double)Convert.ToSingle(sourceHeight));
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = Convert.ToInt32((sourceWidth * nPercent));
            int destHeight = Convert.ToInt32((sourceHeight * nPercent));

            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(cColor);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
        /// <summary>
        ///             ''' Devuelve una relación estandar entre h y w, si no encuentra, devuelve la relación que tengan
        ///             ''' </summary>
        ///             ''' <param name="w"></param>
        ///             ''' <param name="h"></param>
        ///             ''' <returns></returns>
        ///             ''' <remarks></remarks>
        private static double GetStandardRelation(int w, int h)
        {
            double Err = 0.1; // Ajustar según corresponda

            int i = 0;
            while (i < StandardRelations.Length && Math.Abs(w / (double)h - StandardRelations[i]) > Err)
                i += 1;

            if (i < StandardRelations.Length)
                return StandardRelations[i];
            else
                return w / (double)h;
        }

        /// <summary>
        ///             ''' Array para almacenar nuevas relaciones estándar
        ///             ''' </summary>
        ///             ''' <remarks></remarks>
        private static double[] StandardRelations = new[] { 4 / (double)3, 16 / (double)9 };

        /// <summary>
        ///             ''' Función para obtener la altura de una imagen si su ancho es de w2 sin distorsionarla
        ///             ''' </summary>
        ///             ''' <param name="w"></param>
        ///             ''' <param name="h"></param>
        ///             ''' <returns></returns>
        ///             ''' <remarks></remarks>
        private static int GetH(int w, int h, int w2)
        {
            return Convert.ToInt32(w2 / GetStandardRelation(w, h));
        }

        /// <summary>
        ///             ''' w y h son las dimensiones originales, w2 y h2 las finales, h2 se calcula en base a w2 proporcionalmente
        ///             ''' </summary>
        ///             ''' <param name="w"></param>
        ///             ''' <param name="h"></param>
        ///             ''' <param name="w2"></param>
        ///             ''' <param name="h2"></param>
        ///             ''' <remarks></remarks>
        private static void GetResize(int w, int h, ref int w2, ref int h2)
        {
            if (w < w2)
            {
                h2 = h;
                w2 = w;
            }
            else
                h2 = GetH(w, h, w2);
        }

        /// <summary>
        ///             ''' Función para obtener una imágen con tamaño estándar a partir de la original
        ///             ''' </summary>
        ///             ''' <param name="img"></param>
        ///             ''' <param name="w2"></param>
        ///             ''' <returns></returns>
        ///             ''' <remarks></remarks>
        public static Image ResizeImageSTD(Image img, int w2)
        {
            int h = img.Height;
            int w = img.Width;
            int h2 = 0;
            GetResize(w, h, ref w2, ref h2);
            return FixedSize(img, w2, h2, Color.Black);
        }

        /// <summary>
        ///             ''' Función para obtener una miniatura de la imagen original, la miniatura tiene relación 4:3, independientemente de la original, utiliza CROP
        ///             ''' </summary>
        ///             ''' <param name="img"></param>
        ///             ''' <param name="w2"></param>
        ///             ''' <returns></returns>
        ///             ''' <remarks></remarks>
        public static Image MakeThumbnail(Image img, int w2)
        {
            int h = img.Height;
            int w = img.Width;
            int h2 = 0;

            // hacemos el crop
            int w_crop = 0;
            int h_crop = 0;
            GetDimensionsForAspectRatio(ref w_crop, ref h_crop, img, eFormatoDimensionimagen.wxh_4x3);
            Image img_crop = Crop(img, w_crop, h_crop, AnchorPosition.Center);

            // hacemos el resize sobre la img_crop
            h = img_crop.Height;
            w = img_crop.Width;
            GetResize(w, h, ref w2, ref h2);
            return FixedSize(img_crop, w2, h2, Color.Black);
        }

        /// <summary>
        ///             ''' Guarda una imagen jpg con un nivel de compresión entre 0 (máxima compresión) y 100 (sin compresión)
        ///             ''' </summary>
        ///             ''' <param name="image"></param>
        ///             ''' <param name="szFileName"></param>
        ///             ''' <param name="lCompression"></param>
        ///             ''' <remarks></remarks>
        public static void SaveJPGWithCompressionSetting(Image image, string szFileName, long lCompression)
        {
            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(Encoder.Quality, lCompression);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
            image.Save(szFileName, ici, eps);
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j <= encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null/* TODO Change to default(_) if this is not a reference type */;
        }

        private static double ValorDecimalFormatoDimensionimagen(eFormatoDimensionimagen eFormatoDI)
        {
            switch (eFormatoDI)
            {
                case eFormatoDimensionimagen.wxh_4x3:
                    {
                        return 4 / (double)3;
                    }

                case eFormatoDimensionimagen.wxh_16x9:
                    {
                        return 16 / (double)9;
                    }

                default:
                    {
                        return 0; // ERROR
                    }
            }
        }

        enum eFormatoDimensionimagen
        {
            wxh_NoStd = 0,
            wxh_4x3 = 1,
            wxh_16x9 = 2
        }

        public static bool EsImagen(string pNombre)
        {
            List<string> Extenciones = new List<string>();
            Extenciones.Add("png");
            Extenciones.Add("gif");
            Extenciones.Add("bmp");
            Extenciones.Add("jpeg");
            Extenciones.Add("jpg");

            foreach(string extencion in Extenciones)
            {
                if (pNombre.EndsWith(extencion))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

