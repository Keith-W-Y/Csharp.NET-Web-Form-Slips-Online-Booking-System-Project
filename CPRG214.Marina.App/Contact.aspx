<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CPRG214.Marina.App.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%--    <h2><%: Title %>.</h2>--%>
    <h3>Contact Information:</h3>
    <address>
        Inland Lake Marina<br />
        Box 123<br />
        Inland Lake, Arizona<br />
        86038<br />
    </address>

    <address>
        (office ph) 928-555-2234 <br />
        (leasing ph) 928-555-2235 <br />
        (fax) 928-555-2236 <br />
    </address>

    <address>
        Manager: Glenn Cooke <br />
        Slip Manager: Kimberley Carson <br />
        Contact email: <a href="mailto:info@inlandmarina.com">info@inlandmarina.com</a>
    </address>
</asp:Content>