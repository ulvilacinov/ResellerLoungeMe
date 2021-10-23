using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ResellerLoungeMe.Application.Utilities
{
    public static class QRCodeGenerator
    {
        public static string GenerateQrCode(string pnr)
        {
            QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(pnr, QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            System.IO.MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Png);
            byte[] byteImage = ms.ToArray();

            return Convert.ToBase64String(byteImage);
        }
    }
}
