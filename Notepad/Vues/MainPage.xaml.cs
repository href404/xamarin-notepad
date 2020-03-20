using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly GestionnaireNote GestionnaireNote;

        public MainPage() { 
            InitializeComponent();

            GestionnaireNote = new GestionnaireNote(ZoneTextuel);
            GestionnaireNote.ChargerNote();
        }

        private void Button_Clicked(object sender, EventArgs e) { GestionnaireNote.SauvegarderNote(); }

    }
}