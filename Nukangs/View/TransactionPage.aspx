<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="Nukangs.View.TransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .transaction-list {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }

        .transaction-item {
            display: flex;
            align-items: center;
            padding: 10px;
            margin-bottom: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
            border-radius: 5px;
        }

        .transaction-item img {
            width: 60px;
            height: 60px;
            object-fit: cover;
            border-radius: 50%;
            margin-right: 20px;
        }

        .transaction-details {
            flex-grow: 1;
        }

        .transaction-details h3 {
            margin: 0;
            font-size: 16px;
            font-weight: bold;
        }

        .transaction-details .transaction-date {
            font-size: 14px;
            margin-bottom: 5px;
            border-bottom: 1px solid #ccc;
            padding-bottom: 5px;
        }

        .transaction-details p {
            margin: 5px 0;
        }

        .transaction-details .price {
            border-top: 1px solid #ccc;
            font-size: 16px;
            text-align: right;
        }

        .transaction-details .price strong {
            font-weight: bold;
        }

        .transaction-details .price::before {
            content: "";
            position: absolute;
            top: -5px;
            left: 0;
            width: 100%;
            height: 1px;
            background-color: #ccc;
        }

        /* Tambahkan CSS berikut */
        .transaction-border {
            border-radius: 5px;
            margin: 0 320px;
            margin-top: 30px;
        }

        /* Responsif */
        @media (max-width: 980px) {
            .transaction-border {
                margin: 0 20px;
            }
        }

        @media (max-width: 480px) {
            .transaction-border {
                margin: 0 10px;
            }
        }
        button:hover {
            background-color: lightyellow;
        }

    </style>

    <div style="text-align: center; margin-bottom: 20px;">
        <input type="text" id="searchInput" placeholder="Search by Tukang Name" style="width: 300px; padding: 8px; border-radius: 7px;">
        <button type="button" onclick="searchTransactions()" style="background-color: yellow; padding: 8px 16px; border: none; cursor: pointer; border-radius: 10px;">
            Search
        </button>
    </div>


    <asp:Repeater ID="rptTransactionHistory" runat="server">
        <HeaderTemplate>
            <ul class="transaction-list">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <div class="transaction-border">
                    <div class="transaction-item">
                        <img alt="" src="<%# Eval("TukangPicture") %>" />
                        <div class="transaction-details">
                            <h3>  INV/2023006/MPL/3295590<%#Eval("TransactionID") %></h3>
                            <p class="transaction-date">Date: <%# Eval("TransactionDate") %></p>
                            <p>Customer Name: <%# Eval("CustomerName") %></p>
                            <p>Payment : Online Banking</p>
                            <p>Tukang Name: <%# Eval("TukangName") %></p>
                            <p>Tukang Work Hours: <%# Eval("TukangHours") %></p>
                            <p>Tukang Price/Hours: <%# "Rp. " + Convert.ToDecimal(Eval("TukangPrice")).ToString("N", new System.Globalization.CultureInfo("id-ID")) %></p>
                            <p class="price">Total Payment: <strong><%# "Rp. " + Convert.ToDecimal(Eval("TotalPrice")).ToString("N", new System.Globalization.CultureInfo("id-ID")) %></strong></p>
                        </div>
                    </div>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

<script type="text/javascript">
    function searchTransactions() {
        var input = document.getElementById('searchInput').value.toLowerCase();
        var items = document.getElementsByClassName('transaction-item');

        for (var i = 0; i < items.length; i++) {
            var tukangName = items[i].getElementsByClassName('transaction-details')[0].getElementsByTagName('p')[3].innerText.toLowerCase();

            if (tukangName.includes(input)) {
                items[i].style.display = '';
            } else {
                items[i].style.display = 'none';
            }
        }
    }
</script>
</asp:Content>
