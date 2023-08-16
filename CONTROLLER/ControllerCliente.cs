using System.Collections.Generic;
using MODEL;
using DAO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using API_EXTERNAS;

namespace CONTROLLER
{
    public class ControllerCliente
    {
        // Construtor para a classe ControllerCliente.
        public ControllerCliente() { }

        // Insere um novo registro de Cliente usando a classe DAO correspondente.
        public bool Insert(ClientePJ Cliente)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Insert(Cliente);
        }

        // Atualiza um registro existente de Cliente usando a classe DAO correspondente.
        public bool Update(ClientePJ Cliente, decimal cnpj)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Update(Cliente, cnpj);
        }

        // Exclui um registro de Cliente usando a classe DAO correspondente.
        public bool Delete(decimal cnpj)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Delete(cnpj);
        }

        // Recupera uma lista de todos os registros de Cliente usando a classe DAO correspondente.
        public List<ClientePJ> Read()
        {
            DaoCliente dao = new DaoCliente();
            return dao.Read();
        }

        // Recupera uma lista de registros de Cliente com base em critérios de filtro usando a classe DAO correspondente.
        public List<ClientePJ> Filter(decimal? cnpj, string nome)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Filter(cnpj, nome);
        }

        // Recupera uma lista de todos os registros de Cliente para fins de relatório usando a classe DAO correspondente.
        public List<ClientePJ> Report()
        {
            DaoCliente dao = new DaoCliente();
            return dao.report();
        }

    }
}
