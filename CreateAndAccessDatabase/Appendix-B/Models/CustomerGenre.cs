using System;
namespace CreateAndAccessDatabase.AppendixB.Models
{
    // Data structure for CustomerGenre model
    public class CustomerGenre
	{
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Genre { get; set; }
    }
}