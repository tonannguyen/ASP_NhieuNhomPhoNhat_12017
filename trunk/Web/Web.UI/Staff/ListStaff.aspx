﻿ <%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ListStaff.aspx.cs" Inherits="Web.UI.ListStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
   
    function confirmToDelete(id) {
        if (confirm("Do you want to delete?")) {
            window.location = "/Staff/DeleteStaff.aspx?ID=" + id;
        }
    }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <form runat="server">
        <div class="right_col" role="main">
              <div class="">
                <div class="page-title">
                  <div class="title_left">
                    <h3>List of staff in the store</h3>
                  </div>
                </div>
                  <a href="UpdateStaff.aspx" class="pull-right btn btn-primary" id ="tagCreate" runat="server" >Create new</a>
                  
                <div class="clearfix"></div>
                  <asp:GridView ID="GridViewStaff" runat="server" CssClass="table table-bordered">
                   <Columns>
                      <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <a href="DetailStaff.aspx?ID=<%#Eval("ID")%>" class="fa fa-eye btn btn-success" ></a>
                            <a href="UpdateStaff.aspx?ID=<%#Eval("ID")%>" class="fa fa-pencil btn btn-info" id="tagUpdate"></a>
                            <button class="fa fa-trash btn btn-danger" type="button" onclick="confirmToDelete(<%#Eval("ID")%>)"></button>
                        </ItemTemplate>
                      </asp:TemplateField>
                      </Columns>
                      
                  </asp:GridView>
              </div>
            </div>
        </form>

</asp:Content>
