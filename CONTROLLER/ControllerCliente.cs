
using System.Collections.Generic;
using System.Linq;
using MODEL;
using DAO;


namespace CONTROLLER {
    public class ControllerCliente {

        DaoCliente dao = new DaoCliente();
        public ControllerCliente() {
        }

        public bool Insert(Cliente Cliente) {
            return dao.Insert(Cliente);
        }

        public bool Update(Cliente Cliente, decimal cnpj) {
            return dao.Update(Cliente, cnpj);
        }

        public bool Delete(decimal cnpj) {
            return dao.Delete(cnpj);
        }

        public List<Cliente> Read()
        {
            return dao.Read();
        }

        //public Cliente Filter(long cnpj) {

        //}

        public void report()
        {

        }

    }
}