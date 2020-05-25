<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Registration.ascx.cs" Inherits="CPRG214.Marina.App.Controls.Registration" %>

<h3>Registration Upsert</h3>
<asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" OnFinishButtonClick="Wizard1_FinishButtonClick">
    <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Student Profile">
            <table class="table">
                <tr>
                    <td style="width:150px">First Name</td>
                    <td>
                        <asp:TextBox ID="uxFirstName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="First name is required" ControlToValidate="uxFirstName">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td>
                        <asp:TextBox ID="uxLastName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Last name is required" ControlToValidate="uxLastName">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Phone:</td>
                    <td>
                        <asp:TextBox ID="uxPhone" runat="server"></asp:TextBox>
                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>City:</td>
                    <td>
                        <asp:TextBox ID="uxCity" runat="server"></asp:TextBox>
                    </td>
                    <td>

                    </td>
                </tr>
            </table>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Security Credentials">
            <table>
                <tr>
                    <td style="width:150px">Username:</td>
                    <td>
                        <asp:TextBox ID="uxUsername" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="uxPassword" runat="server"></asp:TextBox></td>
                </tr>
            </table>
        </asp:WizardStep>
    </WizardSteps>
</asp:Wizard>

