<%@ Page Title="" Language="C#" MasterPageFile="~/EmpPayroll.Master" AutoEventWireup="true" CodeBehind="EmpPayroll.aspx.cs" Inherits="EmpPayrollWebForms.EmpPayrollWebForms.EmpPayroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../StyleSheets/EmpPayrollStyles.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 31px;
        }
        .auto-style3 {
            width: 161px;
        }
        .auto-style4 {
            height: 31px;
            width: 161px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: x-large; font-weight: bold; color: #000000">Complete CRUD Operation in Asp.Net C# with SQL Using Stored Procedure</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Employee ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            &nbsp;
                <asp:Button ID="Button4" runat="server" BackColor="#6600CC" Font-Size="Large" ForeColor="White" Text="Search" OnClick="Button4_Click" Width="120px" ></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Employee Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Gender"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Department"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Medium" Width="200px">
                    <asp:ListItem>Engineer</asp:ListItem>
                    <asp:ListItem>Sales</asp:ListItem>
                    <asp:ListItem>IT</asp:ListItem>
                    <asp:ListItem>Marketing</asp:ListItem>
                    <asp:ListItem>Developer</asp:ListItem>
                    <asp:ListItem>Accounts</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Salary"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox4" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Start Date"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox3" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="Button1" runat="server" BackColor="#6600CC" Font-Size="Medium" ForeColor="White" Text="Insert" OnClick="Button1_Click" ></asp:Button>
            &nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BackColor="#6600CC" Font-Size="Medium" ForeColor="White" Text="Update" OnClick="Button2_Click" ></asp:Button>
            &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" BackColor="#6600CC" Font-Size="Medium" ForeColor="White" Text="Delete" OnClick="Button3_Click" OnClientClick="return confirm('Are you sure to delete?')" ></asp:Button>
            &nbsp;&nbsp;
                <asp:Button ID="Button5" runat="server" BackColor="#6600CC" Font-Size="Medium" ForeColor="White" Text="Load" OnClick="Button5_Click" ></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="1284px">
                    <HeaderStyle BackColor="#3333FF" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
