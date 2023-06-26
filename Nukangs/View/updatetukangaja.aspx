<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="updatetukangaja.aspx.cs" Inherits="Nukangs.View.updatetukangaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet"
  href="https://unpkg.com/boxicons@latest/css/boxicons.min.css" />
    <link href="../Style/UpdateTukangPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="form_container">
        
    <div class="file-upload-container">
      
      <label for="fuImage" class="file-upload-label">
       <img id="imgTukang" alt=""  src="<%= getAlbumimg() %>" />
      
        <span class="upload-icon"><i class='bx bxs-camera-plus'></i></span>
      
          <asp:FileUpload runat="server" ID="fuImageAlbum" CssClass="file-upload-input"/>
      </label>
        <div>
            <asp:Label ID="errImageTukang" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

 
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
    <label class="input_label" for="email_field">Password</label>
   <div class="input">
       <span><i class='bx bxs-lock'></i></span>
       <asp:TextBox ID="txtPassword" runat="server" CssClass="txtInput" placeholder="Password" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
   </div>
      <div>
        <asp:Label ID="errPassword" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
  </div>

    <div class="input_container">
        <label class="input_label" for="email_field">Address</label>
       <div class="input">
           <span><i class='bx bx-map'></i></span>
           <asp:TextBox ID="txtaddress" runat="server" CssClass="txtInput" placeholder="Address" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
       </div>
         <div>
            <asp:Label ID="erraddress" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
     </div>

  <div class="input_container">
    <label class="input_label" for="email_field">Umur</label>
   <div class="input">
       <span><i class='bx bxs-video-plus'></i></span>
       <asp:TextBox ID="Txtumur" runat="server" CssClass="txtInput" placeholder="Umur" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
   </div>
      <div>
        <asp:Label ID="errumur" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
  </div>

    <div class="input_container">
        <label class="input_label" for="email_field">Rating</label>
       <div class="input">
           <span><i class='bx bx-star' ></i></span>
           <asp:TextBox ID="Txtrating" runat="server" CssClass="txtInput" placeholder="1 - 5" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
       </div>
          <div>
            <asp:Label ID="errrating" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
      </div>

       <div class="input_container">
        <label class="input_label" for="email_field">Price</label>
       <div class="input">
           <span><i class='bx bx-money-withdraw' ></i></span>
           <asp:TextBox ID="Txtprice" runat="server" CssClass="txtInput" placeholder="Rp. " Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
       </div>
          <div>
            <asp:Label ID="errprice" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
      </div>

        <div class="input_container">
        <label class="input_label" for="email_field">Phone</label>
       <div class="input">
           <span><i class='bx bx-phone' ></i></span>
           <asp:TextBox ID="Txttelp" runat="server" CssClass="txtInput" placeholder="+08-XXX-XXX-XXX" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
       </div>
          <div>
            <asp:Label ID="errtelp" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
      </div>

        <div class="input_container">
        <label class="input_label" for="email_field">Status</label>
       <div class="input">
           <span><i class='bx bx-hard-hat' ></i></span>
           <asp:TextBox ID="Txtstatus" runat="server" CssClass="txtInput" placeholder="Booked | Ready" Title="Input title" name="input-name" TextMode="SingleLine"></asp:TextBox>
       </div>
          <div>
            <asp:Label ID="errstatus" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
      </div>

  
   <br />

   <div>
        <asp:Label ID="lblSuccessUpload" runat="server" Text=""></asp:Label>
    </div>

  <div title="Sign In" type="submit" class="sign-in_btn" style="width: fit-content; height: fit-content">
      <asp:Button ID="btnUpdate" runat="server" Text="Save Changes" OnClick="btnUpdateTukang_Click" cssClass="btnSaveChanges"/>
  </div>

  
    <p class="note">Terms of use &amp; Conditions</p>
    </div>
</div>

        <script>
            function previewImage() {
                var fileUpload = document.getElementById("<%= fuImageAlbum.ClientID %>");
    var img = document.getElementById("imgTukang");

    var reader = new FileReader();
    reader.onload = function (e) {
      img.src = e.target.result;
    };

    if (fileUpload.files.length > 0) {
        var fileName = fileUpload.files[0].name;
        img.src = "../Tukang/" + fileName;
        }
        console.log(fileName);
  }

 
  document.getElementById("<%= fuImageAlbum.ClientID %>").addEventListener("change", previewImage);
        </script>
</asp:Content>
