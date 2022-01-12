using ModelsLayer.DataLayer.Tables;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Params.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Params
{
    public class StudentBusParams : PaginationParams
    {
        public int Id { get; set; } = 0;
        public int Student_Id { get; set; } = 0;
        public int Bus_Id { get; set; } = 0;
        public string Student_Name { get; set; } = "0";
        public string Bus_Name { get; set; } = "0";
        public int School_Id { get; set; } = 0;
        public int BusCompany_Id { get; set; } = 0;
        public bool? IsActive { get; set; } = null;



        public IQueryable<Student_Bus> AddFilter(IQueryable<Student_Bus> query)
        {
            query = query.Where(r =>
                (r.Id == this.Id || this.Id == 0)
             && (r.Student_Id == this.Student_Id || this.Student_Id == 0)
             && (r.Bus_Id == this.Bus_Id || this.Bus_Id == 0)
             && (r.Student.Full_Name.Contains(this.Student_Name) || this.Student_Name == "0")
             && ((r.Bus.Marka.Contains(this.Bus_Name) || this.Bus_Name == "0")
             || (r.Bus.Number.Contains(this.Bus_Name) || this.Bus_Name == "0"))
             && (r.IsActive == this.IsActive || this.IsActive ==null)
            );
            return query;
        }

       
    }
}
