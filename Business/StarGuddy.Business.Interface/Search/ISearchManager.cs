using StarGuddy.Api.Models.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Search
{
    public interface ISearchManager
    {
        Task<IEnumerable<TalentGroup>> GetUserGobGroup();
        Task<string> GetName();
    }
}
