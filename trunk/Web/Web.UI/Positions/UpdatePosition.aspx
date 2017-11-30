<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="UpdatePosition.aspx.cs" Inherits="Web.UI.Positons.UpdatePostion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="right_col" role="main">
      <div class="row">
         <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
               <div class="x_content">
                  <br />
                  <form  data-parsley-validate class="form-horizontal form-label-left" runat="server">
                     <asp:ValidationSummary ID="ValidationType" runat="server" CssClass="text-danger" />
                     <asp:RequiredFieldValidator ID="RequiredName" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter type's name" ForeColor="Red" ValidateRequestMode="Disabled" Enabled="True" Display="None"></asp:RequiredFieldValidator>
                     <br />
                     <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Name of Positions: <span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                           <asp:TextBox ID="txtName" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                        </div>
                     </div>
                     <div class="ln_solid"></div>
                     <div class="form-group">
                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                           <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary" />
                           <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSaveClick" />
                        </div>
                     </div>
                  </form>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
