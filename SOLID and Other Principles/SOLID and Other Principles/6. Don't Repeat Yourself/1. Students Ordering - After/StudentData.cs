namespace DRYStudentsOrderingAfter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentData
    {
        private IEnumerable<Student> students;

        public StudentData()
        {
            this.students = new HashSet<Student>();
        }

        public IEnumerable<Student> OrderedByFirstName()
        {
            //// return this.OrderByExpression<string>(st => st.FirstName);
            return this.OrderByExpression(st => st.FirstName);
        }

        public IEnumerable<Student> OrderedByLastName()
        {
            return this.OrderByExpression(st => st.LastName);
        }

        public IEnumerable<Student> OrderedByAge()
        {
            return this.OrderByExpression(st => st.Age);
        }

        public IEnumerable<Student> OrderedByMark()
        {
            return this.OrderByExpression(st => st.Mark);
        }

        public IEnumerable<Student> OrderedByParticipation()
        {
            return this.OrderByExpression(st => st.Participations);
        }

        private IEnumerable<Student> OrderByExpression<Condition>(Func<Student, Condition> expression)
        {
            if (!this.students.Any())
            {
                throw new InvalidOperationException("There are no students to sort");
            }

            var copiedStudents = new HashSet<Student>(this.students);
            var result = copiedStudents.OrderBy(expression);
            return result;
        }
    }
}
