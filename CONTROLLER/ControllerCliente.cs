
using System.Collections.Generic;
using System.Linq;
using MODEL;
using DAO;


namespace CONTROLLER {
    public class ControllerCliente {

        public ControllerCliente(){}
        public bool Insert(Cliente Cliente) 
        {
            DaoCliente dao = new DaoCliente();
            return dao.Insert(Cliente);
        }
        public bool Update(Cliente Cliente, decimal cnpj) 
        {
            DaoCliente dao = new DaoCliente();
            return dao.Update(Cliente, cnpj);
        }
        public bool Delete(decimal cnpj) 
        {
            DaoCliente dao = new DaoCliente();
            return dao.Delete(cnpj);
        }
        public List<Cliente> Read()
        {
            DaoCliente dao = new DaoCliente();
            return dao.Read();
        }
        public List<Cliente> Filter(decimal? cnpj, string nome) 
        {
            DaoCliente dao = new DaoCliente();
            return dao.Filter(cnpj, nome); 
        }
        public List<Cliente> Report()
        {
            DaoCliente dao = new DaoCliente();
            return dao.report();
        }
    }
}