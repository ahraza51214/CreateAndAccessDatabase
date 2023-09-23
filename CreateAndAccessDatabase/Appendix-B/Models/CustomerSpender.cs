using System;
namespace CreateAndAccessDatabase.AppendixB.Models
{
	public class CustomerSpender
	{
		public int CustomerId { get; set; }
		public string? CustomerName { get; set; }
		public decimal TotalSpent { get; set; }
	}
}