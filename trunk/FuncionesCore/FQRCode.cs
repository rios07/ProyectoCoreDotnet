using System.Drawing.Imaging;
using System.IO;
using QRCoder;

namespace FuncionesCore
{
    public class FQRCode
    {
        public static byte[] GenerarQr(string pTexto)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(pTexto, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            using (var stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}