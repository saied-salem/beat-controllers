﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beat.Model;

namespace Beat.Data
{
    public class BeatContext : DbContext
    {
        static string BeatConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=D:\db\BEAT.mdf; Initial Catalog=BeatDb2; Integrated Security=True; Connect Timeout=30;";   
        public BeatContext() : base("BeatConnectionString")
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Partner> Partners { get; set; }
    }
}
