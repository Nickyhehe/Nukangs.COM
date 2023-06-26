<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" EnableEventValidation="false" AutoEventWireup="true"  CodeBehind="CartPage.aspx.cs" Inherits="Nukangs.View.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    
    <style>
        .table td {
          text-align: center;
        }

        .table {
          max-width: 90%;
          margin: 0 auto;
        }

        .table thead th {
          background-color: gold;
          color: white;
        }

        .checkout-btns {
          margin-right:5%;
          align-items: center;
          color: gold;
        }

        .checkout-btns .btn {
          margin-top: 10px;
          
        }

        .total-price {
          display: flex;
          justify-content: flex-end;
          margin-top: 20px;
          margin-right:5%;
        }

        .lblerr{
   
          margin-top: 20px;
          margin-left:5%;
          color: red;
        }

        .card-header h2{
            text-align: center;
            color: gold;
            
        }
        

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card-header">
        <br />
        <h2>Shopping Cart</h2>
    </div>

    <hr />
    <br />
    <br />
 
    <div class="card-body">
        <div class="table-responsive">
            <table class="table table-bordered mx-auto">
                <thead>
                    <tr style="text-align:center;">
                        <th class="text-center py-3 px-4" >Product Name &amp; Details</th>
                        <th class="text-right py-3 px-4" >Price</th>
                        <th class="text-center py-3 px-4" >Hours</th>
                        <th class="text-right py-3 px-4" >Total</th>
                        <th class="text-center align-middle py-3 px-0" ><a href="#" class="shop-tooltip float-none text-light" title="" data-original-title="Clear cart"><i class="ino ion-md-trash"></i></a></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater id="rptCarts" runat="server" onitemcommand="rptCarts_ItemCommand1">
                        <ItemTemplate>
                            <tr>
                                <td class="p-4">
                                    <div class="media align-items-center">
                                        <img class="d-block ui-w-40 ui-bordered mr-4" alt="" src='<%# getTukangImageFromID(Convert.ToInt32(Eval("TukangID"))) %>' style="width: 200px; height: 200px" />
                                        <div class="media-body">
                                            <asp:label id="lblName" class="d-block text-dark" runat="server" text='<%# getTukangNameFromID(Convert.ToInt32(Eval("TukangID"))) %>'></asp:label>
                                            <small>
                                                <asp:label id="Lblstatus" class="text-muted" runat="server" text='<%# "Tukang status : " +   getStatusFromID(Convert.ToInt32(Eval("TukangID"))) %>' ></asp:label>
                                            </small>
                                        </div>
                                    </div>
                                </td>
                                <td class="align-middle p-4">
                                    <asp:label id="lblPrice" runat="server" text='<%# "Rp" + Convert.ToInt32(getTukangPriceFromID(Convert.ToInt32(Eval("TukangID")))).ToString("N", new System.Globalization.CultureInfo("id-ID")) %>'></asp:label>
                                </td>
                                <td class="align-middle p-4">
                                    <asp:label id="lblqty" runat="server" text='<%# Eval("hours") %>'></asp:label>
                                </td>
                                <td class="text-right font-weight-semibold align-middle p-4">
                                    <asp:label id="lblttl" runat="server" text='<%# "Rp"  + calculatesubtotal(Convert.ToInt32(Eval("hours")), Convert.ToInt32(getTukangPriceFromID(Convert.ToInt32(Eval("TukangID"))))) %>'></asp:label>
                                </td>
                                <td class="text-center align-middle px-0">
                                    <asp:button ID="btnRemove" runat="server" Text="X" CommandName="Remove" CommandArgument='<%# Eval("TukangID") %>' OnCommand="btnRemove_Command" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="total-price">
            <div class="text-right mt-4">
                <label class="text-muted font-weight-normal m-0">Total price</label>
                <div class="text-large">
                    <strong>
                        <asp:Label ID="lblttlall" runat="server" Text=""></asp:Label>
                    </strong>
                </div>
            </div>
        </div>

        <div class="float-right checkout-btns">
            <asp:Button ID="Button1" type="button" class="btn btn-lg btn-default md-btn-flat" runat="server" Text="Back to Main Menu" OnClick="Button1_Click" />
            <asp:Button ID="Button2" type="button" class="btn btn-lg btn-primary" runat="server" Text="Check Out" OnClick="btnCheckOut_Click" />
        </div>  
    </div>

    

    <div>
        <asp:Label ID="lblError" runat="server" Text="" CssClass="lblerr"></asp:Label>
    </div>
</asp:Content>
