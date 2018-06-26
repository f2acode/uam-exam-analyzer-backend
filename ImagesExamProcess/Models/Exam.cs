using System.Collections.Generic;

namespace ImagesExamProcess.Models
{
    public class Exam
    {
        public string Title { get; set; }
        public List<QuestionAnswer> Questions { get; set; }
    }
}