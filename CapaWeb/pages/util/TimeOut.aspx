<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeOut.aspx.cs" Inherits="CapaWeb.pages.util.TimeOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.:: <%=nombreSistema%> ::.</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../styles/Index.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        history.forward(1) // Evita retroceder
    </script>    
</head>
<body>
    <form id="form1" runat="server">
    <div id="centrecontainer">
        <div id="outercontainer">
            <div id="header">
                <div id="headertitle">
                    <table width="100%">
                      <tr>
                        <td style="width:3%">
                        </td>                      
                        <td valign="middle" style="width:10%">
                            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/urion_logo.png" Height="40px" Width="35px" />
                        </td>
                        <td>
                            <p style="font-size:14px; font-weight:bold; color:#145F9D;">Grupo Metalindustrias</p>

                        </td>                        
                      </tr>
                    </table>
                </div>
            </div>
            <div id="content">
                <div id="containertext">
                
                    <table width="100%">
                        <tr>
                            <td align="center" >
        <br /><br />
        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="22px" ForeColor="#145F9D" Text="¡ La sesión no es válida o ha expirado !" />
        <br /><br /><br /><br />
        <asp:Image ID="imgExpired" runat="server" ImageUrl="~/images/expired.png" Height="150px" Width="150px" />&nbsp;<br/>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Font-Size="16px"  ForeColor="#145F9D"
        Text="Por medidas de seguridad deberá iniciar sesión nuevamente para acceder al sistema." />
        <br /><br /><br />
        <asp:LinkButton ID="linkSession" runat="server" onclick="linkSession_Click" Font-Size="17px" style="color:#145F9D; text-decoration: none; font-weight:bold;" ><< Iniciar Sesión >></asp:LinkButton>       
                            
                            </td>
                        </tr>
                    </table>
                    
                </div>
            </div>
            <div id="footer" style="text-align:center">
                <p style="font-size:11px; font-weight:bold"> Powered by <a href="http://pe.linkedin.com/pub/jhait-carhuaz/57/286/b66" style="color:#145F9D; font-size:15px; font-family:Cambria; font-weight:bold" target="_blank"><strong>Jhait Carhuaz</strong></a></p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
