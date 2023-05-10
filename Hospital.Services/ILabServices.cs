using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
     public interface ILabServices
    {
        IEnumerable<LabViewModel> GetAll();

        PagedResult<LabViewModel> GetAll(int pageNumber, int pageSize);
        LabViewModel GetLabById(int LabtId);
        void UpdateLab(LabViewModel lab);
        void InsertLab(LabViewModel contact);
        void DeleteLab(int id);
    }
}
