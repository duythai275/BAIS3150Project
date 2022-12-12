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
    public class Customers
    {
        public List<Customer> GetCustomers()
        {
            List<Customer> Customers = new List<Customer>();

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
                CommandText = "GetCustomers"
            };

            SqlDataReader DataReader = AddCommand.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Customer ACustomer = new()
                    {
                        CustomerId = (string)DataReader["CustomerID"],
                        CustomerName = (string)DataReader["CustomerName"],
                        Address = (string)DataReader["Address"],
                        City = (string)DataReader["City"],
                        Province = (string)DataReader["Province"],
                        PostalCode = (string)DataReader["PostalCode"]
                    };
                    Customers.Add(ACustomer);
                }
            }

            DataReader.Close();
            DataSource.Close();

            return Customers;
        }

        public bool AddCustomer(Customer ACustomer)
        {
            bool Success = false;

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
                CommandText = "AddCustomer"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.CustomerId
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.CustomerName
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.Address
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.City
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Province",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.Province
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.PostalCode
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

        public bool UpdateCustomer(Customer ACustomer)
        {
            bool Success = false;

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
                CommandText = "UpdateCustomer"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.CustomerId
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.CustomerName
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.Address
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.City
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Province",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.Province
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ACustomer.PostalCode
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
        
        public bool DeleteCustomer(string CustomerId)
        {
            bool Success = false;

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
                CommandText = "DeleteCustomer"
            };

            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CustomerId
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

        public Customer GetCustomerById(string CustomerId) 
        {
            Customer ACustomer = new();

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
                CommandText = "GetCustomerById"
            };

            SqlParameter AddCommandParameter;
            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CustomerId
            };
            AddCommand.Parameters.Add(AddCommandParameter);

            SqlDataReader DataReader = AddCommand.ExecuteReader();
            if (DataReader.HasRows)
            {
                DataReader.Read();
                ACustomer.CustomerId = (string) DataReader["CustomerId"];
                ACustomer.CustomerName = (string) DataReader["CustomerName"];
                ACustomer.Address = (string) DataReader["Address"];
                ACustomer.City = (string) DataReader["City"];
                ACustomer.Province = (string) DataReader["Province"];
                ACustomer.PostalCode = (string) DataReader["PostalCode"];
            }

            DataReader.Close();
            DataSource.Close();

            return ACustomer;
        }
    }
}
