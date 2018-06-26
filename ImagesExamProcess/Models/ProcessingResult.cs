using System.Collections.Generic;

namespace ImagesExamProcess.Models
{
    public class ProcessingResult
    {
        public List<QuestionAnswer> Feedback { get; set; }
        public int Hits { get; set; }
        public int TotalQuestions { get; set; }
    }
}
