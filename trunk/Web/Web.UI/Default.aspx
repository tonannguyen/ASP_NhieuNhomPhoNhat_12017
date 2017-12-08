<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.UI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <form id="form1" runat="server">

    <div class="right_col" role="main">
          <!-- top tiles -->
          <div class="row tile_count">
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu ngày </span>
              <div><asp:Label ID="lblDay" runat="server" Text="123"  style="font-size: 35px;margin-left: 20px;"></asp:Label></div>
              <span class="green" style="float: right;"> VNĐ</span>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu tuần trước</span>
              <div><asp:Label ID="lblLastWeek" runat="server" Text="123"   style="font-size: 35px;margin-left: 20px;"></asp:Label></div>
              <span class="green" style="float: right;"> VNĐ</span>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-clock-o"></i> Doanh thu tháng trước </span>
              <div><asp:Label ID="lblLastMonth" runat="server" Text="123"   style="font-size: 35px;margin-left: 20px;"></asp:Label></div>
              <span class="green" style="float: right;"> VNĐ</span>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu quý </span>
              <div><asp:Label ID="lblQuarter" runat="server" Text="123"  style="font-size: 35px;margin-left: 20px;"></asp:Label></div>
              <span class="green" style="float: right;"> VNĐ</span>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu năm </span>
              <div><asp:Label ID="lblYear" runat="server" Text="123"  style="font-size: 35px;margin-left: 20px;"></asp:Label></div>
              <span class="green" style="float: right;"> VNĐ</span>
            </div>

          </div>
          <!-- /top tiles -->

          <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
              <div class="dashboard_graph">

                <div class="row x_title">
                  <div class="col-md-6">
                    <h3>Biểu Đồ Doanh Thu <small>Doanh thu trong năm 2017</small></h3>
                  </div>
                  <div class="col-md-6">
                    <div id="reportrange" class="pull-right" style="background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #ccc">
                      <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                      <span>December 30, 2014 - January 28, 2015</span> <b class="caret"></b>
                    </div>
                  </div>
                </div>

                <div class="col-md-12 col-sm-9 col-xs-12">
                  <div id="chart_plot_01" class="demo-placeholder">
                  <asp:Button ID="btnLogout" runat="server" Text="Button" />
                    </div>
                </div>
                <div class="clearfix"></div>
              </div>
            </div>

          </div>
          <br />
        </div>
</form>
</asp:Content>
