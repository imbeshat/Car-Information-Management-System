//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CIMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAR
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string Engine { get; set; }
        public Nullable<int> BHP { get; set; }
        public Nullable<int> TransmissionId { get; set; }
        public int Mileage { get; set; }
        public int Seat { get; set; }
        public string AirBagDetails { get; set; }
        public string BootSpace { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual CarTransmissionType CarTransmissionType { get; set; }
        public virtual CarType CarType { get; set; }
    }
}
