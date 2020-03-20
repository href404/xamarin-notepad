using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SauvegarderNote();
        }

        private void SauvegarderNote()
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
    }
}