<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true"
    CodeBehind="Consolidado.aspx.cs" Inherits="CapaWeb.PeUtiles.pages.Herramienta.Consolidado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../styles/Style.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="X-UA-Compatible" content="IE=7,IE=9" />
    <link href="../../../styles/GridViewNewStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery-ui-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../../scripts/gridviewScroll.min.js"></script>
    <script type="text/javascript" src="../../../scripts/IE7.js"></script>
    <script type="text/javascript" src="../../../scripts/IE8.js"></script>
    <script type="text/javascript" src="../../../scripts/IE9.js"></script>
    <script type="text/javascript">




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="panProgreso" runat="server" Width="99%">
            <table cellspacing="2" cellpadding="5" width="100%" border="0" style="background-color: #0B52A0;">
                <tr>
                    <td style="width: 30%; vertical-align: middle;">
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px"
                            Font-Names="Tahoma" Text="Consolidación de Pedidos" />
                    </td>
                    <td align="right" style="vertical-align: middle;">
                        <asp:Label ID="lblEstadoConsolidado" runat="server" Font-Bold="True" Font-Size="11px"
                            ForeColor="White" Font-Names="Tahoma" />
                    </td>
                    <td style="width: 2%;">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ajax:RoundedCornersExtender ID="rceProgreso" runat="server" TargetControlID="panProgreso"
            Corners="All" Radius="3">
        </ajax:RoundedCornersExtender>
        <asp:UpdatePanel ID="upaEdicion" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlBusqueda">
                    <asp:Table ID="Table1" Width="99%" runat="server" BorderColor="#e6e6fa" BorderWidth="1"
                        Height="40px">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header" BackColor="#e6e6fa"
                                Width="5%">
                                <asp:Label ID="lblPaisSearch" runat="server" Text="Periodo :" Font-Size="11px" Font-Names="Tahoma" />
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="11%">
                                <asp:DropDownList ID="ddlPeriodoSearch" runat="server" AutoPostBack="True" Width="94%"
                                    OnSelectedIndexChanged="ddlPeriodoSearch_SelectedIndexChanged" Font-Size="11px"
                                    Font-Names="Tahoma" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                BackColor="#e6e6fa" Width="5%">
                                <asp:Label ID="lblEmpresaSearch" runat="server" Text="Empresa :" Font-Size="11px"
                                    Font-Names="Tahoma" />
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="9%">
                                <asp:DropDownList runat="server" ID="ddlEmpresaSearch" AutoPostBack="True" Width="94%"
                                    OnSelectedIndexChanged="ddlEmpresaSearch_SelectedIndexChanged" Font-Size="11px"
                                    Font-Names="Tahoma">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="MIMSA">MIMSA</asp:ListItem>
                                    <asp:ListItem Value="MEGA">MEGA</asp:ListItem>
                                    <asp:ListItem Value="RUMI">RUMI</asp:ListItem>
                                    <asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem>
                                    <asp:ListItem Value="POSTES">POSTES</asp:ListItem>
                                    <asp:ListItem Value="Steel Form">Steel Form</asp:ListItem>
                                    <asp:ListItem Value="China Bolts">China Bolts</asp:ListItem>
                                    <asp:ListItem Value="Coorporativo">Coorporativo</asp:ListItem>                                
                                </asp:DropDownList>

                            </asp:TableCell><asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                BackColor="#e6e6fa" Width="5%">
