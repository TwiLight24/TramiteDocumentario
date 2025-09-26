<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true"
    CodeBehind="Pedido.aspx.cs" Inherits="CapaWeb.PeUtiles.pages.Pedido" %>

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
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Pedidos</asp:Label>
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
                <asp:Panel ID="pnlMenuPedido" runat="server" Width="100%"  Visible="False">
                <table width="100%">
                <tr>
                    <td style="width: 2%;">
                    </td>
                    <td style="width: 13%; vertical-align: middle;">
                        <asp:Label ID="lblAgregarActividad" runat="server" Text="Agregar Articulo " Font-Bold="True"
                            Font-Size="11px" />&nbsp;<asp:ImageButton ID="imgbButtonAdd" runat="server" ImageUrl="~/images/buttons/add.png"
                                OnClick="imgbButtonAdd_Click" Width="22px" Height="22px" />
                    </td>
                    <td style="width: 13%; vertical-align: middle;">
                        <asp:Label ID="lblNroPedido" runat="server" Text="N° de Pedido  " Font-Bold="True"
                            Font-Size="11px" />&nbsp;
                        <asp:Label ID="lblNroPedido2" runat="server" Text="N° de Pedido  " Font-Bold="True"
                            Font-Size="11px" />&nbsp;
                            
                           <%-- <project:proyecto id="ctlProyecto" runat="server" />--%>
                    </td>
