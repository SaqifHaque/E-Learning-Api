using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    public class StatusRepository:Repository<Status>
    {
        public List<Status> GetByUserID(int id)
        {
            return this.context.Statuses.Where(x => x.User_Id == id).ToList();
        }
    }
}