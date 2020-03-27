using System;
using System.IO;

namespace Notepad.Modeles
{
    public class NoteModele
    {
        public int Id { get; set; }
        public string Contenu { get; set; }
        public FileInfo Chemin { get; set; }
        public DateTime DateDerniereModification { get; set; }
    }
}
