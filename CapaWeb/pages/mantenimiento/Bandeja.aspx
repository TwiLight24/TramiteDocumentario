<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Bandeja.aspx.cs" Inherits="CapaWeb.pages.mantenimiento.Bandeja" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../styles/Style.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/General.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"> </script>
    <style type="text/css">
        .style1
        {
            width: 607px;
        }
        .auto-style1 {
            width: 2%;
            height: 66px;
        }
        .auto-style2 {
            width: 48%;
            height: 66px;
        }
        .auto-style3 {
            width: 50%;
            height: 66px;
        }
        .auto-style5 {
            width: 100px;
            height: 83px;
        }
        .auto-style6 {
            height: 83px;
        }
        .auto-style7 {
            color: White;
            width: 100px;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 11px;
            line-height: normal;
            font-family: Tahoma;
            background: url('../../images/button_bg.png') no-repeat center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="panProgreso" runat="server" Width="100%">
            <table id="panTabs" cellspacing="2" cellpadding="5" width="100%" border="0" style="background-color: #0B52A0">
                <tr>
                    <td width="33%" style="vertical-align: middle;">
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Bandeja</asp:Label>
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
                            <asp:TableCell ID="Contenedor1" HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header" Width="5%">
                                <asp:Label ID="lblEmpresaSearch" runat="server" Text="Empresa :" />&nbsp;
                            </asp:TableCell><asp:TableCell ID="Contenedor2" VerticalAlign="Middle" Width="11%">
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
                            </asp:TableCell><asp:TableCell ID="Contenedor3" HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                Width="6%">
                                <asp:Label ID="lblSearch" runat="server" Text="Buscar :" />&nbsp;
                            </asp:TableCell><asp:TableCell ID="Contenedor4" VerticalAlign="Middle" Width="19%">
                                &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="96%" />
                            </asp:TableCell><asp:TableCell  ID="Contenedor5" VerticalAlign="Middle" Width="3%">
                                &nbsp;<asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnBuscar_Click" />
                            </asp:TableCell><asp:TableCell ID="Contenedor6" HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                Width="11%">
                               <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="True"
                                    Width="94%" OnSelectedIndexChanged="ddlTipoBusqueda_SelectedIndexChanged">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="1">Cargo</asp:ListItem>
                                    <asp:ListItem Value="2">Fecha Envío</asp:ListItem>
                                    <asp:ListItem Value="3">Id Documento</asp:ListItem>
                                    <asp:ListItem Value="4">Nr. Orden</asp:ListItem>
                                    <asp:ListItem Value="5">Nr. Documento</asp:ListItem>
                                    <asp:ListItem Value="6">Busqueda Masiva Id Documento</asp:ListItem> 
                                    <asp:ListItem Value="7">Fact. Reserva</asp:ListItem>                                         
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
                                                        <asp:HiddenField ID="hdnIdDocumento" runat="server" Value='<%# Bind("IdDocumento") %>' />
                                                        <asp:HiddenField ID="hdnMovimiento" runat="server" Value='<%# Bind("IdMovimiento") %>' />
                                                        <asp:HiddenField ID="hdnEstado" runat="server" Value='<%# Bind("Estado") %>' />
                                                        <asp:HiddenField ID="hdnOrigen" runat="server" Value='<%# Bind("Origen") %>' />
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
                                                <asp:TemplateField HeaderText="Ver">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnVer" runat="server"  CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdDocumento") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:HyperLinkField HeaderText="Id Documento"   
                                                    Target="_blank" Text="PDF" DataNavigateUrlFields="IdDocumento" 
                                                    DataNavigateUrlFormatString="~/pages/mantenimiento/VerPDF.aspx?IdDocumento={0}" 
                                                    DataTextField="IdDocumento" />--%>
                                                <asp:ButtonField DataTextField="IdDocumento" HeaderText="Id Doc." ButtonType="Link"
                                                    CommandName="VerRegMov">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>
                                                <%--Descomentar cuando den visto bueno (visible='true')--%>
                                                <asp:ButtonField Text="....." HeaderText="Doc. Adjuntos" ButtonType="Link"
                                                    CommandName="VerAdjuntos" Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="true"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="true"></HeaderStyle>
                                                </asp:ButtonField>

                                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="22%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="22%" Wrap="False" />
                                                </asp:BoundField>  
                                                <asp:BoundField DataField="FechaVen" HeaderText="Fec Vencimiento"
                                                    ItemStyle-VerticalAlign="Middle" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" DataFormatString="{0:dd/MM/yyyy}"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>                                                                                            
                                                <asp:BoundField DataField="tipodoc" 
                                                    HeaderText="Tipo Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NroDoc" HeaderText="Nr. Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DocNumFactReserva" 
                                                    HeaderText="Fact. Reserva" />
                                                <asp:BoundField DataField="Origen" HeaderText="ID Usuario Origen" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    Visible="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaRegistro" HeaderText="FecEnvío"
                                                    ItemStyle-VerticalAlign="Middle" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" DataFormatString="{0:dd/MM/yyyy}"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                               <asp:BoundField DataField="FePagoR" HeaderText="FecPago"
                                                    ItemStyle-VerticalAlign="Middle" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" DataFormatString="{0:dd/MM/yyyy}"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
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
                                           </asp:GridView><br /><table width="99%">
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label runat="server" ID="lblPaginacion" Text="Registros por Página : " />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <%--Descomentar cuando den visto bueno (visible='true')--%>
                                                <td>&nbsp;
                                                    <asp:Label ID="lblContar" runat="server" Text=""></asp:Label>

                                                    <asp:FileUpload ID="FileUpload1" Visible="false" runat="server" onchange="document.getElementById('btnHidden').click();" />
                                                    <asp:Button ID="btnHidden" runat="server" OnClick="FileUpload1_Changed" Style="display:none;"/>
                                                    
                                                </td>
                                                <td>&nbsp;
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
                                <asp:Panel ID="pnlLeyenda" runat="server" Height="97px"><table width="99%">
                                        <tr>
                                            <td align="left" class="auto-style1"></td>
                                            <td align="left" class="auto-style2"><asp:Panel runat="server" ID="paneLeyenda">
                                                    <b style="font-size: 11px; font-family: Tahoma;">Leyenda :</b>&nbsp;<img src="../../images/circle_silver1.png" /> <asp:Label ID="Label10" runat="server" Text="Ingresado" Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_green.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label3" runat="server" Text="Recibido " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_yellow.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label4" runat="server" Text="Pendiente de Recepción " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_orange.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label1" runat="server" Text="En Proceso " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../images/circle_red.png" width="18px" height="18px" /><asp:Label ID="Label2"
                                                        runat="server" Text="Rechazado" Font-Size="11px" Font-Names="Tahoma" />
                                                <br /><asp:Label ID="Label11" runat="server" Text="Motivo de Rechazo" Font-Bold="True"></asp:Label><br /><asp:TextBox ID="txt_motivo" runat="server" MaxLength="200" TabIndex="18" Width="320px" OnTextChanged="txt_motivo_TextChanged" />
												<br /><asp:Label ID="Label8" runat="server" Text="Fecha Pago" Font-Bold="True"></asp:Label><br /><asp:TextBox ID="TxtFecPago" runat="server" Width="180px" ValidationGroup="Project"
                                                    onblur="javascript:esFechaValida(this)" TabIndex="15" />
                                                    <ajax:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtFecPago" PopupButtonID="TxtFecPago" Enabled="True" Format="dd/MM/yyyy " />
                                                    <ajax:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="TxtFecPago"
                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="Left" ErrorTooltipEnabled="True"
                                                    Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                    CultureTimePlaceholder="" />
                                                
                                                <asp:Button runat="server" ID="btnactualizar" CssClass="button" Text="Actualizar" OnClick="btnactualizar_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" />
                                                            <%--<ajax:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="btnactualizar"
                                                                ConfirmText="¿Está seguro que desea actualizar estos Documentos?">
                                                            </ajax:ConfirmButtonExtender>--%>
                                                                                 </asp:Panel>
                                            </td>
                                            <td align="right" class="auto-style3"><table style="height: 54px"><tr>
                                                        <td align="center" class="auto-style6"><asp:TextBox ID="txtComentario" runat="server" Width="300px" TabIndex="17" />
                                                        <br /></td>
                                                        <td align="center" colspan="2" class="auto-style6"><asp:Button ID="btnExportar" runat="server" 
                                                                Text="Descargar Excel" CssClass="button"  Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" 
                                                                onclick="btnExportar_Click" /></td>
                                                        <td align="center" colspan="2" class="auto-style6"><asp:Button runat="server" ID="btnRecibir" CssClass="auto-style7" Text="Recibir" OnClick="btnRecibir_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" /><ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2"
                                                                    runat="server" TargetControlID="btnrecibir" ConfirmText="¿Está seguro que desea Recibir Estos Documentos?">
                                                                </ajax:ConfirmButtonExtender>
                                                        </td>
                                                        <td align="center" class="auto-style6"><asp:Button runat="server" ID="btnrechazar" CssClass="button" Text="Rechazar" OnClick="btnRechazar_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" /><ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1"
                                                                    runat="server" TargetControlID="btnrechazar" ConfirmText="¿Está seguro que desea Rechazar estos Documentos?">
                                                                </ajax:ConfirmButtonExtender>
                                                        </td>
                                                        <td align="center" class="auto-style5"><asp:DropDownList ID="ddlDestino" runat="server" AutoPostBack="True" Style="width: 100px; font: 11px Tahoma;">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center" class="auto-style6"><asp:Button runat="server" ID="btnEnviar" CssClass="button" Text="Enviar" OnClick="btnEnviar_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" />
                                                            <ajax:ConfirmButtonExtender ID="cbeAprobar" runat="server" TargetControlID="btnEnviar"
                                                                ConfirmText="¿Está seguro que desea Enviar estos Documentos?">
                                                            </ajax:ConfirmButtonExtender>
                                                        </td>
                                                        <td align="center" class="auto-style6"><asp:Button runat="server" ID="btnEliminar" CssClass="button" Text="Eliminar" OnClick="btnEliminar_Click"
                                                                style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" />
                                                            <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="btnEliminar"
                                                                ConfirmText="¿Está seguro que desea Eliminar estos Documentos?">
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
            <Triggers>
                <asp:PostBackTrigger ControlID="btnHidden" />
            </Triggers>
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
