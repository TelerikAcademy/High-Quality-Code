namespace DependencyInversionDatabaseAfter
{
    using DependencyInversionDatabaseAfter.Contracts;

    public class CoursesConstructor
    {
        private ICourseData data;

        // poor man's IoC container
        public CoursesConstructor()
            : this(new CourseData())
        {
        }

        public CoursesConstructor(ICourseData data)
        {
            this.data = data;
        }

        public void PrintAll()
        {
            var courses = this.data.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var courses = this.data.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var courses = this.data.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var courses = this.data.Search(substring);

            // print courses
        }

        // other methods not needing ICourseData
        public void CalculateResults()
        {
            // do operations without needing ICourseData
        }
    }
}
