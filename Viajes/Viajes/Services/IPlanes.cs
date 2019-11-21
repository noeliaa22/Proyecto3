﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Models;

namespace Viajes.Services
{
    public interface IPlanes
    {
        public Task<List<Plan>> GetPlanesAsync();
        public Task<Plan> GetPlanByIdAsync(int? id);
        public Task CreatePlanAsync(Plan plan);
        public Task UpdatePlanAsync(Plan plan);
        public Task DeletePlanAsync(Plan plan);
        public bool PlanExists(int? id);
    }
}