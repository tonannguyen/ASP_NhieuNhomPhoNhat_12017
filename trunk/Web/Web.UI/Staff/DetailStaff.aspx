<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="DetailStaff.aspx.cs" Inherits="Web.UI.Staff.DetailStaff" %>
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
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Phone:
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12" style="margin-top:8px;">
                         <asp:Label ID="lblPhone" runat="server" ></asp:Label>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Address: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12"  style="margin-top:8px;">
                         <asp:Label ID="lblAdress" runat="server" ></asp:Label>
                     </div>
                  </div>
                  
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12" >Position: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12"  style="margin-top:8px;">
                         <asp:Label ID="lblPositon" runat="server" ></asp:Label>
                     </div>
                  </div>

                   <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12" >Salary: 
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12"  style="margin-top:8px;">
                         <asp:Label ID="lblSalary" runat="server" ></asp:Label>
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
