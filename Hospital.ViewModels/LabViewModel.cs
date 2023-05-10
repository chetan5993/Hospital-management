using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{

    public  class LabViewModel
    {

        public int Id { get; set; }
        public string LabNumber { get; set; }
        public ApplicationUser Patient { get; set; }
        public string TestType { get; set; }
        public string TestCode { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int BloodPressure { get; set; }
        public int Temperature { get; set; }
        public string TestResult { get; set; }
        public LabViewModel()
        {
            
        }
         public LabViewModel(Lab model)

        {
            Id = model.Id;
            LabNumber = model.LabNumber;
            Patient = model.Patient;
                
            TestType = model.TestType;
            TestCode = model.TestCode;
            Weight = model.Weight;
            Height = model.Height;
            Temperature = model.Temperature;
            TestResult = model.TestResult;
                BloodPressure=model.BloodPressure;
        }
        public Lab ConvertViewModel(LabViewModel model)

        {
            return new Lab
            {
                Id = model.Id,
                LabNumber = model.LabNumber,
                Patient = model.Patient,
                TestType = model.TestType,
                TestCode = model.TestCode,
                Weight = model.Weight,
                Height = model.Height,
                Temperature = model.Temperature,
                TestResult = model.TestResult,
                BloodPressure = model.BloodPressure,

            };

        }
    }


}


