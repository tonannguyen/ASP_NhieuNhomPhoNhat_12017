<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.UI.Default" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <form id="form1" runat="server">

    <div class="right_col" role="main">
          <!-- top tiles -->
          <div class="row tile_count">
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Revenue of today </span>
              <div><asp:Label ID="lblDay" runat="server" Text="123"  style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Revenue of last week</span>
              <div><asp:Label ID="lblLastWeek" runat="server" Text="123"   style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-clock-o"></i> Revenue of last month </span>
              <div><asp:Label ID="lblLastMonth" runat="server" Text="123"   style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
              
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Revenue of last quarter </span>
              <div><asp:Label ID="lblQuarter" runat="server" Text="123"  style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
              
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Revenue of last year</span>
              <div><asp:Label ID="lblYear" runat="server" Text="123"  style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
              
            </div>

          </div>
          <!-- /top tiles -->

          <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
              <div class="dashboard_graph">

                <div class="row x_title">
                  <div class="col-md-6">
                    <h3>Chart</h3>
                  </div>    
                </div>

                <div class="col-md-12 col-sm-9 col-xs-12">
                  <div id="chart_plot_01" class="demo-placeholder">
                  
                      <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="500px">
                          <series>
                              <asp:Series Name="Series1" ChartType="FastLine" XValueMember="CreatedTime" YValueMembers="QuantityOfDate">
                              </asp:Series>
                          </series>
                          <chartareas>
                              <asp:ChartArea Name="ChartArea1">
                              </asp:ChartArea>
                          </chartareas>
                      </asp:Chart>
                  
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:flower_storeConnectionString %>" SelectCommand="SELECT [QuantityOfDate], [CreatedTime] FROM [Revenues]"></asp:SqlDataSource>
                  
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
