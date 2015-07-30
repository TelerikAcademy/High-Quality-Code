namespace DependencyInversionDatabaseAfter
{
    using DependencyInversionDatabaseAfter.Contracts;

    public class CoursesParameter
    {
        public void PrintAll(ICourseData data)
        {
            var courses = data.CourseNames();

            // print courses
        }

        public void PrintIds(ICourseData data)
        {
            var courses = data.CourseIds();

            // print courses
        }

        public void PrintById(ICourseData data, int id)
        {
            var courses = data.GetCourseById(id);

            // print courses
        }

        public void Search(ICourseData data, string substring)
        {
            var courses = data.Search(substring);

            // print courses
        }

        // other methods not needing ICourseData
        public void CalculateResults()
        {
            // do operations without needing ICourseData
        }
    }
}
