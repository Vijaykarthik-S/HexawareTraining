﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}