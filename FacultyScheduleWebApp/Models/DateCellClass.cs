﻿using Microsoft.EntityFrameworkCore;

namespace FacultyScheduleWebApp.Models
{
    public class DateCellClass
    {
        public Guid Id { get; set; } // Primary Key
        //Genel ID, muhtemelen kullanmak gerekmeyecek bile ama benzersizlik açısından önemli

        public Guid LessonAcademian { get; set; }
        //Akademisyen takvimine buradan erişebilecek
        public Guid LessonClass { get; set; }
        //Derslikler takvimine bu Guidden erişecek
        //Dersliklerin kodları da benzersizdir ama bu bizim üniversiteye özel olabilir o sebeple böyle durmalı.
        public string LessonCode { get; set; }
        //Her ders kodu benzersizdir, derse buradan erişilecek

        public int CellRow { get; set; }
        public int CellColumn { get; set; }
    }

    [Keyless]
    public class AcademianViewCell
    {
        public string ClassName { get; set; }
        public string LessonCode { get; set; }

        public int CellRow { get; set; }
        public int CellColumn { get; set; }
    }
    [Keyless]
    public class ClassroomViewCell
    {
        public string AcademianName { get; set; }
        public string LessonCode { get; set; }

        public int CellRow { get; set; }
        public int CellColumn { get; set; }
    }
    [Keyless]
    public class LessonViewCell
    {
        public string AcademianName { get; set; }
        public string ClassName { get; set; }

        public int CellRow { get; set; }
        public int CellColumn { get; set; }
    }
}
