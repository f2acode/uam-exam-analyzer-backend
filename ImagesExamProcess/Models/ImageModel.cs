using System;

namespace ImagesExamProcess.Models
{
    public class ImageModel
    {
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
    }
}
