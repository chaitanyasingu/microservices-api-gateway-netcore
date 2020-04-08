﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Entities
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string ProductTypeDesc { get; set; }
    }
}
