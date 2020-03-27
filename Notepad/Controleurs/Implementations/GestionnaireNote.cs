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
        
        private const string NOM_FICHIER_NOTE = "Notepad.txt";

        #endregion

        #region Variables

        private readonly IGestionnaireParametre GestionnaireParametre;
        private readonly FileInfo FichierNote;
        public readonly NoteModele Note;

        #endregion

        #region Constructeur

        public GestionnaireNote(NoteModele note, IGestionnaireParametre gestionnaireParametre)
        {
            GestionnaireParametre = gestionnaireParametre;
            Note = note;
            FichierNote = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), NOM_FICHIER_NOTE));
        }

        public GestionnaireNote(IGestionnaireParametre gestionnaireParametre)
        {
            GestionnaireParametre = gestionnaireParametre;
            FichierNote = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), NOM_FICHIER_NOTE));
        }

        #endregion

        #region Méthodes publiques

        public void SauvegarderNote()
        {
            File.WriteAllText(FichierNote.FullName, Note.Contenu);
            Debug.WriteLine("Sauvegarde effectuée !");
        }

        public void SupprimerNote()
        {
            File.Delete(FichierNote.FullName);
            Note.Contenu = string.Empty;
        }

        public void ChargerNote()
        {
            if (!GestionnaireParametre.ObtenirChargementNoteAuDemarrage())
                return;

            if (!FichierNote.Exists)
                return;

            Note.Contenu = File.ReadAllText(FichierNote.FullName);
            Debug.WriteLine("Les notes ont été chargées dans la zone textuel !");
        }

        public NoteModele[] ObtenirNotes()
        {
            List<NoteModele> notes = new List<NoteModele>();
            foreach (string fichier in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.txt"))
                notes.Add(new NoteModele { Contenu = File.ReadAllText(fichier) });

            return notes.ToArray();
        }

        #endregion

    }
}
