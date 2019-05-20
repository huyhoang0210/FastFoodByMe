namespace Fast_food1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mon")]
    public partial class Mon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public long MaMon { get; set; }

        [StringLength(30)]
        public string TenMon { get; set; }

        [StringLength(30)]
        public string UrlImg { get; set; }

        public long? MaLM { get; set; }

        [StringLength(700)]
        public string MoTaNgan { get; set; }

        public decimal Gia { get; set; }

        [StringLength(4000)]
        public string MoTaDai { get; set; }

        [StringLength(100)]
        public string DVT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiMon LoaiMon { get; set; }
    }
}
