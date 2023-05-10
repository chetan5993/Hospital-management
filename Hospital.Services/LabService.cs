using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public  class LabService :ILabServices
    {
        private IUnitOfWork _unitOfWork;

        public LabService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteLab(int id)
        {
            var model = _unitOfWork.GenericRepository<Lab>().GetById(id);
            _unitOfWork.GenericRepository<Lab>().Delete(model);
            _unitOfWork.Save();
        }
        public IEnumerable<LabViewModel> GetAll()
        {
            var labList = _unitOfWork.GenericRepository<Lab>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(labList);
            return vmList;
        }

        public PagedResult<LabViewModel> GetAll(int pageNumber, int pageSize)
        {

            var vm = new LabViewModel();
            int totalCount;
            List<LabViewModel> vmList = new List<LabViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;


                var modelList = _unitOfWork.GenericRepository<Lab>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Lab>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);



            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<LabViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;



        }

        public LabViewModel GetLabById(int LabId)
        {
            var model = _unitOfWork.GenericRepository<Lab>().GetById(LabId);
            var vm = new LabViewModel(model);
            return vm;
        }


        public void InsertLab(LabViewModel Lab)
        {
            var model = new LabViewModel().ConvertViewModel(Lab);
            _unitOfWork.GenericRepository<Lab>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateLab(LabViewModel Lab)
        {
            var model = new LabViewModel().ConvertViewModel(Lab);
            var ModelById = _unitOfWork.GenericRepository<Lab>().GetById(model.Id);
            ModelById.BloodPressure = Lab.BloodPressure;
            ModelById.Temperature = Lab.Temperature;
            ModelById.LabNumber = Lab.LabNumber;
            ModelById.Weight = Lab.Weight;
            ModelById.Height = Lab.Height;
            ModelById.TestCode = Lab.TestCode;
            ModelById.TestResult = Lab.TestResult;
            ModelById.Patient = Lab.Patient;
            ModelById.TestType = Lab.TestType;
            ModelById.Id = Lab.Id;

            _unitOfWork.GenericRepository<Lab>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<LabViewModel> ConvertModelToViewModelList(List<Lab> modelList)
        {
            return modelList.Select(x => new LabViewModel(x)).ToList();
        }
    }
}
