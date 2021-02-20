using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdvanceToDoList
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["ToDoDB"].ToString();

        bool IUserService.DeleteProfile(string userid)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "delete from Users where userid=@Id";

                SqlParameter p1 = new SqlParameter("@Id", userid);

                sqlCommand.Parameters.Add(p1);

                int i = sqlCommand.ExecuteNonQuery();

                if (i == 1)
                {
                    Console.WriteLine("Deleted");
                    return true;
                }
                return false;

            }
        }

        User IUserService.GetProfile(string userid)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "select * from Users where userId = @Id";
                SqlParameter p = new SqlParameter("@Id", userid);
                sqlCommand.Parameters.Add(p);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                User user = new User();

                if (dr.Read())
                {
                    user.Id = dr.GetInt32(0);
                    user.UserId = dr.GetString(1);
                    user.Name = dr.GetString(2);
                    user.DOB = dr.GetDateTime(3);
                    user.Email = dr.GetString(4);
                    user.Contact = dr.GetString(5);
                    user.Password = dr.GetString(6);
                }
                return user;
            }
        }

        bool IUserService.Login(string userid, string password)
        {
            if (checkUserExist(userid))
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "select * from Users where userId = @Id";
                    SqlParameter p = new SqlParameter("@Id", userid);
                    sqlCommand.Parameters.Add(p);
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    User user = new User();

                    if (dr.Read())
                    {
                        user.Id = dr.GetInt32(0);
                        user.UserId = dr.GetString(1);
                        user.Name = dr.GetString(2);
                        user.DOB = dr.GetDateTime(3);
                        user.Email = dr.GetString(4);
                        user.Contact= dr.GetString(5);
                        user.Password = dr.GetString(6);

                        if(password.Equals(user.Password))
                        {
                            return true;
                        }    
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        bool IUserService.SignUp(User user)
        {
            if (!checkUserExist(user.UserId))
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "insert into Users(userid,name,dob,email,contact,password) values(@UserId,@Name,@Dob,@Email,@Contact,@Password)";

                    /*SqlParameter p1 = new SqlParameter("@Id", 0);*/
                    SqlParameter p2 = new SqlParameter("@UserId", user.UserId);
                    SqlParameter p3 = new SqlParameter("@Name", user.Name);
                    SqlParameter p4 = new SqlParameter("@Dob", user.DOB);
                    SqlParameter p5 = new SqlParameter("@Email", user.Email);
                    SqlParameter p6 = new SqlParameter("@Contact", user.Contact);
                    SqlParameter p7 = new SqlParameter("@Password", user.Password);

                    /*sqlCommand.Parameters.Add(p1);*/
                    sqlCommand.Parameters.Add(p2);
                    sqlCommand.Parameters.Add(p3);
                    sqlCommand.Parameters.Add(p4);
                    sqlCommand.Parameters.Add(p5);
                    sqlCommand.Parameters.Add(p6);
                    sqlCommand.Parameters.Add(p7);
                    int i = sqlCommand.ExecuteNonQuery();

                    if (i == 1)
                    {
                        Console.WriteLine("Inserted");
                        return true;
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        User IUserService.UpdateProfile(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "update Users set name=@Name,dob=@Dob,email=@Email,contact=@Contact where userid=@Id";

                SqlParameter p1 = new SqlParameter("@Id", user.UserId);
                SqlParameter p2 = new SqlParameter("@Name", user.Name);
                SqlParameter p3 = new SqlParameter("@Dob", user.DOB);
                SqlParameter p4 = new SqlParameter("@Email", user.Email);
                SqlParameter p5 = new SqlParameter("@Contact", user.Contact);


                sqlCommand.Parameters.Add(p1);
                sqlCommand.Parameters.Add(p2);
                sqlCommand.Parameters.Add(p3);
                sqlCommand.Parameters.Add(p4);
                sqlCommand.Parameters.Add(p5);
                int i = sqlCommand.ExecuteNonQuery();

                if (i == 1)
                {
                    Console.WriteLine("Updated");
                }
                return user;
            }
        }
        bool checkUserExist(String userid)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "select * from Users where userId = @Id";
                SqlParameter p = new SqlParameter("@Id", userid);
                sqlCommand.Parameters.Add(p);
                SqlDataReader dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

