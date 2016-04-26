using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using Dugun.Common;
using Dugun.Models.DataTransferObjects;

namespace Dugun
{
    [ServiceContract]
    public interface IWinService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetCategory")]
        CategoryDto SetCategory(CategoryDto dto);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetGuest")]
        GuestDto SetGuest(GuestDto dto);

    }
}