<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="DetailFlower.aspx.cs" Inherits="Web.UI.DetailFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div class="right_col" role="main">
      <div class="">
         <div class="page-title">
            <div class="title_left">
                <h3 id="txtTitle">Detail</h3> 
            </div>
         </div>
         <div class="clearfix"></div>
         <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <br />
               <form data-parsley-validate class="form-horizontal form-label-left" runat="server">
                  
                   <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Image: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                         <asp:Image ID="image" runat="server" width="100%"/>
                     </div>
                  </div>
                   <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Name: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12" style="margin-top:8px;">
                         <asp:Label ID="lblName" runat="server" ></asp:Label>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Type: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12" style="margin-top:8px;">
                         <asp:Label ID="lblType" runat="server" ></asp:Label>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Price: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12"  style="margin-top:8px;">
                         <asp:Label ID="lblPrice" runat="server" ></asp:Label>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Quantities: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12"  style="margin-top:8px;">
                         <asp:Label ID="lblQuantity" runat="server" ></asp:Label>
                     </div>
                  </div>
                  
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12" >Description: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12"  style="margin-top:8px;">
                         <asp:Label ID="lblDescription" runat="server" ></asp:Label>
                     </div>
                  </div>
                  <div class="ln_solid"></div>
                  <div class="form-group">
                     <div class="col-md-6 col-sm-6 col-xs-12" style="float:right">                        
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-success" OnClick="btnBack_Click" />
                     </div>
                  </div>
               </form>
            </div>
         </div>
      </div>
   </div>
    
</asp:Content>
