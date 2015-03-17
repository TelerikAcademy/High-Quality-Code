namespace DependencyInversionDatabaseStaticBefore
{
    public class Courses
    {
        public void PrintAll()
        {
            var courses = Data.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var courses = Data.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var courses = Data.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var courses = Data.Search(substring);

            // print courses
        }
    }
}
