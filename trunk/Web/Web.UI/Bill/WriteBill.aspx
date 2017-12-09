<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="WriteBill.aspx.cs" Inherits="Web.UI.WriteBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
   <div class="right_col" role="main">
      <div class="page-title">
         <div class="title_left">
            <h3>Write Bill</h3>
         </div>
      </div>
      <div class="clearfix"></div>
      <form id="Form1" runat="server">
         <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="x_panel">
                  <div class="x_content">
                     <table id="tble_write" class="table table-striped table-bordered">
                        <thead>
                           <tr>
                              <th>Staff Name</th>
                              <th>Transaction Type</th>
                              <th>Flower Type</th>
                              <th>Flower Name</th>
                              <th>Quantity</th>
                              <th>Price</th>
                              <th>Total Price</th>
                           </tr>
                        </thead>
                        <tr>
                           <td>
                              <asp:DropDownList ID="staffList" runat="server"></asp:DropDownList>
                              <asp:HiddenField ID="billID_hint" runat="server" Value=""/>
                              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                           </td>
                           <td>
                              <asp:DropDownList ID="transaction_type" runat="server">
                                 <asp:ListItem Value="0">
                                    Buy
                                 </asp:ListItem>
                                 <asp:ListItem Value="1">
                                    Sale
                                 </asp:ListItem>
                              </asp:DropDownList>
                           </td>
                           <td>
                              <asp:DropDownList ID="typeList" runat="server" OnSelectedIndexChanged ="typeList_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                           </td>
                           <td>
                              <asp:DropDownList ID="flowerList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="flowerList_SelectedIndexChanged" ></asp:DropDownList>
                           </td>
                           <td>
                              <asp:TextBox ID="quantity" runat="server" AutoPostBack="true" OnTextChanged="quantity_TextChanged"></asp:TextBox>
                           </td>
                           <td>
                              <p id ="price" runat="server"></p>
                           </td>
                           <td>
                              <p id ="totalPrice" runat="server"></p>
                           </td>
                        </tr>
                     </table>
                  </div>
               </div>
               <asp:Button ID="btn_writeBill" class="pull-right" runat="server" Text="Write Bill" OnClick="writeBill"/>
            </div>
         </div>
         <div class="clearfix"></div>
         <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <div class="x_panel">
                  <div class="x_title">
                     <h2>Bill</h2>
                     <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                           <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                           <ul class="dropdown-menu" role="menu">
                              <li><a href="#">Settings 1</a>
                              </li>
                              <li><a href="#">Settings 2</a>
                              </li>
                           </ul>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                     </ul>
                     <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                     <div class ="col-md-4">
                        <asp:Table ID="tb_unchange" runat="server" class="table table-striped table-bordered">
                           <asp:TableHeaderRow>
                              <asp:TableHeaderCell Text="Staff Name"></asp:TableHeaderCell>
                              <asp:TableHeaderCell Text="Transaction Type"></asp:TableHeaderCell>
                           </asp:TableHeaderRow>
                           <asp:TableRow>
                              <asp:TableCell id="lb_staff"></asp:TableCell>
                              <asp:TableCell id="lb_transaction"></asp:TableCell>
                           </asp:TableRow>
                        </asp:Table>
                     </div>
                     <div class="col-md-8">
                        <asp:GridView ID="gv_change" runat="server" class="table table-striped table-bordered"></asp:GridView>
                        <asp:Table ID="tb_change" runat="server" class="table table-striped table-bordered">
                           <asp:TableHeaderRow>
                              <asp:TableHeaderCell Text="Flower Type"></asp:TableHeaderCell>
                              <asp:TableHeaderCell Text="Flower Name"></asp:TableHeaderCell>
                              <asp:TableHeaderCell Text="Quantity"></asp:TableHeaderCell>
                              <asp:TableHeaderCell Text="Price"></asp:TableHeaderCell>
                              <asp:TableHeaderCell Text="Total Price"></asp:TableHeaderCell>
                           </asp:TableHeaderRow>
                           <asp:TableRow>
                              <asp:TableCell id="lb_fl_Type"></asp:TableCell>
                              <asp:TableCell id="lb_fl_Name"></asp:TableCell>
                              <asp:TableCell id="lb_quantity"></asp:TableCell>
                              <asp:TableCell id="lb_Price"></asp:TableCell>
                              <asp:TableCell id="lb_TotalPrice"></asp:TableCell>
                           </asp:TableRow>
                        </asp:Table>
                     </div>
                  </div>
               </div>
               <asp:Button ID="saveBill" class="pull-right" runat="server" Text="Save Bill" />
            </div>
         </div>
      </form>
      <div class="clearfix"></div>
   </div>
</asp:Content>