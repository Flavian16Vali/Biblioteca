using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Bussiness
{
    class CarteService
    {
        private readonly CarteRepository repository;

        public CarteService()
        {
            repository = new CarteRepository();
        }

        // 1. OPERAȚII CRUD cu validări business
        public void CreateCarte(Carte carte)
        {
            // Validări business
            if (string.IsNullOrWhiteSpace(carte.Titlu))
                throw new ArgumentException("Titlul este obligatoriu.");

            if (carte.AnPublicare < 1445 || carte.AnPublicare > DateTime.Now.Year)
                throw new ArgumentException($"Anul trebuie să fie între 1445 și {DateTime.Now.Year}.");

            if (carte.EdituraId <= 0)
                throw new ArgumentException("Selectați o editură validă.");

            if (carte.AutoriIds == null || carte.AutoriIds.Count == 0)
                throw new ArgumentException("Selectați cel puțin un autor.");

            // Apel către repository
            repository.CreateCarte(carte);
        }

        public void UpdateCarte(Carte carte)
        {
            // Aceleași validări ca la adăugare
            if (string.IsNullOrWhiteSpace(carte.Titlu))
                throw new ArgumentException("Titlul este obligatoriu.");

            if (carte.AnPublicare < 1445 || carte.AnPublicare > DateTime.Now.Year)
                throw new ArgumentException($"Anul trebuie să fie între 1445 și {DateTime.Now.Year}.");

            if (carte.EdituraId <= 0)
                throw new ArgumentException("Selectați o editură validă.");

            if (carte.AutoriIds == null || carte.AutoriIds.Count == 0)
                throw new ArgumentException("Selectați cel puțin un autor.");

            repository.UpdateCarte(carte);
        }

        public void DeleteCarte(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID invalid.");

            repository.DeleteCarte(id);
        }

        // 2. OPERAȚII DE CITIRE
        public List<Carte> GetToateCartile()
        {
            return repository.GetCarti();
        }

        public Carte GetCarteDupaId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID invalid.");

            return repository.GetCarte(id);
        }

        public DataTable GetEdituri()
        {
            return repository.GetEdituri();
        }

        public DataTable GetAutori()
        {
            return repository.GetAutori();
        }

        // 3. OPERAȚII CU FILTRE
        public DataTable GetCartiFiltrare(int? anMin, int? anMax, int? edituraId, int? autorId)
        {
            // Validări business pentru filtre
            if (anMin.HasValue && anMax.HasValue && anMin > anMax)
                throw new ArgumentException("Anul minim nu poate fi mai mare decât anul maxim.");

            return repository.GetCartiFiltrare(anMin, anMax, edituraId, autorId);
        }

        // 4. METODE UTILITARE BUSINESS
        public bool ExistaCarteCuTitlu(string titlu)
        {
            if (string.IsNullOrWhiteSpace(titlu))
                return false;

            var carti = repository.GetCarti();
            return carti.Any(c => c.Titlu.Equals(titlu, StringComparison.OrdinalIgnoreCase));
        }

        public int NumaraCartiPentruEditura(int edituraId)
        {
            if (edituraId <= 0)
                return 0;

            var carti = repository.GetCarti();
            return carti.Count(c => c.EdituraId == edituraId);
        }
    }
}
