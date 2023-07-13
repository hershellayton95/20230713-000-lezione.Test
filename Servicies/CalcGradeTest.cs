using Xunit;
using _20220713_000_lezione.Entities;
using _20220713_000_lezione.Servicies;
using Moq;
using _20230713_000_lezione.Servicies;

namespace _20220713_000_lezione.Test.Servicies
{
    public class CalcGradeTest
    {
        [Fact]
        public void CalcDoubleAverageReturnsCorrectResult()
        {
            List<Student> students = new List<Student>()
            {
                new Student{Name = "Bart", Grade=5},
                new Student{Name = "Marin", Grade=5},
                new Student{Name = "Nelson", Grade=8}
            };
            var mock = new Mock<ICalc>();
            mock.Setup(calc => calc.CalcAverage(It.IsAny<IEnumerable<double>>())).Returns(5.0d);

            var calcStudentsGrade = new CalcGrade(mock.Object);
            var result = calcStudentsGrade.CalcDoubleAverage(students);
            mock.Verify(calc => calc.CalcAverage(It.IsAny<IEnumerable<double>>()), Times.Once());
            Assert.Equal(10.0d, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void CalcDoubleAverageThrowsException(int count)
        {
            var students = new Student[count];

            var mock = new Mock<ICalc>();
            var calcStudentsGrade = new CalcGrade(mock.Object);
            Assert.Throws<Exception>(()=> calcStudentsGrade.CalcDoubleAverage(students));
            mock.Verify(calc => calc.CalcAverage(It.IsAny<IEnumerable<double>>()), Times.Never());

        }

        //[Fact]
        //public void GetBestStudentReturnsCorrectResult()
        //{
        //    var pippoStudent = new Student { Name="Pippo", Grade =10};
        //    List<Student> students = new List<Student>()
        //    {
        //        new Student{Name = "Bart", Grade=5},
        //        new Student{Name = "Marin", Grade=5},
        //        new Student{Name = "Nelson", Grade=8},
        //        pippoStudent
        //    };
        //    var calcStudentsGrade = new CalcGrade<Student>(students);

        //    var result = calcStudentsGrade.GetBestStudent();
        //    Assert.Equal(pippoStudent, result);
        //}
    }
}
