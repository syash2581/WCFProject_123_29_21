﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AdvanceToDoListClient.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

        #txt_error{
            color:red
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
            margin: auto;
            width: 40%;
        }
        .lgnbtn{
            margin:10px;
            width:40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="frmalg">
        <div class="container">
            <h3>Profile</h3>
            <label for="name"><b>Name</b></label>
            <asp:TextBox runat="server" ID="name" placeholder="Enter Username"></asp:TextBox>
            <label for="dob"><b>Date Of Birth</b></label>
            <asp:TextBox runat="server" ID="txt_dob"></asp:TextBox>
            <br />
            <label for="email"><b>Email</b></label>
            <asp:TextBox runat="server" ID="txt_email" TextMode="Email" placeholder="Enter Email"></asp:TextBox>
            
            <br />
            <label for="contact"><b>Contact</b></label>
            <asp:TextBox runat="server" ID="contact" TextMode="Phone" placeholder="Enter Contact no"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="btn_ToDos" CssClass="lgnbtn" Text="Back to ToDos" OnClick="btn_ToDos_Click" />
            <asp:Button runat="server" ID="btn_UpdateProfile" CssClass="lgnbtn" Text="Update Profile" OnClick="btn_Profile_Click" />
        </div>
    </form>
</body>
</html>
