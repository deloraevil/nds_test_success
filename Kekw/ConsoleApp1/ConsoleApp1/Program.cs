namespace ConsoleApp1
{
    internal class Program
    {
        public static void CalcPrices(decimal InputPriceWithNDS, int ProcNDS, out decimal CorrectedPriceWithNDS, out decimal CorrectedPriceWithoutNDS)
        {
            if (ProcNDS >= 0 && ProcNDS <= 99)
            {
                var priceWithoutNDS = Math.Round(InputPriceWithNDS / (1m + ProcNDS / 100m), 1);

                CorrectedPriceWithoutNDS = Convert.ToDecimal(priceWithoutNDS.ToString("G29"));

                CorrectedPriceWithNDS = Convert.ToDecimal(Math.Round(CorrectedPriceWithoutNDS * (1m + ProcNDS / 100.0m), 2).ToString("G29"));
            }
            else
            {
                CorrectedPriceWithNDS = 0;
                CorrectedPriceWithoutNDS = 0;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                decimal CorrectedPriceWithNDS, CorrectedPriceWithoutNDS;

                Console.Write("InputPriceWithNDS: ");
                decimal InputPriceWithNDS = Convert.ToDecimal(Console.ReadLine());

                Console.Write("ProcNDS: ");
                int ProcNDS = Convert.ToInt32(Console.ReadLine());

                CalcPrices(InputPriceWithNDS, ProcNDS, out CorrectedPriceWithNDS, out CorrectedPriceWithoutNDS);

                Console.WriteLine("CorrectedPriceWithNDS: " + CorrectedPriceWithNDS);
                Console.WriteLine("CorrectedPriceWithoutNDS: " + CorrectedPriceWithoutNDS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
