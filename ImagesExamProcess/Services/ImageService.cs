using ImagesExamProcess.Models;
using System;
using System.IO;
using System.Drawing;

namespace ImagesExamProcess.Services
{
    public class ImageService
    {
        double fatorX = 1.75;
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
            for (int x = (int)(44 * fatorX); x < (int)(146 * fatorX)/*bmp.Width*/; x++)
            {
                for (int y = (int)(30 *fatorX); y < (int)(479 * fatorX)/*bmp.Height*/; y++)
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

            for (int x = (int)(194 * fatorX); x < (int)(296 * fatorX)/*bmp.Width*/; x++)
            {
                for (int y = (int)(30 * fatorX); y < (int)(479 * fatorX)/*bmp.Height*/; y++)
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

            for (int x = (int)(343 * fatorX); x < (int)(445 * fatorX)/*bmp.Width*/; x++)
            {
                for (int y = (int)(30 * fatorX); y < (int)(479 * fatorX)/*bmp.Height*/; y++)
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

            for (int x = (int)(493 * fatorX); x < (int)(595 * fatorX)/*bmp.Width*/; x++)
            {
                for (int y = (int)(30 * fatorX); y < (int)(479 *fatorX)/*bmp.Height*/; y++)
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

            for (int x = (int)(642 * fatorX); x < (int)(774 * fatorX)/*bmp.Width*/; x++)
            {
                for (int y = (int)(30 * fatorX); y < (int)(479 * fatorX)/*bmp.Height*/; y++)
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
            if (x <= (int)( fatorX * 59))
                return 0;
            else if (x >= (int) ( 66 * fatorX ) && x <=  (int)( fatorX * 81))
                return 1;
            else if (x >= (int) ( 88 * fatorX ) && x <=  (int)( fatorX * 103))
                return 2;
            else if (x >= (int) ( 109 * fatorX ) && x <=  (int)( fatorX * 124))
                return 3;
            else if (x >= (int) ( 131 * fatorX ) && x <=  (int)( fatorX * 146))
                return 4;

            if (x >= (int) ( 194 * fatorX ) && x <=  (int)( fatorX * 209))
                return 0;
            else if (x >= (int) ( 216 * fatorX ) && x <=  (int)( fatorX * 230))
                return 1;
            else if (x >= (int) ( 237 * fatorX ) && x <=  (int)( fatorX * 252))
                return 2;
            else if (x >= (int) ( 259 * fatorX ) && x <=  (int)( fatorX * 274))
                return 3;
            else if (x >= (int) ( 281 * fatorX ) && x <=  (int)( fatorX * 296))
                return 4;

            if (x >= (int) ( 343 * fatorX ) && x <=  (int)( fatorX * 358))
                return 0;
            else if (x >= (int) ( 365 * fatorX ) && x <=  (int)( fatorX * 380))
                return 1;
            else if (x >= (int) ( 387 * fatorX ) && x <=  (int)( fatorX * 402))
                return 2;
            else if (x >= (int) ( 409 * fatorX ) && x <=  (int)( fatorX * 424))
                return 3;
            else if (x >= (int) ( 431 * fatorX ) && x <=  (int)( fatorX * 446))
                return 4;

            if (x >= (int) ( 493 * fatorX ) && x <=  (int)( fatorX * 508))
                return 0;
            else if (x >= (int) ( 515 * fatorX ) && x <=  (int)( fatorX * 530))
                return 1;
            else if (x >= (int) ( 537 * fatorX ) && x <=  (int)( fatorX * 552))
                return 2;
            else if (x >= (int) ( 559 * fatorX ) && x <=  (int)( fatorX * 574))
                return 3;
            else if (x >= (int) ( 581 * fatorX ) && x <=  (int)( fatorX * 596))
                return 4;

            if (x >= (int) ( 643 * fatorX ) && x <=  (int)( fatorX * 657))
                return 0;
            else if (x >= (int) ( 665 * fatorX ) && x <=  (int)( fatorX * 679))
                return 1;
            else if (x >= (int) ( 687 * fatorX ) && x <=  (int)( fatorX * 701))
                return 2;
            else if (x >= (int) ( 709 * fatorX ) && x <=  (int)( fatorX * 723))
                return 3;
            else if (x >= (int) ( 731 * fatorX ) && x <=  (int)( fatorX * 745))
                return 4;

            return -1;
        }
        private int CheckLine(int y)
        {
            if (y >= (int) ( 30 * fatorX ) && y <=  (int)( 45 * fatorX))
                return 0;
            else if (y >= (int) ( 56 * fatorX ) && y <=  (int)( 71 * fatorX))
                return 1;
            else if (y >= (int) ( 81 * fatorX ) && y <=  (int)( 96 * fatorX))
                return 2;
            else if (y >= (int) ( 107 * fatorX ) && y <=  (int)( 122 * fatorX))
                return 3;
            else if (y >= (int) ( 132 * fatorX ) && y <=  (int)( fatorX * 147))
                return 4;
            else if (y >= (int) ( 158 * fatorX ) && y <=  (int)( fatorX * 173))
                return 5;
            else if (y >= (int) ( 183 * fatorX ) && y <=  (int)( fatorX * 198))
                return 6;
            else if (y >= (int) ( 209 * fatorX ) && y <=  (int)( fatorX * 224))
                return 7;
            else if (y >= (int) ( 234 * fatorX ) && y <=  (int)( fatorX * 249))
                return 8;
            else if (y >= (int) ( 260 * fatorX ) && y <=  (int)( fatorX * 275))
                return 9;
            else if (y >= (int) ( 285 * fatorX ) && y <=  (int)( fatorX * 300))
                return 10;
            else if (y >= (int) ( 311 * fatorX ) && y <=  (int)( fatorX * 326))
                return 11;
            else if (y >= (int) ( 336 * fatorX ) && y <=  (int)( fatorX * 351))
                return 12;
            else if (y >= (int) ( 362 * fatorX ) && y <=  (int)( fatorX * 377))
                return 13;
            else if (y >= (int) ( 387 * fatorX ) && y <=  (int)( fatorX * 402))
                return 14;
            else if (y >= (int) ( 413 * fatorX ) && y <=  (int)( fatorX * 428))
                return 15;
            else if (y >= (int) ( 438 * fatorX ) && y <=  (int)( fatorX * 453))
                return 16;
            else if (y >= (int) ( 464 * fatorX ) && y <=  (int)( fatorX * 479))
                return 17;

            return -1;
        }
    }
}