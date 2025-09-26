<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="VistaAsistentePagos.aspx.cs" Inherits="CapaWeb.pages.herramientas.VistaAsistentePagos" %>

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
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Asistente de Pagos</asp:Label>
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
                <asp:Panel runat="server" ID="pnlBusqueda">
                    <asp:Table ID="Table1" Width="99%" runat="server" BorderColor="#e6e6fa" BorderWidth="1"
                        Height="40px">
                        <asp:TableRow>

                            <asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header" Width="6%">
                                <asp:Label ID="lblSearch" runat="server" Text="Fecha Inicio :" />&nbsp;
                            </asp:TableCell>

                            <asp:TableCell VerticalAlign="Middle" Width="12%">&nbsp;
                                <asp:TextBox ID="txtFechaInicio" runat="server" Width="180px" ValidationGroup="Project"
                                                        onblur="javascript:esFechaValida(this)" AutoPostBack="True" TabIndex="17" OnTextChanged="txtFechaInicio_TextChanged"/>
                                    <ajax:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaInicio" PopupButtonID="txtFechaInicio" Enabled="True" Format="dd/MM/yyyy" />
                                    <ajax:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFechaInicio"
                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" Enabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
                            </asp:TableCell>

                            <asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header" Width="6%">
                                <asp:Label ID="Label1" runat="server" Text="Fecha Fin :" />&nbsp;
                            </asp:TableCell>

                            <asp:TableCell VerticalAlign="Middle" Width="12%">&nbsp;
                                <asp:TextBox ID="txtFechaFin" runat="server" Width="180px" ValidationGroup="Project"
                                                        onblur="javascript:esFechaValida(this)" AutoPostBack="True" TabIndex="17" OnTextChanged="txtFechaFin_TextChanged"/>
                                    <ajax:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFechaFin" PopupButtonID="txtFechaFin" Enabled="True" Format="dd/MM/yyyy" />
                                    <ajax:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtFechaFin"
                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" Enabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
                            </asp:TableCell>

                            <asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header" Width="5%">
                                <asp:Label ID="lblnroplanilla" runat="server" Text="Nro Planilla :" />&nbsp;
                            </asp:TableCell>

                            <asp:TableCell VerticalAlign="Middle" Width="11%">&nbsp;
                                <asp:DropDownList ID="ddlnroplanilla" runat="server" AutoPostBack="True"
                                    Width="94%" OnSelectedIndexChanged="ddlnroplanilla_SelectedIndexChanged">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="MIMSA">MIMSA</asp:ListItem>
                                    <asp:ListItem Value="MEGA">MEGA</asp:ListItem>
                                    <asp:ListItem Value="RUMI">RUMI</asp:ListItem>
                                    <asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem>
                                    <asp:ListItem Value="POSTES">POSTES</asp:ListItem>
                                    <asp:ListItem Value="Steel Form">Steel Form</asp:ListItem>
                                    <asp:ListItem Value="DOBLE RR">DOBLE RR</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                            
                            <asp:TableCell VerticalAlign="Middle" Width="3%">&nbsp;
                                <asp:Button ID="btnCorreoGG" runat="server" 
                                    Text="Enviar a GG" CssClass="button"  Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                    width: 100px; height: 26px; font: 11px Tahoma;" 
                                    onclick="btnCorreoGG_Click" Visible = "false" />
                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnCorreoGG"
                                                                ConfirmText="¿Está seguro que desea Enviar la Planilla a Gerencia General?">
                                                            </ajax:ConfirmButtonExtender>
                            </asp:TableCell>

                            <asp:TableCell VerticalAlign="Middle" Width="3%">&nbsp;
                                <asp:Button ID="btnAceptar" runat="server" 
                                    Text="Aceptar" CssClass="button"  Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                    width: 100px; height: 26px; font: 11px Tahoma;" 
                                    onclick="btnAceptar_Click" />
                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="btnAceptar"
                                                                ConfirmText="¿Está seguro que desea Aceptar la Planilla?">
                                                            </ajax:ConfirmButtonExtender>
                            </asp:TableCell>

                            <asp:TableCell VerticalAlign="Middle" Width="3%">&nbsp;
                                <asp:Button ID="btnRechazar" runat="server" 
                                    Text="Rechazar" CssClass="button"  Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                    width: 100px; height: 26px; font: 11px Tahoma;" 
                                    onclick="btnRechazar_Click" />
                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnRechazar"
                                                                ConfirmText="¿Está seguro que desea Rechazar la Planilla?">
                                                            </ajax:ConfirmButtonExtender>
                            </asp:TableCell>

                        </asp:TableRow></asp:Table></asp:Panel><asp:Panel runat="server" ID="pnlProyectosAll" Width="99%">
                    <br />
                    <asp:Panel ID="pnlProyectosPlanificados" Visible="true" runat="server" Width="99%">
                        <table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 96%">
                                    <asp:Label ID="lblestadoPlanilla" runat="server" Font-Bold="true" Font-Size="13px"></asp:Label><asp:Image ID="imgestadoPlanilla" runat="server" />

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
                                            GridLines="None" OnPageIndexChanging="gvwEmpleado_PageIndexChanging" 
                                            CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada.">
                                            <Columns>
                                                <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%"
                                                    HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# Container.DisplayIndex + 1 %>
                                                        <asp:HiddenField ID="hdnIdDocumento" runat="server" Value='<%# Bind("IdDoc") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
                                                
                                                <asp:ButtonField DataTextField="Id" HeaderText="Id Doc." ButtonType="Link" Visible="False"
                                                    CommandName="VerRegMov">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>
                                                
                                                <asp:ButtonField Text="....." HeaderText="Doc. Adjuntos" ButtonType="Link"
                                                    CommandName="VerAdjuntos">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>
                                                
                                                <asp:BoundField DataField="DocEntry" HeaderText="DocEntry" ItemStyle-VerticalAlign="Middle" Visible="False"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="True">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TipoDoc" HeaderText="Tipo Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NumeroDoc" HeaderText="Numero Doc">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" Wrap="False" />
                                                </asp:BoundField>
                                                
												<asp:BoundField DataField="FechaDoc" HeaderText="Fecha Doc" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}" Visible="True">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaVen" HeaderText="Fecha Ven" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}" Visible="True">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Desc" HeaderText="Desc">
                                                    
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalDocumento" HeaderText="Total Documento">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Retencion" HeaderText="Retencion">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Detraccion" HeaderText="Detraccion">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MontoPagado" HeaderText="Monto Pagado">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" Wrap="False" />
                                                </asp:BoundField>
												
                                            </Columns>
                                            <%--<PagerStyle CssClass="PagerStyle" />--%>
                                            <AlternatingRowStyle CssClass="alt" />
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Blue" />
                                        </asp:GridView>
                                        <table style="table-layout: fixed; width: 100%;">
                                            <tr>
                                                <td style="width: 2%;"></td> <!-- Columna 1 -->
                                                <td style="width: 4%;"></td> <!-- Columna 2 -->
                                                <td style="width: 10%;"></td> <!-- Columna 3 -->
                                                <td style="width: 6%;"></td> <!-- Columna 4 -->
                                                <td style="width: 6%;"></td> <!-- Columna 5 -->
                                                <td style="width: 5%;"></td> <!-- Columna 6 -->
                                                <td style="width: 6%;"></td> <!-- Columna 7 -->
                                                <td style="width: 7%;"></td> <!-- Columna 8 -->
                                                <td style="width: 3.5%; text-align: center;">
                                                    <asp:Label runat="server" ID="totalDoc" Text="0.00" Font-Bold="true" />
                                                </td>
                                                <td style="width: 3%; text-align: center;">
                                                    <asp:Label runat="server" ID="totalRetencion" Text="0.00" Font-Bold="true" />
                                                </td>
                                                <td style="width: 3%; text-align: center;">
                                                    <asp:Label runat="server" ID="totalDetraccion" Text="0.00" Font-Bold="true" />
                                                </td> <!-- Detracción -->
                                                <td style="width: 3.5%; text-align: center;">
                                                    <asp:Label runat="server" ID="montoPagodo" Text="0.00" Font-Bold="true" />
                                                </td> <!-- Monto Pagado -->
                                            </tr>
                                        </table>

                                        <br />
                                        <table width="99%">
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPaginacion" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem><asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem><asp:ListItem Text="30" Value="30"></asp:ListItem><asp:ListItem Text="40" Value="40"></asp:ListItem></asp:DropDownList></td><td>
                                                    &nbsp; </td><td>
                                                    &nbsp; </td></tr></table><ajax:CollapsiblePanelExtender ID="cpePlanificados" runat="Server" TargetControlID="pnlDetallesPlanificado"
                                            ExpandControlID="pnlCollapsePlanificados" CollapseControlID="pnlCollapsePlanificados"
                                            Collapsed="false" ImageControlID="imgCollapsePlanificados" ExpandedText="(Ocultar Detalles)"
                                            CollapsedText="(Ver Detalles)" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
                                            SuppressPostBack="true" SkinID="CollapsiblePanel" />

                                        <br />
                                        <asp:Label ID="Label11" runat="server" Text="Motivo de Rechazo" Font-Bold="True"></asp:Label><br /><asp:TextBox ID="txt_motivo" runat="server" MaxLength="200" TabIndex="18" Width="320px" />
                                    </asp:Panel>
                                </td>
                                <td class="style1">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:HiddenField ID="hdnRutaTemp" runat="server" />
    <asp:LinkButton ID="lnkOculto" runat="server" />
</asp:Content>
