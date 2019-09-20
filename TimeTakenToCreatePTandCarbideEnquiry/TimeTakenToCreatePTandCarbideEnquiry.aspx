<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeTakenToCreatePTandCarbideEnquiry.aspx.cs" Inherits="TimeTakenToCreatePTandCarbideEnquiry.TimeTakenToCreatePTandCarbideEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <div style="width: 800px; font-family: 'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif;
            border: 2px solid black;">
            <asp:Label ID="Label1" runat="server" Style="text-align: center; font-weight: 700;
                font-size: xx-large; color: #000000;" Text="Time Taken To Create PT"></asp:Label></div>
                
        <br />
        <table>
        <tr>
        <td>
            <asp:RadioButton ID="rdbtn1" GroupName="unit" runat="server" Text="AWS-1" 
                style="font-weight: 700; font-size: small; color: #000000;"/></td>
            <td>
                <asp:RadioButton ID="rdbtn2" GroupName="unit" runat="server" Text="AWS-2" 
                    style="font-weight: 700; font-size: small; color: #000000;"/>
            </td>
            <td>
                <asp:RadioButton ID="RadioButton1" GroupName="unit" Text="Both" runat="server" 
                    style="font-weight: 700; font-size: small; color: #000000;" />
            </td>
        </tr>
        </table><br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="From : " 
                        Style="font-weight: 700; font-size: medium; color: #000000;"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="25px" Style="font-weight: 700;
                        font-size: medium; text-align: center" Width="165px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="To : " 
                        Style="font-weight: 700; font-size: medium; color: #000000;"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="25px" Style="font-weight: 700;
                        font-size: medium; text-align: center" Width="165px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                        Style="font-weight: 700; font-size: medium" onclick="btnSubmit_Click"/>
                </td>
            </tr>
        </table><br />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
    <asp:GridView ID="GridView1" runat="server" CellSpacing="2" Style="color: Black;
                text-align: center; height: 218px; width: 800px; color: Black; text-align: center;"
                AutoGenerateColumns="False" ShowFooter="True" ShowHeaderWhenEmpty="True" >
            <Columns>
            <asp:TemplateField HeaderText="Sr No.">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OC" HeaderText="OC" ReadOnly="True" />
                    <asp:BoundField DataField="Order_Date" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="True" />
                    <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" ReadOnly="True" />
                    <asp:BoundField DataField="Cust_PO" HeaderText="Customer PO" ReadOnly="True" />
                    <asp:BoundField DataField="PODate" HeaderText="PO Date" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="True" />
                    <asp:BoundField DataField="DaystoMakePT" HeaderText="Days to Make PT" ReadOnly="True" />
                    <asp:BoundField DataField="Location" HeaderText="Location" ReadOnly="True" />
            </Columns>
            <HeaderStyle BackColor="#ffffff" BorderStyle="Groove" />
                <EmptyDataTemplate>
                    No Record Available</EmptyDataTemplate>
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView><br />
        </center>
</asp:Content>
