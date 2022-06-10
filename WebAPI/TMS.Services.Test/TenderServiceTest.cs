using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TMS.DTO;
using TMS.Repositories.Interfaces;
using TMS.Services.Interfaces;
using TMS.Services.Test.MockRepository;
using Xunit;

namespace TMS.Services.Test
{
    public class TenderServiceTest
    {
        private ITenderRepository _tenderRepository;
        private ITenderService _tenderService;
        private Tender _dummyTender;

        public TenderServiceTest()
        {
            _tenderRepository = new MockTenderRepository();
            _tenderService = new TenderService(_tenderRepository);
            _dummyTender = (new Tender
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
        }

        [Fact]
        public async Task TestCreateTender_ReturnSuccess()
        {
            string actualResult = "";
            //string expectedResult = "000000" + 1.ToString();
           
            CreateTenderAsyncRequest request = (new CreateTenderAsyncRequest
            {
                Data = JsonConvert.SerializeObject(_dummyTender)
            });


            CreateTenderAsyncResponse response = await _tenderService.CreateTenderAsync(request);
            actualResult = ((Tender)response.Data).TenderID;

            Assert.True(response.IsSuccess);
            //Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task TestCreateTender_ReturnError()
        {

            CreateTenderAsyncRequest request = (new CreateTenderAsyncRequest
            {
                Data = JsonConvert.SerializeObject(new Tender { TenderName = "Error" })
            });


            CreateTenderAsyncResponse response = await _tenderService.CreateTenderAsync(request);

            Assert.True(!response.IsSuccess);
        }

        [Fact]
        public async Task TestUpdateTender_ReturnSuccess()
        {

            UpdateTenderAsyncRequest request = (new UpdateTenderAsyncRequest
            {
                Data = JsonConvert.SerializeObject(_dummyTender)
            });


            UpdateTenderAsyncResponse response = await _tenderService.UpdateTenderAsync(request);

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task TestUpdateTender_ReturnError()
        {

            UpdateTenderAsyncRequest request = (new UpdateTenderAsyncRequest
            {
                Data = JsonConvert.SerializeObject(new Tender { TenderName = "Error" })
            });


            UpdateTenderAsyncResponse response = await _tenderService.UpdateTenderAsync(request);

            Assert.True(!response.IsSuccess);
        }

        [Fact]
        public async Task TestDeleteTender_ReturnSuccess()
        {

            DeleteTenderAsyncRequest request = (new DeleteTenderAsyncRequest
            {
                Data = JsonConvert.SerializeObject(_dummyTender)
            });


            DeleteTenderAsyncResponse response = await _tenderService.DeleteTenderAsync(request);

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task TestDeleteTender_ReturnError()
        {

            DeleteTenderAsyncRequest request = (new DeleteTenderAsyncRequest
            {
                Data = JsonConvert.SerializeObject(new Tender { TenderName = "Error" })
            });


            DeleteTenderAsyncResponse response = await _tenderService.DeleteTenderAsync(request);

            Assert.True(!response.IsSuccess);
        }

        [Fact]
        public async Task TestGetTenderByID_ReturnSuccess()
        {
            GetTenderByIdAsyncResponse response = await _tenderService.GetTenderByIdAsync(1);

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task TestGetTenderByID_ReturnError()
        {
            GetTenderByIdAsyncResponse response = await _tenderService.GetTenderByIdAsync(2);

            Assert.True(!response.IsSuccess);
        }

        [Fact]
        public async Task TestGetAllTender_ReturnSuccess()
        {
            GetAllTenderListAsyncResponse response = await _tenderService.GetAllTenderListAsync();

            Assert.True(response.IsSuccess);
        }

    }
}
