//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PolitexCompany
{
    using System;
    using System.Collections.Generic;
    
    public partial class Coming
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int IdSupplier { get; set; }
        public string Status { get; set; }
        public int IdManager { get; set; }
        public int IdIncomingMaterial { get; set; }
        public string Image { get; set; }
        public string NameMaterial { get; set; }
        public string QuantityMaterial { get; set; }
        public Nullable<int> PriceAll { get; set; }
    
        public virtual IncomingMaterials IncomingMaterials { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
