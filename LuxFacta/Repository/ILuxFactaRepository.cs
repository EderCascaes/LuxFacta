using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuxFacta.Entities;

namespace LuxFacta.Repository
{
    public interface ILuxFactaRepository
    {
        Task<int> GetIdSurvey();
        Task PostSurvey(SurveyResponse survey);
        Task PostOptions(int poll_Id, string option, int position);
        Task<string> GetSurvey(int id);
        Task<IEnumerable<Options>> GetListOptions(int id);
        Task UpdateVote(int id, int option_id);
        Task<int> CheckOption_Id(int id);
        Task IncludesView(int poll_id);
        Task<int> GetViewSurvey(int id);
        Task<IEnumerable<Vote>> GetVotesView(int id);
    }
}
