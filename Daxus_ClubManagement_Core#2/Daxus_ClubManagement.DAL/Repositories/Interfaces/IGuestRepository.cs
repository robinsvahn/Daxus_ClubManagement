using System;
using System.Collections.Generic;
using System.Text;
using Daxus_ClubManagement.DAL.Model;

namespace Daxus_ClubManagement.DAL.Repositories.Interfaces
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
