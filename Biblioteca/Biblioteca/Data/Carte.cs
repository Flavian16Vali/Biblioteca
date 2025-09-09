using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class Carte
    {
        private int id;
        private string titlu;
        private int anPublicare;
        private string descriere;

        private int edituraId;
        private string numeEditura;
        private List<int> autoriIds;
        private string numeAutori;

        public Carte()
        {
            autoriIds = new List<int>();
        }


        public int Id { get => id; set => id = value; }
        public string Titlu { get => titlu; set => titlu = value; }
        public int AnPublicare { get => anPublicare; set => anPublicare = value; }
        public string Descriere { get => descriere; set => descriere = value; }

        public int EdituraId { get => edituraId; set => edituraId = value; }
        public string NumeEditura { get => numeEditura; set => numeEditura = value; }
        public List<int> AutoriIds { get => autoriIds; set => autoriIds = value; }
        public string NumeAutori { get => numeAutori; set => numeAutori = value; }
    }
}
