using System.Collections.Generic;
using System.Data;
using BAIS3150Project.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BAIS3150Project.TechnicalService
{
    public class SaleItems
    {
        public List<SaleItem> GetSaleItemsBySaleNumber(int SaleNumber)
        {
            List<SaleItem> SaleItems = new List<SaleItem>();
            Items ItemManager = new();

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection DataSource = new();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("dnguyen97");
            DataSource.Open();

            SqlCommand AddCommand = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetSaleItemsBySaleNumber"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@SaleNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = SaleNumber
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            SqlDataReader DataReader = AddCommand.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    SaleItem ASaleItem = new()
                    {
                        ItemTotal = (decimal)DataReader["ItemTotal"],
                        Quantity = (int)DataReader["Quantity"]
                    };

                    ASaleItem.AItem = ItemManager.GetItemByCode((string)DataReader["ItemCode"]);

                    SaleItems.Add(ASaleItem);
                }
            }

            DataReader.Close();
            DataSource.Close();

            return SaleItems;
        }
    }
}
