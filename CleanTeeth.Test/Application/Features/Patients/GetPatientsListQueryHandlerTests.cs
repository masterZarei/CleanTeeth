using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Test.Application.Features.Patients
{
    [TestClass]
    public class GetPatientsListQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IPatientRepository _patientRepository;
        private GetPatientsListQueryHandler _handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _patientRepository = Substitute.For<IPatientRepository>();
            _handler = new GetPatientsListQueryHandler(_patientRepository);
        }

        [TestMethod]
        public async Task Handle_ValidQuery_ReturnsPatientsPaginated()
        {
            var page =1;
            var recordsPerPage = 2;
            var patient1 = new Patient("Patient 1", new EmailValueObject("p1@gmail.com"));
            var patient2 = new Patient("Patient 2", new EmailValueObject("p2@gmail.com"));

            IEnumerable<Patient> patients = new List<Patient> { patient1,  patient2 };

            _patientRepository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(Task.FromResult(patients));
            _patientRepository.GetTotalAmountOfRecords().Returns(Task.FromResult(10));

            var query = new GetPatientsListQuery { Page = page, RecordsPerPage = recordsPerPage };
            var result = await _handler.Handle(query);

            Assert.AreEqual(10, result.TotalAmountOfRecords);
            Assert.HasCount(2, result.Elements);
        }
        [TestMethod]
        public async Task Handle_WhenThereAreNoPatients_ReturnsEmptyListAndZero()
        {

            IEnumerable<Patient> patients = new List<Patient> {  };

            _patientRepository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(Task.FromResult(patients));
            _patientRepository.GetTotalAmountOfRecords().Returns(Task.FromResult(0));

            var query = new GetPatientsListQuery { Page = 1, RecordsPerPage = 5 };
            var result = await _handler.Handle(query);

            Assert.AreEqual(0, result.TotalAmountOfRecords);
            Assert.IsNotEmpty(result.Elements);
            Assert.IsEmpty(result.Elements);
        }
    }
}
