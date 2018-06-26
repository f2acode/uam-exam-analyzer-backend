using ImagesExamProcess.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace ImagesExamProcess.Controllers
{
    public class ImagesController : ApiController
    {
        [HttpPost]
        public ProcessingResult Post([FromBody]ImageModel imageModel)
        {
            var processingResult = new ProcessingResult
            {
                Feedback = new List<QuestionAnswer>(90)
                {
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]}
                }
            };

            /* Convert imageBase64 to Image */

            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(imageModel.ImageBase64);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            /* convert to Bitmap */
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

            /* Convert to grayscale image */
            Bitmap newBmp = bmp;
            
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    newBmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));

                    if (x >= 44 && x <= 146 && y >= 30 && y <= 45)
                    {
                        if (x <= 59)
                        {
                            processingResult.Feedback[0].Score[0] += avg;
                        }
                        else if (x >= 66 && x <= 81)
                        {
                            processingResult.Feedback[0].Score[1] += avg;
                        }
                        else if (x >= 88 && x <= 103)
                        {
                            processingResult.Feedback[0].Score[2] += avg;
                        }
                        else if (x >= 109 && x <= 124)
                        {
                            processingResult.Feedback[0].Score[3] += avg;
                        }
                        else if (x >= 131 && x <= 146)
                        {
                            processingResult.Feedback[0].Score[4] += avg;
                        }
                    }

                    if (x >= 44 && x <= 146 && y >= 56 && y <= 71)
                    {
                        if (x <= 59)
                        {
                            processingResult.Feedback[1].Score[0] += avg;
                        }
                        else if (x >= 66 && x <= 81)
                        {
                            processingResult.Feedback[1].Score[1] += avg;
                        }
                        else if (x >= 88 && x <= 103)
                        {
                            processingResult.Feedback[1].Score[2] += avg;
                        }
                        else if (x >= 109 && x <= 124)
                        {
                            processingResult.Feedback[1].Score[3] += avg;
                        }
                        else if (x >= 131 && x <= 146)
                        {
                            processingResult.Feedback[1].Score[4] += avg;
                        }
                    }

                    if (x >= 44 && x <= 146 && y >= 81 && y <= 96)
                    {
                        if (x <= 59)
                        {
                            processingResult.Feedback[1].Score[0] += avg;
                        }
                        else if (x >= 66 && x <= 81)
                        {
                            processingResult.Feedback[1].Score[1] += avg;
                        }
                        else if (x >= 88 && x <= 103)
                        {
                            processingResult.Feedback[1].Score[2] += avg;
                        }
                        else if (x >= 109 && x <= 124)
                        {
                            processingResult.Feedback[1].Score[3] += avg;
                        }
                        else if (x >= 131 && x <= 146)
                        {
                            processingResult.Feedback[1].Score[4] += avg;
                        }
                    }

                    if (x >= 44 && x <= 146 && y >= 107 && y <= 122)
                    {
                        if (x <= 59)
                        {
                            processingResult.Feedback[1].Score[0] += avg;
                        }
                        else if (x >= 66 && x <= 81)
                        {
                            processingResult.Feedback[1].Score[1] += avg;
                        }
                        else if (x >= 88 && x <= 103)
                        {
                            processingResult.Feedback[1].Score[2] += avg;
                        }
                        else if (x >= 109 && x <= 124)
                        {
                            processingResult.Feedback[1].Score[3] += avg;
                        }
                        else if (x >= 131 && x <= 146)
                        {
                            processingResult.Feedback[1].Score[4] += avg;
                        }
                    }
                }
            }

            // preenche as respostas
            foreach(var item in processingResult.Feedback)
            {
                var index = processingResult.Feedback.IndexOf(item);
                processingResult.Feedback[index].Answer = Array.IndexOf(item.Score, item.Score.Min());
            }
            
            return processingResult;
        }
    }
}
