<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.UI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <asp:Label ID="name" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    <div class="container">
    	<div class="section-heading">
        	<h2>Browse All Categories</h2>
        </div>
        
        <div class="row">
        	<div class="col-md-3">
            	<div class="item">
                	<h3><a href="#">Whirlpool LTE5243D 3.4</a></h3>
                    <div class="thumb">
                    	<img src="images/product-img1.jpg" alt="item1">
                    </div>
                    <div class="item-price">
                    	$839.93
                    </div>
                    <a href="#" class="btn-add">Add to cart</a>
                </div>
            </div>
            <div class="col-md-3">
            	<div class="item">
                	<h3><a href="#">Whirlpool LTE5243D 3.4</a></h3>
                    <div class="thumb">
                    	<img src="images/product-img1.jpg" alt="item1">
                    </div>
                    <div class="item-price">
                    	$839.93
                    </div>
                    <a href="#" class="btn-add">Add to cart</a>
                </div>
            </div>
            <div class="col-md-3">
            	<div class="item">
                	<h3><a href="#">Whirlpool LTE5243D 3.4</a></h3>
                    <div class="thumb">
                    	<img src="images/product-img1.jpg" alt="item1">
                    </div>
                    <div class="item-price">
                    	$839.93
                    </div>
                    <a href="#" class="btn-add">Add to cart</a>
                </div>
            </div>
            <div class="col-md-3">
            	<div class="item">
                	<h3><a href="#">Whirlpool LTE5243D 3.4</a></h3>
                    <div class="thumb">
                    	<img src="images/product-img1.jpg" alt="item1">
                    </div>
                    <div class="item-price">
                    	$839.93
                    </div>
                    <a href="#" class="btn-add">Add to cart</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
