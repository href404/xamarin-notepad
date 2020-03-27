using Notepad.Controleurs.Interfaces;
using Notepad.Modeles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Notepad.Controleurs.Implementations
{
    public class GestionnaireNote : IGestionnaireNote
    {

        #region Constantes
        
        private const string EXTENSION_FICHIER_TEXTE = ".txt";

        #endregion

        #region Variables

        private readonly IGestionnaireParametre GestionnaireParametre;

        #endregion

        #region Constructeur

        public GestionnaireNote(IGestionnaireParametre gestionnaireParametre)
        {
            GestionnaireParametre = gestionnaireParametre;
        }

        #endregion

        #region Méthodes publiques

        public void SauvegarderNote(NoteModele note)
        {
            note.Chemin = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Guid.NewGuid() + EXTENSION_FICHIER_TEXTE));
            note.DateDerniereModification = DateTime.Now;
            File.WriteAllText(note.Chemin.FullName, note.Contenu);
            Debug.WriteLine("Sauvegarde effectuée !");
        }

        public void SupprimerNote(NoteModele note)
        {
            File.Delete(note.Chemin.FullName);
            note.Contenu = string.Empty;
        }

        public void ChargerNote(NoteModele note)
        {
            if (!GestionnaireParametre.ObtenirChargementNoteAuDemarrage())
                return;

            if (!note.Chemin.Exists)
                return;

            note.Contenu = File.ReadAllText(note.Chemin.FullName);
            note.DateDerniereModification = File.GetLastWriteTime(note.Chemin.FullName);
            Debug.WriteLine("Les notes ont été chargées dans la zone textuel !");
        }

        public NoteModele[] ObtenirNotes()
        {
            List<NoteModele> notes = new List<NoteModele>();
            foreach (string fichier in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.txt"))
                notes.Add(new NoteModele 
                { 
                    Contenu = File.ReadAllText(fichier),
                    Chemin = new FileInfo(fichier),
                    DateDerniereModification = File.GetLastWriteTime(fichier)
                });

            return notes.ToArray();
        }

        #endregion

    }
}
