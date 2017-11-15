using System;
using System.Collections.Generic;
using Daxus_FootballManagement.DAL.Model;

namespace Daxus_FootballManagement.DAL.Repositories.Interfaces
{
    public interface IGuestRepository : IDisposable
    {
        IEnumerable<Guest> GetStudents();
        Guest GetStudentByID(int studentId);
        void InsertStudent(Guest student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Guest student);
        void Save();
    }
}
