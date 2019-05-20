namespace Fast_food1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blog")]
    public partial class blog
    {
        [Key]
        public long MaBlog { get; set; }

        [StringLength(100)]
        public string TenBlog { get; set; }

        public string NoiDung { get; set; }

        public long? MaND { get; set; }

        [StringLength(50)]
        public string urlImg { get; set; }

        public DateTime? ThoiGian { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
