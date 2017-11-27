<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ListFlower.aspx.cs" Inherits="Web.UI.ListFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
   
    function confirmToDelete(id) {
        if (confirm("Do you want to delete?")) {
            window.location = "/Flower/DeleteFlower.aspx?ID=" + id;
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
                    <h3>List of flowers in store</h3>
                  </div>
                </div>
                  <a href="UpdateFlower.aspx" class="pull-right btn btn-primary">Create new</a>
                <div class="clearfix"></div>
                  <asp:GridView ID="GridViewListFlower" runat="server" CssClass="table table-bordered">
                      <Columns>
                      <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <a href="DetailFlower.aspx?ID=<%#Eval("ID")%>" class="fa fa-eye btn btn-success"></a>
                            <a href="UpdateFlower.aspx?ID=<%#Eval("ID")%>" class="fa fa-pencil btn btn-info"></a>
                            <button class="fa fa-trash btn btn-danger" type="button" onclick="confirmToDelete(<%#Eval("ID")%>)"></button>
                        </ItemTemplate>
                      </asp:TemplateField>
                      </Columns>
                      
                  </asp:GridView>
              </div>
            </div>
        </form>
</asp:Content>
