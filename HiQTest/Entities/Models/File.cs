using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("file")]
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }

    }
}
