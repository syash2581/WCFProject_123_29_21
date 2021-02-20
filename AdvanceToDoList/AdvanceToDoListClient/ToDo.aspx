<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="AdvanceToDoListClient.ToDo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ToDos</title>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        form {
            border: 3px solid #f1f1f1;
        }

        input {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        button:hover {
            opacity: 0.8;
        }

        #txt_error {
            color: red
        }

        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }

        .lgnbtn {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 50%;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .container {
            padding: 16px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cnbtn {
                width: 100%;
            }
        }

        .frmalg {
            width: 100%;
        }


        table {
            border-collapse: collapse;
            width: 100%;
            margin: 20px auto;
            border: 3px solid #f1f1f1;
        }

        tr, td, th {
            text-align: left;
            padding: 18px;
        }

            tr:nth-child(even) {
                background-color: #f2f2f2;
            }

        .mainC {
            display: flex;
            background-color: red;
        }

        .abc {
            position: fixed;
            bottom: -150px;
            width: 100%;
            left: 0;
        }
        .lgnbtn{
            margin:10px;
            width:30%;
        }
    </style>
</head>
<body>
    <div>
        <form id="form1" runat="server" class="frmalg">
            <div class="container">

                <h3>Your ToDos</h3>
                <asp:TextBox runat="server" ID="txt_error" Visible="false" ReadOnly="true"></asp:TextBox>
                <label for="txt_title"><b>Title</b></label>
                <asp:TextBox runat="server" ID="txt_title" placeholder="Enter title"></asp:TextBox>
                <label for="txt_description"><b>Description</b></label>
                <asp:TextBox runat="server" ID="txt_description" placeholder="Enter Description"></asp:TextBox>
                <label for="enddate"><b>End Date</b></label>
                <asp:TextBox runat="server" ID="endDate" TextMode="Date"></asp:TextBox>
                <asp:Button runat="server" ID="btn_Save" CssClass="lgnbtn" Text="Save ToDo" OnClick="btn_Save_Click" />
                <asp:Button runat="server" ID="btn_profile" CssClass="lgnbtn" Text="Profile" OnClick="btn_Profile_Click" />
                <asp:Button runat="server" ID="btn_logout" CssClass="lgnbtn" Text="Logout" OnClick="btn_Logout_Click" />
            </div>
            <asp:GridView ID="GridView1"  runat="server" OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="id">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </form>


    </div>

</body>
</html>
