<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TukangPage.aspx.cs" Inherits="Nukangs.View.TukangPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>




.tukang-ini{
    display:flex;
    justify-content: space-evenly;
    align-items: stretch;
}

 .tukang-container {
  display: flex;
  flex-wrap: wrap;
}

 .hahaTuk{
    
     display:flex;
     flex-wrap: wrap;
    margin: 0 auto;
     width: 90%;
   
   
 }

.tukang-card {
  display: flex;
  flex-direction: column;
  width: 23%;
  margin: 10px;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 15px;
  height: 500px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);

}

.img-con{
    width:100%;
    height: 55%;
}

.tukang-card img {
  width: 100%;
  height: 100%;
  margin-bottom: 10px;
}

.tukang-card h4 {
  font-size: 17px;
  margin-bottom: 5px;
}

.tukang-card h3{
    font-size:22px;
}
.tukang-card p {
  margin-bottom: 5px;
}

.tukang-card .rating {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 5px;
}


.tukang-card .rating span {
  font-size: 16px;
  margin-right: 5px;
  
}

.tukang-card .rating .star {
  color: gold; 
}

.tukang-card .status {
  font-size: 10px;
  color: #888;
  border-radius: 5px;
  text-align: center;
  padding: 6px;
  margin-left: 7px;
}

.status.booked {
  background-color: red;
  color : white;
}

.status.ready {
  background-color: green;
  color: white;
}

.rateandstat{
    display:flex;
}

/*.tukang-card .status::before {
  content: '|';
  margin: 0 5px;
}*/

.btn-con{
    padding: 5px 10px;
    border: none;
    outline: none;
    display: block;
    margin: 0 auto;
    margin-top: 22px;
    border-radius: 6px;
    background: white;
    font-weight: 600;
}

.btn-update {
   
    color: gold;
    border: 1.5px solid gold;
}

.btn-delete {
    color: red;
    border: 1.5px solid red;
}

.btn-view {
    color: dodgerblue;
    border: 1.5px solid dodgerblue;
}

.btn-cons{
    display:flex;

  }

@media screen and (max-width: 940px) {
  .tukang-card {
    flex-direction: column;
    width: 40%;
  }

  .btn-cons {
    flex-direction: row;
    justify-content: space-between;
  }
}

.int-btn{
    text-align:center;
    
}

.int-btns{
    border:none;
    outline:none;
    padding:12px 16px;
    background: gold;
    border-radius: 8px;
    color: ghostwhite;
}

.banner{
    background-image: url(../Roles/electro.jpg);
    width: 100%;
    height: 515px;
    background-position: center;
    background-size: cover;
    filter: brightness(0.9);
     display: flex;
     align-items: center;
     padding: 0;
     margin-top:-10px;
     position: relative;
     top:-17px;
}
.banner h1{
    position:absolute;
    top: 48%;
    left:5%;
    font-weight: bold;
}

.banner .nama-role{
    text-align: center;
    margin-left: 20%;
    color: darkorange;

}

   

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
    <div class="banner">
        <h1 class="nama-role"><%= a.nama_role%></h1>
    </div>
       
              
        
   

    <hr />

    
    <br />

    <div class="list-tukang">

         <div class="int-btn">
            <asp:Button ID="btnInsert" runat="server" Text="Insert New Tukang Here" OnClick="btnInsert_Click" CssClass="int-btns"/>
        </div>
        <br />


        <div style="text-align:center; color:gold;">
            <h1><%= "List " +  a.nama_role%></h1>
        </div>
        <br />
        <br />
        <hr />

        <div style="text-align: center; margin-bottom: 20px;">
            <input type="text" id="searchInput" placeholder="Search by Tukang Name" style="width: 300px; padding: 8px; border-radius: 7px;">
            <button type="button" onclick="searchTransactions()" style="background-color: yellow; padding: 8px 16px; border: none; cursor: pointer; border-radius: 10px;">
                Search
            </button>
         </div>
        <hr />
        
        <div class="tukang-ini">
            <div class="hahaTuk">
                 <asp:Repeater ID="rptAlbums" runat="server" OnItemCommand="rptAlbums_ItemCommand">
                <ItemTemplate>
                    <div class="tukang-card">
                        <div class="img-con">
                            <img alt="" src='<%# Eval("foto_wajah") %>' />
                        </div>
                        
                        <h4><%# Eval("nama_tukang") %></h4>
                        <h3><%# "Rp" + Convert.ToDecimal(Eval("price")).ToString("N", new System.Globalization.CultureInfo("id-ID")) %></h3>
                        <p><%# Eval("address") %></p>

                        <div class="rateandstat">
                            <div class="rating">
                            <span class="star">&#9733;</span>
                            <span><%# Eval("rating")  %></span>
                        </div>
                            <p>|</p>
                        <p class="status <%# Eval("status").ToString().ToLower() %>">
                          <%# Eval("status") %>
                        </p>
                        </div>
                
                        <div class="btn-cons">
                             <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Eval("TukangID") %>' OnCommand="btnUpdate_Command" CssClass="btn-con btn-update"/>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("TukangID") %>' OnCommand="btnDelete_Command" CssClass="btn-con btn-delete"/>
                            <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("TukangID") %>' OnCommand="btnView_Command" CssClass="btn-con btn-view"/>
                        </div>
                          

              
                    </div>
                </ItemTemplate>
            </asp:Repeater>
             </div>
        </div>
   


    
   

 <script type="text/javascript">
    function searchTransactions() {
        var input = document.getElementById('searchInput').value.toLowerCase();
        var items = document.getElementsByClassName('tukang-card');

        for (var i = 0; i < items.length; i++) {
            var tukangName = items[i].getElementsByTagName('h4')[0].innerText.toLowerCase();

            if (tukangName.includes(input)) {
                items[i].style.display = '';
            } else {
                items[i].style.display = 'none';
            }
        }
    }
    </script>

</asp:Content>
