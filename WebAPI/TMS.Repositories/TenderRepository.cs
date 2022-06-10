using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.DTO;
using TMS.Repositories.Data;
using TMS.Repositories.Interfaces;

namespace TMS.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly AppDbContext appDbContext;

        public TenderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Tender> CreateTenderAsync(Tender tender)
        {
            await appDbContext.Tenders.AddAsync(tender);
            await appDbContext.SaveChangesAsync();
            return tender;
        }

        public async Task DeleteTenderAsync(Tender tender)
        {
            appDbContext.Remove(await appDbContext.Tenders.FirstOrDefaultAsync(x => x.Id == tender.Id));
            await appDbContext.SaveChangesAsync();
        }

        public async Task<IList<Tender>> GetAllTenderListAsync()
        {
            return await appDbContext.Tenders.ToListAsync();
        }

        public async Task<Tender> GetTenderByIdAsync(int id)
        {
            return await appDbContext.Tenders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Tender>> GetListByCriterisAsync()
        {
            return await appDbContext.Tenders.ToListAsync();
        }

        public async Task<Tender> UpdateTenderAsync(Tender tender)
        {
            var existingTender = appDbContext.Tenders.Attach(tender);
            existingTender.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return tender;
        }
    }
}
