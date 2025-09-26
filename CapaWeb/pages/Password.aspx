<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="CapaWeb.pages.Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.::  <%= nombreSistema%> - Cambiar Contraseña ::.</title>
    <style type="text/css">
        .modalPopup 
        {
            width:  100%;
  	        font: 11px Tahoma;            
        }    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<asp:Panel ID="pnlNuevoPassword" runat="server" Style="background-color: White;" CssClass="modalPopup">
                <div><br />
                <table width="100%">
                <tr>
                    <td style="width:40%" align="right">
                        <asp:Label ID="lblOldPassword" runat="server" Text="Contraseña actual :" />&nbsp;
                    </td>
                    <td style="width:55%" align="right">
                        <asp:TextBox ID="txtOldPassword" runat="server" Width="98%" TextMode="Password" ValidationGroup="pUpPWD" MaxLength="100" />
                        
                    </td>
                    <td style="width:5%">&nbsp;
                        <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword" ForeColor="Red" 
                             ErrorMessage=" *" SetFocusOnError="True" Display="Static" ValidationGroup="pUpPWD" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblNewPassword" runat="server" Text="Nueva contraseña :" />&nbsp;
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txtNewPassword" runat="server" Width="98%" TextMode="Password" ValidationGroup="pUpPWD" MaxLength="100" />
                    </td>
                    <td>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" ForeColor="Red"
                             ErrorMessage=" *" SetFocusOnError="True" Display="Static" ValidationGroup="pUpPWD" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblRepeatPassword" runat="server" Text="Repetir contraseña :" />&nbsp;
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txtRepeatPassword" runat="server" Width="98%" TextMode="Password" ValidationGroup="pUpPWD" MaxLength="100" />
                    </td>
                    <td>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvRepeatPassword" runat="server" ControlToValidate="txtRepeatPassword"  ForeColor="Red"
                             ErrorMessage=" *" SetFocusOnError="True" Display="Static" ValidationGroup="pUpPWD" />
                    </td>                                
                </tr>
            </table>
                <table width="100%">
                <tr>
                    <td align="left" style="width: 66%;">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Size="11px"></asp:Label>
                    </td>
                    <td align="right" style="width: 30%;">
                        <br />
                        <asp:Button ID="btnChange" runat="server" Width="80px" BackColor="#4381B4" ForeColor="White" OnClick="btnChange_Click"
                                    Font-Size="11px" Font-Bold="true" Text="Cambiar" ValidationGroup="pUpPWD" />
                    </td>
                    <td style="width: 4%;" />
                </tr>                                                        
            </table>
                <br /></div>                         
</asp:Panel>
    </div>
    </form>
</body>
</html>
