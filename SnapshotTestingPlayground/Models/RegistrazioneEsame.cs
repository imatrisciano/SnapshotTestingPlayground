namespace SnapshotTestingPlayground.Models
{
    public record RegistrazioneEsame(
        Studente Studente, 
        Corso Corso, 
        int Voto, 
        bool Lode = false)
    {
        public int VotoConBonusLode
        {
            get => Lode ? Voto + 1 : Voto;
        }
    }
}
