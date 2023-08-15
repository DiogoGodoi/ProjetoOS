using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CONEXAO;
using Dapper;
using MODEL;

namespace DAO
{
    public class DaoCliente
    {
        Conexao conexao { get; set; }

        // Construtor para a classe DaoCliente.
        public DaoCliente()
        {
            // Inicializa a conexão com o banco de dados.
            conexao = new Conexao();
        }

        // Insere um novo registro de Cliente no banco de dados.
        public bool Insert(Cliente Cliente)
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constrói a consulta SQL para inserir um novo registro de Cliente.
                var query = $"EXEC cadCliente " +
                     $" {Cliente.GetCnpj()}, " +
                     $"'{Cliente.GetNome()}'," +
                     $"'{Cliente.GetEndereco().telefone}', " +
                     $"'{Cliente.GetEndereco().logradouro}', " +
                     $"'{Cliente.GetEndereco().numero}', " +
                     $"'{Cliente.GetEndereco().bairro}', " +
                     $"'{Cliente.GetEndereco().municipio}', " +
                     $"'{Cliente.GetEndereco().uf}'";
                // Executa a consulta e trata o valor de retorno.
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
                // Trata a exceção de duplicação de nome de usuário.
                throw new Exception($"Nome de usuário: {Cliente.GetNome()} está duplicado" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Atualiza um registro existente de Cliente no banco de dados.
        public bool Update(Cliente Cliente, decimal cnpj)
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constrói a consulta SQL para atualizar um registro existente de Cliente.
                var query = $"EXEC upCliente {Cliente.GetCnpj()}, '{Cliente.GetNome()}', '{Cliente.GetEndereco().telefone}', '{Cliente.GetEndereco().logradouro}', '{Cliente.GetEndereco().numero}', '{Cliente.GetEndereco().bairro}', '{Cliente.GetEndereco().municipio}', '{Cliente.GetEndereco().uf}'";
                // Executa a consulta e trata o valor de retorno.
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
                // Trata a exceção de erro interno.
                throw new Exception("Erro interno" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Exclui um registro de Cliente do banco de dados.
        public bool Delete(decimal cnpj)
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constrói a consulta SQL para excluir um registro de Cliente.
                var query = $"EXEC delCliente {cnpj}";
                // Executa a consulta e trata o valor de retorno.
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
            catch (Exception ex)
            {

                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // Recupera uma lista de todos os registros de Cliente do banco de dados.
        public List<Cliente> Read()
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constrói a consulta SQL para recuperar todos os registros de Cliente.
                var query = "SELECT * FROM Cliente";
                // Executa a consulta e retorna a lista de objetos Cliente.
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

        // Recupera uma lista de registros de Cliente com base em critérios de filtro.
        public List<Cliente> Filter(decimal? cnpj, string nome)
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constrói a consulta SQL para filtrar registros de Cliente.
                var query = $"SELECT * FROM Cliente WHERE nome LIKE '{nome}%' AND Cnpj LIKE '{cnpj}%'";
                // Executa a consulta e retorna a lista filtrada de objetos Cliente.
                var cliente = conn.Query<Cliente>(query).ToList();
                return cliente;

            }
            catch (SqlException)
            {
                conn.Close();
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        // Recupera uma lista de todos os registros de Cliente para fins de relatório.
        public List<Cliente> report()
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constrói a consulta SQL para recuperar todos os registros de Cliente.
                var query = "SELECT * FROM Cliente";
                // Executa a consulta e retorna a lista de objetos Cliente para relatório.
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
