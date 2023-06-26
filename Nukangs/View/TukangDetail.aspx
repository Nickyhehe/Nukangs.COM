<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TukangDetail.aspx.cs" Inherits="Nukangs.View.TukangDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/TukangDetail.css" rel="stylesheet" />
    <link rel="stylesheet"
  href="https://unpkg.com/boxicons@latest/css/boxicons.min.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Open+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;0,800;1,300;1,700;1,800&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Lobster&family=Open+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;0,800;1,300;1,700;1,800&family=Orbitron:wght@500&family=Pacifico&family=Rowdies:wght@300&display=swap" rel="stylesheet">
    <style>
    *, html, .container {
        padding: 0;
        margin: 0;
        box-sizing: border-box;
        list-style: none;
        text-decoration: none;
        font-family: 'Open Sans', sans-serif;
    }

    :root {
        --yellow-primary: #FFBF00;
        --white-primary: #FFFFFF;
        --black-primary: #000000;
        --blue-primary: #115DFC;
        --grey-primary: #8B8E98;
        --white-secondary: #F8F8FF;
        --black-secondary: #454545;
    }

  

    .image-container{
        border: 2px solid green;
        width: 300px;
        height: 300px;
        margin-right: 20px;
    }
    .image-container img{
        width: 100%;
        height: 100%;
    }

    .main-container{
        display: flex;
        padding-bottom: 20px;
        border-bottom: 1px solid var(--grey-primary);
    }
    .main-description-container{
      
        border-radius: 4px;
        padding: 16px;
        align-content: center;
        align-items: center;
        justify-content: space-between;
        margin-bottom: 20px;
        
    }

    .input-hour-container{
        
        margin-bottom: 40px;
        
    }

    .lblName{
        font-size: 24px;
        font-weight: bold;
    }

    .main-description-container ul{
       list-style: none;
        padding: 0;
        margin: 0;
        display: flex;
        align-items: center;
    }
    .main-description-container ul li{
        color: var(--yellow-primary);
         margin-right: 5px;
    }
    .btnAddToCart{
        border: none;
        outline: none;
        width: 100%;
        padding: 15px 20px;
        background-color: var(--yellow-primary);
        font-family: 'Bebas Neue', sans-serif;
        letter-spacing: 2px;
        font-size: 20px;
        cursor: pointer;
        box-shadow: 5px 12px 5px -8px rgba(0,0,0,0.35);
        -webkit-box-shadow: 5px 12px 5px -8px rgba(0,0,0,0.35);
        -moz-box-shadow: 5px 12px 5px -8px rgba(0,0,0,0.35);
        border-radius: 8px;
    }
     .main-description-container .main-desc .lblName {
        font-size: 18px;
        font-weight: bold;
        margin-bottom: 8px;
      }
       .main-description-container .main-desc .lblCost {
        font-size: 24px;
        font-weight: bold;
        color: #f5b301;
      }

         .input-hour-container {
            display: flex;
            align-items: center;
          
          }

          .input-hour-container .lblInpuHours {
            margin-right: 8px;
            font-weight: bold;
         
            
          }

  .input-hour-container .workHours {
    display: flex;
    align-items: center;
    margin-right: 8px;
  }

  .input-hour-container .workHours .btn {
    padding: 4px;
    border: none;
    background-color: #f5b301;
    color: #fff;
    font-weight: bold;
    cursor: pointer;
  }

  .input-hour-container .workHours .lblHours {
    margin: 0 8px;
    font-weight: bold;
  }

  .btnAddToCart {
    padding: 8px 16px;
    background-color: #f5b301;
    color: #fff;
    font-weight: bold;
    border: none;
    cursor: pointer;
  }
    .btn{
        width: 35px;
        height: 35px;
        border: none;
        outline: none;
        color: var(--black-primary);
        font-size: 24px;
    }
    .minus{
       margin-right: 15px;
    }
    .plus{
        margin-left: 15px;
    }
    .lblHours{
        margin-right: 15px;
    }

    .lblInpuHours{
        font-family: 'Open Sans', sans-serif;
    }

    .workHours{
        border: 1px solid var(--grey-primary);
        margin-top: 10px;
        display: flex;
        align-items: center;
        width: 130px;
        justify-content: space-between;
        border-radius: 5px;
        overflow: hidden;
        box-shadow: 5px 12px 5px -8px rgba(0,0,0,0.35);
        -webkit-box-shadow: 5px 12px 5px -8px rgba(0,0,0,0.35);
        -moz-box-shadow: 5px 12px 5px -8px rgba(0,0,0,0.35);
    }
    /*secondary container*/
    

    .secondary-container{
        padding: 30px 0;
        color: var(--grey-primary);
        font-family: 'Open Sans', sans-serif;
        /*border-bottom: 1px solid var(--grey-primary);*/

    }
    .status{
        margin-top: 10px;
    }
    .review-container{
        /*background-color: red;*/
        padding: 30px 0;
        color: var(--grey-primary);
    }



    .review-title{
        display: flex;
        /*background-color: red;*/
        padding: 20px;
        width: 100%;
    }

    

    .review-title h4{
        color: #565051;
        margin-right: 10px;
    }

    .review-content{
        display: flex;
        align-items: center;
        
    }

    .review-content h2{
        color: #413839;
    }

    .review-content ul{
        display: flex;
    }

    .review-content ul li:nth-child(1),
    .review-content ul li:nth-child(2),
    .review-content ul li:nth-child(3),
    .review-content ul li:nth-child(4){
        color: var(--yellow-primary);
    }

   

    .review-content span{
        display: flex;
        align-items: center;
        padding: 5px;
    }

    .review-content span{
        font-size: 12px;
    }
    .review-content span i{
        font-size: 16px;
    }

     .graph {
        background-color: rgba(144, 238, 144, 0.7);
        border-radius: 12px;
    }

    .review-content h2{
        margin-right: 10px;
    }

   
    
    

    .review{
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        width: 100%;
        padding: 0 0 0 15px;
        border-right: 1px solid var(--grey-primary);
    }

    .review-container .review:nth-child(3){
        border: none;
    }

    .line-content{

        display: flex;
        align-items: center;
    }
    .line-content span i{
        font-size: 12px;
    }

    .line-content .line{
        height: 8px;
        border-radius: 12px;
        margin: 4px 6px;
    }
    .line-content:nth-child(1) .line{
        width: 100px;
        background: #3EA99F;
    }
    .line-content:nth-child(2) .line{
        width: 80px;
        background: #E238EC;
    }
    .line-content:nth-child(3) .line{
        width: 60px;
        background: #FFA500;
    }
    .line-content:nth-child(4) .line{
        width: 40px;
        background: #1E90FF;
    }
    .line-content:nth-child(5) .line{
        width: 20px;
        background: red;
    }

    .review-customer{
        padding: 20px;
    }

    .review-customer-container{
        display: flex;
        border-bottom: 1px solid var(--grey-primary);
        padding: 40px 0;
    }
    .review-customer-container:nth-child(3){
        border: none;
    }

    .profil-container{
        display: flex;
        width: 25%;
    }

    .profil-container .profil-image{
        width: 100px;
        height: 100px;
        margin-right: 7px;
        border-bottom: 3px solid red;
    }

    .profil-container .profil-image img{
        width: 100%;
        height: 100%;
    }

    .review-customer-content{
        width: 75%;
    }

    .review-customer-content p{
        margin-bottom: 24px;
    }

    .review-star{
        display: flex;
        margin-bottom: 16px;
    }
    

  
    .review-customer-content .review-star ul{
        display: flex;
        /*background: blue;*/
        color: var(--yellow-primary);
    }

     .review-customer-content .review-star ul li{
        margin-right: 10px;

    }

    .profil-desc{
        height: 100px;
        display: flex;
        /*background: blue;*/
        flex-direction: column;
        justify-content: space-between;
    }

    .profil-desc h2{
        font-size: 14px;
    }

    .profil-desc p{
        font-size: 12px;
    }

    .profil-desc h2{
        color: #565051;
    }
    
    .like-container{
        display: flex;
        align-items: center;
        
    }

    .like-container span{
        margin-right: 22px;
        display: flex;
        align-items: center;
    }

    .like-container span i{
        font-size: 24px;
    }

    .part-title{
        width: fit-content;
        display: flex;
        flex-direction: column;
        color: var(--black-secondary);
        font-size: 24px;
        margin-bottom: 36px;
    }


     .part-title .line {
      background: var(--yellow-primary);
      width: 50%;
      margin-left: 15px;
      height: 5px;
      box-shadow: 10px 10px 5px -4px rgba(0,0,0,0.35);
        -webkit-box-shadow: 10px 10px 5px -4px rgba(0,0,0,0.35);
        -moz-box-shadow: 10px 10px 5px -4px rgba(0,0,0,0.35);
    }

     @media (max-width: 1300px) {
        .profil-container {
            flex-direction: column;
            /*background-color: red;*/
        }
        
        .profil-container .profil-image{
            width: 120px;
            height: 120px;
            border-bottom: 3px solid white;
        }
        .profil-desc h2{
            font-size: 14px;
        }
        .profil-desc p{
            font-size: 12px;
        }
    }

     .main-desc .status {
      font-size: 10px;
      color: #888;
      border-radius: 5px;
      text-align: center;
      padding: 6px;
      margin-left: 7px;
    }

    .status.Booked {
      background-color: red;
      color : white;
    }

    .status.Ready {
      background-color: green;
      color: white;
    }

    </style>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
    <div class="main-container">
        <div class="image-container">
            <img alt="" src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZmlsZXxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=500&q=60" runat="server" id="imgAlbum" />
         </div>
        <div class="main-description-container">

            <div>
             <ul>
                    <% for (int i = 0; i < Math.Floor(rating); i++) { %>
                        <li><span><i class='bx bxs-star'></i></span></li>
                    <% } %>

                    <% if (rating - Math.Floor(rating)  > 0) { %>
                        <li><span><i class='bx bxs-star-half'></i></span></li>

                    <% } %>

                    <% for (int i = 0; i < remainingStars; i++) { %>
                        <li><span><i class='bx bx-star'></i></span></li>
                    <% } %>
                 <asp:Label ID="lblrating" Text="" runat="server" />
                </ul>
               

                <div class="main-desc">
                    <asp:Label ID="lblName" runat="server" Text="" CssClass="lblName"></asp:Label>
                    
                    <asp:Label ID="lblstatus2" runat="server" Text="" CssClass=""></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblCost" runat="server" Text="" CssClass="lblCost"></asp:Label>
                </div>
            </div>
            
            
            <div id="divhours" class="input-hour-container" runat="server">
                <asp:Label ID="lblInpHours" runat="server" Text="Work Hours : " CssClass="lblInpuHours"></asp:Label>
                <div class="workHours">
                    <asp:Button ID="btnMinus" runat="server" Text="-" CssClass="btn minus" OnClick="btnMinus_Click"/>
                    <asp:Label ID="lblHours" runat="server" Text="0" CssClass="lblHours"></asp:Label>
                    <asp:Button ID="btnPlus" runat="server" Text="+" CssClass="btn plus" OnClick="btnPlus_Click"/>
                </div>
                
            </div>
             <div style="display: flex; gap: 10px">
             <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" CssClass="btnAddToCart" />
             <asp:Button ID="btnContactNow" runat="server" Text="Contact Now" OnClick="btnContactNow_Click" CssClass="btnAddToCart"/>
             </div>
        </div>
        <div>
            <asp:Label ID="errmsg" Text="" runat="server" />
        </div>
        </div>

        <div class="secondary-container">
            <div class="part-title">
                <h3>About this Tukang</h3>
                <div class="line"></div>
            </div>
            <div class="status">
                <asp:Label ID="lblumur" runat="server" Text=""></asp:Label>
            </div >
            <div class="status">
                <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>
            </div>
            <div class="status">
                <asp:Label ID="Lbltelp" runat="server" Text=""></asp:Label>
            </div>
           <div class="status">
               <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>
           </div>
            <div class="status">
                <p>
                    Description : Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting
                </p>
            </div>
            
        </div>

        <div class="review-container">
            <div class="part-title">
                <h3>Review Customer</h3>
                 <div class="line"></div>
            </div>
            <div class="review-title">
                <div class="total-review review">
                    <h4>Total Review</h4>
                    <div class="review-content">
                        <h2>10.0 K</h2>
                        <span class="graph">21% <i class='bx bx-line-chart'></i></span>
                    </div>
                    <p>Growth on review this year</p>
                </div>
                <div class="average-rating review">
                    <h4>Average Rating</h4>
                    <div class="review-content">
                        <h2>4.0</h2>
                        <ul>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                        </ul>
                        
                    </div>
                    <p>Average rating on this year</p>
                </div>

                <div class="line-graphic review">
                    <div class="line-container">
                        <div class="line-content">
                            <span><i class='bx bxs-star' ></i></span>
                            <div class="line"></div>
                            <span>5</span>
                        </div>
                        <div class="line-content">
                            <span><i class='bx bxs-star' ></i></span>
                            <div class="line"></div>
                            <span>4</span>
                        </div>
                        <div class="line-content">
                            <span><i class='bx bxs-star' ></i></span>
                            <div class="line"></div>
                            <span>3</span>
                        </div>
                        <div class="line-content">
                            <span><i class='bx bxs-star' ></i></span>
                            <div class="line"></div>
                            <span>2</span>
                        </div>
                        <div class="line-content">
                            <span><i class='bx bxs-star' ></i></span>
                            <div class="line"></div>
                            <span>1</span>
                        </div>
                    </div>
                </div>
                
            </div>

            <div class="review-customer">
                <div class="review-customer-container">
                    <div class="profil-container">
                    <div class="profil-image">
                        <img alt="" src="https://images.unsplash.com/photo-1534528741775-53994a69daeb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cGVvcGxlfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60" />
                    </div>
                    <div class="profil-desc">
                        <h2>Gerald Pique</h2>
                        <p>Total Spend : Rp. 200.000</p>
                        <p>Total Review : 15 Reviews</p>
                    </div>
                </div>
                <div class="review-customer-content">
                    <div class="review-star">
                        <ul>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                        </ul>
                        <p>24 - 11 - 2003</p>
                    </div>
                    <p>
                        It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                    </p>
                    <div class="like-container">
                        <span><i class='bx bxs-like' ></i>34</span>
                        <span><i class='bx bxs-dislike' ></i>12</span>
                    </div>
                </div>
                </div>
                 <div class="review-customer-container">
                    <div class="profil-container">
                    <div class="profil-image">
                        <img alt="" src="https://images.unsplash.com/photo-1534528741775-53994a69daeb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cGVvcGxlfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60" />
                    </div>
                    <div class="profil-desc">
                        <h2>Gerald Pique</h2>
                        <p>Total Spend : Rp. 200.000</p>
                        <p>Total Review : 15 Reviews</p>
                    </div>
                </div>
                <div class="review-customer-content">
                    <div class="review-star">
                        <ul>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                        </ul>
                        <p>24 - 11 - 2003</p>
                    </div>
                    <p>
                        It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                    </p>
                    <div class="like-container">
                        <span><i class='bx bxs-like' ></i>34</span>
                        <span><i class='bx bxs-dislike' ></i>12</span>
                    </div>
                </div>
                </div>
                 <div class="review-customer-container">
                    <div class="profil-container">
                    <div class="profil-image">
                        <img alt="" src="https://images.unsplash.com/photo-1534528741775-53994a69daeb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cGVvcGxlfGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60" />
                    </div>
                    <div class="profil-desc">
                        <h2>Gerald Pique</h2>
                        <p>Total Spend : Rp. 200.000</p>
                        <p>Total Review : 15 Reviews</p>
                    </div>
                </div>
                <div class="review-customer-content">
                    <div class="review-star">
                        <ul>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                            <li><span><i class='bx bxs-star' ></i></span></li>
                        </ul>
                        <p>24 - 11 - 2003</p>
                    </div>
                    <p>
                        It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
                    </p>
                    <div class="like-container">
                        <span><i class='bx bxs-like' ></i>34</span>
                        <span><i class='bx bxs-dislike' ></i>12</span>
                    </div>
                </div>
                </div>
                
            </div>
        </div>
    </div>

</asp:Content>
