using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using JBSoft.Dal;
using JBSoft.Dal.Helpers;
using JBSoft.Dal.Models;
using QualityServices.Dal;
using QualityServices.Models;
using JBSoft.Dal.ResultHelpers;
using JBSoft.Logging;
using JBSoft.Dal.Dal;
using System.Data;
using System.Configuration;

namespace QualityServices.Bll
{
    public class ServiceBll : IServiceBll
    {
        #region Private Members

        //other blls
        

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ServiceBll()
        {
            
        }

        #endregion

        public IResult Delete(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                ServiceDb.Delete(id, userId);

                return new DeleteResult();
            }
            catch (Exception ex)
            {
                //Logger.Instance.Log.ErrorException("Service.Delete", ex);
                entityError.Add(new EntityError("Service", "Delete", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }

        public IResult DeleteUpdate(Guid id, Guid userId)
        {
            var entityError = new List<EntityError>();

            try
            {
                var entityToDelete = this.SelectById(id, userId);
                entityToDelete.StatusId = (int)ActiveStatus.Deleted;

                return this.Update(entityToDelete, userId);
            }
            catch (Exception ex)
            {
                //Logger.Instance.Log.ErrorException("Service.DeleteUpdate", ex);
                entityError.Add(new EntityError("Service", "DeleteUpdateUpdate", ex.InnerException.ToString()));
                return new DeleteResult(entityError);
            }
        }

        
        public IResult Insert(Service item, Guid userId)
        {
            //Audit
            item.StatusId = ActiveStatus.Active;
            item.CreatedUserId = userId;

            var entityError = new List<EntityError>();
            try
            {
                Guid? id = Guid.NewGuid();

                ServiceDb.Insert(
                 id,
                item.ServiceCategory,
                item.ServiceName,
                userId,
                userId,
                DateTime.Now,
                DateTime.Now,
                (int?)item.StatusId);

                item.Id = id.Value;

                return new InsertResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Service", "Insert", ex.InnerException.ToString()));
                return new InsertResult(entityError);
            }
        }

        public IResult Insert(SqlTransaction transaction, Service item, Guid userId)
        {
            //Audit
            item.StatusId = ActiveStatus.Active;
            item.CreatedUserId = userId;

            var entityError = new List<EntityError>();
            try
            {
                Guid? id = item.Id;

                ServiceDb.Insert(transaction,
                 id,
                item.ServiceCategory,
                item.ServiceName,
                (int?)item.StatusId,
                userId,
                DateTime.Now);

                item.Id = id.Value;

                return new InsertResult();
            }
            catch (Exception ex)
            {
                entityError.Add(new EntityError("Service", "Insert", ex.InnerException.ToString()));
                return new InsertResult(entityError);
            }
        }

        public IResult Update(Service item, Guid userId)
        {
            try
            {
                ServiceDb.Update(
                item.Id,
                item.ServiceCategory,
                item.ServiceName,
                (int?)item.StatusId,
                userId,
                DateTime.Now);

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                //Logger.Instance.Log.ErrorException("Service.Update", ex);
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Service", "Update", ex.InnerException.ToString()));
                return new UpdateResult(entityError);
            }
        }

        public IResult Update(SqlTransaction transaction, Service item, Guid userId)
        {
            try
            {
                ServiceDb.Update(transaction,
                item.Id,
                item.ServiceCategory,
                item.ServiceName,
                (int?)item.StatusId,
                userId,
                DateTime.Now);

                return new UpdateResult();
            }
            catch (SqlException ex)
            {
                //Logger.Instance.Log.ErrorException("Service.Update", ex);
                var entityError = new List<EntityError>();
                entityError.Add(new EntityError("Service", "Update", ex.InnerException.ToString()));
                return new UpdateResult(entityError);
            }
        }

        public List<Service> SelectAll(Guid? serviceCategory, string serviceName, int? statusId)
        {
            using (var dr = ServiceDb.SelectAll(serviceCategory, serviceName, statusId))
                return dr.TranslateMany<Service>().ToList();
        }

        public List<Service> SelectAllPaged(Guid serviceCategory, string serviceName, int? statusId, int? pageNo, int? pageSize)
        {
            using (var dr = ServiceDb.SelectAllPaged(serviceCategory, serviceName, statusId, pageNo, pageSize))
                //(barcode, ServiceNumber, inventoryNumber, ServiceTypeId, locationId, roomId, statusId, description, ServiceGroupId,pageNo,pageSize))
                return dr.TranslateMany<Service>().ToList();
        }

        public Service SelectById(Guid id, Guid userId)
        {
            using (var dr = ServiceDb.SelectById(id))
                return dr.TranslateSingle<Service>();
        }

        /// <summary>
        /// Updates an existing Service with the user selected data.
        /// Following that will update/insert all the Servicedetails and Servicenonlistitems associated,
        /// </summary>
        
    }
}
