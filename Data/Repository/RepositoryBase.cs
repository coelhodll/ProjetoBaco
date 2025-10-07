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
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    TipoDeChakra TEXT NOT NULL,
                    Vila TEXT NOT NULL,
                    Vivo INTEGER NOT NULL,
                    JutsuPrincipal TEXT NOT NULL);";

            _dbConnection.Execute(sqlCreateTablePersonagens);
            _dbConnection.Close();
        }
    }
}
