using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

namespace Notepad
{
    public class GestionnaireNote
    {

        #region Constantes
        
        private const string NOM_FICHIER_NOTE = "Notepad.txt";

        #endregion

        #region Variables

        private readonly FileInfo FichierNote;
        private readonly Editor ZoneTextuel;

        #endregion

        #region Constructeur

        public GestionnaireNote(Editor zoneTextuel)
        {
            FichierNote = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), NOM_FICHIER_NOTE));
            ZoneTextuel = zoneTextuel;
        }

        #endregion

        #region Méthodes publiques


        public void SauvegarderNote()
        {
            File.WriteAllText(FichierNote.FullName, ZoneTextuel.Text);
            Debug.WriteLine("Sauvegarde effectuée !");
        }

        public void SupprimerNote()
        {
            File.WriteAllText(FichierNote.FullName, string.Empty);
            ZoneTextuel.Text = string.Empty;
        }

        public void ChargerNote()
        {
            if (!FichierNote.Exists)
                return;

            ZoneTextuel.Text = File.ReadAllText(FichierNote.FullName);
            Debug.WriteLine("Les notes ont été chargées dans la zone textuel !");
        }

        #endregion

    }
}
