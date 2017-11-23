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
                            <select>
                              <option>Nhân viên 1</option>
                              <option>Nhân viên 2</option>
                              <option>Nhân viên 3</option>
                            </select>
                          </td>
                          <td>
                            <select>
                              <option>Bán hàng</option>
                              <option>Nhập hàng</option>
                            </select>
                          </td>

                          <td>
                            <select>
                              <option>Loại hoa 1</option>
                              <option>Loại hoa 2</option>
                              <option>Loại hoa 3</option>
                            </select>
                          </td>
                          <td>
                            <select>
                              <option>Hoa 1</option>
                              <option>Hoa 2</option>
                              <option>Hoa 3</option>
                            </select>
                          </td>
                          <td><input type="text" name="quatity" placeholder="Số lượng"></td>
                          
                          <td>2011/07/25</td>
                          <td>$170,750</td>
                        </tr>
                    </table>
                    <button class="pull-right">Nhập Hóa Đơn</button>
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
