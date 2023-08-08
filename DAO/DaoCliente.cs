using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CONEXAO;
using Dapper;
using MODEL;

namespace DAO {
    public class DaoCliente {

        Conexao conexao { get; set; }

        public DaoCliente() 
        {
        conexao = new Conexao();
        }
        public bool Insert(Cliente Cliente) {

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

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                var query = $"EXEC upCliente {Cliente.GetCnpj()}, '{Cliente.GetNome()}', '{Cliente.GetTelefone()}', '{Cliente.GetRua()}', '{Cliente.GetNumero()}', '{Cliente.GetBairro()}', '{Cliente.GetCidade()}', '{Cliente.GetSiglaEs()}'";
                var resultado = conn.Execute(query, Cliente);
                if (resultado > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
                throw new Exception("Erro interno" + ex.Message);
            }
            finally
            {
                conn.Close() ;
            } 
        }
        public bool Delete(decimal cnpj) {

            var conn = conexao.Connection();
            try
            {
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
            }catch(Exception ex) {

                conn.Close();
                return false;
            }
            finally
            {
                conn.Close(); 
            }            
        }
        public List<Cliente> Read() {
           
            var conn = conexao.Connection();
            try
            {
                conn.Open();
                var query = "SELECT * FROM Cliente";
                var clientes = conn.Query<Cliente>(query).ToList();
                return clientes;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
            finally
            {
                conn.Close();
            } 
        }
        public List<Cliente> Filter(decimal? cnpj, string nome) {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                var query = $"SELECT * FROM Cliente WHERE nome LIKE '{nome}%' AND Cnpj LIKE '{cnpj}%'";
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
        public List<Cliente> report() {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                var query = "SELECT * FROM Cliente";
                var clientes = conn.Query<Cliente>(query).ToList();
                return clientes;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}