using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.DTO;
using TMS.Repositories.Interfaces;

namespace TMS.Services.Test.MockRepository
{
    public class MockTenderRepository : ITenderRepository
    {
        public async Task<Tender> CreateTenderAsync(Tender tender)
        {
            Tender validResult = new Tender
            {
                Id = 1,
                IsActive = true,
                ClosingDate = DateTime.Now,
                ContractNo = "",
                TenderValue = 50_000_000,
                TenderName = "Test",
                TenderID = "0000001",
                Description = "Test Descript",
                ReleaseDate = DateTime.Now.AddDays(1),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            };

            if (tender.TenderName == "Error")
            {
                throw new Exception();
            }

            return await Task.FromResult(validResult);
        }

        public async Task DeleteTenderAsync(Tender tender)
        {
            await Task.FromResult(new Tender
            {
                Id = 1,
                IsActive = true,
                ClosingDate = DateTime.Now,
                ContractNo = "",
                TenderValue = 50_000_000,
                TenderName = "Test",
                TenderID = "0000001",
                Description = "Test Descript",
                ReleaseDate = DateTime.Now.AddDays(1),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            });

            if (tender.TenderName == "Error")
            {
                throw new Exception();
            }

            return;
        }

        public async Task<IList<Tender>> GetAllTenderListAsync()
        {
            IList<Tender> tenderList = new List<Tender>
            {
                new Tender
                {
                    Id = 1,
                    IsActive = true,
                    ClosingDate = DateTime.Now,
                    ContractNo = "Ctr 1",
                    TenderValue = 50_000_000,
                    TenderName = "Test",
                    TenderID = "0000001",
                    Description = "Test Descript",
                    ReleaseDate = DateTime.Now.AddDays(1),
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },

                new Tender
                {
                    Id = 2,
                    IsActive = true,
                    ClosingDate = DateTime.Now,
                    ContractNo = "Ctr 2",
                    TenderValue = 150_000_000,
                    TenderName = "Test",
                    TenderID = "0000001",
                    Description = "Test Descript",
                    ReleaseDate = DateTime.Now.AddDays(1),
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
            };

            return await Task.FromResult(tenderList);
        }

        public async Task<IList<Tender>> GetListByCriterisAsync()
        {
            IList<Tender> tenderList = new List<Tender>
            {
                new Tender
                {
                    Id = 1,
                    IsActive = true,
                    ClosingDate = DateTime.Now,
                    ContractNo = "",
                    TenderValue = 50_000_000,
                    TenderName = "Test",
                    TenderID = "0000001",
                    Description = "Test Descript",
                    ReleaseDate = DateTime.Now.AddDays(1),
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },

                new Tender
                {
                    Id = 2,
                    IsActive = true,
                    ClosingDate = DateTime.Now,
                    ContractNo = "",
                    TenderValue = 150_000_000,
                    TenderName = "Test",
                    TenderID = "0000002",
                    Description = "Test Descript",
                    ReleaseDate = DateTime.Now.AddDays(1),
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
            };
            return await Task.FromResult(tenderList);
        }

        public async Task<Tender> GetTenderByIdAsync(int id)
        {
            Tender validResult = new Tender
            {
                Id = 1,
                IsActive = true,
                ClosingDate = DateTime.Now,
                ContractNo = "",
                TenderValue = 50_000_000,
                TenderName = "Test",
                TenderID = "0000001",
                Description = "Test Descript",
                ReleaseDate = DateTime.Now.AddDays(1),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            };

            if (id == 2)
            {
                throw new Exception();
            }

            return await Task.FromResult(validResult);
        }

        public async Task<Tender> UpdateTenderAsync(Tender tender)
        {
            Tender validResult = new Tender
            {
                Id = 1,
                IsActive = true,
                ClosingDate = DateTime.Now,
                ContractNo = "",
                TenderValue = 50_000_000,
                TenderName = "Test",
                TenderID = "0000001",
                Description = "Test Descript",
                ReleaseDate = DateTime.Now.AddDays(1),
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now
            };

            if (tender.TenderName == "Error")
            {
                throw new Exception();
            }

            return await Task.FromResult(validResult);
        }
    }
}
