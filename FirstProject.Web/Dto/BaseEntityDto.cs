using System;

namespace FirstProject.Web.Dto
{
    public class BaseEntityDto
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Archived { get; set; }
    }
}
