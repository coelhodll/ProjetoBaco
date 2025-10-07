using Dapper;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryBase(IDbConnection dbConnection) : IRepositoryBase
    {
        private readonly IDbConnection _dbConnection = dbConnection;
        public void Init()
        {
            _dbConnection.Open();

            string sqlCreateTablePersonagens = @"CREATE TABLE IF NOT EXISTS Personagens (
                        Id SERIAL PRIMARY KEY,
                        Nome VARCHAR(255) NOT NULL,
                        TipoDeChakra VARCHAR(50) NOT NULL,
                        Vila VARCHAR(100) NOT NULL,
                        Vivo BOOLEAN NOT NULL DEFAULT TRUE,
                        JutsuPrincipal VARCHAR(255) NOT NULL
                    );";

            _dbConnection.Execute(sqlCreateTablePersonagens);
            _dbConnection.Close();
        }
    }
}
