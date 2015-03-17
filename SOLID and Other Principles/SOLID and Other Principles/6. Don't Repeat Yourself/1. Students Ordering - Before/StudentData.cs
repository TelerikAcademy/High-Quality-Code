namespace DRYStudentsOrderingBefore
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
            if (!this.students.Any())
            {
                throw new InvalidOperationException("There are no students to sort");
            }

            var copiedStudents = new HashSet<Student>(this.students);
            var result = copiedStudents.OrderBy(st => st.FirstName);
            return result;
        }

        public IEnumerable<Student> OrderedByLastName()
        {
            if (!this.students.Any())
            {
                throw new InvalidOperationException("There are no students to sort");
            }

            var copiedStudents = new HashSet<Student>(this.students);
            var result = copiedStudents.OrderBy(st => st.LastName);
            return result;
        }

        public IEnumerable<Student> OrderedByAge()
        {
            if (!this.students.Any())
            {
                throw new InvalidOperationException("There are no students to sort");
            }

            var copiedStudents = new HashSet<Student>(this.students);
            var result = copiedStudents.OrderBy(st => st.Age);
            return result;
        }

        public IEnumerable<Student> OrderedByMark()
        {
            if (!this.students.Any())
            {
                throw new InvalidOperationException("There are no students to sort");
            }

            var copiedStudents = new HashSet<Student>(this.students);
            var result = copiedStudents.OrderBy(st => st.Mark);
            return result;
        }

        public IEnumerable<Student> OrderedByParticipation()
        {
            if (!this.students.Any())
            {
                throw new InvalidOperationException("There are no students to sort");
            }

            var copiedStudents = new HashSet<Student>(this.students);
            var result = copiedStudents.OrderBy(st => st.Participations);
            return result;
        }
    }
}
