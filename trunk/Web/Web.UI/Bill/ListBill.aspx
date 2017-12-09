<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ListBill.aspx.cs" Inherits="Web.UI.ListBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
   <div class="right_col" role="main">
      <div class="page-title">
         <div class="title_left">
            <h3>List Bill</h3>
         </div>
      </div>
      <div class="clearfix"></div>
      <div class="row">
         <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
               <div class="x_content">
                  <form id="Form1" runat="server">
                     <asp:GridView ID="gv_Bills" runat="server" class="table table-striped table-bordered"></asp:GridView>
                  </form>
                  <div class="clearfix"></div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>