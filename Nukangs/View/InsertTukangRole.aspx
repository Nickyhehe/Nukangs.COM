<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertTukangRole.aspx.cs" Inherits="Nukangs.View.InsertTukangRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/UpdateTukangRole.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="form_container">
        
    <div class="file-upload-container">
      
      <label for="fuImage" class="file-upload-label">
       <img alt="" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTr2TWLC89uQt3vWdCNxxESU3iK9Pj-acV5CA&usqp=CAU" id="imgArtist"/>

      
        <span class="upload-icon"><i class='bx bxs-camera-plus'></i></span>
      
          <asp:FileUpload runat="server" ID="fuArtistImage" CssClass="file-upload-input"/>
      </label>
        <div>
            <asp:Label ID="errArtistImage" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

 
  <div class="input_container">
    <label class="input_label" for="email_field">Tukang Role Name</label>
   <div class="input">
       <span><i class='bx bx-user'></i></span>
       <asp:TextBox ID="txtName" runat="server" CssClass="txtInput" placeholder="Tukang Role Name" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
   </div>
   <div>
        <asp:Label ID="errName" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
  </div>

   

    <div>
        <asp:Label ID="successUpload" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>

  <div title="Sign In" type="submit" class="sign-in_btn">
      <asp:Button ID="btnUpdate" runat="server" Text="Insert" OnClick="btnSubmit_Click" cssClass="btnSaveChanges"/>
  </div>

  
    <p class="note">Terms of use &amp; Conditions</p>
    </div>
</div>

    <script>
    function previewImage() {
        var fileUpload = document.getElementById("<%= fuArtistImage.ClientID %>");
    var img = document.getElementById("imgArtist");

    var reader = new FileReader();
    reader.onload = function (e) {
      img.src = e.target.result;
    };

    if (fileUpload.files.length > 0) {
        var fileName = fileUpload.files[0].name;
        img.src = "../Roles/" + fileName;
        }
        console.log(fileName);
  }

 
  document.getElementById("<%= fuArtistImage.ClientID %>").addEventListener("change", previewImage);
    </script>


</asp:Content>
