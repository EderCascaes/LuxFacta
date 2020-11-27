using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using LuxFacta.Entities;
using LuxFacta.Repositorys;

namespace LuxFacta.Services
{
    public class PollService : IPollService
    {
        private readonly ILuxFactaRepository _repository;

        public PollService(ILuxFactaRepository repository)
        {
            _repository = repository;
        }

        public async  Task<View_Survey> GetStatsAsync(int id)
        {
            var view_Survey = new View_Survey();
            try
            {
                view_Survey.views = await _repository.GetViewSurvey(id);
                view_Survey.votes = await _repository.GetVotesView(id);

                return view_Survey;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar View :" + ex.Message);
            }
            
        }

        public async Task<Survey> GetSurveyAsync(int id)
        {
            var survey = new Survey();
            var list = new List<Options>();

            try
            {
                survey.poll_Id = id;
                survey.poll_description = await _repository.GetSurvey(id);
                survey.options = await _repository.GetListOptions(id);

                await IncludesView(id);

                return survey;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter Enquete com {id}: " + ex.Message);
            }


        }

        public async Task<dynamic> PostSurveyAsync(SurveyResponse survey)
        {
            var position = 1;
            try
            {
                survey.poll_Id = await _repository.GetIdSurvey() + 1;

                await _repository.PostSurvey(survey);

                foreach (var option in survey.options)
                {
                    await _repository.PostOptions(survey.poll_Id, option, position);
                    position++;
                }

                dynamic result = new ExpandoObject();
                result.poll_Id = survey.poll_Id;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Cadastrar Enquete: " + ex.Message);
            }
        }

        public async Task<int> PostVoteAsync(int option_id, int id)
        {
            try
            {
                if (await _repository.CheckOption_Id(id) > 0)
                {
                    await _repository.UpdateVote(id, option_id);

                    return id;
                }
                else
                    return  0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar Voto Enquete {id} e opção {option_id}:" + ex.Message);
            }
        }

      
        private async Task IncludesView(int poll_id) =>     
            await _repository.IncludesView(poll_id);

        
    }
}
