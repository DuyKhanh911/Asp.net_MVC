namespace DataProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Login")]
    public partial class Login
    {
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(10)]
        public string pass { get; set; }

        [StringLength(30)]
        public string fullname { get; set; }
    }
}
