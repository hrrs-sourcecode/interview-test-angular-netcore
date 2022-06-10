using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.DTO;
using TMS.DTO.Shared;

namespace TMS.Repositories.Interfaces
{
    public interface ITenderRepository
    {
        Task<IList<Tender>> GetAllTenderListAsync();

        Task<IList<Tender>> GetListByCriterisAsync();

        Task<Tender> GetTenderByIdAsync(int id);

        Task<Tender> CreateTenderAsync(Tender tender);

        Task<Tender> UpdateTenderAsync(Tender tender);

        Task DeleteTenderAsync(Tender tender);
    }

}
