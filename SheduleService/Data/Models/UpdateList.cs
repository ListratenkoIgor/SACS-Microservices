using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheduleService.Data.Models
{
    public class UpdateList
    {
        public List<UpdateInfo> EmployeesToUpdate = new List<UpdateInfo>();
        public List<UpdateInfo> GroupsToUpdate = new List<UpdateInfo>();
    }
}
