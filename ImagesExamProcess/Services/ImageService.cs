using ImagesExamProcess.Models;
using System;
using System.IO;
using System.Drawing;

namespace ImagesExamProcess.Services
{
    public class ImageService
    {
        public ProcessingResult ProcessENEMAnswerKey(ImageModel imageModel, ProcessingResult processingResult)
        {
            byte[] imageBytes = Convert.FromBase64String(imageModel.ImageBase64);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            Bitmap bmp = (Bitmap)image;

            Color[][] colorMatrix = new Color[bmp.Width][];
            for (int i = 0; i < bmp.Width; i++)
            {
                colorMatrix[i] = new Color[bmp.Height];
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorMatrix[i][j] = bmp.GetPixel(i, j);
                }
            }

            //Bitmap newBmp = bmp;
            for (int x = 44; x < 146/*bmp.Width*/; x++)
            {
                for (int y = 30; y < 479/*bmp.Height*/; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    //newBmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                    int column = CheckInnerColumn(x);
                    int line = CheckLine(y);
                    if (column != -1 && line != -1)
                    {
                        processingResult.Feedback[line].Score[column] += avg;
                    }
                }
            }

            for (int x = 194; x < 296/*bmp.Width*/; x++)
            {
                for (int y = 30; y < 479/*bmp.Height*/; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    //newBmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                    int column = CheckInnerColumn(x);
                    int line = CheckLine(y);
                    if (column != -1 && line != -1)
                    {
                        processingResult.Feedback[line + 18].Score[column] += avg;
                    }
                }
            }

            for (int x = 343; x < 445/*bmp.Width*/; x++)
            {
                for (int y = 30; y < 479/*bmp.Height*/; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    //newBmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                    int column = CheckInnerColumn(x);
                    int line = CheckLine(y);
                    if (column != -1 && line != -1)
                    {
                        processingResult.Feedback[line + 36].Score[column] += avg;
                    }
                }
            }

            for (int x = 493; x < 595/*bmp.Width*/; x++)
            {
                for (int y = 30; y < 479/*bmp.Height*/; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    //newBmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                    int column = CheckInnerColumn(x);
                    int line = CheckLine(y);
                    if (column != -1 && line != -1)
                    {
                        processingResult.Feedback[line + 54].Score[column] += avg;
                    }
                }
            }

            for (int x = 642; x < 774/*bmp.Width*/; x++)
            {
                for (int y = 30; y < 479/*bmp.Height*/; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    //newBmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                    int column = CheckInnerColumn(x);
                    int line = CheckLine(y);
                    if (column != -1 && line != -1)
                    {
                        processingResult.Feedback[line + 72].Score[column] += avg;
                    }
                }
            }
            return processingResult;
        }

        private int CheckInnerColumn(int x)
        {
            if (x <= 59)
                return 0;
            else if (x >= 66 && x <= 81)
                return 1;
            else if (x >= 88 && x <= 103)
                return 2;
            else if (x >= 109 && x <= 124)
                return 3;
            else if (x >= 131 && x <= 146)
                return 4;

            if (x >= 194 && x <= 209)
                return 0;
            else if (x >= 216 && x <= 230)
                return 1;
            else if (x >= 237 && x <= 252)
                return 2;
            else if (x >= 259 && x <= 274)
                return 3;
            else if (x >= 281 && x <= 296)
                return 4;

            if (x >= 343 && x <= 358)
                return 0;
            else if (x >= 365 && x <= 380)
                return 1;
            else if (x >= 387 && x <= 402)
                return 2;
            else if (x >= 409 && x <= 424)
                return 3;
            else if (x >= 431 && x <= 446)
                return 4;

            if (x >= 493 && x <= 508)
                return 0;
            else if (x >= 515 && x <= 530)
                return 1;
            else if (x >= 537 && x <= 552)
                return 2;
            else if (x >= 559 && x <= 574)
                return 3;
            else if (x >= 581 && x <= 596)
                return 4;

            if (x >= 643 && x <= 657)
                return 0;
            else if (x >= 665 && x <= 679)
                return 1;
            else if (x >= 687 && x <= 701)
                return 2;
            else if (x >= 709 && x <= 723)
                return 3;
            else if (x >= 731 && x <= 745)
                return 4;

            return -1;
        }
        private int CheckLine(int y)
        {
            if (y >= 30 && y <= 45)
                return 0;
            else if (y >= 56 && y <= 71)
                return 1;
            else if (y >= 81 && y <= 96)
                return 2;
            else if (y >= 107 && y <= 122)
                return 3;
            else if (y >= 132 && y <= 147)
                return 4;
            else if (y >= 158 && y <= 173)
                return 5;
            else if (y >= 183 && y <= 198)
                return 6;
            else if (y >= 209 && y <= 224)
                return 7;
            else if (y >= 234 && y <= 249)
                return 8;
            else if (y >= 260 && y <= 275)
                return 9;
            else if (y >= 285 && y <= 300)
                return 10;
            else if (y >= 311 && y <= 326)
                return 11;
            else if (y >= 336 && y <= 351)
                return 12;
            else if (y >= 362 && y <= 377)
                return 13;
            else if (y >= 387 && y <= 402)
                return 14;
            else if (y >= 413 && y <= 428)
                return 15;
            else if (y >= 438 && y <= 453)
                return 16;
            else if (y >= 464 && y <= 479)
                return 17;

            return -1;
        }
    }
}