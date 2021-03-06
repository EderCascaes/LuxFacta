﻿using LuxFacta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxFacta.Services
{
    public interface IPollService
    {
        Task<Survey> GetSurveyAsync(int id);
        Task<dynamic> PostSurveyAsync(SurveyResponse survey);
        Task<int> PostVoteAsync(int option_id, int id);
        Task<View_Survey> GetStatsAsync(int id);
    }
}
