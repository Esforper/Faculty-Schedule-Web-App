namespace FacultyScheduleWebApp.Models
{
    public class DateCellClass
    {
        public Guid Id { get; set; } // Primary Key


        public Guid LessonAcademian { get; set; }
        public Guid LessonClass { get; set; }
        public Guid LessonName { get; set; }

        public int CellRow { get; set; }
        public int CellColumn { get; set; }
    }
}
