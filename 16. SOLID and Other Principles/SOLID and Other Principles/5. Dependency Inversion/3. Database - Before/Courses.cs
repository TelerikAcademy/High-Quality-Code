namespace DependencyInversionDatabaseBefore
{
    public class Courses
    {
        public void PrintAll()
        {
            var database = new Data();
            var courses = database.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var database = new Data();
            var courses = database.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var database = new Data();
            var courses = database.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var database = new Data();
            var courses = database.Search(substring);

            // print courses
        }
    }
}
