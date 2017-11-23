<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ListFlower.aspx.cs" Inherits="Web.UI.ListFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Danh sách loại hoa</h3>
              </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_content">
                    <table id="datatable" class="table table-striped table-bordered">
                      <thead>
                        <tr>
                          <th>Tên hoa</th>
                          <th>Loại</th>
                          <th>Đơn giá</th>
                          <th>Số lượng</th>
                          <th>Tình trạng</th>
                          <th>Tùy chọn</th>
                        </tr>
                      </thead>
                        <tr>
                          <td>Garrett Winters</td>
                          <td>Accountant</td>
                          <td>Tokyo</td>
                          <td>65</td>
                          <td>2011/07/25</td>
                          <td>$170,750</td>
                        </tr><tr>
                          <td>Garrett Winters</td>
                          <td>Accountant</td>
                          <td>Tokyo</td>
                          <td>63</td>
                          <td>2011/07/25</td>
                          <td>$170,750</td>
                        </tr>
                    </table>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
