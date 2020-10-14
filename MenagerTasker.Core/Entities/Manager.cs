using System.Collections.Generic;

namespace MenagerTasker.Core.Entities
{
    public sealed class Manager : EntityBase
    {
        public string FirstName { get; }
        public string LastName { get; }

        public string FullName => $"{LastName} {FirstName}";

        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

        public Manager(int id, string firstName, string lastName) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
