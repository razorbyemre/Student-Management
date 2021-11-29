namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mark
    {
        public int ID { get; set; }

        public int? Result { get; set; }

        public int TypeMarkID { get; set; }

        public int DisciplineID { get; set; }

        public int StudentID { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Student Student { get; set; }

        public virtual TypeMark TypeMark { get; set; }
    }
}
