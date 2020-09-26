using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    public class EnrollRepository : Repository<Enroll>
    {


        public List<Enroll> GetAllEnrolledStudents(int id)
        {
            return this.context.Enrolls.Where(x => x.Course_Id == id).ToList();
        }
    }
}