<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Distribucion.aspx.cs" Inherits="CapaWeb.pages.documento.Distribucion" %>
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
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Distribución de Documentos</asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ajax:RoundedCornersExtender ID="rceProgreso" runat="server" TargetControlID="panProgreso"
            Corners="All" Radius="3">
        </ajax:RoundedCornersExtender>
        <asp:UpdatePanel ID="upaEdicion" runat="server">
            <ContentTemplate>
                <br />
                <asp:Panel runat="server" ID="pnlBusqueda" DefaultButton="btnBuscar">
                    <asp:Table ID="Table1" Width="99%" runat="server" BorderColor="#e6e6fa" BorderWidth="1"
                        Height="40px">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header" Width="5%">
                                <asp:Label ID="lblEmpresaSearch" runat="server" Text="Empresa :" />&nbsp;
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="11%">
                                &nbsp;<asp:DropDownList ID="ddlEmpresaSearch" runat="server" AutoPostBack="True"
                                    Width="94%" OnSelectedIndexChanged="ddlEmpresaSearch_SelectedIndexChanged">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="MIMSA">MIMSA</asp:ListItem>
                                    <asp:ListItem Value="MEGA">MEGA</asp:ListItem>
                                    <asp:ListItem Value="RUMI">RUMI</asp:ListItem>
                                    <asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem>
                                    <asp:ListItem Value="POSTES">POSTES</asp:ListItem>
                                    <asp:ListItem Value="Steel Form">Steel Form</asp:ListItem>
                                    <asp:ListItem Value="DOBLE RR">DOBLE RR</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                Width="6%">
                                <asp:Label ID="lblSearch" runat="server" Text="Buscar :" />&nbsp;
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="19%">
                                &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="96%" />
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="3%">
                                &nbsp;<asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnBuscar_Click" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Width="20%">
<%--                                <asp:CheckBox ID="chkEliminados" runat="server" Text="&nbsp;Mostrar Documentos desactivados."
                                    AutoPostBack="True" OnCheckedChanged="chkEliminados_CheckedChanged" />&nbsp;&nbsp;--%>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="7%"
                                BackColor="#e6e6fa">
                                &nbsp;&nbsp;
