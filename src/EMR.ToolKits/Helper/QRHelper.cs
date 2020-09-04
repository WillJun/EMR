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
using System.Drawing.Imaging;
using System.IO;

using QRCoder;

namespace EMR.ToolKits.Helper
{
    public static class QRHelper
    {
        public static string GetQRCode(string content, string logourl)
        {
            return "data:image/png;base64," + ToBase64(GetQRCodeWithLogo(content, 30, logourl));
        }

        private static string ToBase64(Bitmap bmp)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                return strbaser64;
            }
            catch (Exception)
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
            catch (Exception)
            {
                return null;
            }
        }

        ///// <summary>
        ///// 生成二维码
        ///// </summary>
        ///// <param name="text">内容</param>
        ///// <param name="width">宽度</param>
        ///// <param name="height">高度</param>
        ///// <returns></returns>
        //private static Bitmap Generate(string text, int width = 200, int height = 200)
        //{
        //    BarcodeWriter writer = new BarcodeWriter();
        //    writer.Format = BarcodeFormat.QR_CODE;
        //    QrCodeEncodingOptions options = new QrCodeEncodingOptions()
        //    {
        //        DisableECI = true,//设置内容编码
        //        CharacterSet = "UTF-8",  //设置二维码的宽度和高度
        //        Width = width,
        //        Height = height,
        //        Margin = 1//设置二维码的边距,单位不是固定像素
        //    };

        //    writer.Options = options;
        //    Bitmap map = writer.Write(text);
        //    return map;
        //}

        /////// <summary>
        /////// 生成一维条形码
        /////// </summary>
        /////// <param name="text">内容</param>
        /////// <param name="width">宽度</param>
        /////// <param name="height">高度</param>
        /////// <returns></returns>
        ////public static Bitmap Generate2(string text, int width = 200, int height = 200)
        ////{
        ////    BarcodeWriter writer = new BarcodeWriter();
        ////    //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
        ////    //如果想生成可识别的可以使用 CODE_128 格式
        ////    //writer.Format = BarcodeFormat.ITF;
        ////    writer.Format = BarcodeFormat.CODE_39;
        ////    EncodingOptions options = new EncodingOptions()
        ////    {
        ////        Width = width,
        ////        Height = height,
        ////        Margin = 2
        ////    };
        ////    writer.Options = options;
        ////    Bitmap map = writer.Write(text);
        ////    return map;
        ////}

        ///// <summary>
        ///// Generates the logo.
        ///// </summary>
        ///// <param name="text">The text.</param>
        ///// <param name="logo">The logo.</param>
        ///// <param name="width">The width.</param>
        ///// <param name="height">The height.</param>
        ///// <returns>System.DrawingCore.Bitmap.</returns>
        ///// <remarks>Will Wu</remarks>
        //private static Bitmap GenerateLogo(string text, Bitmap logo, int width = 200, int height = 200)
        //{
        //    if (null == logo)
        //    {
        //        return Generate(text, width, height);
        //    }
        //    //Logo 图片
        //    //string logoPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\img\logo.png";
        //    //Bitmap logo = new Bitmap(logoPath);
        //    //构造二维码写码器
        //    MultiFormatWriter writer = new MultiFormatWriter();
        //    Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
        //    hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
        //    hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.L);
        //    //hint.Add(EncodeHintType.MARGIN, 2);//旧版本不起作用，需要手动去除白边

        // //生成二维码 BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, width + 30, height +
        // 30, hint); bm = deleteWhite(bm); BarcodeWriter barcodeWriter = new BarcodeWriter();
        // Bitmap map = barcodeWriter.Write(bm);

        // //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸） int[] rectangle = bm.getEnclosingRectangle();

        // //计算插入图片的大小和位置 int middleW = Math.Min((int)(rectangle[2] / 3), logo.Width); int middleH =
        // Math.Min((int)(rectangle[3] / 3), logo.Height); int middleL = (map.Width - middleW) / 2;
        // int middleT = (map.Height - middleH) / 2;

        //    Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
        //    using (Graphics g = Graphics.FromImage(bmpimg))
        //    {
        //        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        g.SmoothingMode = SmoothingMode.HighQuality;
        //        g.CompositingQuality = CompositingQuality.HighQuality;
        //        g.DrawImage(map, 0, 0, width, height);
        //        //白底将二维码插入图片
        //        g.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
        //        g.DrawImage(logo, middleL, middleT, middleW, middleH);
        //    }
        //    return bmpimg;
        //}

        ///// <summary>
        ///// 删除默认对应的空白
        ///// </summary>
        ///// <param name="matrix"></param>
        ///// <returns></returns>
        //private static BitMatrix deleteWhite(BitMatrix matrix)
        //{
        //    int[] rec = matrix.getEnclosingRectangle();
        //    int resWidth = rec[2] + 1;
        //    int resHeight = rec[3] + 1;
        //}
        //    BitMatrix resMatrix = new BitMatrix(resWidth, resHeight);
        //    resMatrix.clear();
        //    for (int i = 0; i < resWidth; i++)
        //    {
        //        for (int j = 0; j < resHeight; j++)
        //        {
        //            if (matrix[i + rec[0], j + rec[1]])
        //                resMatrix[i, j] = true;
        //        }
        //    }
        //    return resMatrix;

        public static Bitmap GetQRCodeWithLogo(string plainText, int pixel = 30, string logoPath = "")
        {
            if (string.IsNullOrWhiteSpace(logoPath))
            {
                return GetQRCode(plainText, pixel);
            }

            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCode(qrCodeData);

            #region 参数介绍

            //GetGraphic方法参数介绍
            //pixelsPerModule //生成二维码图片的像素大小 ，我这里设置的是5
            //darkColor       //暗色   一般设置为Color.Black 黑色
            //lightColor      //亮色   一般设置为Color.White  白色
            //icon             //二维码 水印图标 例如：Bitmap icon = new Bitmap(context.Server.MapPath("~/images/zs.png")); 默认为NULL ，加上这个二维码中间会显示一个图标
            //iconSizePercent  //水印图标的大小比例 ，可根据自己的喜好设置
            //iconBorderWidth  // 水印图标的边框
            //drawQuietZones   //静止区，位于二维码某一边的空白边界,用来阻止读者获取与正在浏览的二维码无关的信息 即是否绘画二维码的空白边框区域 默认为true

            #endregion 参数介绍

            var bitmap = qrCode.GetGraphic(pixel, Color.Black, Color.White, (Bitmap)Image.FromFile(logoPath), 15, 8);

            return bitmap;
        }

        public static Bitmap GetQRCode(string plainText, int pixel = 30)
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCode(qrCodeData);

            var bitmap = qrCode.GetGraphic(pixel);

            return bitmap;
        }
    }
}