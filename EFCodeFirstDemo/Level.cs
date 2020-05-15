namespace EFCodeFirstDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Level
    {
        public int LevelId { get; set; }

        public string LevelName { get; set; }
    }
}
