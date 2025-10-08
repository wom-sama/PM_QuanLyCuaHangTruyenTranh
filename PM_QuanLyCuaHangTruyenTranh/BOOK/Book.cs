namespace PM_QuanLyCuaHangTruyenTranh.BOOK
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int BookId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public int? Quantity { get; set; }

        public decimal? RentPrice { get; set; }
    }
}
