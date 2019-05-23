namespace CRM.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notes
    {
        [Key]
        public int NoteID { get; set; }

        public int? CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string NoteDetail { get; set; }

        public DateTime? Date { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
