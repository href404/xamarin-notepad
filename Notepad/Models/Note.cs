using System;
using System.IO;

namespace Notepad.Models
{
    public class Note
    {
        public string Content { get; set; }
        public FileInfo Path { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
