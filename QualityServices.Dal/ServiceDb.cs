using System;
using System.Data;
using System.Data.SqlClient;

namespace QualityServices.Dal
{
    ///<summary>
    ///A generated Data Access Layer class containing all stored procedures matching the pattern sp_Service_*.
    ///</summary>
    public static class ServiceDb
    {
        #region Public Members

        

        ///<summary>Deletes a [dbo].[Service] record.</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Delete.</remarks>
        ///<param name="id">The Id of Service</param>
        ///<param name="userId">The User Owner of Service</param>
        public static void Delete(Guid? id, Guid? userId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildDeleteCommand(id, userId))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }

        ///<summary>Deletes a [dbo].[Service] record.</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Delete.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of Service</param>
        ///<param name="userId">The User Owner of Service</param>
        public static void Delete(string connectionString, Guid? id, Guid? userId)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildDeleteCommand(id, userId))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }

        ///<summary>Deletes a [dbo].[Service] record.</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Delete.</remarks>
        ///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
        ///<param name="id">The Id of Service</param>
        ///<param name="userId">The User Owner of Service</param>
        public static void Delete(SqlTransaction transaction, Guid? id, Guid? userId)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");

            SqlConnection connection = transaction.Connection;
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildDeleteCommand(id, userId))
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                /*int rowsAffected = */
                cmd.ExecuteNonQuery();
            } // using SqlCommand
            connection.InfoMessage -= InfoMessageHandler;
        }

        ///<summary>Inserts a [dbo].[Service] record.</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Insert.</remarks>
        ///<param name="id">The Id of Service</param>
        ///<param name="description">The Description of Service</param>
        ///<param name="barcode">The Barcode of Service</param>
        ///<param name="ServiceNumber">The ServiceNumber of Service</param>
        ///<param name="inventoryNumber">The InventoryNumber of Service</param>
        ///<param name="vendorId">The VendorId of Service</param>
        ///<param name="roomId">The ServiceRoomId of Service</param>
        ///<param name="locationId">The LocationId of Service</param>
        ///<param name="ServiceTypeId">The ServiceTypeId of Service</param>
        ///<param name="ServiceTypeDescriptionId">The ServiceTypeDescription of Service</param>
        ///<param name="sAPDescription">The SAPDescription of Service</param>
        ///<param name="createdUserId">The CreatedUserId of Service</param>
        ///<param name="modifiedUserId">The ModifiedUserId of Service</param>
        ///<param name="utcModifiedDate">The UtcModifiedDate of Service</param>
        ///<param name="utcCreatedDate">The UtcCreatedDate of Service</param>
        ///<param name="statusId">The StatusId of Service</param>
        public static void Insert(Guid? id, Guid serviceCategory, string serviceName, Guid? createdUserId, Guid? modifiedUserId, DateTime? utcModifiedDate, DateTime? utcCreatedDate, int? statusId)
        {
            if ((serviceName != null) && (serviceName.Length > 200))
                throw new ArgumentException("Stored procedure sp_Service_Insert limits parameter @ServiceName to a maximum length of 200.", "serviceName");
            
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildInsertCommand(id, serviceCategory, serviceName, statusId, createdUserId, utcCreatedDate))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }

        ///<summary>Inserts a [dbo].[Service] record.</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Insert.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of Service</param>
        ///<param name="description">The Description of Service</param>
        ///<param name="barcode">The Barcode of Service</param>
        ///<param name="ServiceNumber">The ServiceNumber of Service</param>
        ///<param name="inventoryNumber">The InventoryNumber of Service</param>
        ///<param name="vendorId">The VendorId of Service</param>
        ///<param name="roomId">The ServiceRoomId of Service</param>
        ///<param name="locationId">The LocationId of Service</param>
        ///<param name="ServiceTypeId">The ServiceTypeId of Service</param>
        ///<param name="ServiceTypeDescriptionId">The ServiceTypeDescription of Service</param>
        ///<param name="sAPDescription">The SAPDescription of Service</param>
        ///<param name="createdUserId">The CreatedUserId of Service</param>
        ///<param name="modifiedUserId">The ModifiedUserId of Service</param>
        ///<param name="utcModifiedDate">The UtcModifiedDate of Service</param>
        ///<param name="utcCreatedDate">The UtcCreatedDate of Service</param>
        ///<param name="statusId">The StatusId of Service</param>
        public static void Insert(string connectionString, Guid? id, Guid serviceCategory, string serviceName, int? statusId, Guid? createdUserId, DateTime? utcCreatedDate)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            if ((serviceName != null) && (serviceName.Length > 255))
                throw new ArgumentException("Stored procedure sp_Service_Insert limits parameter @ServiceName to a maximum length of 200.", "serviceName");
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildInsertCommand(id, serviceCategory, serviceName, statusId, createdUserId, utcCreatedDate))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }

        ///<summary>Inserts a [dbo].[Service] record.</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Insert.</remarks>
        ///<param name="transaction">The existing SqlTransaction context to be used for the stored procedure execution.</param>
        ///<param name="id">The Id of Service</param>
        ///<param name="description">The Description of Service</param>
        ///<param name="barcode">The Barcode of Service</param>
        ///<param name="ServiceNumber">The ServiceNumber of Service</param>
        ///<param name="inventoryNumber">The InventoryNumber of Service</param>
        ///<param name="vendorId">The VendorId of Service</param>
        ///<param name="roomId">The ServiceRoomId of Service</param>
        ///<param name="locationId">The LocationId of Service</param>
        ///<param name="ServiceTypeId">The ServiceTypeId of Service</param>
        ///<param name="ServiceTypeDescriptionId">The ServiceTypeDescription of Service</param>
        ///<param name="sAPDescription">The SAPDescription of Service</param>
        ///<param name="createdUserId">The CreatedUserId of Service</param>
        ///<param name="modifiedUserId">The ModifiedUserId of Service</param>
        ///<param name="utcModifiedDate">The UtcModifiedDate of Service</param>
        ///<param name="utcCreatedDate">The UtcCreatedDate of Service</param>
        ///<param name="statusId">The StatusId of Service</param>
        public static void Insert(SqlTransaction transaction, Guid? id, Guid serviceCategory, string serviceName, int? statusId, Guid? createdUserId, DateTime? utcCreatedDate)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");

            if ((serviceName != null) && (serviceName.Length > 255))
                throw new ArgumentException("Stored procedure sp_Service_Insert limits parameter @ServiceName to a maximum length of 200.", "serviceName");

            SqlConnection connection = transaction.Connection;
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildInsertCommand(id, serviceCategory, serviceName, statusId, createdUserId, utcCreatedDate))
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                /*int rowsAffected = */
                cmd.ExecuteNonQuery();
            } // using SqlCommand
            connection.InfoMessage -= InfoMessageHandler;
        }

        

        ///<summary>Retrieves all the records from [dbo].[Service].</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectAll.</remarks>
        ///<param name="barcode">The Barcode of ServiceGroup</param>
        ///<param name="ServiceNumber">The ServiceNumber of ServiceGroup</param>
        ///<param name="inventoryNumber">The InventoryNumber of ServiceGroup</param>
        ///<param name="ServiceTypeId">The ServiceTypeId of ServiceGroup</param>
        ///<param name="locationId">The LocationId of ServiceGroup</param>
        ///<param name="roomId">The RoomId of ServiceGroup</param>
        ///<param name="statusId">The StatusId of Service</param>
        ///<param name="description">The Description of Service</param>
        ///<param name="ServiceGroupId"></param>
        public static SqlDataReader SelectAll(Guid? serviceCategory, string serviceName, int? statusId)
        {
            if ((serviceName != null) && serviceName.Length > 200)
                throw new ArgumentException("Stored procedure sp_Service_SelectAll limits parameter @ServiceName to a maximum length of 200.", "serviceName");
            
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectAllCommand(serviceCategory, serviceName, statusId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves all the records from [dbo].[Service].</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectAll.</remarks>
        ///<param name="barcode">The Barcode of ServiceGroup</param>
        ///<param name="ServiceNumber">The ServiceNumber of ServiceGroup</param>
        ///<param name="inventoryNumber">The InventoryNumber of ServiceGroup</param>
        ///<param name="ServiceTypeId">The ServiceTypeId of ServiceGroup</param>
        ///<param name="locationId">The LocationId of ServiceGroup</param>
        ///<param name="roomId">The RoomId of ServiceGroup</param>
        ///<param name="statusId">The StatusId of Service</param>
        ///<param name="description">The Description of Service</param>
        ///<param name="ServiceGroupId"></param>
        public static SqlDataReader SelectAllPaged(Guid serviceCategory, string serviceName, int? statusId, int? pageNo, int? pageSize)
        {
            if ((serviceName != null) && (serviceName.Length > 200))
                throw new ArgumentException("Stored procedure sp_Service_SelectUnprocessed parameter @serviceName to a maximum length of 200.", "serviceName");
            
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectAllPagedCommand(serviceCategory, serviceName, statusId, pageNo, pageSize))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }



        ///<summary>Retrieves all the records from [dbo].[Service].</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectAll.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="barcode">The Barcode of ServiceGroup</param>
        ///<param name="ServiceNumber">The ServiceNumber of ServiceGroup</param>
        ///<param name="inventoryNumber">The InventoryNumber of ServiceGroup</param>
        ///<param name="ServiceTypeId">The ServiceTypeId of ServiceGroup</param>
        ///<param name="locationId">The LocationId of ServiceGroup</param>
        ///<param name="roomId">The RoomId of ServiceGroup</param>
        ///<param name="statusId">The StatusId of Service</param>
        ///<param name="description">The Description of Service</param>
        ///<param name="ServiceGroupId"></param>
        public static SqlDataReader SelectAll(string connectionString, Guid? serviceCategory, string serviceName, string inventoryNumber, int? ServiceTypeId, int? locationId, Guid? roomId, int? statusId, string description, int? ServiceGroupId)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            if ((serviceName != null) && serviceName.Length > 200)
                throw new ArgumentException("Stored procedure sp_Service_SelectAll limits parameter @ServiceName to a maximum length of 200.", "serviceName");


            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectAllCommand(serviceCategory, serviceName, statusId))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        

        ///<summary>Retrieves a record from [dbo].[Service].</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectById.</remarks>
        ///<param name="id">The Id of Service</param>
        public static SqlDataReader SelectById(Guid? id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByIdCommand(id))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        ///<summary>Retrieves a record from [dbo].[Service].</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectById.</remarks>
        ///<param name="connectionString">The connection string to be used to execute the stored procedure.</param>
        ///<param name="id">The Id of Service</param>
        public static SqlDataReader SelectById(string connectionString, Guid? id)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildSelectByIdCommand(id))
            {
                cmd.Connection = connection;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } // using SqlCommand
        }

        public static void Update(Guid? id, Guid serviceCategory, string serviceName, int? statusId, Guid? modifiedUserId, DateTime? utcModifiedDate)
        {
            if ((serviceName != null) && (serviceName.Length > 200))
                throw new ArgumentException("Stored procedure sp_Service_Update limits parameter @ServiceName to a maximum length of 200.", "serviceName");
            
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildUpdateCommand(id, serviceCategory, serviceName, statusId, modifiedUserId, utcModifiedDate))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }


        public static void Update(string connectionString, Guid? id, Guid serviceCategory, string serviceName, int? statusId, Guid? modifiedUserId, DateTime? utcModifiedDate)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            if ((serviceName != null) && (serviceName.Length > 200))
                throw new ArgumentException("Stored procedure sp_Service_Update limits parameter @ServiceName to a maximum length of 200.", "serviceName");
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.InfoMessage += InfoMessageHandler;
                using (SqlCommand cmd = BuildUpdateCommand(id, serviceCategory, serviceName, statusId, modifiedUserId, utcModifiedDate))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    /*int rowsAffected = */
                    cmd.ExecuteNonQuery();
                } // using SqlCommand
                connection.InfoMessage -= InfoMessageHandler;
            } // using SqlConnection
        }


        public static void Update(SqlTransaction transaction, Guid? id, Guid serviceCategory, string serviceName, int? statusId, Guid? modifiedUserId, DateTime? utcModifiedDate)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");

            if ((serviceName != null) && (serviceName.Length > 200))
                throw new ArgumentException("Stored procedure sp_Service_Update limits parameter @ServiceName to a maximum length of 200.", "serviceName");
            
            SqlConnection connection = transaction.Connection;
            connection.InfoMessage += InfoMessageHandler;
            using (SqlCommand cmd = BuildUpdateCommand(id, serviceCategory, serviceName, statusId, modifiedUserId, utcModifiedDate))
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                /*int rowsAffected = */
                cmd.ExecuteNonQuery();
            } // using SqlCommand
            connection.InfoMessage -= InfoMessageHandler;
        }

        #endregion

        #region Private Members

        

        ///<summary>Deletes a [dbo].[Service] record.</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_Delete.</remarks>
        ///<param name="id">The Id of Service</param>
        ///<param name="userId">The User Owner of Service</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildDeleteCommand(Guid? id, Guid? userId)
        {
            SqlCommand cmd = new SqlCommand("sp_Service_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
            param = cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
            param.Value = (userId.HasValue) ? (object)userId.Value : DBNull.Value;
            return cmd;
        }

        private static SqlCommand BuildInsertCommand(Guid? id, Guid serviceCategory, string serviceName, int? statusId, Guid? createdUserId, DateTime? utcCreatedDate)
        {
            SqlCommand cmd = new SqlCommand("sp_Service_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
            param = cmd.Parameters.Add("@ServiceCategory", SqlDbType.UniqueIdentifier);
            param.Value = serviceCategory;
            param = cmd.Parameters.Add("@ServiceName", SqlDbType.VarChar, 200);
            param.Value = serviceName;
            param = cmd.Parameters.Add("@CreatedUserId", SqlDbType.UniqueIdentifier);
            param.Value = (createdUserId.HasValue) ? (object)createdUserId.Value : DBNull.Value;
            param = cmd.Parameters.Add("@UtcCreatedDate", SqlDbType.DateTime);
            param.Value = (utcCreatedDate.HasValue) ? (object)utcCreatedDate.Value : DBNull.Value;
            param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
            param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
            return cmd;
        }

       
        private static SqlCommand BuildSelectAllCommand(Guid? serviceCategory, string serviceName, int? statusId)
        {
            SqlCommand cmd = new SqlCommand("sp_Service_SelectAll");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@ServiceCategory", SqlDbType.UniqueIdentifier);
            param.Value = (serviceCategory.HasValue) ? (object)serviceCategory.Value : DBNull.Value;
            param = cmd.Parameters.Add("@ServiceName", SqlDbType.VarChar, 200);
            param.Value = serviceName;
            param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
            param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
            return cmd;
        }

        
        private static SqlCommand BuildSelectAllPagedCommand(Guid serviceCategory, string serviceName, int? statusId, int? pageNo, int? pageSize)
        {
            SqlCommand cmd = new SqlCommand("sp_Service_SelectPaged");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@ServiceCategory", SqlDbType.UniqueIdentifier);
            param.Value = serviceCategory;
            param = cmd.Parameters.Add("@ServiceName", SqlDbType.VarChar, 200);
            param.Value = serviceName;
            param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
            param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
            param = cmd.Parameters.Add("@PageNo", SqlDbType.Int);
            param.Value = (pageNo.HasValue) ? (object)pageNo.Value : DBNull.Value;
            param = cmd.Parameters.Add("@PageSize", SqlDbType.Int);
            param.Value = (pageSize.HasValue) ? (object)pageSize.Value : DBNull.Value;
            return cmd;
        }


        ///<summary>Retrieves a record from [dbo].[Service].</summary>
        ///<remarks>This method maps directly onto the stored procedure sp_Service_SelectById.</remarks>
        ///<param name="id">The Id of Service</param>
        ///<returns>A SqlCommand object with the parameters already bound.</returns>
        private static SqlCommand BuildSelectByIdCommand(Guid? id)
        {
            SqlCommand cmd = new SqlCommand("sp_Service_SelectById");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
            return cmd;
        }

        private static SqlCommand BuildUpdateCommand(Guid? id, Guid serviceCategory, string serviceName, int? statusId, Guid? modifiedUserId, DateTime? utcModifiedDate)
        {
            SqlCommand cmd = new SqlCommand("sp_Service_Update");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            param.Value = (id.HasValue) ? (object)id.Value : DBNull.Value;
            param = cmd.Parameters.Add("@ServiceCategory", SqlDbType.UniqueIdentifier);
            param.Value = serviceCategory;
            param = cmd.Parameters.Add("@ServiceName", SqlDbType.VarChar, 200);
            param.Value = serviceName;
            param = cmd.Parameters.Add("@StatusId", SqlDbType.Int);
            param.Value = (statusId.HasValue) ? (object)statusId.Value : DBNull.Value;
            param = cmd.Parameters.Add("@ModifiedUserId", SqlDbType.UniqueIdentifier);
            param.Value = (modifiedUserId.HasValue) ? (object)modifiedUserId.Value : DBNull.Value;
            param = cmd.Parameters.Add("@UtcModifiedDate", SqlDbType.DateTime);
            param.Value = (utcModifiedDate.HasValue) ? (object)utcModifiedDate.Value : DBNull.Value;
            return cmd;
        }

        #endregion

        #region Internal Members

        internal static void InfoMessageHandler(object sender, SqlInfoMessageEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(e.ToString(), string.Format("{0}[{1}]", typeof(ServiceDb).FullName, e.Errors[0].Procedure));
        }

        #endregion
    }
}