<%--                                <asp:ImageButton ID="ibNuevoEmpleado" runat="server" ImageUrl="~/images/buttons/add.png"
                                    Width="30px" Height="30px" OnClick="ibNuevoEmpleado_Click" ToolTip="Agregar Empleado" />--%>
                            </asp:TableCell></asp:TableRow></asp:Table></asp:Panel><asp:Panel runat="server" ID="pnlProyectosAll" Width="99%">
                    <br />
                    <asp:Panel ID="pnlProyectosPlanificados" Visible="true" runat="server" Width="99%">
                        <table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 96%">
                                    <asp:Panel ID="pnlCollapsePlanificados" runat="server" CssClass="collapsePanelHeader"
                                        Width="100%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Distribución</div><div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapsePlanificados" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDetallesPlanificado" runat="server" Width="100%">
                                        <br />
                                        <asp:GridView ID="gvwEmpleado" Width="100%" runat="server" OnRowCommand="gvwEmpleado_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            DataKeyNames="IdDocumento,IdMovimiento" GridLines="None" OnPageIndexChanging="gvwEmpleado_PageIndexChanging"
                                            AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                                            OnRowDataBound="gvwEmpleado_DataBound" 
                                            onselectedindexchanged="gvwEmpleado_SelectedIndexChanged"><Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll_CheckedChanged"
                                                            AutoPostBack="true" />
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%"
                                                    HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DisplayIndex + 1 %>
                                                        <asp:HiddenField ID="hdnIdEmpleados" runat="server" Value='<%# Bind("IdDocumento") %>' />
                                                        <asp:HiddenField ID="hdnMovimiento" runat="server" Value='<%# Bind("IdMovimiento") %>' />
                                                        <asp:HiddenField ID="hdnEstado" runat="server" Value='<%# Bind("Estado") %>' />                                                       
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Editar" Visible="False">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/edit.png"
                                                            Height="18px" Width="18px" CommandName="Editar" CommandArgument='<%# Bind("IdDocumento") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver" Visible="False"><HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdDocumento") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdDocumento" HeaderText="Id Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IdMovimiento" 
                                                    HeaderText="Id Movimiento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="22%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="22%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TipoDoc" HeaderText="Tipo Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NroDoc" HeaderText="Nr. Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UsuarioAsignado" 
                                                    HeaderText="Distribuido" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Aprobado">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgestado" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="PagerStyle" />
                                            <AlternatingRowStyle CssClass="alt" />
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Blue" />
                                        </asp:GridView>
                                        <br />
                                        <table width="99%">
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPaginacion" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem><asp:ListItem Text="30" Value="30"></asp:ListItem><asp:ListItem Text="40" Value="40"></asp:ListItem><asp:ListItem Text="50" Value="50"></asp:ListItem></asp:DropDownList></td><td>
                                                    &nbsp; </td><td>
                                                    &nbsp; </td></tr></table><ajax:CollapsiblePanelExtender ID="cpePlanificados" runat="Server" TargetControlID="pnlDetallesPlanificado"
                                            ExpandControlID="pnlCollapsePlanificados" CollapseControlID="pnlCollapsePlanificados"
                                            Collapsed="false" ImageControlID="imgCollapsePlanificados" ExpandedText="(Ocultar Detalles)"
                                            CollapsedText="(Ver Detalles)" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
                                            SuppressPostBack="true" SkinID="CollapsiblePanel" />
                                    </asp:Panel>
                                </td>
                                <td class="style1">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <table width="99%">
                        <tr>
                            <td>
                                <asp:Panel ID="pnlLeyenda" runat="server">
                                    <table width="99%">
                                        <tr>
                                            <td align="left" style="width: 2%;">
                                            </td>
                                            <td align="left" style="width: 48%;">
                                                <asp:Panel runat="server" ID="paneLeyenda">
                                                    <b style="font-size: 11px; font-family: Tahoma;">Leyenda :</b>&nbsp;<img src="../../images/circle_silver1.png" /> <asp:Label ID="Label10" runat="server" Text="Ingresado" Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_green.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label3" runat="server" Text="Recibido " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_yellow.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label4" runat="server" Text="Pendiente de Recepción " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_orange.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label1" runat="server" Text="En Proceso " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_red.png" width="18px" height="18px" /><asp:Label ID="Label2"
                                                        runat="server" Text="Rechazado" Font-Size="11px" Font-Names="Tahoma" />
                                                </asp:Panel>
                                            </td>
                                            <td align="right" style="width: 50%;">
                                                <table>
                                                    <tr>
    <%--                                                    <td align="center">
                                                            <asp:Button runat="server" ID="btnRecibir" CssClass="button" 
                                                                Text="Recibir" OnClick="btnRecibir_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" /><ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnrecibir"
                                                                ConfirmText="¿Está seguro que desea Recibir Estos Documentos?">
                                                            </ajax:ConfirmButtonExtender>
                                                        </td>
                                                        <td align="center" style="width: 2%;">
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btnrechazar" CssClass="button" 
                                                                Text="Rechazar" OnClick="btnRechazar_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" /><ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnrechazar"
                                                                ConfirmText="¿Está seguro que desea Rechazar estos Documentos?">
                                                            </ajax:ConfirmButtonExtender>
                                                        </td>--%>
                                                        <td align="center" style="width: 100px;">
                                                            <asp:DropDownList ID="ddlDestino" runat="server" AutoPostBack="false" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btnAprobar" CssClass="button" Text="Enviar" OnClick="btnAprobar_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" />
                                                            <ajax:ConfirmButtonExtender ID="cbeAprobar" runat="server" TargetControlID="btnAprobar"
                                                                ConfirmText="¿Está seguro que desea Enviar estos Documentos?">
                                                            </ajax:ConfirmButtonExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </asp:Content>