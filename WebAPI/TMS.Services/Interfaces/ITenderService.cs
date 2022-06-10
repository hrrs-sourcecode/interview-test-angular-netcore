using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMS.DTO.Shared;

namespace TMS.Services.Interfaces
{
    public interface ITenderService
    {
        Task<GetAllTenderListAsyncResponse> GetAllTenderListAsync();

        Task<GetTenderByIdAsyncResponse> GetTenderByIdAsync(int Id);

        Task<CreateTenderAsyncResponse> CreateTenderAsync(CreateTenderAsyncRequest request);

        Task<UpdateTenderAsyncResponse> UpdateTenderAsync(UpdateTenderAsyncRequest request);

        Task<DeleteTenderAsyncResponse> DeleteTenderAsync(DeleteTenderAsyncRequest request);
    }

    public class GetAllTenderListAsyncResponse : ResponseBase
    {
    }

    public class GetTenderByIdAsyncResponse : ResponseBase
    {
    }
    public class CreateTenderAsyncResponse : ResponseBase
    {
    }

    public class UpdateTenderAsyncResponse : ResponseBase
    {
    }

    public class DeleteTenderAsyncResponse : ResponseBase
    {
    }

    public class CreateTenderAsyncRequest : RequestBase
    {
    }

    public class UpdateTenderAsyncRequest : RequestBase
    {
    }

    public class DeleteTenderAsyncRequest : RequestBase
    {
    }
}