<%--                                <asp:Label ID="lblProyectoSearch" runat="server" Text="Proyecto :" Font-Size="11px"
                                    Font-Names="Tahoma" />--%>
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="9%">
<%--                                <asp:DropDownList runat="server" ID="ddlProyectoSearch" Width="94%" Font-Size="11px"
                                    Font-Names="Tahoma" />--%>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                BackColor="#e6e6fa" Width="5%">
                                <%--<asp:Label ID="Label1" runat="server" Text="Actividad :" Font-Size="11px" Font-Names="Tahoma" />--%>
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="11%">
                                <%--<asp:DropDownList ID="ddlActividadSearch" runat="server" Width="94%" Font-Size="11px"
                                    Font-Names="Tahoma" />--%>
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="9%">
                                <asp:Button runat="server" ID="btnSearch" Text="Buscar" CssClass="button" OnClick="btnSearch_Click"
                                    Font-Size="11px" Font-Names="Tahoma" Style="color: White; background: url(../../../images/button_bg.png) center no-repeat;
                                    width: 100px; height: 26px; font: 11px Tahoma;" />
                            </asp:TableCell></asp:TableRow></asp:Table></asp:Panel><br /><asp:Panel ID="pnlDetallesPlanificado" runat="server" Width="100%">
                    <asp:Panel ID="pnlRegistro" runat="server" Width="100%">
                        <asp:GridView ID="gvwSupervisor" Width="100%" runat="server" OnRowCommand="gvwSupervisor_RowCommand"
                            AutoGenerateColumns="False" CellPadding="3" ShowFooter="True" ForeColor="#333333"
                            CssClass="NewGrid" PagerStyle-CssClass="PagerStyle" AlternatingRowStyle-CssClass="alt"
                            DataKeyNames="IdPeriodo,IdArticulo" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                            OnRowDataBound="gvwSupervisor_RowDataBound" BorderStyle="Solid" BorderWidth="1px"
                            BorderColor="#A6C4E0" Style="padding: 5px 8px 5px 8px; font-weight: bold; white-space: normal;
                            font-family: Tahoma; font-size: 11px; border: solid 1px #A6C4E0; border-collapse: collapse;
                            background-color: #2CB2EB; vertical-align: middle; background-repeat: repeat-x;
                            background-position: top; background-image: url(../../images/headergvw.gif);
                            height: 20px; color: White;" OnPreRender="gvwSupervisor_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%# Container.DisplayIndex + 1 %>
                                        <asp:HiddenField ID="hdnIdPeriodos" runat="server" Value='<%# Bind("IdPeriodo") %>' />
                                        <asp:HiddenField ID="hdnIdEmpleados" runat="server" Value='<%# Bind("IdArticulo") %>' />
                                        <asp:HiddenField ID="hdnEmpleado" runat="server" Value='<%# Bind("NombreArticulo") %>' />
                                        <asp:HiddenField ID="hdnEstado" runat="server" Value='<%# Bind("Cantidad") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" Wrap="true">
                                    </ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" Wrap="true">
                                    </HeaderStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Area" HeaderText="Área" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreUsuarioRegistro" HeaderText="Nombres" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdArticulo" HeaderText="Id Articulo" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreArticulo" HeaderText="Descripción" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnidadMedida" HeaderText="U. Medida" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Precio" HeaderText="Precio" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-VerticalAlign="Middle"
                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle BackColor="White" ForeColor="#717171" Font-Bold="false" Font-Names="Tahoma"
                                Font-Size="11px" />
                            <AlternatingRowStyle BackColor="#E7F6FD" ForeColor="#717171" Font-Bold="false" Font-Names="Tahoma"
                                Font-Size="11px" />
                            <FooterStyle BackColor="White" ForeColor="Black" Font-Names="Tahoma" Font-Size="11px"
                                VerticalAlign="Middle" Height="30px" />
                            <EmptyDataRowStyle Width="99%" Height="100px" Font-Bold="true" Font-Names="Tahoma"
                                Font-Size="11px" HorizontalAlign="Center" BackColor="White" BorderColor="White"
                                VerticalAlign="Middle" ForeColor="Black" />
                        </asp:GridView>
                    </asp:Panel>
                    <br />
                    <table width="99%">
                        <tr>
                            <td style="width: 96%">
                                <table width="99%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" ForeColor="OrangeRed" Font-Size="11px" Font-Names="Tahoma"
                                                Font-Bold="true"></asp:Label></td><td align="right">
                                            <asp:Panel runat="server" ID="paneL1">
                                                <b style="font-size: 11px; font-family: Tahoma;">Leyenda :</b>&nbsp; <asp:Image runat="server" ID="Image1" ImageUrl="~/images/circle_green1.png"></asp:Image>&nbsp;<asp:Label
                                                    ID="Label5" runat="server" Text="Completo" Font-Size="11px" Font-Names="Tahoma" />
                                                &nbsp;&nbsp; <asp:Image runat="server" ID="Image2" ImageUrl="~/images/circle_red1.png"></asp:Image>&nbsp;<asp:Label
                                                    ID="Label6" runat="server" Text="Incompleto" Font-Size="11px" Font-Names="Tahoma" />
                                                &nbsp; </asp:Panel></td><td align="right">
                                            <asp:Literal ID="ltlFecha" runat="server"></asp:Literal><asp:DropDownList runat="server"
                                                ID="ddlExportar" Width="150px" Font-Size="11px" Font-Names="Tahoma">
                                                <asp:ListItem Value="1">Excel</asp:ListItem><asp:ListItem Value="3">Word</asp:ListItem></asp:DropDownList>&nbsp;&nbsp; <asp:Button runat="server" ID="btnImprimir" Text="Exportar" Font-Size="11px" Font-Names="Tahoma"
                                                CssClass="button" OnClick="btnImprimir_Click" Style="color: White; background: url(../../../images/button_bg.png) center no-repeat;
                                                width: 100px; height: 26px; font: 11px Tahoma;" />
                                            &nbsp;<asp:ImageButton ID="ibtnVolver" runat="server" ImageUrl="~/images/buttons/undo.png"
                                                OnClick="ibtnVolver_Click" ToolTip="Volver a la página anterior" Visible="False" />&nbsp; </td></tr></table></td></tr></table></asp:Panel></ContentTemplate><Triggers>
                <asp:PostBackTrigger ControlID="btnImprimir" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:HiddenField ID="hfGridView1SV" runat="server" />
        <asp:HiddenField ID="hfGridView1SH" runat="server" />
        <br />
    </div>
</asp:Content>
