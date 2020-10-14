using System;

namespace MenagerTasker.Core.Entities
{
    public sealed class TaskItem : EntityBase
    {
        public string Name { get; }
        public DateTime CreationDate { get; }
        public DateTime EndDate { get;}
        public TaskStatus Status { get; set; } = TaskStatus.Created;

        public int ManagerId { get; set; }

        public TaskItem(int id, string name, DateTime creationDate, DateTime endDate, int managerId) : base(id)
        {
            Name = name;
            EndDate = endDate;
            CreationDate = creationDate;

            ManagerId = managerId;
        }
    }
}
