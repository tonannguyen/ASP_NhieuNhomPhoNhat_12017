<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="WriteBill.aspx.cs" Inherits="Web.UI.WriteBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Write Bill</h3>
              </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                      <form id="Form1" runat="server">
                    <table id="write" class="table table-striped table-bordered">
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
                          </td>
                          <td>
                            <select>
                              <option value="0">Sale</option>
                              <option value="1">Buy</option>
                            </select>
                          </td>

                          <td>
                              <asp:DropDownList ID="typeList" runat="server" OnSelectedIndexChanged ="typeList_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                          </td>
                          <td>
                              <asp:DropDownList ID="flowerList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="flowerList_SelectedIndexChanged" ></asp:DropDownList>
                          </td>
                          <td>
                              <asp:TextBox ID="quantity" runat="server" AutoPostBack="true" OnTextChanged="quantity_TextChanged"></asp:TextBox>
                          <td>
                             <p id ="price" runat="server"></p>
                          </td>
                          <td>
                            <p id ="totalPrice" runat="server"></p>
                          </td>
                        </tr>
                    </table>
                    <asp:Button ID="writebill" class="pull-right" runat="server" Text="Write Bill" OnClick="writeBill"/>
                         
                  </div>
                </div>
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
					                      <table id="saveBill" class="table table-striped table-bordered">
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
							  <asp:Label ID="staff" runat="server" Text=""></asp:Label>
                          </td>
                          <td>
							  <asp:Label ID="transaction" runat="server" Text=""></asp:Label>
                          </td>

                          <td>
                              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                          <td>
                             <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                          </td>
                          <td>
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                          </td>
                        </tr>
                    </table>
					  <asp:Button ID="saveBill" class="pull-right" runat="server" Text="Save Bill" />
                  </div>
                </div>
              </div>
				 </form>
              <div class="clearfix"></div>
          </div>
        </div>
</asp:Content>
