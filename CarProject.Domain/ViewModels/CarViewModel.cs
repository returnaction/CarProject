﻿using CarProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Domain.ViewModels
{
    public class CarViewModel
    {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Model { get; set; }
            public decimal Speed { get; set; }
            public decimal Price { get; set; }
            public DateTime DateCreate { get; set; }
            public string TypeCar { get; set; }
    }
}
