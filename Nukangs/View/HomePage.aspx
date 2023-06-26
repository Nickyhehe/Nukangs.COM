<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Nukangs.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/HomePageStyle.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="full-image"> 
        <div class="content-wrap">
            <asp:Label Text="Efficient Solutions for Home Improvement and Repairs" runat="server" CssClass="test-lbl"/>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button Text="Explore Our Services" runat="server" CssClass="explore-btn" OnClientClick="scrollToContainer()"/>
        </div>
    </div>

    <br />
    <br />
    <br />

    <div id="textaja">
    <asp:Label ID="Label1" runat="server" Text="Services we provide" CssClass="lblser" ></asp:Label>
    </div>
  
    <br />
        <div class="insert-btn">
            <asp:Button ID="btnInsert" runat="server" Text="Insert New Tukang Tole" OnClick="btnInsert_Click" CssClass="insert-btns"/>
        </div>

    <br />
    <br />
    <br />

    <div id="kat-con" class="kategori-container" >
      
        <asp:Repeater ID="rptArtists" runat="server" OnItemCommand="rptArtists_ItemCommand">
       
            <ItemTemplate>
                <div class="kategori-item">
                    <div class="kategori-row">
                        <div class="kategori-column">
                            <img alt="" src=<%# Eval("role_img") %>  />
                        </div>
                        <br />
                        <div class="kategori-column"><%# Eval("nama_role") %> </div>
                        <br />
                        <dv class="kategori-column">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Eval("role_id") %>' OnCommand="btnUpdate_Command" CssClass="btn-style btn-update" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("role_id") %>' OnCommand="btnDelete_Command" CssClass="btn-style btn-delete"/>
                            <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("role_id") %>' OnCommand="btnView_Command" CssClass="btn-style btn-view"/>
                        </dv>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script>
        function scrollToContainer() {
            var container = document.getElementById('textaja'); 
            container.scrollIntoView({ behavior: 'smooth' });
        }

    </script>


</asp:Content>