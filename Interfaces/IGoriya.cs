using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendofZelda.Interfaces
{
    public interface IGoriya : IEnemy
    {
        public bool IsDamaged { get; set; }
    }
}
