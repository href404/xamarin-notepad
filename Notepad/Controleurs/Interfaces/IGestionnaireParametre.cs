namespace Notepad.Controleurs.Interfaces
{
    public interface IGestionnaireParametre
    {
        bool ObtenirSauvegarderNoteSurFermeture();
        bool ObtenirChargementNoteAuDemarrage();
        void DefinirChargementNoteAuDemarrage(bool estNoteChargeeAuDemarrage);
        void DefinirSauvegarderNoteSurFermeture(bool estNoteSauvegardeeSurFermeture);
    }
}
