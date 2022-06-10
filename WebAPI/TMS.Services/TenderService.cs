using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.DTO;
using TMS.Repositories.Interfaces;
using TMS.Services.Interfaces;

namespace TMS.Services
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            this.tenderRepository = tenderRepository;
        }

        public async Task<GetAllTenderListAsyncResponse> GetAllTenderListAsync()
        {
            GetAllTenderListAsyncResponse response = new GetAllTenderListAsyncResponse();

            try
            {
                response.Data = await tenderRepository.GetAllTenderListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<GetTenderByIdAsyncResponse> GetTenderByIdAsync(int Id)
        {
            GetTenderByIdAsyncResponse response = new GetTenderByIdAsyncResponse();

            try
            {
                response.Data = await tenderRepository.GetTenderByIdAsync(Id);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<CreateTenderAsyncResponse> CreateTenderAsync(CreateTenderAsyncRequest request)
        {
            CreateTenderAsyncResponse response = new CreateTenderAsyncResponse();

            Tender tender = JsonConvert.DeserializeObject<Tender>(request.Data.ToString());
            tender.Id = 0;
            tender.IsActive = true;

            try
            {
                response.Data = await tenderRepository.CreateTenderAsync(tender);
                response.IsSuccess = true;

                // Can be commented out, just want to make some scenarios for unit test
                // GenerateTenderID(tender);
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<UpdateTenderAsyncResponse> UpdateTenderAsync(UpdateTenderAsyncRequest request)
        {
            UpdateTenderAsyncResponse response = new UpdateTenderAsyncResponse();

            Tender tender = JsonConvert.DeserializeObject<Tender>(request.Data.ToString());

            try
            {
                response.Data = await tenderRepository.UpdateTenderAsync(tender);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<DeleteTenderAsyncResponse> DeleteTenderAsync(DeleteTenderAsyncRequest request)
        {
            DeleteTenderAsyncResponse response = new DeleteTenderAsyncResponse();

            Tender tender = JsonConvert.DeserializeObject<Tender>(request.Data.ToString());

            try
            {
                await tenderRepository.DeleteTenderAsync(tender);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
                response.IsSuccess = false;
            }

            return response;
        }

        private async void GenerateTenderID(Tender tender)
        {
            tender.TenderID = tender.Id.ToString().PadLeft(7, '0');
            await tenderRepository.UpdateTenderAsync(tender);
        }
    }
}
