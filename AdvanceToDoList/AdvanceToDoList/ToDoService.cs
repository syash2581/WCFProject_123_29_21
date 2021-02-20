using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdvanceToDoList
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ToDoService" in both code and config file together.
    public class ToDoService : IToDoService
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["ToDoDB"].ToString();
        List<ToDo> IToDoService.GetAllToDos(string userid)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                List<ToDo> toDos = new List<ToDo>();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "select * from ToDos where userid=@Id";

                SqlParameter p1 = new SqlParameter("@Id", userid);

                sqlCommand.Parameters.Add(p1);

                SqlDataReader dr = sqlCommand.ExecuteReader();
                

                while(dr.Read())
                {
                    ToDo toDo = new ToDo();
                    toDo.Id = dr.GetInt32(0);
                    toDo.Title = dr.GetString(1);
                    toDo.Description = dr.GetString(2);
                    toDo.EndDate = dr.GetDateTime(3);
                    toDo.UserId = dr.GetString(4);

                    toDos.Add(toDo);
                }
                return toDos;
            }
        }
        DataSet IToDoService.GetAllToDosGrid(string userid)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //List<ToDo> toDos = new List<ToDo
                connection.Open();

                
                
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "select id,title,description,CONVERT(date,endDate) as enddate from ToDos where userid=@Id";
                SqlParameter p1 = new SqlParameter("@Id", userid);
                sqlCommand.Parameters.Add(p1);


                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }

        ToDo IToDoService.GetToDo(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "select * from ToDos where Id = @Id";
                SqlParameter p = new SqlParameter("@Id", id);
                sqlCommand.Parameters.Add(p);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                ToDo toDo= new ToDo();

                if (dr.Read())
                {
                    toDo.Id= dr.GetInt32(0);
                    toDo.Title = dr.GetString(1);
                    toDo.Description= dr.GetString(2);
                    toDo.EndDate = dr.GetDateTime(3);
                    toDo.UserId = dr.GetString(4);
                }
                return toDo;
            }
        }

        void IToDoService.SaveToDo(ToDo toDo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "insert into ToDos(title,description,endDate,userid) values(@Title,@Description,@EndDate,@UserId)";
                
                /*SqlParameter p1 = new SqlParameter("@Id", 0);*/
                SqlParameter p2 = new SqlParameter("@Title", toDo.Title);
                SqlParameter p3 = new SqlParameter("@Description", toDo.Description);
                SqlParameter p4 = new SqlParameter("@EndDate", toDo.EndDate);
                SqlParameter p5 = new SqlParameter("@UserId", toDo.UserId);
                
                /*sqlCommand.Parameters.Add(p1);*/
                sqlCommand.Parameters.Add(p2);
                sqlCommand.Parameters.Add(p3);
                sqlCommand.Parameters.Add(p4);
                sqlCommand.Parameters.Add(p5);
                int i = sqlCommand.ExecuteNonQuery();

                if (i == 1)
                {
                    Console.WriteLine("Inserted");
                }

            }
        }

        ToDo IToDoService.UpdateToDo(ToDo toDo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "update ToDos set title=@Title,description=@Description,endDate=@EndDate where id=@Id";

                SqlParameter p1 = new SqlParameter("@Id", toDo.Id);
                SqlParameter p2 = new SqlParameter("@Title", toDo.Title);
                SqlParameter p3 = new SqlParameter("@Description", toDo.Description);
                SqlParameter p4 = new SqlParameter("@EndDate", toDo.EndDate);

                sqlCommand.Parameters.Add(p1);
                sqlCommand.Parameters.Add(p2);
                sqlCommand.Parameters.Add(p3);
                sqlCommand.Parameters.Add(p4);
                int i = sqlCommand.ExecuteNonQuery();

                if (i == 1)
                {
                    Console.WriteLine("Updated");
                }
                return toDo;
            }
        }


        bool IToDoService.DeleteToDo(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "delete from ToDos where id=@Id";

                SqlParameter p1 = new SqlParameter("@Id", id);
                
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
    }
}
