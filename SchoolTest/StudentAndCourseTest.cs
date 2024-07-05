namespace SchoolTest
{
    using Xunit;
    using SchoolTracker;
    public class StudentAndCourseTest
    {
        private readonly Student _student;
        private readonly Course _course;
        private readonly List<Student> _students;
        private readonly List<Course> _courses;
        private readonly CourseAction _courseaction;
        private readonly StudentAction _studentaction;


        public StudentAndCourseTest(string studentName = "test", string lastname = "TEST", string dateString = "2000/01/01", string coursName = "coursTest") 
        {
            DateOnly date = DateOnly.Parse(dateString);
            _student = new Student( studentName, lastname, date);
            _course = new Course(coursName);
            _courses = new List<Course>();
            _students = new List<Student>();
            _courseaction = new CourseAction(_students, _courses);
            _studentaction = new StudentAction(_students, _courses);

        }

        [Fact]
        public void Create_Student_Grade_ReturnTrue()
        {
            // Arrange
            var coursname = "coursTest";
            var note = 0;
            var comment = "";
            _courses.Add(_course);

            // Act
            var result = _student.AddGrade(_courses, coursname, note, comment);
            // Assert
            Assert.True(result);

        }
        [Fact]
        public void Add_Course_ReturnTrue()
        {
            // Arrange
            var coursetotest = "coursTest";
            // Act
            var result = _courseaction.AddCourse(coursetotest);
            // Assert
            Assert.True(result);

        }
    }
}