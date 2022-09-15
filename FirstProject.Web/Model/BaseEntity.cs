using System;

namespace FirstProject.Web.Model
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool  Archived { get; set; }
    }
}
