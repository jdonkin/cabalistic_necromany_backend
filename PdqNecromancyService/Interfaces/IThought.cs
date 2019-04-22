using PdqNecromancyService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PdqNecromancyService.Interfaces
{
    public interface IThought
    {
        Task<ServiceThoughtsModel> GetThoughts();
    }
}
