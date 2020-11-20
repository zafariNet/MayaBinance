using CSharpFunctionalExtensions;

namespace MayaBinance.Domain.BaseModels
{
    public class Coin: Entity<int>
    {
        public Coin(string name, string symbol, string icon, bool isActive)
        {
            Name = name;
            Symbol = symbol;
            Icon = icon;
            IsActive = isActive;
        }
        protected Coin(){}

        public string Name { get; }
        public string Symbol { get; }
        public string Icon { get;}
        public bool IsActive { get; }
    }
}
