<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="WriteBill.aspx.cs" Inherits="Web.UI.WriteBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Nhập hóa đơn bán hàng</h3>
              </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                      <form id="Form1" runat="server">
                    <table id="" class="table table-striped table-bordered">
                      <thead>
                        <tr>
                          <th>Họ tên nhân viên bán hàng</th>
                          <th>Thao tác</th>
                          <th>Loại hoa</th>
                          <th>Tên hoa</th>
                          <th>Số lượng</th>
                          <th>Đơn giá</th>
                          <th>Tổng tiền</th>
                        </tr>
                      </thead>
                        <tr>
                          <td>
                            <asp:DropDownList ID="staffList" runat="server"></asp:DropDownList>
                          </td>
                          <td>
                            <select>
                              <option value="0">Bán hàng</option>
                              <option value="1">Nhập hàng</option>
                            </select>
                          </td>

                          <td>
                              <asp:DropDownList ID="typeList" runat="server" OnSelectedIndexChanged ="typeList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          </td>
                          <td>
                              <asp:DropDownList ID="flowerList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="flowerList_SelectedIndexChanged"></asp:DropDownList>
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
                    <button class="pull-right">Nhập Hóa Đơn</button>
                          </form>
                  </div>
                </div>
              </div>
            </div>
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                    <h2>Hóa đơn</h2>
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

                    <table class="table">
                      <thead>
                        <tr>
                          <th>Họ tên nhân viên bán hàng</th>
                          <th>Thao tác</th>
                          <th>Loại hoa</th>
                          <th>Tên hoa</th>
                          <th>Số lượng</th>
                          <th>Đơn giá</th>
                          <th>Tổng tiền</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <th scope="row">1</th>
                          <td>Mark</td>
                          <td>Otto</td>
                          <td>@mdo</td>
                        </tr>
                        <tr>
                          <th scope="row">2</th>
                          <td>Jacob</td>
                          <td>Thornton</td>
                          <td>@fat</td>
                        </tr>
                        <tr>
                          <th scope="row">3</th>
                          <td>Larry</td>
                          <td>the Bird</td>
                          <td>@twitter</td>
                        </tr>
                      </tbody>
                      <thead>
                        <tr>
                          <th>#</th>
                          <th>Tổng số</th>
                          <th>1000000</th>
                          <th>100%</th>
                        </tr>
                      </thead>

                    </table>
                    <button class="pull-right">Lưu Hóa Đơn</button>
                  </div>
                </div>
              </div>

              <div class="clearfix"></div>
          </div>
        </div>
</asp:Content>
