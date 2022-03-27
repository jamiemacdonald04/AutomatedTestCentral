using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CSHARP.CoffeeMaker.BaselineBad
{
    public class CoffeeMaker
    {
        public CoffeeMaker()
        {
        }

        private const string ConnectionString = "Server=PDATA_SQLEXPRESS;Database=;User Id =; Password=!;";

        private List<string> BrewCoffeeAndPriceCoffee(int milk, int sugar, int strength, SyrupEnum syrup, bool sweetner, bool whitner, ToppingEnum toppings)
        {

            bool failure = false;

            List<string> bp = new List<string>();
            decimal p = 3.00M;


            DataTable dt = new DataTable();
            int rows_returned;

            string sqlQuery = $"SELECT top 1 milk FROM  [dbo].[MilkType] WHERE milkId ={milk}";


            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                using SqlCommand cmd = c.CreateCommand();
                using SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                c.Open();
                rows_returned = sda.Fill(dt);
                c.Close();
            }

            DataRow dr = dt.Rows[0];
            bp.Add($"added {(string)dr[0]} milk to cup.");

            sqlQuery = $"SELECT top 1 sugar FROM  [dbo].[sugarType] WHERE sugerId ={sugar}";

            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                using SqlCommand cmd = c.CreateCommand();
                using SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                c.Open();
                rows_returned = sda.Fill(dt);
                c.Close();
            }

            DataRow dr2 = dt.Rows[0];
            bp.Add($"added {(string)dr[0]} sugar to cup.");

            var beans = (3 * strength);

            if (syrup == SyrupEnum.lemon)
            {
                p = +0.50M;
                bp.Add($"turn bottle.");
                bp.Add($"Pour syrup into to Coffee Pot.");
            }
            else if (syrup == SyrupEnum.toffee)
            {
                p = +0.50M;
                bp.Add($"turn bottle.");
                bp.Add($"squeeze bottle.");
                bp.Add($"Pour syrup into to Coffee Pot.");
            }
            else if (syrup == SyrupEnum.noThanks)
            {
                bp.Add($"turn bottle.");
                bp.Add($"squeeze bottle.");
                bp.Add($"Pour syrup into to Coffee Pot.");
            }
            else if (syrup == SyrupEnum.vanila)
            {
                p = +0.60M;
                bp.Add($"turn bottle.");
                bp.Add($"squeeze bottle.");
                bp.Add($"Pour syrup into to Coffee Pot.");
                bp.Add($"shake bottle.");
                bp.Add($"turn bottle.");
                bp.Add($"squeeze bottle.");
                bp.Add($"Pour syrup into to Coffee Pot.");
            }
            else
            {
                bp.Add($"Syrup is not available");
                failure = true;
            }


            bp.Add($"added {beans} to Coffee Pot.");

            bp.Add($"pour coffee.");

            if (sweetner & sugar > 1)
            {

            }
            /*
             * code not needed needed so we better comment it out just in case.
                        if (whitner) {
                            bp.Add($"whitner has been added to the coffee");
                            if (bp.Select(i => i.Contains("milk")).First()) {
                                //OMG what rubbish code i have never seen anything so bad in all my life
                                bp.Add($"milk is in cup already");
                                failure = true;
                            }

                        }
            */

            if ((toppings != null) && ((toppings == ToppingEnum.coffee || toppings == ToppingEnum.hundredAndThousands || toppings == ToppingEnum.chocolate) && (syrup == null)))
            {
                bp.Add($"added topings to coffee cup.");
            }

            if (failure)
            {
                return new List<string>() { "coffee was attepted but not made" };
            }
            else
            {
                bp.Add($"Cost of service today was £{p * 1.2M}");
                return bp;
            }
        }
    }
}
