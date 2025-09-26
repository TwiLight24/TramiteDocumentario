<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true"
    CodeBehind="Principal.aspx.cs" Inherits="CapaWeb.PeUtiles.Principal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Style.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/General.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"> </script>
    <style type="text/css">
        .style1
        {
            width: 11px;
        }
        .style2
        {
            width: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="panProgreso" runat="server" Width="100%">
            <table id="panTabs" cellspacing="2" cellpadding="5" width="100%" border="0" style="background-color: #0B52A0">
                <tr>
                    <td width="33%" style="vertical-align: middle;">
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Pedido de Articulos</asp:Label>
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
                <asp:Panel runat="server" ID="pnlBusqueda" DefaultButton="btnTipoBusqueda">
                    <asp:Table ID="Table1" Width="99%" runat="server" BorderColor="#e6e6fa" BorderWidth="1"
                        Height="40px">
                        <asp:TableRow>
                            <asp:TableCell ID="Contenedor1" HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                Width="5%">
                                <asp:Label ID="lblEmpresaSearch" runat="server" Text="Grupo :" />&nbsp;
                            </asp:TableCell><asp:TableCell ID="Contenedor2" VerticalAlign="Middle" Width="11%">
                                &nbsp;<asp:DropDownList ID="ddlGrupoSearch" runat="server" AutoPostBack="True" Width="94%"
                                    OnSelectedIndexChanged="ddlGrupoSearch_SelectedIndexChanged">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell><asp:TableCell ID="Contenedor6" HorizontalAlign="Right" VerticalAlign="Middle"
                                CssClass="header" Width="15%">
                                <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="True" Width="94%"
                                    OnSelectedIndexChanged="ddlTipoBusqueda_SelectedIndexChanged">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="1">Id Árticulo</asp:ListItem>
                                    <asp:ListItem Value="2">Descripción</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell><asp:TableCell ID="Contenedor7" VerticalAlign="Middle" Width="19%">
                                &nbsp;<asp:TextBox ID="txtTipoBusqueda" runat="server" Width="96%" />
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="3%">
                                &nbsp;<asp:ImageButton runat="server" ID="btnTipoBusqueda" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnTipoBusqueda_Click" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Width="20%">
<%--                                <asp:CheckBox ID="chkEliminados" runat="server" Text="&nbsp;Mostrar Documentos desactivados."
                                    AutoPostBack="True" OnCheckedChanged="chkEliminados_CheckedChanged" />&nbsp;&nbsp;--%>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="7%"
                                BackColor="#e6e6fa">
                                &nbsp;&nbsp;
<%--                                <asp:ImageButton ID="ibDistribucion" runat="server" ImageUrl="~/images/buttons/add.png"
                                    Width="30px" Height="30px" OnClick="ibDistribucion_Click" ToolTip="Distribuir Documentos" />--%>
                            </asp:TableCell></asp:TableRow></asp:Table></asp:Panel><br /><asp:Panel runat="server" ID="pnlProyectosAll" Width="99%">
                    <br />
                    <asp:Panel ID="pnlProyectosPlanificados" Visible="true" runat="server" Width="99%">
                        <table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 75%">
                                    <asp:Panel ID="pnlCollapsePlanificados" runat="server" CssClass="collapsePanelHeader"
                                        Width="98%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Lista de Artículo </div><div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapsePlanificados" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlPedidoArticulos" runat="server" Width="98%">
                                        <br />
                                        <asp:GridView ID="gvwArticulo" Width="100%" runat="server" OnRowCommand="gvwArticulo_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            ShowFooter="True" CssClass="NewGrid" DataKeyNames="IdArticulo" Style="padding: 5px 8px 5px 8px;
                                            font-weight: bold; white-space: normal; font-family: Tahoma; font-size: 11px;
                                            border: solid 1px #A6C4E0; border-collapse: collapse; background-color: #2CB2EB;
                                            vertical-align: middle; background-repeat: repeat-x; background-position: top;
                                            background-image: url(../../images/headergvw.gif); height: 20px; color: White;"
                                            BorderStyle="Solid" BorderWidth="1px" BorderColor="#A6C4E0" PageSize="20" OnPageIndexChanging="gvwArticulo_PageIndexChanging"
                                            AllowPaging="True" PagerStyle-CssClass="PagerStyle" 
                                            EmptyDataText="No se encontraron resultados, para la búsqueda realizada."><Columns>
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
                                                    <asp:Label runat="server" ID="lblPaginacion" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem><asp:ListItem Text="30" Value="30"></asp:ListItem><asp:ListItem Text="50" Value="50"></asp:ListItem><asp:ListItem Text="80" Value="80"></asp:ListItem><asp:ListItem Text="100" Value="100"></asp:ListItem></asp:DropDownList></td><td>
                                                    &nbsp; </td><td>
                                                    &nbsp; </td></tr></table><ajax:CollapsiblePanelExtender ID="cpePlanificados" runat="Server" TargetControlID="pnlPedidoArticulos"
                                            ExpandControlID="pnlCollapsePlanificados" CollapseControlID="pnlCollapsePlanificados"
                                            Collapsed="false" ImageControlID="imgCollapsePlanificados" ExpandedText="(Ocultar Detalles)"
                                            CollapsedText="(Ver Detalles)" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
                                            SuppressPostBack="true" SkinID="CollapsiblePanel" />
                                    </asp:Panel>
                                </td>
                                <td class="style1">
                                </td>
                                <td style="width: 35%">
                                    <asp:Panel ID="pnlCollapseCarrito" runat="server" CssClass="collapsePanelHeader"
                                        Width="98%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Carrito de Útiles</div><div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapseCarrito" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlCarrito" runat="server" Width="98%">
                                        <br />
                                        <br />
                                        <asp:GridView ID="gvwEmple" Width="100%" runat="server" AutoGenerateColumns="true"
                                            CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt" GridLines="None"
                                            AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="PagerStyle" 
                                            EmptyDataText="No se encontraron resultados, para la búsqueda realizada." 
                                            onrowcommand="gvwEmple_RowCommand" 
                                            onpageindexchanging="gvwEmple_PageIndexChanging"><Columns>
                                            					        <asp:TemplateField HeaderText="Eliminar">
						        <HeaderStyle Width="7%"></HeaderStyle>
						        <ItemStyle HorizontalAlign="Center"></ItemStyle>
						        <ItemTemplate>
							        <asp:ImageButton id="btnEliminar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/borrar.png" Height="18px" Width="18px"
								        CommandName="Eliminar" CommandArgument='<%# Bind("IdArticulo") %>'></asp:ImageButton>
                                        <ajax:ConfirmButtonExtender ID="cbeEliminar1" runat="server" TargetControlID="btnEliminar"
                                        ConfirmText="¿Está seguro que desea quitar el Artículo?">
                                    </ajax:ConfirmButtonExtender>
						        </ItemTemplate>
					        </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                        <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" TargetControlID="pnlCarrito"
                                            ExpandControlID="pnlCollapseCarrito" CollapseControlID="pnlCollapseCarrito" Collapsed="false"
                                            ImageControlID="imgCollapseCarrito" ExpandedText="(Ocultar Detalles)" CollapsedText="(Ver Detalles)"
                                            ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
                                            SuppressPostBack="true" SkinID="CollapsiblePanel" />
                                            <asp:Label id="lblTotalPedido" runat="server" Text="Total Pedido"> </asp:Label>&nbsp;&nbsp; <asp:TextBox 
                                            ID="txtTotalPedido" runat="server" Width="30%" Enabled="False" /><br />
                                            <asp:Button runat="server" ID="btnEnviar" CssClass="button" Text="Enviar" OnClick="btnEnviar_Click"
                                            Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                            width: 100px; height: 26px; font: 11px Tahoma;" />
                                        <ajax:ConfirmButtonExtender ID="cbeAprobar" runat="server" TargetControlID="btnEnviar"
                                            ConfirmText="¿Está seguro que desea Registrar el Pedido?">
                                        </ajax:ConfirmButtonExtender>
                                    </asp:Panel>
                                </td>
                                <%--                                <td class="style1">
                                </td>--%>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
