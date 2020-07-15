namespace TarkariWala.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int CommentID { get; set; }

        public int? ClientID { get; set; }

        [Column("Comment")]
        [StringLength(50)]
        public string Comment1 { get; set; }

        [StringLength(50)]
        public string Rating { get; set; }

        public virtual Client Client { get; set; }
    }
}
