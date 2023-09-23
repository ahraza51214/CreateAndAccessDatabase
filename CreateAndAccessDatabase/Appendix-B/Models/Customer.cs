﻿using System;
using System.Collections.Generic;

namespace CreateAndAccessDatabase.AppendixB.Models
{
    // Data structure for Customer object
    public partial class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Country { get; set; }

        public string? PostalCode { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; } = null!;

        public List<string> PopularGenres { get; set; } = new List<string>();
    }
}