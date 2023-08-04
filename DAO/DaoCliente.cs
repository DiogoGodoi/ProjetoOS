using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CONEXAO;
using Dapper;
using MODEL;

namespace DAO {
    public class DaoCliente {

        
        public DaoCliente() {
   
        }

        public bool Insert(Cliente Cliente) {
            Conexao conexao = new Conexao();
            var conn = conexao.Connection();

            try
            {
                conn.Open();
                var query = $"EXEC cadCliente " +
                     $" {Cliente.GetCnpj()}, " +
                     $"'{Cliente.GetNome()}'," +
                     $"'{Cliente.GetTelefone()}', " +
                     $"'{Cliente.GetRua()}', " +
                     $"'{Cliente.GetNumero()}', " +
                     $"'{Cliente.GetBairro()}', " +
                     $"'{Cliente.GetCidade()}', " +
                     $"'{Cliente.GetSiglaEs()}'";
                var retorno = conn.Execute(query, Cliente);
                if (retorno > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                conn.Close();
                return false;
                throw new Exception($"Nome de usuário: {Cliente.GetNome()} está duplicado" + ex.Message);
            }
            finally
            {
                conn.Close();
            }             
        }

        public bool Update(Cliente Cliente, decimal cnpj) {

            Conexao conexao = new Conexao();
            var conn = conexao.Connection();
            conn.Open();
            var query = $"EXEC upCliente {Cliente.GetCnpj()}, '{Cliente.GetNome()}', '{Cliente.GetTelefone()}', '{Cliente.GetRua()}', '{Cliente.GetNumero()}', '{Cliente.GetBairro()}', '{Cliente.GetCidade()}', '{Cliente.GetSiglaEs()}'";
            var resultado = conn.Execute(query, Cliente);
            if(resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(decimal cnpj) {
            Conexao conexao = new Conexao();
            var conn = conexao.Connection();
            conn.Open();
            var query = $"EXEC delCliente {cnpj}";
            var resultado = conn.Execute(query);
            if (resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Cliente> Read() {
           
            Conexao Conexao = new Conexao();
            var conn = Conexao.Connection();
            conn.Open();
            var query = "SELECT * FROM Cliente";
            var clientes = conn.Query<Cliente>(query).ToList();
            return clientes;
        }

        public List<Cliente> Filter(decimal cnpj, string nome) {

            Conexao Conexao = new Conexao();
            var conn = Conexao.Connection();
            try
            {
            conn.Open();
            var query = $"SELECT * FROM Cliente WHERE cnpj LIKE '{cnpj}%' OR nome LIKE '{nome}%'";
            var cliente = conn.Query<Cliente>(query).ToList();
            return cliente;

            }catch(SqlException)
            {
                conn.Close();
                return null;
            }
            finally
            {
                conn.Close() ;
            }
        }

        public void report() {
    
        }

    }
}