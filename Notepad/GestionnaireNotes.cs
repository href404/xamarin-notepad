using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

namespace Notepad
{
    public class GestionnaireNotes
    {
        private FileInfo FichierNote;
        private Editor ZoneTextuel;
        
        public GestionnaireNotes(Editor zoneTextuel)
        {
            FichierNote = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notepad.txt"));
            ZoneTextuel = zoneTextuel;
        }

        public void SauvegarderNote()
        {
            try
            {
                string cheminFichierNote = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notepad.txt");
                string note = ZoneTextuel.Text;

                File.AppendAllText(cheminFichierNote, note);
                Debug.WriteLine("Sauvegarde effectuée !");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ZoneTextuel.Text = ex.Message;
            }
        }

        public void ChargerNote()
        {
            if (!FichierNote.Exists)
                throw new Exception("Le fichier de note n'existe pas.");

            ZoneTextuel.Text = File.ReadAllText(FichierNote.FullName);
            Debug.WriteLine("Les notes ont été chargées dans la zone textuel !");
        }
    }
}
