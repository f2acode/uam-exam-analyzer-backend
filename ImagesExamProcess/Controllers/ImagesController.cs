using ImagesExamProcess.Models;
using ImagesExamProcess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ImagesExamProcess.Controllers
{
    public class ImagesController : ApiController
    {
        readonly ImageService ImageService = new ImageService();

        [HttpPost]
        public ProcessingResult Post([FromBody]ImageModel imageModel)
        {
            var processingResult = new ProcessingResult
            {
                Feedback = new List<QuestionAnswer>(90)
                {
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},

                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},

                     new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},

                     new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},

                     new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                    new QuestionAnswer{Score = new int[5]},
                }
            };

            processingResult = ImageService.ProcessENEMAnswerKey(imageModel, processingResult);

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            foreach (var item in processingResult.Feedback)
            {
                var index = processingResult.Feedback.IndexOf(item);
                processingResult.Feedback[index].Question = index + 1;
                processingResult.Feedback[index].Answer = alpha[Array.IndexOf(item.Score, item.Score.Min())];
                processingResult.Feedback[index].Score = null;
            }

            return processingResult;
        }
    }
}
