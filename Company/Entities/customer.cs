using System;
using System.Data.Linq.Mapping;
namespace Company.Entities
{
    [Table(Name = "Customers")]
    internal class customer
    {
        [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false)] public int Id;
        [Column(CanBeNull = false)] public string Name;
        [Column(CanBeNull = false)] public string VATNo;
        [Column(CanBeNull = true)] public string Street;
        [Column(CanBeNull = false)] public string City;
    }
}
