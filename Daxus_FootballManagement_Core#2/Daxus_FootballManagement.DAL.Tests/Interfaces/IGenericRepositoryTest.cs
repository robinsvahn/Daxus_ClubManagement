using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Tests.Interfaces
{
    interface IGenericRepositoryTest
    {
        Task GetAll_WithNothing_ShouldReturnCorrectNumberOfEntities();
        Task GetByIdAysnc_WithValidIds_ShouldReturnValidEntities(int id);
        Task AddAsync_WithValidData_ShouldAddEntityToLastPositionInList();
        Task UpdateAsync_WithValidPropertyData_ShouldUpdateEntities(int idToTest, string propertyData);
        Task UpdateAsync_WithValidEntityCopyButChangedProperty_ShouldUpdateEntitytWithNewPropertyValue();
    }
}
