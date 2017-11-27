<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="UpdateFlower.aspx.cs" Inherits="Web.UI.UpdateFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
   <!-- page content -->
   <div class="right_col" role="main">
      <div class="">
         <div class="page-title">
            <div class="title_left">
               <!--  <h3 id="txtTitle">Chỉnh sửa thông tin hoa</h3> -->
            </div>
         </div>
         <div class="clearfix"></div>
         <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <br />
               <form data-parsley-validate class="form-horizontal form-label-left" runat="server">
                  <!-- List validation-->
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
                  <asp:RequiredFieldValidator ID="RequiredName" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter flower's name" ForeColor="Red" ValidateRequestMode="Disabled" Enabled="True" Display="None"></asp:RequiredFieldValidator>
                  <br />
                  <asp:RegularExpressionValidator Display = "None" ControlToValidate = "txtName" ID="RegularName" ValidationExpression = "^[\s\S]{0,100}$" runat="server" ForeColor="Red" ErrorMessage="Name has maximum 100 characters allowed."></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Please enter flower's price." ForeColor="Red" ValidateRequestMode="Disabled" Enabled="True" Display="None"></asp:RequiredFieldValidator>
                  <br />
                  <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="txtPrice" Display="None" ErrorMessage="Price much be number." />
                  <asp:RequiredFieldValidator ID="RequiredQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please enter flower's quantities." ForeColor="Red" ValidateRequestMode="Disabled" Enabled="True" Display="None"></asp:RequiredFieldValidator>
                  <br />
                  <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="txtQuantity" Display="None" ErrorMessage="Quantities much be number." />
                  <asp:RegularExpressionValidator Display = "None" ControlToValidate = "description" ID="RegularDescription" ValidationExpression = "^[\s\S]{0,1000}$" runat="server" ForeColor="Red" ErrorMessage="Description has maximum 1000 characters allowed."></asp:RegularExpressionValidator>
                  <br />
                   <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Name: <span class="required">*</span>
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtName" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12" >Type: <span class="required">*</span>
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="typeList" runat="server" CssClass="form-control col-md-7 col-xs-12">
                        </asp:DropDownList>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Price: <span class="required">*</span>
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtPrice" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12">Quantity: <span class="required">*</span>
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                        <asp:TextBox ID="txtQuantity" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                     </div>
                  </div>
                  <div class="form-group">
                     <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">Image: </label>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                        <asp:FileUpload ID="image" runat="server" CssClass="form-control col-md-7 col-xs-12"/>
                     </div>
                  </div>
                  <div class="form-group">
                     <label class="control-label col-md-3 col-sm-3 col-xs-12" >Description: <span class="required">*</span>
                     </label>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                        <textarea id="description" name="last-name" runat="server" class="form-control col-md-7 col-xs-12"></textarea>
                     </div>
                  </div>
                  <div class="ln_solid"></div>
                  <div class="form-group">
                     <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btnCancel_Click"/>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSaveClick" />
                     </div>
                  </div>
               </form>
            </div>
         </div>
      </div>
   </div>

   <!-- /page content -->
</asp:Content>