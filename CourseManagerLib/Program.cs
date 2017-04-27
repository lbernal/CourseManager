using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProgram
{

    public class Program
    {

        public Dictionary<string, Course> Courses { get; }

        public Program(string[] courseEntries)
        {
            Courses = new Dictionary<string, Course>();
            foreach (var courseEntry in courseEntries)
            {
                var courseSections = courseEntry.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                var name = courseSections[0].Trim();
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("A empty course entry was found. Please review your course entries.");
                }
                var prerequisite = courseSections.Length > 1 ? courseSections[1].Trim() : string.Empty;
                AddCourse(name, prerequisite);
            }
            ValidateNotSelfStatedCourses();
        }

        public override string ToString()
        {
            return string.Join(", ", Courses.Values.OrderBy(c => c.DependencyLevel).ThenBy(c => c.Prerequisite?.Name).Select(c => c.Name));
        }

        private void AddCourse(string name, string prerequisite)
        {
            if (!Courses.ContainsKey(name))
            {
                Courses.Add(name, new Course(name));
            }
            Courses[name].IsSelfStated = true;
            if (!string.IsNullOrEmpty(prerequisite))
            {
                ValidateCircularDependencies(name, prerequisite);
                if (!Courses.ContainsKey(prerequisite))
                {
                    Courses.Add(prerequisite, new Course(prerequisite, null, new List<Course>() {Courses[name]}, false));
                }
                else
                {
                    Courses[prerequisite].Dependents.Add(Courses[name]);
                }
                if (Courses[name].Prerequisite != null)
                {
                    throw new ArgumentException($"The course '{name}' already has '{Courses[name].PrerequisiteName}' as prerequisite. You can't replace the existing prerequisite by '{prerequisite}'.");
                }
                Courses[name].Prerequisite = Courses[prerequisite];
            }
        }

        private void ValidateNotSelfStatedCourses()
        {
            if (Courses.Values.Any(c => !c.IsSelfStated))
            {
                throw new ArgumentException("At least one course wasn't self stated. It only appeared as prerequisite.");
            }
        }

        private void ValidateCircularDependencies(string name, string prerequisite)
        {
            List<string> visitedCourses = new List<string>() {name};
            string current = prerequisite;
            while (!string.IsNullOrEmpty(current))
            {
                if (!Courses.ContainsKey(current))
                {
                    return;
                }
                visitedCourses.Add(current);
                if (visitedCourses.Count(s => s == current) > 1)
                {
                    throw new ArgumentException($"A circular dependency was detected at course entry: {name}: {prerequisite}.");
                }
                current = Courses[current].PrerequisiteName;
            }
        }

    }
}
