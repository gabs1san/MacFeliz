using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace MacFeliz.Models
{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IFormeFile { get; set; }
        public List<IFormFile> IFormFiles { get; set; }

        public string PathImagesProduto { get; set; }
    }
}
