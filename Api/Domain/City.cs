using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Api.Domain
{
    public class City
    {
        public string Name { get; set; }

        public int RegionId { get; set; }

        public Region Region { get; set; }
    }
}
