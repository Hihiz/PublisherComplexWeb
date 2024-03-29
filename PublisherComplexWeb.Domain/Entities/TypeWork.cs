﻿namespace PublisherComplexWeb.Domain.Entities
{
    public class TypeWork
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Work> Works { get; } = new List<Work>();
    }
}
