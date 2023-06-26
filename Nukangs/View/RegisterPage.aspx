<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Nukangs.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/RegisterPage.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Lobster&family=Open+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;0,800;1,300;1,700;1,800&family=Orbitron:wght@500&family=Pacifico&family=Rowdies:wght@300&display=swap" rel="stylesheet">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="form_container">
        <p class="title">REGISTER</p>
 
 
  <div class="input_container">
    <label class="input_label" for="email_field">Username</label>
   <div class="input">
       <span><i class='bx bx-user'></i></span>
       <asp:TextBox ID="txtName" runat="server" CssClass="txtInput" placeholder="Username" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
   </div>
   <div>
        <asp:Label ID="errName" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
  </div>

   <div class="input_container">
    <label class="input_label" for="email_field">Email</label>
   <div class="input">
       <span><i class='bx bx-envelope' ></i></span>
       <asp:TextBox ID="txtEmail" runat="server" CssClass="txtInput" placeholder="Email" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
   </div>
    <div>
        <asp:Label ID="errEmail" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
  </div>

    <div class="input_container">
         <label class="input_label" for="email_field">Gender</label>

        <div class="gender-container">
            <asp:RadioButtonList ID="rblGender" runat="server" CssClass="rblGender">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="errGender" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="input_container">
        <label class="input_label" for="email_field">Address</label>
       <div class="input">
           <span><i class='bx bx-map'></i></span>
           <asp:TextBox ID="txtAddress" runat="server" CssClass="txtInput" placeholder="Address" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
       </div>
         <div>
            <asp:Label ID="errAddress" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
     </div>

  <div class="input_container">
    <label class="input_label" for="email_field">Password</label>
   <div class="input">
       <span><i class='bx bxs-lock'></i></span>
       <asp:TextBox ID="txtPassword" runat="server" CssClass="txtInput" placeholder="Password" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
   </div>
      <div>
        <asp:Label ID="errPassword" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
  </div>

  
   <br />

    <div>
        <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>

  <div title="Sign In" type="submit" class="sign-in_btn">
      <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" cssClass="btnSaveChanges"/>
  </div>

  
    <p class="note">Terms of use &amp; Conditions</p>
    </div>
</div>
</asp:Content>
