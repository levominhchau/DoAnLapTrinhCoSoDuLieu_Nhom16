//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBH_ltcsdl_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaHoa { get; set; }
        public Nullable<short> SoLuong { get; set; }
        public Nullable<float> DonGia { get; set; }
        public Nullable<float> GiamGia { get; set; }
    
        public virtual Hoa Hoa { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}
