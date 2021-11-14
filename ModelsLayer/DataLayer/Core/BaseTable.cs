using System;


namespace ModelsLayer.DataLayer.Core
{
    public class BaseTable
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
    }
}
