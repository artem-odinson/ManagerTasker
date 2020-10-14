﻿using MenagerTasker.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MenagerTasker.Core.Data.Configs
{
    internal sealed class TaskItemConfig : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(t => t.CreationDate)                
                .IsRequired();

            builder
                .Property(t => t.EndDate)
                .IsRequired();

            builder
               .Property(t => t.Status)
               .IsRequired();
                

            builder.HasData(
                new TaskItem(1, "Отчет1", DateTime.Now.AddHours(-2), DateTime.Now.AddHours(2), 1),
                new TaskItem(2, "Отчет2", DateTime.Now.AddDays(-1), DateTime.Now.AddHours(4), 1),
                new TaskItem(3, "Отчет3", DateTime.Now.AddHours(-3), DateTime.Now.AddHours(2), 1) { Status = TaskStatus.Closed},
                new TaskItem(4, "Отчет4", DateTime.Now.AddHours(-2), DateTime.Now.AddHours(2), 1));
        }
    }
}
