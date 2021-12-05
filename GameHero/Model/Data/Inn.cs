
namespace GameHero.Model.Data
{
    public class Inn
    {
        private const string DEFAULT_INN_NAME = "Inn for rest";
        private const int DEFAULT_INN_PRICE_REST = 10;
        private static Inn inn;

        public string Name { get; private set; }
        public int PriceRest { get; private set; }

        static Inn()
        {
            inn = new Inn();
        }

        private Inn()
        {
            Name = DEFAULT_INN_NAME;
            PriceRest = DEFAULT_INN_PRICE_REST;
        }

        public static Inn GetInctance()
        {
            return inn;
        }

        public override string ToString()
        {
            return $"\"{Name}\" (price: {PriceRest})";
        }
    }
}
