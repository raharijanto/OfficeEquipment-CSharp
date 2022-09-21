using OfficeEquipment.Models;
using System;
using System.Data.SqlClient;

namespace OfficeEquipment
{
    class Program
    {
        SqlConnection connection;
        string connectionString = "Data Source=DESKTOP-QC1NOEP;" +
            "Initial Catalog=OFFICEEQUIPMENT;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";
        
        static void Main(string[] args)
        {
            Program progItem = new Program();
            Placement placement = new Placement()
            {
                //PlaceId = 4,
                //PlaceName = "Mechanical Engineering Workspace",
                //RefPlace = 1
            };

            //progItem.insert(placement);   // Uncomment all (PlaceId, PlaceName, RefPlace) in placement class
            //progItem.update(placement);   // Uncomment only (PlaceId, PlaceName) in placement class
            //progItem.delete(placement);   // Uncomment only (PlaceId) in placement class

            progItem.getAll();
            //progItem.getId(1);
        }

        void getAll()
        {
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select inventory.inventname, placement.placename " +
                "from inventory " +
                "join placement " +
                "on placement.refplace = inventory.inventid";

            try
            {
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("Item Name : " + dataReader[0]);
                            Console.WriteLine("Total Used : " + dataReader[1]);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void getId (int id)
        {
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select inventory.inventname, quantity.itemused " +
                "from inventory " +
                "join quantity " +
                "on quantity.refnumber = inventory.inventid " +
                "where inventory.inventid = @id";

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = id;
            command.Parameters.Add(param);

            try
            {
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("Item Name : " + dataReader[0]);
                            Console.WriteLine("Total Used : " + dataReader[1]);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void insert (Placement placement)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlTransaction transaction = connect.BeginTransaction();
                SqlCommand commandment = connect.CreateCommand();
                commandment.Transaction = transaction;

                try
                {
                    commandment.CommandText = "insert into placement(placeid, placename, refplace) " +
                        "values (@placeid, @placename, @refplace)";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@placeid";
                    parameter.Value = placement.PlaceId;

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@placename";
                    parameter2.Value = placement.PlaceName;

                    SqlParameter parameter3 = new SqlParameter();
                    parameter3.ParameterName = "@refplace";
                    parameter3.Value = placement.RefPlace;

                    commandment.Parameters.Add(parameter);
                    commandment.Parameters.Add(parameter2);
                    commandment.Parameters.Add(parameter3);
                    commandment.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }

        void update (Placement placement)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlTransaction transaction = connect.BeginTransaction();
                SqlCommand commandment = connect.CreateCommand();
                commandment.Transaction = transaction;

                try
                {
                    commandment.CommandText = "update placement " +
                        "set placename = @placename " +
                        "where placeid = @placeid";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@placeid";
                    parameter.Value = placement.PlaceId;

                    SqlParameter parameter2 = new SqlParameter();
                    parameter2.ParameterName = "@placename";
                    parameter2.Value = placement.PlaceName;

                    //SqlParameter parameter3 = new SqlParameter();
                    //parameter3.ParameterName = "@refplace";
                    //parameter3.Value = placement.RefPlace;

                    commandment.Parameters.Add(parameter);
                    commandment.Parameters.Add(parameter2);
                    //commandment.Parameters.Add(parameter3);
                    commandment.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }

        void delete (Placement placement)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlTransaction transaction = connect.BeginTransaction();
                SqlCommand commandment = connect.CreateCommand();
                commandment.Transaction = transaction;

                try
                {
                    commandment.CommandText = "delete from placement " +
                        "where placeid = @placeid";

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@placeid";
                    parameter.Value = placement.PlaceId;

                    //SqlParameter parameter2 = new SqlParameter();
                    //parameter2.ParameterName = "@placename";
                    //parameter2.Value = placement.PlaceName;

                    //SqlParameter parameter3 = new SqlParameter();
                    //parameter3.ParameterName = "@refplace";
                    //parameter3.Value = placement.RefPlace;

                    commandment.Parameters.Add(parameter);
                    //commandment.Parameters.Add(parameter2);
                    //commandment.Parameters.Add(parameter3);
                    commandment.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }
    }
}
