namespace CRM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Emails
    {
        [Key]
        public int EmailID { get; set; }

        public int? EmailTo { get; set; }

        public string Body { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
