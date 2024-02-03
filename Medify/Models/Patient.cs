namespace Medify.Models;

using System;
using Medify.Resources.Interfaces;

public class Patient : IPerson
{
    public int Id { get; set; }
    public string FIN { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birth { get; set; }
}