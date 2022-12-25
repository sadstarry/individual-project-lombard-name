//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace individual_project_lombard.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ClientProduct = new HashSet<ClientProduct>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> AccaountID { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<int> StatusID { get; set; }
        public byte[] Image { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<bool> IsDropToLoss { get; set; }
        public Nullable<bool> IsDropToHistory { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientProduct> ClientProduct { get; set; }
        public virtual Status Status { get; set; }
    }
}