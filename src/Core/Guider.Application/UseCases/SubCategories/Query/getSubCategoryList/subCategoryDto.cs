﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.SubCategories.Query.getSubCategoryList
{
    public  class subCategoryDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

    }
}
