<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaWeb.Inicio" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: <%= nombreSistema %> ::.</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="styles/Index.css" rel="stylesheet" type="text/css" />
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
                        <td valign="middle" style="width:8%">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/urion_logo.png" Height="40px" Width="35px" />
                        </td>
                        <td>
                            <p style="font-size:14px; font-weight:bold; color:#145F9D;">Grupo Metalindustrias</p>

                        </td>                        
                      </tr>
                    </table>
                </div>
            </div>
            <div id="container">
                <div id="containertext">
                 <ajax:ToolkitScriptManager ID="tsmSistema" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="True" />                                
                   <asp:UpdatePanel ID="upanIndex" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                        <tr>
                            <td style="width:50%;" />
                            <td style="width:50%" align="center" >
                                <br />
                                <p style="font-size:18px; font-weight:bold; color:#145F9D;">Acceso Sistema Integrado de Aplicaciones</p>

                                <br /><br /><br />
                                <table width="100%">
                                                                    <tr>
                                        <td style="width:40%" align="right" >
                                            <asp:Label ID="Label5" runat="server" Text="Tipo de Autenticación" CssClass="lbl" />
                                        </td>
                                        <td style="width:55%" align="right" >


                                        <asp:RadioButtonList ID="rdbTipoAuten" runat="server" RepeatDirection="Horizontal" Width="92%" MaxLength="100" Font-Size="11px" >

                                        <asp:ListItem Text="Sistema" Value="1" Selected="True" ></asp:ListItem>                   
                                        <asp:ListItem Text="Windows" Value="2"> </asp:ListItem>
     

                                        </asp:RadioButtonList>   


                                                                  
                                        </td>
                                        <td style="width:5%">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" Debe seleccionar una opción para acceder al sistema. " ForeColor="Red" Font-Bold="true" 
                                                InitialValue="0" ControlToValidate="ddlAutenticacion" Display="Dynamic" ValidationGroup="Login" Text=" * " />                                                     
                                        </td>
                                    </tr>   
                                    <tr>
                                        <td style="width:40%" align="right" >
                                            <asp:Label ID="Label4" runat="server" Text="Seleccionar Aplicativo" CssClass="lbl" />
                                        </td>
                                        <td style="width:55%" align="right" >
                                            <asp:DropDownList ID="ddlAutenticacion" runat="server" CssClass="ddl" Width="94%" 
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlAutenticacion_SelectedIndexChanged" >
                                                <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                                <asp:ListItem Value="1">Jcarhuaz</asp:ListItem>
                                                <asp:ListItem Value="2">Carhuaz</asp:ListItem>
                                               
                                            </asp:DropDownList>                                                                       
                                        </td>
                                        <td style="width:5%">
                                            <asp:RequiredFieldValidator ID="rfvAutenticacion" runat="server" ErrorMessage=" Debe seleccionar una opción para acceder al sistema. " ForeColor="Red" Font-Bold="true" 
                                                InitialValue="0" ControlToValidate="ddlAutenticacion" Display="Dynamic" ValidationGroup="Login" Text=" * " />                                                     
                                        </td>
                                    </tr>                                
                                </table>
                                <asp:Panel ID="pnlLoginSistema" runat="server" Visible="false" style="text-align:center;">
                                    <br /><br />
                                    <table width="100%">                                  
                                        <tr>
                                            <td style="width:40%" align="right">
                                                <asp:Label ID="Label2" runat="server" Text="Usuario" CssClass="lbl" />
                                            </td>
                                            <td style="width:55%" align="right">
                                                <asp:TextBox ID="txtUsuario" runat="server" Width="92%" MaxLength="100" Font-Size="11px" />
                                            </td>
                                            <td style="width:5%" align="left">
                                                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="El nombre de usuario no ha sido ingresado." ControlToValidate="txtUsuario" 
                                                ForeColor="Red" Font-Bold="true"  ValidationGroup="Login" Text=" * " />                                                
                                            </td>                                        
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label3" runat="server" Text="Contraseña" CssClass="lbl" MaxLength="100" />
                                            </td>
                                            <td align="right">
                                                <asp:TextBox ID="txtContrasena" TextMode="Password" runat="server" Width="92%" Font-Size="11px" />
                                            </td>
                                            <td style="width:5%" align="left">
                                                <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ErrorMessage="La contraseña no ha sido ingresada." ControlToValidate="txtContrasena" 
                                                     ForeColor="Red" Font-Bold="true" ValidationGroup="Login" Text=" * " />                                                 
                                            </td>                                        
                                        </tr>                                            
                                    </table>    
                                </asp:Panel>
                                <br />
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:UpdateProgress ID="upgForm" runat="server" AssociatedUpdatePanelID="upanIndex"
                                                DisplayAfter="0" DynamicLayout="false">
                                                <ProgressTemplate>
                                                    <asp:Image ID="imgLoad" runat="server" ImageUrl="~/images/cargando.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="width:75%" align="right" >
                                            <br />
                                            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="button" 
                                                 ValidationGroup="Login" OnClick="btnLogin_Click" />
                                        </td>
                                        <td style="width:5%" />                                        
                                    </tr>                                
                                </table>
                                <br />
                                <br />
                                <table width="100%">
                                    <tr>
                                        <td style="width:5%" />
                                        <td style="width:95%" align="left" >
                                            <asp:ValidationSummary ID="vsLogin" runat="server" ValidationGroup="Login" Font-Size="11px" ForeColor="Red" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                   </asp:UpdatePanel>
                </div>
            </div>
            <div id="footer" style="text-align:center">
                <p style="font-size:11px; font-weight:bold"> Powered by 
                    <a href="#" style="color:#145F9D; font-size:15px; font-family:Cambria; font-weight:bold" target="_blank">
                    <strong>Jhait Carhuaz</strong></a></p>
            </div>
        </div>
    </div>
</form>
</body>
</html>
