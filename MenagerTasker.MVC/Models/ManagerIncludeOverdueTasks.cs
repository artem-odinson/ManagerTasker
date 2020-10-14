using System.Collections.Generic;

namespace MenagerTasker.MVC.Models
{
    public class ManagerIncludeOverdueTasks
    {
        public string ManagerFullName { get; set; }
        public IEnumerable<OverdueTask> OverdueTasks { get; set; }
    }
}
