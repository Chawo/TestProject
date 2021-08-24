using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTO
{
    public class FileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }

    }
}
