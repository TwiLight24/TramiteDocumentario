<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Documento.aspx.cs" Inherits="CapaWeb.pages.documento.Documento"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../styles/Style.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/General.js" type="text/javascript"></script>
    <script src="../../scripts/Concurrent_Thread.js" type="text/javascript"></script>
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="panProgreso" runat="server" Width="100%">
            <table id="panTabs" cellspacing="2" cellpadding="5" width="100%" border="0" style="background-color: #0B52A0">
                <tr>
                    <td width="33%" style="vertical-align: middle;">
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Ingreso de Documentos</asp:Label>
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
                                    <asp:ListItem Value="China Bolts">China Bolts</asp:ListItem>
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
                                    <asp:ListItem Value="2">Fecha Resgistro</asp:ListItem>
                                    <asp:ListItem Value="3">Id Documento</asp:ListItem>
                                    <asp:ListItem Value="4">Nr. Orden</asp:ListItem>
                                    <asp:ListItem Value="5">Nr. Documento</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="19%">
                                &nbsp;<asp:TextBox ID="txtTipoBusqueda" runat="server" Width="96%" />
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="3%">
                                &nbsp;<asp:ImageButton runat="server" ID="btnTipoBusqueda" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnTipoBusqueda_Click" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Width="20%">
                                <asp:CheckBox ID="chkEliminados" runat="server" Text="&nbsp;Mostrar Documentos desactivados."
                                    AutoPostBack="True" OnCheckedChanged="chkEliminados_CheckedChanged" />&nbsp;&nbsp;
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="7%"
                                BackColor="#e6e6fa">
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="ibNuevoEmpleado" runat="server" ImageUrl="~/images/buttons/add.png"
                                    Width="30px" Height="30px" OnClick="ibNuevoEmpleado_Click" ToolTip="Agregar Documento" />
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
                                            CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada." OnSelectedIndexChanged="gvwEmpleado_SelectedIndexChanged"><Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%"
                                                    HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DisplayIndex + 1 %>
                                                        <asp:HiddenField ID="hdnIdDocumento" runat="server" Value='<%# Bind("IdDocumento") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Editar">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/edit.png"
                                                            Height="18px" Width="18px" CommandName="Editar" CommandArgument='<%# Bind("IdDocumento") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
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
                                                <asp:BoundField DataField="IdDocumento" HeaderText="Id Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <%--Descomentar cuando den visto bueno (visible='true')--%>
                                                <asp:ButtonField Text="....." HeaderText="Doc. Adjuntos" ButtonType="Link"
                                                    CommandName="VerAdjuntos" Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>

                                                <asp:BoundField DataField="Ruc" HeaderText="Ruc" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NOrden" HeaderText="NOrden" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TipoDoc" HeaderText="Tipo Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="FePago" HeaderText="Fecha Pago" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}">
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
                <asp:Panel ID="pnlBusOrden" runat="server" DefaultButton="btnBuscarOrden">
                    <asp:Table ID="Table2" runat="server" CssClass="group">
                        <asp:TableHeaderRow CssClass="headerrow">
                            <asp:TableCell ID="tcBusOrdenTitulo" ColumnSpan="4" Text="&nbsp;Busqueda a SAP"></asp:TableCell></asp:TableHeaderRow><asp:TableRow>
                            <asp:TableCell Text="Empresa: " CssClass="header"></asp:TableCell><asp:TableCell
                                CssClass="edit">
                                <asp:DropDownList ID="ddlEmpresaBusOrden" runat="server" Width="185px" CssClass="ddl"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlEmpresaBusOrden_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="MIMSA">MIMSA</asp:ListItem>
                                    <asp:ListItem Value="MEGA">MEGA</asp:ListItem>
                                    <asp:ListItem Value="RUMI">RUMI</asp:ListItem>
                                    <asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem>
                                    <asp:ListItem Value="POSTES">POSTES</asp:ListItem>
                                    <asp:ListItem Value="Steel Form">Steel Form</asp:ListItem>
                                    <asp:ListItem Value="China Bolts">China Bolts</asp:ListItem>
                                    <asp:ListItem Value="DOBLE RR">DOBLE RR</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ErrorMessage="Seleccione Empresa "
                                    ForeColor="Red" Font-Bold="True" InitialValue="-1" ControlToValidate="ddlEmpresaBusOrden"
                                    Display="None" ValidationGroup="BusOrden" />
                            </asp:TableCell><asp:TableCell CssClass="header">
                            Tipo:
                                <asp:DropDownList ID="ddlTipoBusSap" runat="server" Width="70%" CssClass="ddl"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlTipoBusSap_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="0">Nr. de Orden : </asp:ListItem>
                                    <asp:ListItem Value="1">RUC :</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Seleccione Tipo de Busqueda SAP "
                                    ForeColor="Red" Font-Bold="True" InitialValue="-1" ControlToValidate="ddlTipoBusSap"
                                    Display="None" ValidationGroup="BusOrden" />
                            </asp:TableCell><asp:TableCell CssClass="edit">
                                &nbsp;<asp:TextBox ID="txtNrOrdenBusOrden" runat="server" Width="300px" />
                                <asp:RequiredFieldValidator ID="rfvOrdenBusOrden" runat="server" ErrorMessage="Ingrese Nr. Orden"
                                    ForeColor="Red" Font-Bold="True" ControlToValidate="txtNrOrdenBusOrden" Display="None"
                                    ValidationGroup="BusOrden" />
                                <ajax:FilteredTextBoxExtender ID="fteNrOrdenBusOrden" runat="server" TargetControlID="txtNrOrden"
                                    FilterType="Numbers" ValidChars=" ñÑ" />
                                <asp:ImageButton runat="server" ID="btnBuscarOrden" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnBuscarOrden_Click" ValidationGroup="BusOrden" />
                            </asp:TableCell></asp:TableRow></asp:Table><br /><asp:ValidationSummary runat="server" ID="ValidationSummary1" DisplayMode="BulletList"
                        ShowSummary="false" ShowMessageBox="true" ValidationGroup="BusOrden" HeaderText="Se encontraron los siguientes inconvenientes : " />
                    <%--    Name:<asp:TextBox ID="txtName" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="display: none" />--%>
                </asp:Panel>
                <asp:Panel ID="Formulario" runat="server" Visible="false">
                    <asp:HiddenField runat="server" ID="hdnEstado" />
                        <asp:Table ID="tblItem1" runat="server" CssClass="group">
                        <asp:TableHeaderRow CssClass="headerrow">
                            <asp:TableCell ID="tcTitulo" ColumnSpan="4" Text="&nbsp;Información General"></asp:TableCell></asp:TableHeaderRow>
                        
                        
                        
                            <asp:TableRow runat="server">
                                <asp:TableCell Text="IdDocumento: " CssClass="header" runat="server"></asp:TableCell>
                                <asp:TableCell CssClass="edit" runat="server">&nbsp;<asp:TextBox ID="txtIdDocumento" runat="server" Width="180px" TabIndex="1" Enabled="False" /></asp:TableCell>
            
                                <asp:TableCell Text="Empresa: " CssClass="header" runat="server"></asp:TableCell>
                                <asp:TableCell CssClass="edit" runat="server"><asp:DropDownList ID="ddlEmpresa" AutoPostBack="True" runat="server" Width="185px" CssClass="ddl" TabIndex="12" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                        <asp:ListItem Value="MIMSA">MIMSA</asp:ListItem>
                                        <asp:ListItem Value="MEGA">MEGA</asp:ListItem>
                                        <asp:ListItem Value="RUMI">RUMI</asp:ListItem>
                                        <asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem>
                                        <asp:ListItem Value="POSTES">POSTES</asp:ListItem>
                                        <asp:ListItem Value="Steel Form">Steel Form</asp:ListItem>
                                        <asp:ListItem Value="China Bolts">China Bolts</asp:ListItem>
                                        <asp:ListItem Value="DOBLE RR">DOBLE RR</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                        
                        
                            <asp:TableRow>
                                <asp:TableCell Text="Proveedor :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtProveedor" runat="server" Width="180px" TabIndex="2" />
                                </asp:TableCell>
            
                                <asp:TableCell Text="Nr. de Orden :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtNrOrden" runat="server" Width="180px" TabIndex="13" />
                                    <ajax:FilteredTextBoxExtender ID="fteNombreEmpleado" runat="server" TargetControlID="txtNrOrden" FilterType="Numbers" ValidChars=" ñÑ" />
                                </asp:TableCell>
                            </asp:TableRow>
                        
                        
                            <asp:TableRow>
                                <asp:TableCell Text="RUC :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit"> &nbsp;<asp:TextBox ID="txtRuc" runat="server" Width="180px" TabIndex="3" />
                                </asp:TableCell>
            
                                <asp:TableCell Text="Moneda :&nbsp;" CssClass="header" Enabled="false"></asp:TableCell>
                                <asp:TableCell VerticalAlign="Middle" Width="1%">&nbsp;
                                    <asp:DropDownList ID="ddlTMoneda" runat="server" AutoPostBack="True" Width="20%" TabIndex="14" OnSelectedIndexChanged="ddlTMoneda_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                        <asp:ListItem Value="SOL">SOL</asp:ListItem>
                                        <asp:ListItem Value="USD">USD</asp:ListItem>
                                        <asp:ListItem Value="EUR">EUR</asp:ListItem>                              
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                        
                        
                            <asp:TableRow>
                                <asp:TableCell Text="Nr. Documento :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtNrDocumento" runat="server" Width="180px" TabIndex="4" />
                                </asp:TableCell>
            
                                <asp:TableCell Text="Forma de Pago :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit"> &nbsp;<asp:TextBox ID="txtFrPago" runat="server" Width="180px" TabIndex="15" />
                                </asp:TableCell>
                            </asp:TableRow>
                      
                        
                            <asp:TableRow>
                                <asp:TableCell Text="Tipo de Documento :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;
                                    <asp:DropDownList ID="ddlTDocumento" AutoPostBack="true" runat="server" Width="185px" CssClass="ddl" OnSelectedIndexChanged="ddlTDocumento_SelectedIndexChanged" TabIndex="5">
                                        <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                        <asp:ListItem Value="Factura">Factura</asp:ListItem>
                                        <asp:ListItem Value="Solicitud de Anticipo">Solicitud de Anticipo</asp:ListItem>
                                        <asp:ListItem Value="Nota de Credito">Nota de Credito</asp:ListItem>
                                        <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                        <asp:ListItem Value="Letra">Letra</asp:ListItem>
                                        <asp:ListItem Value="Nota de Debito">Nota de Debito</asp:ListItem>
                                        <asp:ListItem Value="Comp. Retenc.">Comp. Retenc.</asp:ListItem>
                                        <asp:ListItem Value="Comp. Percep.">Comp. Percep.</asp:ListItem>
                                        <asp:ListItem Value="Recibo Honor.">Recibo Honor.</asp:ListItem>
                                        <asp:ListItem Value="Boleta">Boleta</asp:ListItem>
                                        <asp:ListItem Value="Nota Contable">Nota Contable</asp:ListItem>
                                        <asp:ListItem Value="Nota de Credito">Nota de Crédito</asp:ListItem>
                                        <asp:ListItem Value="Liquidacion de Cobranza">Liquidación de Cobranza</asp:ListItem>
                                        <asp:ListItem Value="Lote de Importacion">Lote de Importación</asp:ListItem>
                                        <asp:ListItem Value="Recibo de Caja">Recibo de Caja</asp:ListItem>
                                        <asp:ListItem Value="Recibo">Recibo</asp:ListItem>
                                        <asp:ListItem Value="Aviso de Cobranza">Aviso de Cobranza</asp:ListItem>
                                        <asp:ListItem Value="Gastos de representacion">Gastos de representacion</asp:ListItem>
                                        <asp:ListItem Value="Gastos de Combustible">Gastos de Combustible</asp:ListItem>
                                        <asp:ListItem Value="Caja Chica">Caja Chica</asp:ListItem>
                                        <asp:ListItem Value="Otros">Otros</asp:ListItem>
                                        <asp:ListItem Value="Reembolso">Reembolso</asp:ListItem>
                                        <asp:ListItem Value="ER">Entrega a Rendir</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="rfvTDocumento" runat="server" ErrorMessage="Seleccione Tipo De Documento " ForeColor="Red" Font-Bold="True" InitialValue="-1" ControlToValidate="ddlTDocumento" Display="None" ValidationGroup="Project" />--%>
                                </asp:TableCell>
            
                                <asp:TableCell Text="Tipo :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;
                                    <asp:DropDownList ID="ddlTipo" AutoPostBack="true" runat="server" Width="185px" CssClass="ddl" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" TabIndex="16">
                                        <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                        <asp:ListItem Value="Articulo">Articulo</asp:ListItem>
                                        <asp:ListItem Value="Servicio">Servicio</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                   
                        
                            <asp:TableRow>
                                <asp:TableCell Text="Fecha de Recepcion :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtFechaRecepcion" runat="server" Width="180px" ValidationGroup="Project"
                                                        OnTextChanged="txtFechaRecepcion_DateChanged" onblur="javascript:esFechaValida(this)" AutoPostBack="True" TabIndex="6" />
                                    <ajax:CalendarExtender ID="ceEmpleado1" runat="server" TargetControlID="txtFechaRecepcion" PopupButtonID="txtFechaRecepcion" Enabled="True" Format="dd/MM/yyyy" />
                                    <ajax:MaskedEditExtender ID="meeFNacimiento1" runat="server" TargetControlID="txtFechaRecepcion"
                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" ErrorTooltipEnabled="True"
                                        Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" />
                                </asp:TableCell>

                                <asp:TableCell Text="Fecha de Vencimiento :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtFechaVen" runat="server" Width="180px" ValidationGroup="Project"
                                                        onblur="javascript:esFechaValida(this)" AutoPostBack="True" TabIndex="17" />
                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaVen" PopupButtonID="txtFechaVen" Enabled="True" Format="dd/MM/yyyy" />
                                    <ajax:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFechaVen"
                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" Enabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
                                </asp:TableCell>
                            </asp:TableRow>
                        

                            <asp:TableRow>
                                <asp:TableCell Text="Fecha de Documento :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtFechaDoc" runat="server" Width="180px" ValidationGroup="Project" onblur="javascript:esFechaValida(this)" TabIndex="7" />
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDoc" PopupButtonID="txtFechaDoc" Enabled="True" Format="dd/MM/yyyy " />
                                    <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFechaDoc"
                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" ErrorTooltipEnabled="True"
                                        Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" />
                                </asp:TableCell>

                                <asp:TableCell Text="Monto Inicial" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtMonIni" runat="server" Width="180px" TabIndex="18" />
                                </asp:TableCell>
                            </asp:TableRow>            
                        
                        
                            <asp:TableRow>
                                <asp:TableCell Text="Monto Facturado :&nbsp;" CssClass="header" Enabled="false"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtMonFac" runat="server" Width="180px" TabIndex="8" />
                                </asp:TableCell>
            
                                <asp:TableCell Text="Saldo Actual :&nbsp;" CssClass="header" Enabled="false"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtSaldAct" runat="server" Width="180px" TabIndex="19" />
                                </asp:TableCell>
                            </asp:TableRow>
                   
                        
                            <asp:TableRow>
                                <asp:TableCell Text="Comentario :&nbsp;" CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtComentario" runat="server" Width="300px" TabIndex="9" /></asp:TableCell>
                            
                                <asp:TableCell Text="Fact. Reserva SAP : " CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtFactReserva" runat="server" Width="180px" TabIndex="20" /></asp:TableCell>
                            </asp:TableRow>
                        
                        
                            <asp:TableRow>
                                <asp:TableCell runat="server" CssClass="header">Nro ER:</asp:TableCell>
                                <asp:TableCell runat="server" CssClass="edit">&nbsp;<asp:TextBox ID="txtNroEr" runat="server" Width="60px" TabIndex="10" /><ajax:FilteredTextBoxExtender ID="fteNroEr" runat="server" TargetControlID="txtNroEr" FilterType="Numbers" ValidChars=" ñÑ" /></asp:TableCell>

                                <asp:TableCell Text="Cantidad de Comprobantes de Pago : " CssClass="header"></asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="txtCanComPago" runat="server" Width="180px" TabIndex="21" /></asp:TableCell>
                            </asp:TableRow>
                        

                            <asp:TableRow>
                                <asp:TableCell runat="server" CssClass="header">Fecha de Pago</asp:TableCell>
                                <asp:TableCell CssClass="edit">&nbsp;<asp:TextBox ID="TxtFePago" runat="server" Width="180px" ValidationGroup="Project" onblur="javascript:esFechaValida(this)" TabIndex="11" />
                                    <ajax:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtFePago" PopupButtonID="TxtFePago" Enabled="True" Format="dd/MM/yyyy " />
                                    <ajax:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="TxtFePago"
                                            Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" ErrorTooltipEnabled="True"
                                            Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" />
                                </asp:TableCell>

                                <asp:TableCell Text="Prioridad :&nbsp;" CssClass="header" Visible="true"></asp:TableCell>
                                <asp:TableCell CssClass="edit" Visible="true">&nbsp;
                                    <asp:DropDownList ID="ddlTipoPrioridad" AutoPostBack="true" runat="server" Width="185px" CssClass="ddl" OnSelectedIndexChanged="ddlPrioridad_SelectedIndexChanged" TabIndex="22">
                                        <asp:ListItem Value="-1">---- Seleccionar ----</asp:ListItem>
                                        <asp:ListItem Value="Urgente">Urgente</asp:ListItem>
                                        <asp:ListItem Value="No Urgente">No Urgente</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>
                    
                    <br />
                    <asp:Table ID="tSeguridad" runat="server" CssClass="group" Visible="false">
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
                                <asp:Panel ID="pnlAdjuntar" runat="server" Visible="false" HorizontalAlign="Center">
                                    <br />
                                        <%--Descomentar cuando den visto bueno (visible='true')--%>
                                        <asp:FileUpload ID="FileUpload1" Visible="false" runat="server" onchange="document.getElementById('btnHidden').click();" />
                                        <asp:Button ID="btnHidden" runat="server" OnClick="FileUpload1_Changed" Style="display:none;" />
                                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
                                        <%--Descomentar cuando den visto bueno (visible='true')--%>
                                        <asp:GridView ID="dgvDocAdjuntos" Visible="false" Width="100%" runat="server" OnRowCommand="gvwEmpleado_RowCommand" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt" GridLines="None" AllowPaging="True" OnRowDeleting="dgvDocAdjuntos_RowDeleting"
                                            CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada." OnSelectedIndexChanged="gvwDocAdjuntos_SelectedIndexChanged"><PagerStyle CssClass="PagerStyle" />
                                            <AlternatingRowStyle CssClass="alt" />

                                            <Columns>
                                                    <asp:ButtonField Text="Eliminar" HeaderText="" ButtonType="Link"
                                                    CommandName="Delete">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>                                                
                                            </Columns>

                                            <Columns></Columns><EmptyDataRowStyle Font-Bold="True" ForeColor="Blue" />
                                        </asp:GridView>

                                    <br /></asp:Panel></td>
                                <td>

                                <asp:Panel ID="pnlGrabar2" runat="server" HorizontalAlign="Center" Visible="false">
                                    <br />
                                    <asp:ImageButton ID="btnGrabar2" runat="server" ImageUrl="~/images/buttons/save.png"
                                        ToolTip="Grabar Empleado" ValidationGroup="Project" OnClick="btnGrabar_Click" 
                                        TabIndex="18"  /><br />
                                        <%--ClientIDMode="Static" OnClientClick="test(); "--%>
                                    <asp:Label ID="Label1" CssClass="label" Text="Grabar" runat="server" ></asp:Label><br /></asp:Panel></td><td>
                                <asp:Panel ID="pnlEliminar" runat="server" HorizontalAlign="Center" Visible="false">
                                    <br />
                                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/buttons/block.png"
                                        ToolTip="Desactivar Empleado" OnClick="btnEliminar_Click" Height="32px" Width="32px"
                                        TabIndex="19" /><ajax:ConfirmButtonExtender ID="cbeEliminar" runat="server" TargetControlID="btnEliminar"
                                            ConfirmText="¿Está seguro que desea desactivar el empleado?">
                                        </ajax:ConfirmButtonExtender>
                                    <br />
                                    <asp:Label ID="Label3" CssClass="label" Text="Desactivar" runat="server"></asp:Label><br /></asp:Panel></td><td>
                                <asp:Panel ID="pnlRestaurar" runat="server" Visible="false" HorizontalAlign="Center"
                                    Height="60px" Width="77px">
                                    <br />
                                        <asp:ImageButton ID="btnRestaurar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/button_check.png"
                                            OnClick="btnRestaurar_Click" ToolTip="Restaurar Documento" TabIndex="20" Height="35px"
                                            Width="48px" /><ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                                TargetControlID="btnRestaurar" ConfirmText="¿Está seguro que desea restaurar el Documento?">
                                        </ajax:ConfirmButtonExtender>
                                    <br />
                                <asp:Label ID="Label5" CssClass="label" Text="Restaurar" runat="server"></asp:Label><br /></asp:Panel></td><td>
                                
                                <asp:Panel ID="pnlLimpiar" runat="server" Visible="false" HorizontalAlign="Center">
                                    <br />
                                    <asp:ImageButton ID="btnlimpiar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/restaurar.png"
                                        OnClick="btnlimpiar_Click" TabIndex="21" /><br />
                                    <asp:Label ID="Label8" CssClass="label" Text="Limpiar" runat="server"></asp:Label><br /></asp:Panel></td><td>
                                <asp:Panel ID="pnlCancelar2" runat="server" Visible="false" HorizontalAlign="Center">
                                    <br />
                                    <asp:ImageButton ID="btnCancelar2" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/cancel.png"
                                        OnClick="btnCancelar_Click" ToolTip="Cancelar" TabIndex="22" /><br />
                                    <asp:Label ID="Label9" CssClass="label" Text="Cancelar" runat="server"></asp:Label><br /></asp:Panel></td></tr></table><br /><asp:ValidationSummary runat="server" ID="frmEmpleado" DisplayMode="BulletList" ShowSummary="false"
                                    ShowMessageBox="true" ValidationGroup="Project" HeaderText="Se encontraron los siguientes inconvenientes : " />
                                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnHidden" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:HiddenField ID="hdnRutaTemp" runat="server" />
    <asp:LinkButton ID="lnkOculto" runat="server" />
</asp:Content>
