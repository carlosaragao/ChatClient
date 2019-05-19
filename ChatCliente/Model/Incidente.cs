using System;

namespace ChatCliente.Model
{
    class Incidente
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime dataIncidente { get; set; }
        public string solucao { get; set; }
    }
}
