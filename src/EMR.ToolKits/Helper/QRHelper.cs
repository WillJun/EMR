//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Helper
// FileName : QRHelper
//
// Created by : Will.Wu at 2020/9/3 15:01:23
//
//
//========================================================================
using System;
using System.Drawing;
using System.IO;

using ZXing;
using ZXing.Common;

namespace EMR.ToolKits.Helper
{
    public static class QRHelper
    {
        public static string GetQRCode(string content)
        {
            BitMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 300, 300);
            System.Drawing.Bitmap bitmap = toBitmap(byteMatrix);
            return ToBase64(bitmap);
        }

        private static System.Drawing.Bitmap toBitmap(BitMatrix matrix)
        {
            int width = matrix.Width;
            int height = matrix.Height;
            var white = System.Drawing.ColorTranslator.FromHtml("0xFFFFFFFF");
            var black = System.Drawing.ColorTranslator.FromHtml("0xFF000000");
            System.Drawing.Bitmap bmap = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bmap.SetPixel(x, y, matrix[x, y] ? black : white);
                }
            }
            return bmap;
        }

        private static string ToBase64(Bitmap bmp)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                return strbaser64;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        //base64编码的文本转为图片
        private static Bitmap Base64StringToImage(string inputStr)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                return bmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}