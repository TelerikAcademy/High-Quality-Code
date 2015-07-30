namespace NinjectIoCContainer.Configuration
{
    using Ninject.Modules;
    using NinjectIoCContainer.Contracts;

    public class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICourseData>().To<CourseData>();
        }
    }
}
