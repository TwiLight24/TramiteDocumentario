<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true" CodeBehind="ReporteCargo.aspx.cs" Inherits="CapaWeb.pages.reportes.ReporteCargo" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../styles/Style.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/General.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="panProgreso" runat="server" Width="100%">
            <table id="panTabs" cellspacing="2" cellpadding="5" width="100%" border="0" style="background-color: #0B52A0">
                <tr>
                    <td width="33%" style="vertical-align: middle;">
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Reporte de Cargo</asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ajax:RoundedCornersExtender ID="rceProgreso" runat="server" TargetControlID="panProgreso"
            Corners="All" Radius="3">
        </ajax:RoundedCornersExtender>
        <asp:UpdatePanel ID="upaEdicion" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlBusqueda" DefaultButton="btnBuscar">
                    <table id="Table1" width="100%" border="0">
                        <tr>
                            <td width="20%">
                                <asp:TextBox ID="txtBuscar" runat="server" Width="96%" />
                            </td>
                            <td width="20%">
                                <asp:Button runat="server" ID="btnBuscar" CssClass="button" Text="Buscar" OnClick="btnAprobar_Click"
                                    Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                    width: 100px; height: 26px; font: 11px Tahoma;" />
                            </td>
                            <td width="20%">
                                <asp:Button runat="server" ID="btnImprimir" CssClass="button" Text="Imprimir" OnClick="btnImprimir_Click"
                                    Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                    width: 100px; height: 26px; font: 11px Tahoma;" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Formulario" runat="server">
                    <table id="Report" width="100%" border="0">
                        <tr>
                            <CR:CrystalReportViewer ID="ReportDocument" runat="server" AutoDataBind="true" />
                        </tr>
                        <tr>
                        <CR:CrystalReportViewer ID="rvVistaReporte" runat="server" AutoDataBind="true" />
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
</asp:Content>