<%--                    <td style="width: 13%; vertical-align: middle;">
                        <asp:Label ID="lblAgregarSolicitante" runat="server" Text="Agregar Solicitante  "
                            Font-Bold="True" Font-Size="11px" />&nbsp;
                            <project:solicitante id="ctlSolicitante"
                                runat="server" />
                    </td>--%>
                    <td style="width: 13%; vertical-align: middle;">
                        <asp:Label ID="lblTotalPedido" runat="server" Text="Total Pedido " Font-Bold="True"
                            Font-Size="11px" />&nbsp;
                                                    <asp:Label ID="lblTotalPedido2" runat="server" Text="Total Pedido " Font-Bold="True"
                            Font-Size="11px" />&nbsp;
                            <%--<project:empemp id="ctlEmpresaEmpleado" runat="server" />--%>
                    </td>
                    <td align="center">
                        <asp:UpdateProgress ID="upgForm" runat="server" AssociatedUpdatePanelID="upaEdicion"
                            DisplayAfter="0" DynamicLayout="false">
                            <ProgressTemplate>
                                <asp:Image ID="imgLoad" runat="server" ImageUrl="~/images/progress_bar.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                    <td style="width: 15%; vertical-align: middle; text-align: right;">
                        <asp:Label ID="Label9" runat="server" Text="Registro por Pedido " Font-Bold="True"
                            Font-Size="11px" />&nbsp;<asp:ImageButton ID="imgbVistaDetallada" runat="server"
                                ImageUrl="~/images/buttons/view_detailed.png" Width="26px" Height="26px" ToolTip="Vista Detallada"
                                OnClick="imgbVistaDetallada_Click" CausesValidation="true" />
                    </td>
                    <td style="width: 11%; vertical-align: middle; text-align: right;">
                        <asp:Label ID="Label11" runat="server" Text="Refrescar Datos " Font-Bold="True" Font-Size="11px" />&nbsp;<asp:ImageButton
                            ID="imgbRefresh" runat="server" ImageUrl="~/images/buttons/restaurar.png" Width="26px"
                            Height="26px" ToolTip="Refrescar Página" OnClick="imgbRefresh_Click" />
                    </td>
                    <td style="width: 2%;">
                    </td>
                </tr>
            </table>
            </asp:Panel>

                <asp:Panel runat="server" ID="pnlPedidosAll" Width="99%">
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
                                                Lista de Pedidos</div>
                                            <div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapsePlanificados" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDetallesPlanificado" runat="server" Width="100%">
                                        <br />
                                        <asp:GridView ID="gvwPedido" Width="100%" runat="server" OnRowCommand="gvwPedido_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            DataKeyNames="IdPedido" GridLines="None" OnPageIndexChanging="gvwPedido_PageIndexChanging"
                                            AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                                            OnRowDataBound="gvwPedido_DataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%"
                                                    HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DisplayIndex + 1 %>
                                                        <asp:HiddenField ID="hdnIdEmpleados" runat="server" Value='<%# Bind("IdPedido") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Editar">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/edit.png"
                                                            Height="18px" Width="18px" CommandName="Editar" CommandArgument='<%# Bind("IdPedido") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver" Visible="False">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdPedido") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdPedido" HeaderText="Nro. Pedido" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalPedido" HeaderText="Monto Total" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Pedido" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                                                               <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false" Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Comentario" />
                                                <asp:TemplateField HeaderText="Estado">
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
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" 
                                                        OnSelectedIndexChanged="ddlPagegvPedido_SelectedIndexChanged">
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <ajax:CollapsiblePanelExtender ID="cpePlanificados" runat="Server" TargetControlID="pnlDetallesPlanificado"
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
                                                    <b style="font-size: 11px; font-family: Tahoma;">Leyenda :</b>&nbsp;<img src="../../images/circle_silver1.png" />
                                                    <asp:Label ID="Label10" runat="server" Text="Enviado" Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp;
                                                    <img src="../../images/circle_green.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label3" runat="server" Text="Recibido " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp;
                                                    <img src="../../images/circle_yellow.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label4" runat="server" Text="Pendiente de Entrega " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp;
                                                    <img src="../../images/circle_orange.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label1" runat="server" Text="Entregado " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp;
                                                    <img src="../../images/circle_red.png" width="18px" height="18px" /><asp:Label ID="Label2"
                                                        runat="server" Text="Rechazado" Font-Size="11px" Font-Names="Tahoma" />
                                                </asp:Panel>
                                            </td>
                                            <td align="right" style="width: 50%;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="center" style="width: 2%;">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="center" style="width: 100px;">
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
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
                <asp:Panel ID="pnlPedidoEditar" Visible="False" runat="server" Width="99%">
                        <table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 96%">
                                                                    <asp:Panel ID="pnlCollapseFormulario" runat="server" CssClass="collapsePanelHeader"
                                        Width="100%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Detalle de Pedido</div>
                                            <div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapseFormulario" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>

                                    

                <asp:Panel ID="Formulario" runat="server">
                    <asp:HiddenField runat="server" ID="hdnEstado" />
                    <br />
                    <asp:GridView ID="gvPedidoDetalle" Width="100%" runat="server" OnRowCommand="gvPedidoDetalle_RowCommand"
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                        GridLines="None" OnPageIndexChanging="gvPedidoDetalle_PageIndexChanging" AllowPaging="True"
                        CssClass="mGrid" PagerStyle-CssClass="PagerStyle" 
                        EmptyDataText="No se encontraron resultados, para la búsqueda realizada." 
                        onrowupdating="gvPedidoDetalle_RowUpdating">
                        <Columns>
                                                                        <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%"
                                                    HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DisplayIndex + 1 %>
                                                        <asp:HiddenField ID="hdnIdArticulo" runat="server" Value='<%# Bind("IdArticulo") %>' />
                                                        <asp:HiddenField ID="hdnCantidad" runat="server" Value='<%# Eval("Cantidad") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Editar" 
                                Visible="False">
                                <HeaderStyle Width="7%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/edit.png"
                                        Height="18px" Width="18px" CommandName="Editar" CommandArgument='<%# Bind("IdPedido") %>'>
                                    </asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ver" Visible="False">
                                <HeaderStyle Width="7%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                        Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdPedido") %>'>
                                    </asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                                           
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
                                                    ItemStyle-Width="10%" 
                                ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Cantidad">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="txt" ValidationGroup="RegCantidad"
                                                            MaxLength="4" Style="text-align: center;" Text='<%# Eval("Cantidad") %>'>>
                                                        </asp:TextBox></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                               <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" 
                                ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnAgregar" runat="server" AlternateText="Actualizar Articulo"
                                                            ImageUrl="~/images/editar.gif" Height="18px" Width="18px" ToolTip="Actualizar Cantidad"
                                                            CommandName="Actualizar"  CommandArgument='<%# Container.DisplayIndex + 1 %>'></asp:ImageButton>
                                                        <%-- <ajax:ConfirmButtonExtender ID="cbeAgregar" runat="server" TargetControlID="btnAgregar"
                                                            ConfirmText='<%# "¿Está seguro(a) que desea Agregar el Articulo seleccionado?" %>'>
                                                        </ajax:ConfirmButtonExtender>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
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
                                                    <asp:Label runat="server" ID="Label8" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:DropDownList ID="ddlPagegvPedidoDetalle" runat="server" AutoPostBack="true" 
                                                        OnSelectedIndexChanged="ddlPagegvPedidoDetalle_SelectedIndexChanged">
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" TargetControlID="pnlDetallesPlanificado"
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

                 <asp:Panel ID="pnlPedidoAgregarAll" Visible="False" runat="server" Width="99%">
                        <table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 96%">
                                                                    <asp:Panel ID="pnlCollapsePedidoAgregar" runat="server" CssClass="collapsePanelHeader"
                                        Width="100%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Agregar Pedido</div>
                                            <div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapsePedidoAgregar" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>


                                    
                <asp:Panel ID="pnlPedidoAgregar" runat="server">

                    <br />
                                        <asp:GridView ID="gvPedidoAgregar" Width="100%" runat="server" OnRowCommand="gvPedidoAgregar_RowCommand"
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                        GridLines="None" OnPageIndexChanging="gvPedidoAgregar_PageIndexChanging" AllowPaging="True"
                        CssClass="mGrid" PagerStyle-CssClass="PagerStyle" 
                        EmptyDataText="No se encontraron resultados, para la búsqueda realizada." 
                        onrowupdating="gvPedidoAgregar_RowUpdating">
                        <Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%"
                                                    HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DisplayIndex + 1 %>
                                                        <asp:HiddenField ID="hdnIdArticulo" runat="server" Value='<%# Bind("IdArticulo") %>' />
                                                        <asp:HiddenField ID="hdnNombreArticulo" runat="server" Value='<%# Bind("NombreArticulo") %>' />
                                                        <asp:HiddenField ID="hdnPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
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
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Cantidad">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="txt" ValidationGroup="RegCantidad"
                                                            MaxLength="4" Style="text-align: center;">
                                                        </asp:TextBox></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnAgregar" runat="server" AlternateText="Agergar Articulo"
                                                            ImageUrl="~/images/buttons/new.png" Height="18px" Width="18px" ToolTip="Agregar Articulo"
                                                            CommandName="Agregar" CommandArgument='<%# Container.DisplayIndex + 1 %>'></asp:ImageButton>
                                                        <%--                                                        <ajax:ConfirmButtonExtender ID="cbeAgregar" runat="server" TargetControlID="btnAgregar"
                                                            ConfirmText='<%# "¿Está seguro(a) que desea Agregar el Articulo seleccionado?" %>'>
                                                        </ajax:ConfirmButtonExtender>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="PagerStyle" />
                                            <RowStyle BackColor="White" ForeColor="#717171" Font-Bold="false" Font-Names="Tahoma"
                                                Font-Size="11px" />
                                            <AlternatingRowStyle BackColor="#E7F6FD" ForeColor="#717171" Font-Bold="false" Font-Names="Tahoma"
                                                Font-Size="11px" />
                                            <FooterStyle BackColor="White" ForeColor="Black" Font-Names="Tahoma" Font-Size="11px"
                                                Height="30px" />
                                            <EmptyDataRowStyle Width="99%" Height="100px" Font-Bold="true" Font-Names="Tahoma"
                                                Font-Size="11px" HorizontalAlign="Center" BackColor="White" BorderColor="White"
                                                VerticalAlign="Middle" ForeColor="Black" />
                                        </asp:GridView>








                                                            <br />
                                        <table width="99%">
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="Label12" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:DropDownList ID="ddlPagegvPedidoAgregar" runat="server" AutoPostBack="true" 
                                                        OnSelectedIndexChanged="ddlPagegvPedidoAgregar_SelectedIndexChanged">
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="Server" TargetControlID="pnlDetallesPlanificado"
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

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:Panel ID="pnlCambiarFoto" runat="server" Width="600px" Height="220px" Style="display: none;
        background-color: White;" CssClass="modalPopup">
        <asp:Panel ID="Panel3" runat="server" Style="cursor: move; background-image: url(../../images/headerform.gif);
            border: solid 1px Gray; color: #5f524a">
            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 85%">
                            <asp:Label ID="Label5" runat="server" Text="Cambiar Foto" Font-Bold="True" ForeColor="White"
                                Font-Size="12px" />
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="CancelButton" runat="server" ImageUrl="../../images/exit.png" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <br />
        <br />
        <table width="100%">
            <tr>
                <td align="center">
                    <%--                    <ajax:AsyncFileUpload runat="server" ID="afuFoto" Width="500px" UploaderStyle="Modern"
                        OnClientUploadComplete="uploadComplete" PersistFile="true" ToolTip="Seleccionar Foto"
                        AccessKeyUploadingBackColor="#B0C4DE" ThrobberID="myThrobber" UploadingBackColor="#B0C4DE"
                        CompleteBackColor="#B0C4DE" />
                    <asp:Label runat="server" ID="myThrobber" Style="display: none;"><img alt="" src="../../images/iconos16x16/uploading.gif" /></asp:Label>--%>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <div style="display: none; text-align: center;" id="dvFileInfo">
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label6" Text="Nombre del archivo: " runat="server" />&nbsp;<asp:Label
                            ID="lblNameArchivo" Font-Bold="true" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label7" Text="Tamaño del archivo: " runat="server" />&nbsp;<asp:Label
                            ID="lblSizeArchivo" Font-Bold="true" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: none; width: 100%; text-align: center;" id="dvFileErrorInfo">
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblErrorArchivo" ForeColor="Red" Font-Bold="true" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="display: none; width: 100%; text-align: center;" id="dvUpLoad">
            <table width="100%">
                <tr>
                    <td align="center">
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <ajax:ModalPopupExtender ID="mpeCambiarImagen" runat="server" TargetControlID="lnkOculto"
        PopupControlID="pnlCambiarFoto" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
        DropShadow="true" PopupDragHandleControlID="Panel3" />
    <asp:HiddenField ID="hdnRutaTemp" runat="server" />
    <asp:LinkButton ID="lnkOculto" runat="server" />
</asp:Content>
