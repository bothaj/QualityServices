using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using JBSoft.Models;

namespace QualityServices.Models
{
    [Serializable]
    public class Service : AuditModelBase
    {
        public Guid Id { get; set; }

        public Guid ServiceCategory { get; set; }

        public string CategoryName { get; set; }

        public string ServiceName { get; set; }

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Service()
        {
            //this.AssetColumnValues = new List<AssetColumnValue>();
            //this.AssetType = new AssetType();
            //this.AssetTypeDescription = new AssetTypeDescription();
        }

        #endregion

    }
}
