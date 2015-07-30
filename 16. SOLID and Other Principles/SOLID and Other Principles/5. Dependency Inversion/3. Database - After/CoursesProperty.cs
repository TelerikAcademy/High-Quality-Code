namespace DependencyInversionDatabaseAfter
{
    using DependencyInversionDatabaseAfter.Contracts;

    public class CoursesProperty
    {
        public ICourseData Data { get; set; }

        public void PrintAll()
        {
            var courses = this.Data.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var courses = this.Data.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var courses = this.Data.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var courses = this.Data.Search(substring);

            // print courses
        }

        // other methods not needing ICourseData
        public void CalculateResults()
        {
            // do operations without needing ICourseData
        }
    }
}
