// -------------------------------------------------------------------------------
// <copyright file="RepositoryAbstract.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Repository.Base
{
    #region Imports
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Dapper;
    using StarGuddy.Repository.Configuration;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Repository Abstract With Generic Function
    /// </summary>
    /// <typeparam name="T">Generic parameter</typeparam>
    /// <seealso cref="System.IDisposable" />
    /// <inheritdoc />
    public abstract class RepositoryAbstract<T> : IDisposable
    {
        /// <summary>
        /// The table name
        /// </summary>
        private readonly string tableName;

        /// <summary>
        /// The configuration singleton
        /// </summary>
        private readonly IConfigurationSingleton configurationSingleton;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAbstract{T}" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        /// <param name="tableName">Name of the table.</param>
        public RepositoryAbstract(IConfigurationSingleton configurationSingleton, string tableName)
        {
            this.configurationSingleton = configurationSingleton;
            this.tableName = tableName;
        }

        /// <summary>
        /// Creation an object of SQL connection
        /// </summary>
        /// <value>
        /// The SQL connection.
        /// </value>
        public SqlConnection Connection => new SqlConnection(this.configurationSingleton.SQLConnectionString);

        /// <summary>
        /// Gets a value indicating whether this instance is connection open.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is connection open; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnectionOpen => this.Connection.State == ConnectionState.Open;

        /// <summary>
        /// Gets the open connection.
        /// </summary>
        /// <value>
        /// The get open connection.
        /// </value>
        public SqlConnection OpenConnection
        {
            get
            {
                if (this.Connection.State == ConnectionState.Closed || this.Connection.State == ConnectionState.Broken)
                {
                    this.Connection.Open();
                }

                return this.Connection;
            }
        }

        /// <summary>
        /// Gets the get open connection asynchronous.
        /// </summary>
        /// <returns>
        /// The get open connection asynchronous.
        /// </returns>
        public SqlConnection OpenConnectionAsync
        {
            get
            {
                if (this.Connection.State == ConnectionState.Closed || this.Connection.State == ConnectionState.Broken)
                {
                    Connection.OpenAsync().ConfigureAwait(false);
                }

                return Connection;
            }

        }

        /// <summary>
        /// Gets the sequence identifier.
        /// </summary>
        /// <value>
        /// The get sequence identifier.
        /// </value>
        public Guid GetSequenceId
        {
            get
            {
                using (var conn = OpenConnectionAsync)
                {
                    var result = SqlMapper.QueryAsync(conn, "select NEWID()");
                    return new Guid(result.Result.ToString());
                }
            }
        }

        /// <summary>
        /// Finds the single.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// Generic Type
        /// </returns>
        public virtual T FindSingle(string query, dynamic parameter)
        {
            using (var conn = OpenConnection)
            {
                return conn.QueryFirstOrDefault<T>(query, (object)parameter);
            }
        }
        public virtual async Task<T> FindSingleAsync(string query, dynamic parameter)
        {
            using (var conn = OpenConnectionAsync)
            {
                return await conn.QueryFirstOrDefaultAsync<T>(query, (object)parameter);
            }
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetAll()
        {
            using (var connection = OpenConnection)
            {
                return connection.Query<T>("SELECT * FROM " + this.tableName);
            }
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = OpenConnectionAsync)
            {
                return await connection.QueryAsync<T>("SELECT * FROM " + tableName);
            }
        }

        /// <summary>
        /// Gets all by parameter.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetAllByParameter(string query, dynamic parameter)
        {
            using (var connection = OpenConnection)
            {
                return SqlMapper.Query<T>(connection, query, parameter, commandType: CommandType.Text);
            }
        }
        public virtual async Task<IEnumerable<T>> GetAllByParameterAsync(string query, dynamic parameter)
        {
            using (var connection = OpenConnectionAsync)
            {
                return await SqlMapper.QueryAsync<T>(connection, query, parameter, commandType: CommandType.Text);
            }
        }

        /// <summary>
        /// Gets the procedure data.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetProcedureData(string storeProcedureName)
        {
            using (var connection = OpenConnection)
            {
                return SqlMapper.Query<T>(connection, storeProcedureName, commandType: CommandType.StoredProcedure);
            }
        }
        public virtual async Task<IEnumerable<T>> GetProcedureDataAsync(string storeProcedureName)
        {
            using (var connection = OpenConnectionAsync)
            {
                return await SqlMapper.QueryAsync<T>(connection, storeProcedureName, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Gets the procedure data.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetProcedureData(string storeProcedureName, dynamic parameter)
        {
            using (var connection = OpenConnection)
            {
                return SqlMapper.Query<T>(connection, storeProcedureName, parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public virtual async Task<IEnumerable<T>> GetProcedureDataAsync(string storeProcedureName, dynamic parameter)
        {
            using (var connection = OpenConnectionAsync)
            {
                return await SqlMapper.QueryAsync<T>(connection, storeProcedureName, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual T FindById(Guid id)
        {
            using (var conn = OpenConnection)
            {
                return SqlMapper.Query<T>(conn, "SELECT * FROM " + this.tableName + " WHERE ID = @ID", new { ID = id }, commandType: CommandType.Text).FirstOrDefault();
            }
        }
        public virtual async Task<T> FindActiveByIdAsync(Guid id)
        {
            using (var conn = OpenConnectionAsync)
            {
                return (await SqlMapper.QueryAsync<T>(
                    conn,
                    "SELECT * FROM " + this.tableName + " WHERE Id = @Id AND IsActive = @IsActive AND IsDeleted = @IsDeleted",
                    new { Id = id, IsActive = 1, IsDeleted = 0 },
                    commandType: CommandType.Text)).FirstOrDefault();
            }
        }
        public virtual async Task<T> FindActiveByUserIdAsync(Guid userId)
        {
            using (var conn = OpenConnectionAsync)
            {
                return (await SqlMapper.QueryAsync<T>(
                    conn,
                    "SELECT * FROM " + this.tableName + " WHERE UserId = @UserId AND IsActive = @IsActive AND IsDeleted = @IsDeleted",
                    new { UserId = userId, IsActive = 1, IsDeleted = 0 },
                    commandType: CommandType.Text)).FirstOrDefault();
            }
        }

        public virtual async Task<IEnumerable<T>> FindAllActiveByUserIdAsync(Guid userId)
        {
            using (var conn = OpenConnectionAsync)
            {
                return (await SqlMapper.QueryAsync<T>(
                    conn,
                    "SELECT * FROM " + this.tableName + " WHERE UserId = @UserId AND IsActive = @IsActive AND IsDeleted = @IsDeleted",
                    new { UserId = userId, IsActive = 1, IsDeleted = 0 },
                    commandType: CommandType.Text));
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(Guid id)
        {
            using (var conn = OpenConnection)
            {
                conn.Execute("DELETE FROM " + this.tableName + " WHERE ID = @ID", new { ID = id });
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual async Task<bool> SoftDelete(Guid id)
        {
            using (var conn = OpenConnectionAsync)
            {
                await conn.ExecuteAsync("UPDATE " + this.tableName + " SET IsDeleted = 1, IsActive = 0, @DttmModified= DttmModified WHERE ID = @ID", new { DttmModified = DateTime.UtcNow, ID = id }, commandType: CommandType.Text);
            }

            return true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
