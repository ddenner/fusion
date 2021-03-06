﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using FusionSoapService.Contracts.Data;
using FusionSoapService.Contracts.Mapper;

namespace FusionSoapService.DataSource
{
    public class PatientMapper : AbstractMapper, IPatientMapper
    {
        private static Patient MapPatientResult(SqlDataReader reader)
        {
            return new Patient()
            {
                PatientId = (Guid) reader[0],
                Key = (int) reader[1],
                PatientName = new PersonName()
                {
                    FirstName = (string) reader[2],
                    LastName = (string) reader[3]
                },
                PrimaryEmail = new EmailAddress()
                {
                    Email = (string) reader[4]
                },
                HomePhone = new Phone()
                {
                    Number = (string) reader[5]
                },
                HomeAddress = new Address()
                {
                    Address1 = (string) reader[6],
                    Address2 = (string) reader[7],
                    City = (string) reader[8],
                    State = (string) reader[9],
                    ZipCode = (string) reader[10],
                    GeoLocation = new SpatialData()
                    {
                        Latitude = Convert.ToSingle(reader[11]),
                        Longitude = Convert.ToSingle(reader[12])
                    }
                },
                Tracking = new ChangeInformation()
                {
                    InsertDate = (DateTime) reader[13],
                    ModifiedDate = (DateTime) reader[14]
                }
            };
        }

        public Patient GetPatient(Guid patientId, int region)
        {
            var command = new SqlCommand("EXEC dbo.p_GetPatient @PatientId, @Region", Connection);
            SqlDataReader reader = null;

            try
            {
                command.Parameters.Add("@Region", SqlDbType.Int).Value = region;
                command.Parameters.Add("@PatientId", SqlDbType.UniqueIdentifier).Value = patientId;

                OpenAndSetKey(region, "RegionFederation", "Region");

                reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow);

                Patient res = null;

                while (reader.Read())
                    res = MapPatientResult(reader);
                
                return res;
            }
            finally
            {
                if (null != reader)
                {
                    if (!reader.IsClosed)
                        reader.Close();
                    reader.Dispose();
                }

                command.Dispose();
            }
        }

        public List<Patient> GetPatientsWithInMiles(SpatialData location, int miles)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetPatientsByName(PersonName name)
        {
            throw new NotImplementedException();
        }

        public Patient InsertUpdatePatient(Patient patient)
        {
            var command = new SqlCommand(string.Format("EXEC dbo.p_InsertUpdatePatient @PatientId, @Region," +
                                                          "@FirstName, @LastName, @Email, @Phone," +
                                                          "@Address1, @Address2, @City, @State," +
                                                          "@ZipCode, @Latitude, @Longitude"), Connection);
            
            try
            {
                command.Parameters.Add("@PatientId", SqlDbType.UniqueIdentifier).Value = patient.PatientId;
                command.Parameters.Add("@Region", SqlDbType.Int).Value = patient.Key;

                var nameValid = new PersonNameValidator();
                var personValidationResult = nameValid.Validate(patient.PatientName);

                if ((!personValidationResult.IsValid) && (null != personValidationResult.Errors))
                    throw new ValidationException(personValidationResult.Errors);

                // we should be data validated by hitting here.  no need to check for null ref
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = patient.PatientName.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = patient.PatientName.LastName;

                var emailValid = new EmailAddressValidator();
                var emailValidationResult = emailValid.Validate(patient.PrimaryEmail);

                if ((!emailValidationResult.IsValid) && (null != emailValidationResult.Errors))
                    throw new ValidationException(emailValidationResult.Errors);

                command.Parameters.Add("@Email", SqlDbType.NVarChar, 255).Value = patient.PrimaryEmail.Email;

                var phoneValid = new PhoneValidator();
                var phoneValidationResult = phoneValid.Validate(patient.HomePhone);

                if ((!phoneValidationResult.IsValid) && (null != phoneValidationResult.Errors))
                    throw new ValidationException(phoneValidationResult.Errors);

                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 255).Value = patient.HomePhone.Number;

                var addressValid = new AddressValidator();
                var addressValidationResult = addressValid.Validate(patient.HomeAddress);

                if ((!addressValidationResult.IsValid) && (null != addressValidationResult.Errors))
                    throw new ValidationException(addressValidationResult.Errors);
                 
                command.Parameters.Add("@Address1", SqlDbType.NVarChar, 50).Value = patient.HomeAddress.Address1;
                if (string.IsNullOrEmpty(patient.HomeAddress.Address2))
                    command.Parameters.Add("@Address2", SqlDbType.NVarChar, 50).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Address2", SqlDbType.NVarChar, 50).Value = patient.HomeAddress.Address2;
                command.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = patient.HomeAddress.City;
                command.Parameters.Add("@State", SqlDbType.Char, 2).Value = patient.HomeAddress.State;
                command.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 10).Value = patient.HomeAddress.ZipCode;

                command.Parameters.Add("@Latitude", SqlDbType.Float).Value = patient.HomeAddress.GeoLocation.Latitude;
                command.Parameters.Add("@Longitude", SqlDbType.Float).Value = patient.HomeAddress.GeoLocation.Longitude;

                OpenAndSetKey(patient.Key, "RegionFederation", "Region");
                command.ExecuteNonQuery();

                return patient;
            }
            finally
            {
                command.Dispose();
             }
        }

        public void DeletePatient(Guid patientId)
        {
            throw new NotImplementedException();
        }
    }
}
