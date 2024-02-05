using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Medify.Models;
using Dapper;
using Medify.Repositories.Base;
namespace Medify.Repositories;
public class MedRepository : IRepository
{
    private const string connectionString = $"Server=(localdb)\\MedifyDB;Database=medify;Trusted_Connection=True;TrustServerCertificate=True;";
    public int AddDoctor(Doctor doctor)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.Execute(
            @"insert into Games (FIN, Phone, Mail, Name, Surname, Birth, Speciality, Hospitals, IsPaid, Subscription, SubscriptionStartDate)
             values (@FIN, @Phone, @Mail, @Name, @Surname, @Birth, @Speciality, @Hospitals, @IsPaid, @Subscription, @SubscriptionStartDate)",
            param: new
            {
                doctor.FIN,
                doctor.Phone,
                doctor.Mail,
                doctor.Name,
                doctor.Surname,
                doctor.Birth,
                doctor.Speciality,
                doctor.Hospitals,
                doctor.IsPaid,
                doctor.Subscription,
                doctor.SubsciptionStartDate,
            }
        );
    }

    public Doctor? GetDoctorById(int id)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.QueryFirstOrDefault<Doctor>(
            sql: "select * from Doctors where Id = @Id",
            param: new {
                Id = id 
            }                
        );
    }

    public Doctor? GetDoctorByName(string name)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.QueryFirstOrDefault<Doctor>(
            sql: "select * from Doctors where Name = @name",
            param: new {
                Name = name 
            }                
        );
    }

    public IEnumerable<Doctor> GetDoctors()
    {
        using var connection = new SqlConnection(connectionString);
        return connection.Query<Doctor>("select * from Doctors");
    }

    public int DeleteDoctor(int id)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.Execute(
            @"delete Doctors where Id = @Id",
            param: new
            {
                Id = id,
            }
        );
    }

}