﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacultyScheduleWebApp.Models
{
    public class AcademianClass
    {
        public Guid Id { get; set; }
        public Guid WorkspaceID { get; set; }

        public string AcademianName { get; set; }
        public string AcademianFaculty { get; set; }
        public int AcademianLessonCount { get; set; }

        [NotMapped]
        public List<string> LessonCodes { get; set; } = new List<string>();
        [NotMapped]
        public int[] AvaibleDates { get; set; }

        public List<AcademianViewCell> Dates { get; set; } = new List<AcademianViewCell>();

        public string LessonCodesSerialized
        {
            get => JsonConvert.SerializeObject(LessonCodes);
            set => LessonCodes = JsonConvert.DeserializeObject<List<string>>(value);
        }

        public string AvaibleDatesSerialized
        {
            get => JsonConvert.SerializeObject(AvaibleDates);
            set => AvaibleDates = JsonConvert.DeserializeObject<int[]>(value);
        }
    }
}