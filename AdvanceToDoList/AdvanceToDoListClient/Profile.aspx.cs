using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvanceToDoListClient
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("User.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BindData();
                }
            }

        }
        void BindData()
        {
            UserService.UserServiceClient client2 = new UserService.UserServiceClient("BasicHttpBinding_IUserService");

            UserService.User user = client2.GetProfile(Session["userid"].ToString());

            name.Text = user.Name;
            txt_dob.Text = user.DOB.Date.ToString("dd-MM-yyyy");
            txt_email.Text = user.Email;
            contact.Text = user.Contact;


            client2.Close();
        }

        protected void btn_ToDos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ToDo.aspx");
        }

        protected void btn_Profile_Click(object sender, EventArgs e)
        {
            UserService.UserServiceClient client2 = new UserService.UserServiceClient("BasicHttpBinding_IUserService");

            UserService.User user = new UserService.User();

            user.UserId = Session["userid"].ToString();
            user.Name = name.Text;
            user.DOB = Convert.ToDateTime(txt_dob.Text);
            user.Email = txt_email.Text;
            user.Contact = contact.Text;

            client2.UpdateProfile(user);
            BindData();
            client2.Close();
        }
    }
}