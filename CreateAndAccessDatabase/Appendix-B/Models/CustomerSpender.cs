using System;
namespace CreateAndAccessDatabase.AppendixB.Models
{
    // Data structure for CustomerSpender model
    public class CustomerSpender
	{
		public int CustomerId { get; set; }
		public string? CustomerName { get; set; }
		public decimal TotalSpent { get; set; }
	}
}