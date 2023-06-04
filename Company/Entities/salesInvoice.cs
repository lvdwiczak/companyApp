using System;
using System.Data.Linq.Mapping;
namespace Company.Entities
{
    [Table(Name = "SalesInvoices")]
    internal class salesInvoice
    {
        [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false)] public int Id;
        [Column(CanBeNull = false)] public string No;
        [Column(CanBeNull = false)] public double Net;
        [Column(CanBeNull = false)] public double VAT;
        [Column(CanBeNull = false)] public double Paid;
        [Column(CanBeNull = false)] public DateTime Date;
        [Column(CanBeNull = false)] public int CustomerID;
        [Column(CanBeNull = false)] public int EmployeeID;
    }
}
