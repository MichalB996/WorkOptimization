namespace WorkOptimization.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Machines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MachineID { get; set; }

        public int Special { get; set; }

        public int Efficiency_1 { get; set; }

        public int Profit_1 { get; set; }

        public int? Efficiency_2 { get; set; }

        public int? Profit_2 { get; set; }

        public int FactoryID { get; set; }

        public virtual Factories Factories { get; set; }
    }
}
