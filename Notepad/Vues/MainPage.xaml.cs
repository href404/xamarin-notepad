using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly GestionnaireNotes GestionnaireNotes;

        public MainPage() { 
            InitializeComponent();

            GestionnaireNotes = new GestionnaireNotes(ZoneTextuel);
            GestionnaireNotes.ChargerNote();
        }

        private void Button_Clicked(object sender, EventArgs e) { GestionnaireNotes.SauvegarderNote(); }

    }
}