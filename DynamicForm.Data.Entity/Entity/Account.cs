namespace DynamicForm.Data.Entity.Entity
{
    using DynamicForm.Framework.Data.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account: IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Form = new HashSet<Form>();
        }

        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountSurname { get; set; }

        public int AccountAge { get; set; }

        [Required]
        [StringLength(250)]
        public string AccountEmail { get; set; }

        [Required]
        [StringLength(250)]
        public string AccountPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Form> Form { get; set; }
    }
}
