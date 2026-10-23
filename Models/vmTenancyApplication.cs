using Gharshare.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.Models
{
    public class vmTenancyApplication
    {
        [ValidateNever]
        public Applicant? Applicant { get; set; }
        [ValidateNever]
        public ApplicantAddIncome? ApplicantAddIncome { get; set; }
        public List<ApplicantDependent>? ApplicantDependents { get; set; }
        public List<ApplicantDocument>? ApplicantDocument { get; set; }
        public List<ApplicantDocType>? ApplicantDocType { get; set; }
        public List<ApplicantEmployer>? ApplicantEmployer { get; set; }
        public List<ApplicantHistory>? ApplicantHistory { get; set; }
        public List<ApplicantPet>? ApplicantPets { get; set; }
        public List<ApplicantReference>? ApplicantReference { get; set; }
        [ValidateNever]
        public ApplicantVehicle? ApplicantVehicle { get; set; }
        public List<ApplicantVehicle>? ApplicantVehicles { get; set; }
    }
}
