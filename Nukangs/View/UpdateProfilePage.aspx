<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="Nukangs.View.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet"
  href="https://unpkg.com/boxicons@latest/css/boxicons.min.css" />
    <link href="../Style/UpdateProfilePage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <div class="form_container">
        
 
 
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

  <div title="Sign In" type="submit" class="sign-in_btn" style="width: 200px">
      <asp:Button ID="btnUpdate" runat="server" Text="Save Changes" OnClick="btnUpdate_Click" cssClass="btnSaveChanges" style="width: 100%"/>
  </div>

  
    <p class="note">Terms of use &amp; Conditions</p>
    </div>
</div>
</asp:Content>
