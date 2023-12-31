using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using API_EXTERNAS;
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
            // Inicializa a conex�o com o banco de dados.
            conexao = new Conexao();
        }

        // Insere um novo registro de Cliente no banco de dados.
        public bool Insert(ClientePJ Cliente)
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constr�i a consulta SQL para inserir um novo registro de Cliente.
                var query = $"EXEC cadCliente " +
                     $" {Cliente.GetCnpj()}, " +
                     $"'{Cliente.GetNome()}'," +
                     $"'{Cliente.GetDadosAPI().telefone}', " +
                     $"'{Cliente.GetDadosAPI().logradouro}', " +
                     $"'{Cliente.GetDadosAPI().numero}', " +
                     $"'{Cliente.GetDadosAPI().bairro}', " +
                     $"'{Cliente.GetDadosAPI().municipio}', " +
                     $"'{Cliente.GetDadosAPI().uf}'";
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
                // Trata a exce��o de duplica��o de nome de usu�rio.
                throw new Exception($"Nome de usu�rio: {Cliente.GetNome()} est� duplicado" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Atualiza um registro existente de Cliente no banco de dados.
        public bool Update(ClientePJ Cliente, decimal cnpj)
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constr�i a consulta SQL para atualizar um registro existente de Cliente.
                var query = $"EXEC upCliente {cnpj}, '{Cliente.GetNome()}', '{Cliente.GetDadosAPI().telefone}', '{Cliente.GetDadosAPI().logradouro}', '{Cliente.GetDadosAPI().numero}', '{Cliente.GetDadosAPI().bairro}', '{Cliente.GetDadosAPI().municipio}', '{Cliente.GetDadosAPI().uf}'";
                // Executa a consulta e trata o valor de retorno.
                var linhasAfetadas = conn.Execute(query, Cliente);
                if (linhasAfetadas > 0)
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
                // Trata a exce��o de erro interno.
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
                // Constr�i a consulta SQL para excluir um registro de Cliente.
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
        public List<ClientePJ> Read()
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constr�i a consulta SQL para recuperar todos os registros de Cliente.
                var query = "EXEC readCliente";
                // Executa a consulta e retorna a lista de objetos Cliente.
                var clientes = conn.Query<ClientePJ, ModelApiReceita, ClientePJ>(query, (cliente, dadosAPI) =>
                {
                    cliente.SetDadosAPI(dadosAPI);
                    return cliente;
                }, splitOn: "telefone").ToList();
                
                if(clientes.Count > 0)
                {
                return clientes;
                }
                else
                {
                return null;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Mensagem: "+ ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Recupera uma lista de registros de Cliente com base em crit�rios de filtro.
        public List<ClientePJ> Filter(decimal? cnpj, string nome)
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constr�i a consulta SQL para filtrar registros de Cliente.
                var query = $"SELECT * FROM Cliente WHERE nome LIKE '{nome}%' AND Cnpj LIKE '{cnpj}%'";
                // Executa a consulta e retorna a lista filtrada de objetos Cliente.
                var cliente = conn.Query<ClientePJ>(query).ToList();
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

        // Recupera uma lista de todos os registros de Cliente para fins de relat�rio.
        public List<ClientePJ> report()
        {

            var conn = conexao.Connection();
            try
            {
                conn.Open();
                // Constr�i a consulta SQL para recuperar todos os registros de Cliente.
                var query = "SELECT * FROM Cliente";
                // Executa a consulta e retorna a lista de objetos Cliente para relat�rio.
                var clientes = conn.Query<ClientePJ>(query).ToList();
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
