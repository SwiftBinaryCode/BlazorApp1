using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class SuperCourse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Category? Category { get; set; }

        public int CategoryId { get; set; }



    }
}
