﻿using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Aurora
{
    internal sealed class ConnectionFactory
    {
        private readonly Engine _engine;

        internal ConnectionFactory(Engine engine) => _engine = engine;       

        internal DbConnection CreateConnection()
        {
            switch (_engine)
            {
                case Engine.SqlServer:
                    return new SqlConnection();

                case Engine.PostgreSql:
                    return new NpgsqlConnection();

                case Engine.MySql:
                    return new MySqlConnection();

                case Engine.MariaDB:
                    return new MySqlConnection();

                case Engine.SQLite:
                    return new SQLiteConnection();

                case Engine.Oracle:
                #pragma warning disable
                    return new OracleConnection();

                default:
                    throw new ArgumentOutOfRangeException("Not expected engine.");
            }
        }
    }
}
