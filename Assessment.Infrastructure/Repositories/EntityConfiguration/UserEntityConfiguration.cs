﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Domain.Entities;
using Assessment.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.Infrastructure.Repositories.EntityConfiguration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.Email);    
            builder.HasIndex(x => x.CustomerType);    
            builder.HasIndex(x => x.PhoneNumber);    
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(x=>x.Salt).IsRequired().HasMaxLength(1000);
            builder.Property(x=>x.Password).IsRequired().HasMaxLength(1000);
            builder.Property(x=>x.CustomerType).IsRequired();
            builder.HasData(new List<User>
            {
                //new User { Id = 1, }

                });
        }
    }
}
