using System;
using MayaBinance.Domain.SeedWork;

namespace MayaBinance.Domain.BaseModels.ViewModels
{

    public class SimpleCoinsViewModel:BaseSimpleViewModel<int>
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}
