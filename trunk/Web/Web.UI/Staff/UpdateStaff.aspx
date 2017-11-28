<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="UpdateStaff.aspx.cs" Inherits="Web.UI.Staff.UpdateStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
   <!-- page content -->
   <div class="right_col" role="main">
      <div class="">
         <div class="page-title">
            <div class="title_left">
               <h3>Chỉnh sửa thông tin nhân viên</h3>
            </div>
         </div>
         <div class="clearfix"></div>
         <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="x_panel">
                  <div class="x_content">
                     <br />
                     <form  data-parsley-validate class="form-horizontal form-label-left" runat="server">
                        <div class="form-group">
                           <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Name: <span class="required">*</span>
                           </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:TextBox ID="txtName" runat="server" required="required" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                           </div>
                        </div>
                        <div class="form-group">
                           <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Password: <span class="required">*</span>
                           </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:TextBox ID="txtPass" runat="server" required="required" TextMode="Password" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                           </div>
                        </div>
                        <div class="form-group">
                           <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Confirm Password: <span class="required">*</span>
                           </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:TextBox ID="txtRePass" runat="server" required="required" TextMode="Password" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                           </div>
                        </div>
                        <div class="form-group">
                           <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Phone: <span class="required">*</span>
                           </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:TextBox ID="txtPhone" runat="server" required="required" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                           </div>
                        </div>
                        <div class="form-group">
                           <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Adress: <span class="required">*</span>
                           </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:TextBox ID="txtAdress" runat="server" required="required" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                           </div>
                        </div>
                        <div class="form-group">
                           <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">Avatar: </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:FileUpload ID="avatar" runat="server" CssClass="form-control col-md-7 col-xs-12"/>
                           </div>
                        </div>
                        <div class="form-group">
                           <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">Positon: <span class="required">*</span>
                           </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:DropDownList ID="PositionList" runat="server" CssClass="form-control col-md-7 col-xs-12">
                              </asp:DropDownList>
                           </div>
                        </div>
                        <div class="form-group">
                           <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Salary: <span class="required">*</span>
                           </label>
                           <div class="col-md-6 col-sm-6 col-xs-12">
                              <asp:TextBox ID="txtSalary" runat="server" required="required" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                           </div>
                        </div>
                        <div class="ln_solid"></div>
                        <div class="form-group">
                           <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                              <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary"/>
                              <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSaveClick" />
                           </div>
                        </div>
                     </form>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
   <!-- /page content -->
</asp:Content>