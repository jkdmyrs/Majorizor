using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources
{
    public class ProgressTracker
    {
        public Student student { get; private set; }
        public List<Course> major1_required { get; private set; }
        public List<Course> major2_required { get; private set; }
        public List<Course> minor1_required { get; private set; }
        public List<Course> minor2_required { get; private set; }
        public List<Course> major1_acquired { get; private set; }
        public List<Course> major2_acquired { get; private set; }
        public List<Course> minor1_acquired { get; private set; }
        public List<Course> minor2_acquired { get; private set; }
    }
}