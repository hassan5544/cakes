using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cakes.Models;
namespace cakes.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
