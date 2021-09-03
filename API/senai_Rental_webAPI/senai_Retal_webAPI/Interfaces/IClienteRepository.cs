using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using senai_Rental_webAPI.Domains;

namespace senai_Rental_webAPI.Interfaces
{
    interface IClienteRepository
    {
        List<ClienteDomain> ListarTodos();
        ClienteDomain BuscarPorId(int idCliente);
        void Cadastrar(ClienteDomain novoCliente);
        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);
        void Deletar(int idCliente);
    }
}
