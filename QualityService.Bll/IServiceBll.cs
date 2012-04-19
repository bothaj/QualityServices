using System;
using System.Data;
using QualityServices.Models;
using System.Collections.Generic;
using JBSoft.Dal.ResultHelpers;
using System.Data.SqlClient;

namespace QualityServices.Bll
{
    public interface IServiceBll
    {
        IResult Delete(Guid id, Guid userId);

        ///<summary></summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Insert.</remarks>
        IResult Insert(Service newService, Guid CurrentUserId);

        ///<summary></summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectAll.</remarks>
        List<Service> SelectAll(Guid? serviceCategory, string serviceName, int? statusId);
        ///<summary></summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectAll.</remarks>
        List<Service> SelectAllPaged(Guid serviceCategory, string serviceName, int? statusId, int? pageNo, int? pageSize);

        ///<summary></summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectById.</remarks>
        ///<param name="id"></param>
        Service SelectById(Guid id, Guid userId);

        ///<summary></summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectByBarcode.</remarks>
        ///<param name="id"></param>


        ///<summary></summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Update.</remarks>
        IResult Update(Service Service, Guid CurrentUserId);

        /// <summary>
        /// Updates an existing Service with the user selected data.
        /// Following that will update/insert all the Servicedetails and Servicenonlistitems associated,
        /// </summary>
        

        IResult Insert(SqlTransaction transaction, Service item, Guid userId);

        IResult Update(SqlTransaction transaction, Service item, Guid userId);
    }
}
