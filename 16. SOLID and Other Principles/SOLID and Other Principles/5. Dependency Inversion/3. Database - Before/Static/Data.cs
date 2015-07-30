namespace DependencyInversionDatabaseStaticBefore
{
    using System.Collections.Generic;

    public static class Data
    {
        public static IEnumerable<int> CourseIds()
        {
            // return course ids
            return null;
        }

        public static IEnumerable<string> CourseNames()
        {
            // return course names
            return null;
        }

        public static IEnumerable<string> Search(string substring)
        {
            // return found results
            return null;
        }

        public static string GetCourseById(int id)
        {
            // return course by id
            return null;
        }
    }
}
