<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="CapaWeb.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="styles/Style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaEdicion" runat="server">
        <ContentTemplate>
            <table cellspacing="2" cellpadding="5" width="100%" border="0" style="background-color: #0B52A0;">
	        <tr>
		        <td style="width:30%; vertical-align: middle;">
			        <asp:Label id="lblTabGeneral" runat="server" Font-Bold="true"  ForeColor="White" Font-Size="14px" Text="Inicio" />
                </td>
                <td align="right" style="vertical-align: middle;">
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="White" />
                </td>
                <td style="width:2%;"></td>
	        </tr>
	        </table>
            <br />
            <table width="100%">
             <tr>
                <td colspan="3">
                &nbsp; <h3><b> Bienvenidos a Tramite Documentario </b> Sistema de Gestión del Proceso de Registro de Documentos.</h3>
                <br /><br />
                </td>
             </tr>
             <tr>
                <td style="width:2%"></td>
                <td align="center">
                    <asp:Image ID="fasdfas" runat="server" ImageUrl="~/images/backgrounds/Main_Urion.png" Height="510px" Width="800px" />
                </td>
                <td style="width:2%"></td>
             </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
