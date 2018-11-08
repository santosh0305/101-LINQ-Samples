﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqSamplesCommon.Model;

namespace Quantifiers
{
    public partial class LinqSamplesQuantifiers
    {
        [Category("Quantifiers")]
        [Description("This sample uses Any to return a grouped a list of products only for categories " +
             "that have at least one product that is out of stock.")]
        public void Linq69()
        {
            List<Products.Product> products = Products.GetProductList();

            var productGroups =
                from prod in products
                group prod by prod.Category into prodGroup
                where prodGroup.Any(p => p.UnitsInStock == 0)
                select new { Category = prodGroup.Key, Products = prodGroup };

            ObjectDumper.Write(productGroups, 1);
        }
    }
}
