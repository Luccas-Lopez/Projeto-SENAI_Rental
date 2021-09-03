using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idVeiculo { get; set; }
        public int idCliente { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }

        public VeiculoDomain veiculo { get; set; }
        public ClienteDomain cliente { get; set; }
    }
}
