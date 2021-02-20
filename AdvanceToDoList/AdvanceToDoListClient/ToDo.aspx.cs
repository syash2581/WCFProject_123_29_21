using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvanceToDoListClient
{
    public partial class ToDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                if (Session["userid"] == null)
                {
                    Response.Redirect("User.aspx");
                }
                else
                {
                    ToDoService.ToDoServiceClient client = new ToDoService.ToDoServiceClient("BasicHttpBinding_IToDoService");

                    /*ToDoService.ToDo[] toDos = client.GetAllToDos(Session["userid"].ToString());

                    TableRow defHeaderrow = new TableHeaderRow();
                    TableCell defHeadercell1 = new TableHeaderCell();
                    TableCell defHeadercell2 = new TableHeaderCell();
                    TableCell defHeadercell3 = new TableHeaderCell();

                    defHeadercell1.Text = "Title";
                    defHeadercell2.Text = "Description";
                    defHeadercell3.Text = "End Date";

                    defHeaderrow.Cells.Add(defHeadercell1);
                    defHeaderrow.Cells.Add(defHeadercell2);
                    defHeaderrow.Cells.Add(defHeadercell3);

                    Table1.Rows.Add(defHeaderrow);
                    foreach (var item in toDos)
                    {
                        TableRow row = new TableRow();


                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        TableCell cell3 = new TableCell();

                        //Debug.WriteLine(item + "\n");

                        cell1.Text = item.Title;
                        cell2.Text = item.Description;
                        cell3.Text = item.EndDate.ToString("dd/MM/yyyy");

                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);

                        Table1.Rows.Add(row);
                    }*/
                    GridView1.DataSource = client.GetAllToDosGrid(Session["userid"].ToString());
                    GridView1.DataBind();

                    client.Close();
                }

            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {

            if (ModelState.IsValid)
            {
                ToDoService.ToDoServiceClient client = new ToDoService.ToDoServiceClient("BasicHttpBinding_IToDoService");

                string title = txt_title.Text.Trim();
                string description = txt_description.Text.Trim();
                DateTime enddate = Convert.ToDateTime(endDate.Text);

                ToDoService.ToDo toDo = new ToDoService.ToDo();
                toDo.Title = title;
                toDo.Description = description;
                toDo.EndDate = enddate;
                toDo.UserId = Session["userid"].ToString();

                client.SaveToDo(toDo);

                ToDoService.ToDo[] toDos = client.GetAllToDos(Session["userid"].ToString());

                /* foreach (var item in toDos)
                 {
                     TableRow row = new TableRow();
                     TableCell cell1 = new TableCell();
                     TableCell cell2 = new TableCell();
                     TableCell cell3 = new TableCell();
                     Console.WriteLine(item + "\n");

                     cell1.Text = item.Title;
                     cell2.Text = item.Description;
                     cell3.Text = item.EndDate.ToString();

                     row.Cells.Add(cell1);
                     row.Cells.Add(cell2);
                     row.Cells.Add(cell3);

                     Table1.Rows.Add(row);                    
                 }*/
                GridView1.DataSource = client.GetAllToDosGrid(Session["userid"].ToString());
                GridView1.DataBind();

                client.Close();
            }
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("User.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ToDoService.ToDoServiceClient client = new ToDoService.ToDoServiceClient("BasicHttpBinding_IToDoService");

            int id = int.Parse(e.Keys[0].ToString());
            string userid = Session["userid"].ToString();
            string title = e.NewValues["title"].ToString();
            string description = e.NewValues["description"].ToString();
            DateTime enddate = Convert.ToDateTime(e.NewValues["enddate"].ToString());



            ToDoService.ToDo toDo = new ToDoService.ToDo();
            toDo.Id = id;
            toDo.Title = title;
            toDo.Description = description;
            toDo.EndDate = enddate;
            toDo.UserId = userid;

            client.UpdateToDo(toDo);

            GridView1.DataSource = client.GetAllToDosGrid(Session["userid"].ToString());

            client.Close();

            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ToDoService.ToDoServiceClient client = new ToDoService.ToDoServiceClient("BasicHttpBinding_IToDoService");

            int id = int.Parse(e.Keys[0].ToString());

            client.DeleteToDo(id);

            BindData();

            client.Close();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        private void BindData()
        {
            ToDoService.ToDoServiceClient client = new ToDoService.ToDoServiceClient("BasicHttpBinding_IToDoService");

            GridView1.DataSource = client.GetAllToDosGrid(Session["userid"].ToString());
            GridView1.DataBind();

            client.Close();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }
    }
}