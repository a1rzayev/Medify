using System.Runtime.CompilerServices;

namespace Medify.Models;

using System;
using Medify.Resources.Enums;
using Medify.Resources.Interfaces;

public class Doctor : IPerson
{
    public int Id { get; set; }
    public string FIN { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birth { get; set; }
    public SpecialityEnum Speciality { get; set; }
    public IEnumerable<HospitalEnum> Hospitals { get; set; }
    public bool isPaid { get; set; }
    public SubscriptionEnum Subscription { get; set; }
    public DateTime subsciptionStartDate { get; set; }
}