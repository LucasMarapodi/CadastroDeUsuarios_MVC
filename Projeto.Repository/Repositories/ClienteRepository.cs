using Dapper;
using Projeto.Repository.Contracts;
using Projeto.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        #region connectionString

        private readonly string connectionString;

        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        public void Create(Cliente entity)
        {
            var query = "insert into Cliente (Nome,DataNascimento,Email,Usuario,Senha)"
                + "values(@Nome,@DataNascimento,@Email,@Usuario,@Senha)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Cliente> GetAll()
        {
            var query = "Select idCliente,Nome,DataNascimento,Email,Usuario,Senha "
                + "From Cliente";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query).ToList();
            }
        }
    }
}
