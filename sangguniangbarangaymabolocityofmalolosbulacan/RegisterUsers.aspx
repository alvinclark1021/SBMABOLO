<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="RegisterUsers.aspx.cs" Inherits="sangguniangbarangaymabolocityofmalolosbulacan.RegisterUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="ID" Width="744px" GridLines="Horizontal" Font-Names="Times New Roman"  RowStyle-HorizontalAlign="Center" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" Height="219px">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="Name" ItemStyle-Width="90px" >
<ItemStyle Width="90px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"
                        ItemStyle-Width="90px" >
<ItemStyle Width="90px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"
                        ItemStyle-Width="90px" >
<ItemStyle Width="90px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkdelete" runat="server" OnClick="lnkdelete_Click" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
    </div>
</asp:Content>
