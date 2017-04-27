using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProgram
{
    public class Course
    {

        public Course(string name, Course prerequisite = null, List<Course> dependents = null, bool isSelfStated = true)
        {
            Name = name;
            Prerequisite = prerequisite;
            Prerequisite?.Dependents.Add(this);
            Dependents = dependents ?? new List<Course>();
            IsSelfStated = isSelfStated;
        }

        public string Name { get; }

        public Course Prerequisite { get; set; }

        public string PrerequisiteName => Prerequisite != null ? Prerequisite.Name : string.Empty;

        public List<Course> Dependents { get; set; }

        public bool IsSelfStated { get; set; }

        public bool IsLeaf => Prerequisite == null;

        public int DependencyLevel => (Prerequisite?.DependencyLevel ?? -1) + 1;
    }
}
