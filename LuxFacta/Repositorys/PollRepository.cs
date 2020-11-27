using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LuxFacta.Entities;

namespace LuxFacta.Repositorys
{
    public class PollRepository : ILuxFactaRepository
    {  

        private readonly string  _connString;

        public PollRepository(IConfiguration config)
        {
            _connString = config["ConnString"];
         
        }

        public async Task<int> GetIdSurvey()
        {
            using (var db =  new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@" SELECT COALESCE(MAX(POLL_ID), 0) FROM SURVEY";

                return await db.QueryFirstOrDefaultAsync<int>(sSql);
            }             
        }

       
        public async Task PostSurvey(SurveyResponse survey)
        {

            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@"INSERT INTO SURVEY( 
                                POLL_ID,
                                POLL_DESCRIPTION)
                                VALUES (
                                        {survey.poll_Id},
                                        '{survey.poll_description}'
                                )";

                await db.ExecuteAsync(sSql);
            }   
        }

        public async Task PostOptions(int poll_Id, string option, int position)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@"INSERT INTO OPTION_SURVEY(                             
                                OPTION_DESCRIPTION,
                                POLL_ID,
                                POSITION)
                                VALUES (
                                        '{option}',
                                        {poll_Id},
                                        {position}
                                )";

                await db.ExecuteAsync(sSql);               
            }
        }

        public async Task<string> GetSurvey(int id)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@" SELECT  POLL_DESCRIPTION  FROM SURVEY WHERE POLL_ID = {id}";

                return await db.QueryFirstOrDefaultAsync<string>(sSql);
            }
        }

        public async Task<IEnumerable<Options>> GetListOptions(int id)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@" SELECT  POSITION AS OPTION_ID, OPTION_DESCRIPTION  
                                    FROM OPTION_SURVEY 
                                    WHERE POLL_ID = {id}";

                return await db.QueryAsync<Options>(sSql);
            }
        }

        public async  Task UpdateVote(int id, int option_id)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@" SELECT  QTD_VOTOS  
                                    FROM OPTION_SURVEY 
                                    WHERE POLL_ID = {id} 
                                    AND POSITION = {option_id}
                               ";

                var qtd_db = await db.QueryFirstOrDefaultAsync<int>(sSql);

                sSql = $@" UPDATE  OPTION_SURVEY SET QTD_VOTOS = {qtd_db} + 1                                
                                WHERE POLL_ID = {id} 
                                AND POSITION = {option_id}
                           ";

                await db.ExecuteAsync(sSql);
            }
        }

        public async  Task<int> CheckOption_Id(int id)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@" SELECT  COUNT(POLL_ID) FROM SURVEY WHERE POLL_ID = {id}";

                return await db.QueryFirstOrDefaultAsync<int>(sSql);
            }
        }

        public async Task IncludesView(int poll_id)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();             

                var sSql = $@" UPDATE SURVEY 
                                SET COUNTER = ((SELECT COUNTER FROM SURVEY WHERE POLL_ID = {poll_id}) +1)                                
                                WHERE POLL_ID = {poll_id}
                           ";

                await db.ExecuteAsync(sSql);
            }
        }

        public async Task<int> GetViewSurvey(int id)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@" SELECT
	                                COUNTER 	                                  
                                    FROM SURVEY 
                                    WHERE POLL_ID = {id}";

                return await db.QueryFirstOrDefaultAsync<int>(sSql);
            }
        }

        public async  Task<IEnumerable<Vote>> GetVotesView(int id)
        {
            using (var db = new SqlConnection(_connString))
            {
                await db.OpenAsync();

                var sSql = $@" SELECT
                                    POSITION AS OPTION_ID,
                                    QTD_VOTOS AS QTY                                       
                                FROM OPTION_SURVEY
                                    WHERE POLL_ID = {id}";

                return await db.QueryAsync<Vote>(sSql);
            }
        }
    }
}
