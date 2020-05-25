<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lease.aspx.cs" Inherits="CPRG214.Marina.App.Secure.Lease" %>

<%@ Register Src="~/Controls/DockSelector.ascx" TagPrefix="uc1" TagName="DockSelector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Lease Slip</h3>
    
    <!-- To enroll, all we need is the course selector, a new dropdown for course
         sections and the student id we get from session and date enrolled 
         from current date -->
    To lease slip, perform the following steps:<br />
    <ul>
        <li>Select a dock</li>
        <li>Select a Slip ID</li>
        <li>Click the Lease button</li>
    </ul>    

        <br />
    <table class="table col-5">
        <tr>
            <td>Select Dock</td>
            <td style="width:200px">
                <uc1:DockSelector runat="server" ID="DockSelector" AllowPostBack="True "/>
            </td>
        </tr>
        <tr>
            <td>Select Slip ID</td>
            <td>
                <asp:ListBox ID="uxSlips" runat="server" Width="197px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="uxEnroll" runat="server" Text="Lease" OnClick="uxEnroll_Click" />
            </td>
        </tr>
    </table>
    <br />
    <hr />
    <h3>Current Registered Leases </h3>
    <p>
        <asp:GridView ID="uxEnrollment" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="694px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#224C72" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#224C72" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </p>


</asp:Content>
