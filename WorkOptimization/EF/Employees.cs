namespace WorkOptimization.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        public int Abilities { get; set; }

        public int FactoryID { get; set; }

        public string VectorOfAbilities { get; set; }

        public virtual Factories Factories { get; set; }
    }
}
