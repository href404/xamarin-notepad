using Notepad.Controleurs.Implementations;
using Notepad.Controleurs.Interfaces;
using Notepad.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeNotesPage : ContentPage
    {
        #region Variables

        private readonly IGestionnaireParametre GestionnaireParametre;
        private readonly IGestionnaireNote GestionnaireNote;

        #endregion
        #region Constructeur

        public ListeNotesPage() 
        { 
            InitializeComponent();
            GestionnaireParametre = new GestionnaireParametre();
            GestionnaireNote = new GestionnaireNote(GestionnaireParametre);
        }

        #endregion

        #region Implémentation ContentPage

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListeNotes.ItemsSource = GestionnaireNote.ObtenirNotes();
        }

        #endregion

        #region Evenements

        private void SurElementListeNoteSelectionnee(object sender, SelectedItemChangedEventArgs e)
        {

        }

        #endregion

    }
}