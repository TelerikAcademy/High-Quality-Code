namespace NinjectIoCContainer
{
    using System;
    using System.Collections.Generic;

    using NinjectIoCContainer.Contracts;

    public class Courses
    {
        private readonly ICourseData data;

        public Courses(ICourseData data)
        {
            this.data = data;
        }

        public void PrintAll()
        {
            var courses = this.data.CourseNames();
            this.Print(courses);
        }

        private void Print(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
