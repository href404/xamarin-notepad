using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Notepad.Services.Implementations
{
    public class NoteService : INoteService
    {

        private const string EXTENSION_FICHIER_TEXTE = ".txt";

        private readonly ISettingsService settingsService;

        public NoteService(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public void Save(Note note)
        {
            if (note.Path == null)
                note.Path = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Guid.NewGuid() + EXTENSION_FICHIER_TEXTE));
            
            note.UpdatedAt = DateTime.Now;
            File.WriteAllText(note.Path.FullName, note.Content);
            Debug.WriteLine("Sauvegarde effectuée !");
        }

        public void Delete(Note note)
        {
            File.Delete(note.Path.FullName);
            note.Content = string.Empty;
        }

        public void Load(Note note)
        {
            if (!settingsService.HasNotesLoadedOnStart())
                return;

            if (!note.Path.Exists)
                return;

            note.Content = File.ReadAllText(note.Path.FullName);
            note.UpdatedAt = File.GetLastWriteTime(note.Path.FullName);
            Debug.WriteLine("Les notes ont été chargées dans la zone textuel !");
        }

        public Note[] Get()
        {
            List<Note> notes = new List<Note>();
            foreach (string fichier in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.txt"))
                notes.Add(new Note 
                { 
                    Content = File.ReadAllText(fichier),
                    Path = new FileInfo(fichier),
                    UpdatedAt = File.GetLastWriteTime(fichier)
                });

            return notes.ToArray();
        }
    }
}
