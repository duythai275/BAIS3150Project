using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150Project.Domain;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BAIS3150Project.TechnicalService
{
    public class Items
    {
        public List<Item> GetItems()
        {
            List<Item> Items = new List<Item>();

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
                CommandText = "GetItems"
            };

            SqlDataReader DataReader = AddCommand.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Item AItem = new()
                    {
                        ItemCode = (string) DataReader["ItemCode"],
                        Description = (string)DataReader["Description"],
                        UnitPrice = (decimal)DataReader["UnitPrice"],
                        Quantity = (int)DataReader["Quantity"]
                    };
                    Items.Add(AItem);
                }
            }

            DataReader.Close();
            DataSource.Close();

            return Items;
        }

        public bool AddItem(Item AItem)
        {
            bool Success = false;

            /*
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            */

            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Database=dnguyen97;User ID=dnguyen97;Password=Thaianh1011;server=dev1.baist.ca";
            // DataSource.ConnectionString = DataSource.GetConnectionString("dnguyen97");
            DataSource.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = DataSource,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "AddItem"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.ItemCode
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.Description
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Quantity",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.Quantity
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.UnitPrice
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ReturnCode",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommand.ExecuteNonQuery();
            int result = (int)AddCommand.Parameters["@ReturnCode"].Value;
            if (result == 0)
            {
                Success = true;
            }

            DataSource.Close();

            return Success;
        }
        
        public bool UpdateItem(Item AItem)
        {
            bool Success = false;

            /*
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            */

            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Database=dnguyen97;User ID=dnguyen97;Password=Thaianh1011;server=dev1.baist.ca";
            // DataSource.ConnectionString = DataSource.GetConnectionString("dnguyen97");
            DataSource.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = DataSource,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "UpdateItem"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.ItemCode
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.Description
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Quantity",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.Quantity
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = AItem.UnitPrice
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ReturnCode",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommand.ExecuteNonQuery();
            int result = (int)AddCommand.Parameters["@ReturnCode"].Value;
            if (result == 0)
            {
                Success = true;
            }

            DataSource.Close();

            return Success;
        }
        
        public bool DeleteItem(string ItemCode)
        {
            bool Success = false;

            /*
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            */

            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Database=dnguyen97;User ID=dnguyen97;Password=Thaianh1011;server=dev1.baist.ca";
            // DataSource.ConnectionString = DataSource.GetConnectionString("dnguyen97");
            DataSource.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = DataSource,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "DeleteItem"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ItemCode
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ReturnCode",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.ReturnValue
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommand.ExecuteNonQuery();
            int result = (int)AddCommand.Parameters["@ReturnCode"].Value;
            if (result == 0)
            {
                Success = true;
            }

            DataSource.Close();

            return Success;
        }

        public Item GetItemByCode(string ItemCode) 
        {
            Item AItem = new();

            /*
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();
            */

            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Database=dnguyen97;User ID=dnguyen97;Password=Thaianh1011;server=dev1.baist.ca";
            // DataSource.ConnectionString = DataSource.GetConnectionString("dnguyen97");
            DataSource.Open();

            SqlCommand AddCommand = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItemByCode"
            };

            SqlParameter AddCommandParameter;
            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ItemCode
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            SqlDataReader DataReader = AddCommand.ExecuteReader();
            if (DataReader.HasRows)
            {
                DataReader.Read();
                AItem.ItemCode = (string) DataReader["ItemCode"];
                AItem.Description = (string)DataReader["Description"];
                AItem.UnitPrice = (decimal)DataReader["UnitPrice"];
                AItem.Quantity = (int)DataReader["Quantity"];
            }

            DataReader.Close();
            DataSource.Close();

            return AItem;
        }
    }
}
