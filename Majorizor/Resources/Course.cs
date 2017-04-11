﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources
{
    public class Course
    {
        public int id { get; private set; }
        public string subject { get; private set; }
        public string catalog { get; private set; }
        public string section { get; private set; }
        public string name { get; private set; }
        public DateTime startTime { get; private set; }
        public DateTime endTime { get; private set; }
        public string days { get; private set; }

        public Course() { }

        public Course(int _ID, string _subject, string _catalog, string _section, string _name, DateTime _start, DateTime _end, string _days)
        {
            this.id = _ID;
            this.subject = _subject;
            this.catalog = _catalog;
            this.section = _section;
            this.name = _name;
            this.startTime = _start;
            this.endTime = _end;
            this.days = _days;
        }

    }
}