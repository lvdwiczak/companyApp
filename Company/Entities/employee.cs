using System;
using System.Data.Linq.Mapping;
namespace Company.Entities
{
    [Table(Name = "Employee")]
    internal class Employee
    {
        [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false)] public int Id;
        [Column(CanBeNull = false)] public string Name;
        [Column(CanBeNull = false)] public string LastName;
        [Column(CanBeNull = false)] public string Email;
        [Column(CanBeNull = false)] public string Telefon;
    }
}
