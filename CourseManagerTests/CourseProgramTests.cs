using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseManagerTests
{
    [TestClass]
    public class CourseProgramTests
    {
        [TestMethod]
        public void TestEmptyProgram()
        {
            var courseEntries = new string[] {};
            var program = new CourseProgram.Program(courseEntries);
            string expected = string.Empty;
            string actual = program.ToString();
            Assert.AreEqual(expected, actual, "The course program must be empty.");
        }

        [TestMethod]
        public void TestProgramWithOneSingleCourse()
        {
            var courseEntries = new string[] { "A:" };
            var program = new CourseProgram.Program(courseEntries);
            string expected = "A";
            string actual = program.ToString();
            Assert.AreEqual(expected, actual, "The course program must only have the course A.");
        }

        [TestMethod]
        public void TestProgramWithMoreThanOneDependencyToOneSingleCourse()
        {
            var courseEntries = new string[] { "A:", "B1: A", "B2: A", "A: A0", "A0:" };
            var program = new CourseProgram.Program(courseEntries);
            string expected = "A0, A, B1, B2";
            string actual = program.ToString();
            Assert.AreEqual(expected, actual, "The course program was not printed in the expected order.");
        }

        [TestMethod]
        public void TestProgramHomeworkSample()
        {
            var courseEntries = new string[]
            {
                "Introduction to Paper Airplanes:",
                "Advanced Throwing Techniques: Introduction to Paper Airplanes",
                "History of Cubicle Siege Engines: Rubber Band Catapults 101",
                "Advanced Office Warfare: History of Cubicle Siege Engines",
                "Rubber Band Catapults 101:",
                "Paper Jet Engines: Introduction to Paper Airplanes"
            };
            var program = new CourseProgram.Program(courseEntries);
            string expected = "Introduction to Paper Airplanes, Rubber Band Catapults 101, Advanced Throwing Techniques, Paper Jet Engines, History of Cubicle Siege Engines, Advanced Office Warfare";
            string actual = program.ToString();
            Assert.AreEqual(expected, actual, "The course program was not printed in the expected order.");
        }

        [TestMethod]
        public void TestProgramWithCircularDependencyToItself()
        {
            var courseEntries = new string[] { "A: A" };
            try
            {
                var program = new CourseProgram.Program(courseEntries);
            }
            catch (ArgumentException exc)
            {
                StringAssert.Contains(exc.Message, "A circular dependency was detected at course entry");
            }
        }

        [TestMethod]
        public void TestProgramWithCircularDependencyHomeworkSample()
        {
            var courseEntries = new string[]
            {
                "Intro to Arguing on the Internet: Godwin’s Law",
                "Understanding Circular Logic: Intro to Arguing on the Internet",
                "Godwin’s Law: Understanding Circular Logic"
            };
            try
            {
                var program = new CourseProgram.Program(courseEntries);
            }
            catch (ArgumentException exc)
            {
                StringAssert.Contains(exc.Message, "A circular dependency was detected at course entry");
            }
        }

        [TestMethod]
        public void TestProgramWithCaseSensitiveness()
        {
            var courseEntries = new string[] { "Course0:", "Course1: Course0", "course1: course0", "course0:" };
            var program = new CourseProgram.Program(courseEntries);
            string expected = "Course0, course0, course1, Course1";
            string actual = program.ToString();
            Assert.AreEqual(expected, actual, "The course program was not printed in the expected order.");
        }

        [TestMethod]
        public void TestProgramWithPrerequisiteReplacement()
        {
            var courseEntries = new string[]
            {
                "A:",
                "B: A",
                "B: C"
            };
            try
            {
                var program = new CourseProgram.Program(courseEntries);
            }
            catch (ArgumentException exc)
            {
                StringAssert.Contains(exc.Message, "You can't replace the existing prerequisite");
            }
        }

        [TestMethod]
        public void TestProgramWithAtLeastOneNotSelfStatedCourse()
        {
            var courseEntries = new string[]
            {
                "A:",
                "B: A",
                "C: B1"
            };
            try
            {
                var program = new CourseProgram.Program(courseEntries);
            }
            catch (ArgumentException exc)
            {
                StringAssert.Contains(exc.Message, "At least one course wasn't self stated");
            }
        }
    }
}
