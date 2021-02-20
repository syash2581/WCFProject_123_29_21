using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvanceToDoListClient
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            if (ModelState.IsValid)
            {
                UserService.UserServiceClient client = new UserService.UserServiceClient("BasicHttpBinding_IUserService");

                string UserId = userid.Text;
                string username = name.Text;
                string email = txt_email.Text;
                string contact = txt_dob.Text;
                DateTime dob= Convert.ToDateTime(txt_dob.Text);
                string Password = password.Text;

                UserService.User user = new UserService.User();

                user.UserId = UserId;
                user.Name = username;
                user.DOB  = dob;
                user.Email = email;
                user.Contact = contact;
                user.Password = Password;

                if (client.SignUp(user))
                {
                    txt_error.Text = "User Registered. Try to login";
                    txt_error.Visible = true;
                }
                else
                {
                    txt_error.Text = "Failed to Register";
                    txt_error.Visible = true;
                }

                client.Close();
            }
        }
    }
}