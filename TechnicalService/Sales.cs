using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150Project.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BAIS3150Project.TechnicalService
{
    public class Sales
    {
        public List<Sale> GetAllSales ()
        {
            List<Sale> Sales = new List<Sale>();
            SaleItems SaleItemManager = new();
            Customers CustomerManager = new();

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
                CommandText = "GetAllSales"
            };

            SqlDataReader DataReader = AddCommand.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Sale ASale = new()
                    {
                        SaleNumber = (int)DataReader["SaleNumber"],
                        SaleDate = ((DateTime)DataReader["SaleDate"]).ToString("yyyy-MM-dd"),
                        SalePerson = (string)DataReader["SalePerson"],
                        SubTotal = (decimal)DataReader["SubTotal"],
                        GST = (decimal)DataReader["GST"],
                        Total = (decimal)DataReader["Total"]
                    };

                    ASale.Customer = CustomerManager.GetCustomerById((string)DataReader["CustomerID"]);
                    ASale.SaleItems = SaleItemManager.GetSaleItemsBySaleNumber((int)DataReader["SaleNumber"]);

                    Sales.Add(ASale);
                }
            }

            DataReader.Close();
            DataSource.Close();

            return Sales;
        }

        public int AddSale(Sale ASale)
        {
            bool Success = false;
            int SaleNumner = 0;

            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection DataSource = new();
            DataSource.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("dnguyen97");
            DataSource.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = DataSource,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "AddSale"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ASale.Customer.CustomerId
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@SaleDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = ASale.SaleDate
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@SalePerson",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ASale.SalePerson
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@SubTotal",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = ASale.SubTotal
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@GST",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = ASale.GST
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Total",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = ASale.Total
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
            if (result != 0)
            {
                Success = true;
                SaleNumner = result;
            }

            if ( Success)
            {
                foreach( SaleItem saleitem in ASale.SaleItems )
                {
                    AddCommand = new SqlCommand
                    {
                        Connection = DataSource,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "AddSaleItem"
                    };

                    AddCommandParameter = new SqlParameter
                    {
                        ParameterName = "@SaleNumber",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        SqlValue = SaleNumner
                    };
                    AddCommand.Parameters.Add(AddCommandParameter);

                    AddCommandParameter = new SqlParameter
                    {
                        ParameterName = "@ItemCode",
                        SqlDbType = SqlDbType.VarChar,
                        Direction = ParameterDirection.Input,
                        SqlValue = saleitem.AItem.ItemCode
                    };
                    AddCommand.Parameters.Add(AddCommandParameter);

                    AddCommandParameter = new SqlParameter
                    {
                        ParameterName = "@Quantity",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        SqlValue = saleitem.Quantity
                    };
                    AddCommand.Parameters.Add(AddCommandParameter);

                    AddCommandParameter = new SqlParameter
                    {
                        ParameterName = "@ItemTotal",
                        SqlDbType = SqlDbType.Decimal,
                        Direction = ParameterDirection.Input,
                        SqlValue = saleitem.ItemTotal
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
                    result = (int)AddCommand.Parameters["@ReturnCode"].Value;
                    if (result == 1)
                    {
                        Success = false;
                    }
                }
            }

            DataSource.Close();
            return Success ? SaleNumner : 0;
        }
    }
}
