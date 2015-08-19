namespace NinjectIoCContainer
{
    using System.Reflection;

    using Ninject;
    using NinjectIoCContainer.Contracts;

    public class NinjectIoC
    {
        internal static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly()); // Loads NinjectModules (code configurations)
            // Easier: this.Bind<ICourseData>().To<CourseData>();

            var data = kernel.Get<ICourseData>();

            var courses = new Courses(data);
            courses.PrintAll();
        }
    }
}
