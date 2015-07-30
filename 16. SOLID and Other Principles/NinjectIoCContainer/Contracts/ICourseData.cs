namespace NinjectIoCContainer.Contracts
{
    using System.Collections.Generic;

    public interface ICourseData
    {
        IEnumerable<string> CourseNames();
    }
}
