using System.Collections.Generic;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityManagementSystemApp.Models.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UniversityManagementSystemApp.Models.UniversityDbContext context)
        {
            //new List<Semester>
            //{
            //    new Semester{SemesterName = "1st Semester"},
            //    new Semester{SemesterName = "2nd Semester"},
            //    new Semester{SemesterName = "3rd Semester"},
            //    new Semester{SemesterName = "4th Semester"},
            //    new Semester{SemesterName = "5th Semester"},
            //    new Semester{SemesterName = "6th Semester"},
            //    new Semester{SemesterName = "7th Semester"},
            //    new Semester{SemesterName = "8th Semester"}
            //}.ForEach(semesters => context.Semesters.AddOrUpdate(semesters)); ;

            //new List<Designation>
            //{
            //    new Designation {Name = "Lecturer"},
            //    new Designation {Name = "Assistant Professor"},
            //    new Designation {Name = "Associate Professor"},
            //    new Designation {Name = "Professor"}
            //}.ForEach(designations => context.Designations.AddOrUpdate(designations));

            //new List<Room>
            //{
            //    new Room {RoomNo = "101"},
            //    new Room {RoomNo = "102"},
            //    new Room {RoomNo = "103"},
            //    new Room {RoomNo = "201"},
            //    new Room {RoomNo = "202"},
            //    new Room {RoomNo = "203"}
            //}.ForEach(rooms => context.Rooms.AddOrUpdate(rooms));

            //new List<GradeLetter>
            //{
            //    new GradeLetter {Grade = "A+"},
            //    new GradeLetter {Grade = "A"},
            //    new GradeLetter {Grade = "A-"},
            //    new GradeLetter {Grade = "B+"},
            //    new GradeLetter {Grade = "B"},
            //    new GradeLetter {Grade = "B-"},
            //    new GradeLetter {Grade = "C"},
            //    new GradeLetter {Grade = "D"},
            //    new GradeLetter {Grade = "F"}
            //}.ForEach(grades => context.GradeLetters.AddOrUpdate(grades));

            //new List<Department>
            //{
            //    new Department {Code = "CSE", Name = "Computer Science & Engineering"},
            //    new Department {Code = "EEE", Name = "Electrical & Electronics Engineering"},
            //    new Department {Code = "BBA", Name = "Bachelor of Business Administration"},
            //    new Department {Code = "PHY", Name = "Physics"},
            //    new Department {Code = "CHY", Name = "Chemistry"},
            //    new Department {Code = "MATH", Name = "Mathmetics"}
            //}.ForEach(departments => context.Departments.AddOrUpdate(departments));


            //new List<Day>
            //{
            //    new Day {TimeDay = "Saturday"},
            //    new Day {TimeDay = "Sunday"},
            //    new Day {TimeDay = "Monday"},
            //    new Day {TimeDay = "Tuesday"},
            //    new Day {TimeDay = "Wednesday"},
            //    new Day {TimeDay = "Thursday"},
            //    new Day {TimeDay = "Friday"}
            //}.ForEach(day => context.Days.AddOrUpdate(day));
        }
    }
}
