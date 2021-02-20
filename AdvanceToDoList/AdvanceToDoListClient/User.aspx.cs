using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvanceToDoListClient
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (ModelState.IsValid)
            {
                UserService.UserServiceClient client = new UserService.UserServiceClient("BasicHttpBinding_IUserService");

                string UserId = txt_Username.Text;
                string Password = txt_password.Text;

                if (client.Login(UserId, Password))
                {
                    Session.Add("userid", UserId);
                    Response.Redirect("ToDo.aspx");
                }
                else
                {
                    txt_error.Text = "Failed to Login";
                    txt_error.Visible = true;
                }
                
                client.Close();
            }
        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}