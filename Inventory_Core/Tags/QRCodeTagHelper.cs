﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ZXing.QrCode;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_Core.Tags
{
    [HtmlTargetElement("pager", Attributes = "total-pages, current-page, link-url")]
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("qrcode")]
    public class QRCodeTagHelper : TagHelper
    {
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //var content = context.AllAttributes["content"].Value.ToString();
            var content = context.AllAttributes["content"].Value.ToString();
            var width = int.Parse(context.AllAttributes["width"].Value.ToString());
            var height = int.Parse(context.AllAttributes["height"].Value.ToString());
            var barcodeWriterPixelData = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = 0
                }
            };

            //Write(content);
            var pixelData = barcodeWriterPixelData.Write(content);
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height)
                        , System.Drawing.Imaging.ImageLockMode.WriteOnly
                        , System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    output.TagName = "img";
                    output.Attributes.Clear();
                    output.Attributes.Add("width", width);
                    output.Attributes.Add("height", height);
                    output.Attributes.Add("src", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(memoryStream.ToArray())));
                    output.Attributes.Add("onclick", "qrImgPopup('" + String.Format("data:image/png;base64,{0}", Convert.ToBase64String(memoryStream.ToArray())) + "')");
                }
            }
        }
    }
}
