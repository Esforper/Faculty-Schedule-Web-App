namespace FacultyScheduleWebApp.Models
{
    public class AcademianClass
    {
        public Guid Id { get; set; }
        public Guid WorkspaceID { get; set; }

        public string AcademianName { get; set; }
        public string AcademianFaculty { get; set; }
        public int AcademianLessonCount { get; set; }
        public List<string> LessonCodes { get; set; } = new List<string>();

        public List<OneLessonDateClass> Dates { get; set; } = new List<OneLessonDateClass>();
    }
}
