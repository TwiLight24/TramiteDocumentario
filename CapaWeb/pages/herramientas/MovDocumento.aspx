<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="MovDocumento.aspx.cs" Inherits="CapaWeb.pages.herramientas.MovDocumento" %>

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
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Movimientos de Documentos</asp:Label>
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
                            </asp:TableCell><asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                Width="11%">
                                <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="True" Width="94%">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="1">Cargo</asp:ListItem>
                                    <asp:ListItem Value="2">Fecha Envío</asp:ListItem>
                                    <asp:ListItem Value="3">Id Documento</asp:ListItem>
                                    <asp:ListItem Value="4">Nr. Orden</asp:ListItem>
                                    <asp:ListItem Value="5">Nr. Documento</asp:ListItem>
                                    <asp:ListItem Value="6">Fact. Reserva</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="19%">
                                &nbsp;<asp:TextBox ID="txtTipoBusqueda" runat="server" Width="96%" />
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="3%">
                                &nbsp;<asp:ImageButton runat="server" ID="btnTipoBusqueda" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnTipoBusqueda_Click" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Width="20%">
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="7%"
                                BackColor="#e6e6fa">
                                &nbsp;&nbsp;
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
                                                Documentos</div><div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapsePlanificados" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDetallesPlanificado" runat="server" Width="100%">
                                        <br />
                                        <asp:GridView ID="gvwEmpleado" Width="100%" runat="server" OnRowCommand="gvwEmpleado_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            GridLines="None" OnPageIndexChanging="gvwEmpleado_PageIndexChanging" AllowPaging="True"
                                            CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada.">
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%"
                                                    HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DisplayIndex + 1 %>
                                                        <asp:HiddenField ID="hdnIdDocumento" runat="server" Value='<%# Bind("IdDocumento") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdDocumento") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField DataTextField="IdDocumento" HeaderText="Id Doc." ButtonType="Link"
                                                    CommandName="VerRegMov">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>
                                                <asp:BoundField DataField="IdMovimiento" HeaderText="Id Mov." ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Ruc" HeaderText="Ruc" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <%--Descomentar cuando den visto bueno (visible='true')--%>
                                                <asp:ButtonField Text="....." HeaderText="Doc. Adjuntos" ButtonType="Link"
                                                    CommandName="VerAdjuntos" Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>
                                                
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NCargo" HeaderText="Cargo" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NOrden" HeaderText="NOrden" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DocNumFactReserva" HeaderText="Fact. Reserva" />
                                                <asp:BoundField DataField="NroDoc" HeaderText="Nr. Documento" />
                                                <asp:BoundField DataField="TipoDoc" HeaderText="Tipo Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NombreUsuarioOrigen" HeaderText="Envía" />
                                                <asp:BoundField DataField="NombreUsuarioDestino" HeaderText="Recibe" />
												<asp:BoundField DataField="FePagoR" HeaderText="FecPago" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}" Visible="True">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}" Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
												
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
                </asp:Panel>
                <asp:Panel ID="Formulario" runat="server" Visible="false">
                    <asp:HiddenField runat="server" ID="hdnEstado" />
                    <asp:Table ID="tblItem1" runat="server" CssClass="group">
                        <asp:TableHeaderRow CssClass="headerrow">
                            <asp:TableCell ID="tcTitulo" ColumnSpan="4" Text="&nbsp;Información General"></asp:TableCell></asp:TableHeaderRow><asp:TableRow>
                            <asp:TableCell Text="IdDocumento: " CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtIdDocumento" runat="server" Width="180px" TabIndex="9"
                                    Enabled="False" />
                            </asp:TableCell><asp:TableCell Text="Empresa: " CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                <asp:DropDownList ID="ddlEmpresa" AutoPostBack="true" runat="server" Width="185px"
                                    CssClass="ddl" TabIndex="1" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="MIMSA">MIMSA</asp:ListItem>
                                    <asp:ListItem Value="MEGA">MEGA</asp:ListItem>
                                    <asp:ListItem Value="RUMI">RUMI</asp:ListItem>
                                    <asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem>
                                    <asp:ListItem Value="POSTES">POSTES</asp:ListItem>
                                    <asp:ListItem Value="Steel Form">Steel Form</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvPrefijo" runat="server" ErrorMessage="Seleccione Empresa "
                                    ForeColor="Red" Font-Bold="True" InitialValue="-1" ControlToValidate="ddlEmpresa"
                                    Display="None" ValidationGroup="Project" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="Proveedor :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtProveedor" runat="server" Width="180px" TabIndex="10" />
                                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ErrorMessage="Ingrese Proveedor"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtProveedor" Display="None"
                                    ValidationGroup="Project" />
                            </asp:TableCell><asp:TableCell Text="Nr. de Orden :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtNrOrden" runat="server" Width="180px" TabIndex="2" />
                                <asp:RequiredFieldValidator ID="rfvNombreEmpleado" runat="server" ErrorMessage="Ingrese Nr. Orden"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtNrOrden" Display="None"
                                    ValidationGroup="Project" />
                                <ajax:FilteredTextBoxExtender ID="fteNombreEmpleado" runat="server" TargetControlID="txtNrOrden"
                                    FilterType="Numbers" ValidChars=" ñÑ" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="RUC :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtRuc" runat="server" Width="180px" TabIndex="11" />
                                <asp:RequiredFieldValidator ID="rfvPPaterno" runat="server" ErrorMessage="Ingrese RUC"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtRuc" Display="None" ValidationGroup="Project" />
                            </asp:TableCell><asp:TableCell Text="Moneda :&nbsp;" CssClass="header" Enabled="false"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtMoneda" runat="server" Width="180px" TabIndex="3" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="Nr. Documento :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtNrDocumento" runat="server" Width="180px" TabIndex="12" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Nr. Documento"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtNrDocumento" Display="None"
                                    ValidationGroup="Project" />
                            </asp:TableCell><asp:TableCell Text="Forma de Pago :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtFrPago" runat="server" Width="180px" TabIndex="4" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Foma de Pago"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtFrPago" Display="None"
                                    ValidationGroup="Project" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="Tipo de Documento :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:DropDownList ID="ddlTDocumento" AutoPostBack="true" runat="server" Width="185px"
                                    CssClass="ddl" OnSelectedIndexChanged="ddlTDocumento_SelectedIndexChanged" TabIndex="13">
                                    <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="Factura">Factura</asp:ListItem>
                                    <asp:ListItem Value="Nota de Credito">Nota de Credito</asp:ListItem>
                                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                    <asp:ListItem Value="Letra">Letra</asp:ListItem>
                                    <asp:ListItem Value="Nota de Debito">Nota de Debito</asp:ListItem>
                                    <asp:ListItem Value="Comp. Retenc.">Comp. Retenc.</asp:ListItem>
                                    <asp:ListItem Value="Comp. Percep.">Comp. Percep.</asp:ListItem>
                                    <asp:ListItem Value="Recibo Honor.">Recibo Honor.</asp:ListItem>
                                    <asp:ListItem Value="Boleta">Boleta</asp:ListItem>
                                    <asp:ListItem Value="Otros">Otros</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTDocumento" runat="server" ErrorMessage="Seleccione Tipo De Documento "
                                    ForeColor="Red" Font-Bold="True" InitialValue="-1" ControlToValidate="ddlTDocumento"
                                    Display="None" ValidationGroup="Project" />
                            </asp:TableCell><asp:TableCell Text="Tipo :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:DropDownList ID="ddlTipo" AutoPostBack="true" runat="server" Width="185px"
                                    CssClass="ddl" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" TabIndex="5">
                                    <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="Articulo">Articulo</asp:ListItem>
                                    <asp:ListItem Value="Servicio">Servicio</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTipo" runat="server" ErrorMessage="Seleccione Tipo "
                                    ForeColor="Red" Font-Bold="True" InitialValue="-1" ControlToValidate="ddlTipo"
                                    Display="None" ValidationGroup="Project" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="Fecha de Recepcion :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtFechaRecepcion" runat="server" Width="180px" ValidationGroup="Project"
                                    onblur="javascript:esFechaValida(this)" AutoPostBack="True" TabIndex="14" />
                                <ajax:CalendarExtender ID="ceEmpleado1" runat="server" TargetControlID="txtFechaRecepcion"
                                    PopupButtonID="txtFechaRecepcion" Enabled="True" Format="dd/MM/yyyy" />
                                <ajax:MaskedEditExtender ID="meeFNacimiento1" runat="server" TargetControlID="txtFechaRecepcion"
                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" ErrorTooltipEnabled="True"
                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" />
                            </asp:TableCell><asp:TableCell Text="Fecha de Vencimiento :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtFechaVen" runat="server" Width="180px" ValidationGroup="Project"
                                    onblur="javascript:esFechaValida(this)" AutoPostBack="True" TabIndex="6" />
                                <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaVen"
                                    PopupButtonID="txtFechaVen" Enabled="True" Format="dd/MM/yyyy" />
                                <ajax:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFechaVen"
                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" Enabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="Fecha de Documento :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtFechaDoc" runat="server" Width="180px" ValidationGroup="Project"
                                    onblur="javascript:esFechaValida(this)" TabIndex="15" />
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDoc"
                                    PopupButtonID="txtFechaDoc" Enabled="True" Format="dd/MM/yyyy" />
                                <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFechaDoc"
                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" ErrorTooltipEnabled="True"
                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" />
                            </asp:TableCell><asp:TableCell Text="Monto Inicial" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtMonIni" runat="server" Width="180px" TabIndex="7" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Foma de Pago"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtMonIni" Display="None"
                                    ValidationGroup="Project" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="Monto Facturado :&nbsp;" CssClass="header" Enabled="false"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtMonFac" runat="server" Width="180px" TabIndex="16" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese Monto Facturado"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtMonFac" Display="None"
                                    ValidationGroup="Project" />
                            </asp:TableCell><asp:TableCell Text="Saldo Actual :&nbsp;" CssClass="header" Enabled="false"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtSaldAct" runat="server" Width="180px" TabIndex="8" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese Saldo Actual"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtSaldAct" Display="None"
                                    ValidationGroup="Project" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Text="Comentario :&nbsp;" CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtComentario" runat="server" Width="300px" TabIndex="17" />
                            </asp:TableCell></asp:TableRow></asp:Table><br /><asp:Table ID="tSeguridad" runat="server" CssClass="group" Visible="false">
                        <asp:TableHeaderRow CssClass="headerrow">
                            <asp:TableCell ColumnSpan="2" Text="&nbsp;Detalles de Seguridad"></asp:TableCell></asp:TableHeaderRow><asp:TableRow>
                            <asp:TableCell Width="15%" HorizontalAlign="Right" BackColor="#e6e6fa" Height="10px">
                            </asp:TableCell><asp:TableCell>
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Width="15%" HorizontalAlign="Right" CssClass="header">
                                <asp:Label ID="Label2" runat="server" Text="Usuario Creador :" CssClass="label" />&nbsp;
                            </asp:TableCell><asp:TableCell>
                                &nbsp;<asp:Label ID="lblUserReg" runat="server" CssClass="label" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Width="15%" HorizontalAlign="Right" CssClass="header">
                                <asp:Label ID="Label4" runat="server" Text="Último Cambio :" CssClass="label" />&nbsp;
                            </asp:TableCell><asp:TableCell>
                                &nbsp;<asp:Label ID="lblUserCambio" runat="server" CssClass="label" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell Width="15%" HorizontalAlign="Right" BackColor="#e6e6fa" Height="10px">
                            </asp:TableCell><asp:TableCell>
                            </asp:TableCell></asp:TableRow></asp:Table><table align="center" border="0" width="35%">
                        <tr>
                            <td>
                                <asp:Panel ID="pnlGrabar2" runat="server" HorizontalAlign="Center" Visible="false">
                                    <br />
                                    <asp:ImageButton ID="btnGrabar2" runat="server" ImageUrl="~/images/buttons/save.png"
                                        ToolTip="Grabar Empleado" ValidationGroup="Project" TabIndex="18" OnClick="btnGrabar2_Click" /><br />
                                    <asp:Label ID="Label1" CssClass="label" Text="Grabar" runat="server"></asp:Label><br /></asp:Panel></td><td>
                                <asp:Panel ID="pnlEliminar" runat="server" HorizontalAlign="Center" Visible="false">
                                    <br />
                                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/buttons/block.png"
                                        ToolTip="Desactivar Empleado" Height="32px" Width="32px" TabIndex="19" /><ajax:ConfirmButtonExtender
                                            ID="cbeEliminar" runat="server" TargetControlID="btnEliminar" ConfirmText="¿Está seguro que desea desactivar el empleado?">
                                        </ajax:ConfirmButtonExtender>
                                    <br />
                                    <asp:Label ID="Label3" CssClass="label" Text="Desactivar" runat="server"></asp:Label><br /></asp:Panel></td><td>
                                <asp:Panel ID="pnlRestaurar" runat="server" Visible="false" HorizontalAlign="Center"
                                    Height="50px" Width="65px">
                                    <br />
                                    <asp:ImageButton ID="btnRestaurar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/button_check.png"
                                        ToolTip="Restaurar Documento" TabIndex="20" Height="46px" Width="52px" /><ajax:ConfirmButtonExtender
                                            ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnRestaurar" ConfirmText="¿Está seguro que desea restaurar el Documento?">
                                        </ajax:ConfirmButtonExtender>
                                    <br />
                                    <asp:Label ID="Label5" CssClass="label" Text="Restaurar" runat="server"></asp:Label><br /></asp:Panel></td><td>
                                <asp:Panel ID="pnlLimpiar" runat="server" Visible="false" HorizontalAlign="Center">
                                    <br />
                                    <asp:ImageButton ID="btnlimpiar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/restaurar.png"
                                        TabIndex="21" /><br />
                                    <asp:Label ID="Label8" CssClass="label" Text="Limpiar" runat="server"></asp:Label><br /></asp:Panel></td><td>
                                <asp:Panel ID="pnlCancelar2" runat="server" Visible="false" HorizontalAlign="Center">
                                    <br />
                                    <asp:ImageButton ID="btnCancelar2" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/cancel.png"
                                        OnClick="btnCancelar_Click" ToolTip="Cancelar" TabIndex="22" /><br />
                                    <asp:Label ID="Label9" CssClass="label" Text="Cancelar" runat="server"></asp:Label><br /></asp:Panel></td></tr></table><br /><asp:ValidationSummary runat="server" ID="frmEmpleado" DisplayMode="BulletList" ShowSummary="false"
                        ShowMessageBox="true" ValidationGroup="Project" HeaderText="Se encontraron los siguientes inconvenientes : " />
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:HiddenField ID="hdnRutaTemp" runat="server" />
    <asp:LinkButton ID="lnkOculto" runat="server" />
</asp:Content>
