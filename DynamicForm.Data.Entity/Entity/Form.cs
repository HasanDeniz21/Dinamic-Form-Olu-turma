namespace DynamicForm.Data.Entity.Entity
{
    using DynamicForm.Framework.Data.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Form")]
    public partial class Form: IEntity
    {
        public int FormId { get; set; }

        [Required]
        [StringLength(250)]
        public string FormName { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AccountId { get; set; }

        public string Field { get; set; }

        public virtual Account Account { get; set; }
    }
}
