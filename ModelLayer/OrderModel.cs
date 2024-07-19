﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class OrderModel
    {
        public int CustomersDetailsId { get; set; }

        public OrderModel( int customersDetailsId)
        {
            CustomersDetailsId = customersDetailsId;
        }
    }
}
