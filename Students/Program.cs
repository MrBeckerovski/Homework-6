
namespace Students
{
    class Student
    {
        public string firstName;
        public string lastName;
        public string university;
        public string faculty;
        public string department;
        public int age;
        public int course;
        public int group;
        public string city;

        public Student(string firstName, string lastName, string university, string faculty,
            string department, int age, int course, int group, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;
        }
    }
}