using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Dugun.Common
{
    public static class ImageCompresser
    {
        public static void SaveImage(Image originalImage, string path, int quality, int? maxWidth, int? maxHeight)
        {
            Size newSize = originalImage.Size;
            if ((maxWidth.HasValue && originalImage.Width > maxWidth) || (maxHeight.HasValue && originalImage.Height > maxHeight))
            {
                newSize = ScaleSize(new Size() { Width = originalImage.Width, Height = originalImage.Height }, maxWidth, maxHeight);
            }
            //Image resizedImage = Utils.ResizeImage(orginalImage, newSize.Width, newSize.Height);
            Bitmap resizedImage = new Bitmap(ResizeImage(originalImage, newSize));

            ImageCodecInfo jpgEncoder = null;
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == ImageFormat.Jpeg.Guid)
                {
                    jpgEncoder = codec;
                    break;
                }
            }
            if (jpgEncoder != null)
            {
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters encoderParameters = new EncoderParameters(1);

                EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
                encoderParameters.Param[0] = encoderParameter;

                string fileOut = Path.Combine(path);
                FileStream fileStream = new FileStream(fileOut, FileMode.Create, FileAccess.Write);
                resizedImage.Save(fileStream, jpgEncoder, encoderParameters);
                fileStream.Flush();
                fileStream.Close();

                //using (MagickImage image = new MagickImage(fileOut))
                //{
                //    // Set the format and write to a stream so ImageMagick won't detect the file type.
                //    image.Format = MagickFormat.Pjpeg;
                //    image.Quality = 80;

                //    image.CompressionMethod = CompressionMethod.JPEG;
                //    using (FileStream fs = new FileStream(fileOut, FileMode.Create))
                //    {
                //        try
                //        {
                //            image.Write(fs);
                //        }
                //        catch { }
                //    }
                //}
            }
        }

        public static Size ScaleSize(Size orjinalImageSize, int? maxWidth, int? maxHeight)
        {
            if (!maxWidth.HasValue && !maxHeight.HasValue)
                throw new ArgumentException("At least one scale factor (toWidth or toHeight) must not be null.");

            if (orjinalImageSize.Height == 0 || orjinalImageSize.Width == 0)
                throw new ArgumentException("Cannot scale size from zero.");

            //if (maxWidth.HasValue && maxHeight.HasValue)
            //    return new Size(maxWidth.Value, maxHeight.Value);

            double? widthScale = null;
            double? heightScale = null;

            if (maxWidth.HasValue)
                widthScale = maxWidth.Value / (double)orjinalImageSize.Width;

            if (maxHeight.HasValue)
                heightScale = maxHeight.Value / (double)orjinalImageSize.Height;

            double scale = Math.Min((double)(widthScale ?? heightScale), (double)(heightScale ?? widthScale));

            return new Size((int)Math.Floor(orjinalImageSize.Width * scale), (int)Math.Ceiling(orjinalImageSize.Height * scale));
        }

        public static Image ResizeImage(Image image, Size newSize)
        {
            double ratio = 0d;
            double myThumbWidth = 0d;
            double myThumbHeight = 0d;
            int x = 0;
            int y = 0;

            Bitmap bitmap;

            if ((image.Width / Convert.ToDouble(newSize.Width)) > (image.Height / Convert.ToDouble(newSize.Height)))
                ratio = Convert.ToDouble(image.Width) / Convert.ToDouble(newSize.Width);
            else
                ratio = Convert.ToDouble(image.Height) / Convert.ToDouble(newSize.Height);

            myThumbHeight = Math.Ceiling(image.Height / ratio);
            myThumbWidth = Math.Ceiling(image.Width / ratio);

            //Size thumbSize = new Size((int)myThumbWidth, (int)myThumbHeight);
            Size thumbSize = new Size((int)newSize.Width, (int)newSize.Height);
            bitmap = new Bitmap(newSize.Width, newSize.Height);
            x = (newSize.Width - thumbSize.Width) / 2;
            y = (newSize.Height - thumbSize.Height);

            // Had to add System.Drawing class in front of Graphics ---
            System.Drawing.Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.Default;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
            g.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

            return bitmap;
        }

        public static FileInfo CropImage(int cropPointX, int cropPointY, int cropWidth, int cropHeight, int? resizeWidth, string imageName)
        {
            var path = ImagePathGenerator.GetTemporaryFilePath(imageName);
            var newPath = ImagePathGenerator.GetTemporaryFilePath(Guid.NewGuid() + "." + imageName.Split('.').Last());

            using (Bitmap orginalImage = Image.FromFile(path) as Bitmap)
            {
                Rectangle cropRect = new Rectangle(new Point(cropPointX, cropPointY), new Size(cropWidth, cropHeight));
                Bitmap newImage;
                if(resizeWidth != null && resizeWidth < cropWidth)
                    newImage = new Bitmap((int)resizeWidth, Convert.ToInt32(((double)cropHeight / (double)cropWidth) * resizeWidth));
                else
                    newImage = new Bitmap(cropWidth, cropHeight);
                
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.InterpolationMode = InterpolationMode.Default;
                    g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.DrawImage(orginalImage, new Rectangle(0, 0, newImage.Width, newImage.Height), cropRect, GraphicsUnit.Pixel);
                }

                newImage.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                newImage.Dispose();    
            }

            File.Delete(path);

            return new FileInfo(newPath);
        }
    }
}