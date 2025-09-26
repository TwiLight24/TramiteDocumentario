<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true" CodeBehind="PlantillaGenerar.aspx.cs" Inherits="CapaWeb.PeUtiles.pages.administracion.PlantillaGenerar" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../styles/Style.css" rel="stylesheet" type="text/css" />
    <script src="../../../scripts/General.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"> </script>
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
                <asp:Panel runat="server" ID="pnlBusqueda" DefaultButton="btnBusqueda">
                    <asp:Table ID="Table1" Width="99%" runat="server" BorderColor="#e6e6fa" BorderWidth="1"
                        Height="40px">
                        <asp:TableRow>
                            <asp:TableCell ID="Contenedor1" HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header" Width="5%">
                                
                            </asp:TableCell>
                            <asp:TableCell ID="Contenedor2" VerticalAlign="Middle" Width="15%">
                                
                            </asp:TableCell><asp:TableCell ID="Contenedor3" HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                Width="5%">
         
                            </asp:TableCell><asp:TableCell ID="Contenedor4" VerticalAlign="Middle" Width="15%">
                               
                            </asp:TableCell><asp:TableCell  ID="Contenedor5" VerticalAlign="Middle" Width="5%">
                              &nbsp;<asp:ImageButton runat="server" ID="btnBusqueda" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnBusqueda_Click" />                      
                                     </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Center" Width="20%">
                                <asp:CheckBox ID="chkEliminados" runat="server" Text="&nbsp;Mostrar Articulos desactivados."
                                    AutoPostBack="True" OnCheckedChanged="chkEliminados_CheckedChanged" />&nbsp;&nbsp;
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="7%"
                                BackColor="#e6e6fa">
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="ibAgregarPlantilla" runat="server" ImageUrl="~/images/buttons/add.png"
                                    Width="30px" Height="30px" OnClick="ibAgregarPlantilla_Click" ToolTip="Agregar Plantilla" />
                            </asp:TableCell></asp:TableRow></asp:Table></asp:Panel>
      <asp:Panel runat="server" ID="pnlProyectosAll" Width="99%">
      <table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 96%">
                                    <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanelHeader"
                                        Width="100%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Lista de Plantillas</div><div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" Width="100%">
                                        <br />

                                          
                                          <asp:GridView ID="gvwPlantilla" Width="100%" runat="server" OnRowCommand="gvwPlantilla_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            DataKeyNames="IdPlantilla" GridLines="None" OnPageIndexChanging="gvwPlantilla_PageIndexChanging"
                                            AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                                            OnRowDataBound="gvwPlantilla_DataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAllPlantillas" runat="server" OnCheckedChanged="chkAllPlantillas_CheckedChanged"
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
                                                        <asp:HiddenField ID="hdnIdPlantillas" runat="server" Value='<%# Bind("IdPlantilla") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Editar">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/edit.png"
                                                            Height="18px" Width="18px" CommandName="Editar" CommandArgument='<%# Bind("IdPlantilla") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdPlantilla") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdPlantilla" HeaderText="Id Plantilla" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NombreUsuarioModificacion" 
                                                    HeaderText="Usuario Modificacion" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Modificacion"
                                                    ItemStyle-VerticalAlign="Middle" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" DataFormatString="{0:dd/MM/yyyy}"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Activo" HeaderText="Estado" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Activo">
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
                                                <td>
                                                    <asp:Label runat="server" ID="Label5" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server" 
                                                        AutoPostBack="true" 
                                                        OnSelectedIndexChanged="ddlPlantillaPage_SelectedIndexChanged">
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem><asp:ListItem Text="30" Value="30"></asp:ListItem><asp:ListItem Text="50" Value="50"></asp:ListItem><asp:ListItem Text="100" Value="100"></asp:ListItem></asp:DropDownList></td><td>
                                                    &nbsp; </td><td>
                                                    &nbsp; </td></tr></table><ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" TargetControlID="pnlDetallesPlanificado"
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
                    <br />
                    <asp:Panel ID="pnlProyectosPlanificados" Visible="false" runat="server" Width="99%">
                    <asp:HiddenField runat="server" ID="hdnEstado" />
                        <table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 96%">
                                    <asp:Panel ID="pnlCollapsePlanificados" runat="server" CssClass="collapsePanelHeader"
                                        Width="100%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Lista de Articulos</div><div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapsePlanificados" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDetallesPlanificado" runat="server" Width="100%">
                                        <br />

                                          
                                          <asp:GridView ID="gvwArticulos" Width="100%" runat="server" OnRowCommand="gvwArticulos_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            DataKeyNames="IdPlantilla,IdArticulo" GridLines="None" OnPageIndexChanging="gvwArticulos_PageIndexChanging"
                                            AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                                            OnRowDataBound="gvwArticulos_DataBound" PageSize="150">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAllArticulos" runat="server" OnCheckedChanged="chkAllArticulos_CheckedChanged"
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
                                                        <asp:HiddenField ID="hdnIdPlantilla" runat="server" Value='<%# Bind("IdPlantilla") %>' />
                                                        <asp:HiddenField ID="hdnIdArticulo" runat="server" Value='<%# Bind("IdArticulo") %>' />
                                                        <asp:HiddenField ID="hdnEstado" runat="server" Value='<%# Bind("Activo") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Editar">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/edit.png"
                                                            Height="18px" Width="18px" CommandName="Editar" CommandArgument='<%# Bind("IdArticulo") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdArticulo") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdArticulo" HeaderText="Id Articulo" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NombreArticulo" HeaderText="Descripción" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UnidadMedida" HeaderText="UMedida" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Precio" 
                                                    HeaderText="Precio" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CantidadTope" HeaderText="Tope" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Activo" HeaderText="Estado" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaRegistro" HeaderText="FecEnvío"
                                                    ItemStyle-VerticalAlign="Middle" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Wrap="false" DataFormatString="{0:dd/MM/yyyy}" Visible="False"><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Activo">
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
                                                <td>
                                                    <asp:Label runat="server" ID="lblPaginacion" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlPage" runat="server" 
                                                        AutoPostBack="true" 
                                                        OnSelectedIndexChanged="ddlArticuloPage_SelectedIndexChanged">
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem><asp:ListItem Text="30" Value="30"></asp:ListItem><asp:ListItem Text="50" Value="50"></asp:ListItem><asp:ListItem Text="100" Value="100"></asp:ListItem></asp:DropDownList></td><td>
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
                                                    <b style="font-size: 11px; font-family: Tahoma;">Leyenda :</b>&nbsp;<img src="../../../images/circle_silver1.png" /> <asp:Label ID="Label10" runat="server" Text="Ingresado" Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../../images/circle_green.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label3" runat="server" Text="Recibido " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../../images/circle_yellow.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label4" runat="server" Text="Pendiente de Recepción " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../../images/circle_orange.png" width="18px" height="18px" /><asp:Label
                                                        ID="Label1" runat="server" Text="En Proceso " Font-Size="11px" Font-Names="Tahoma" />
                                                    &nbsp; <img src="../../../images/circle_red.png" width="18px" height="18px" /><asp:Label ID="Label2"
                                                        runat="server" Text="Rechazado" Font-Size="11px" Font-Names="Tahoma" />
                                                </asp:Panel>
                                            </td>
                                            <td align="right" style="width: 50%;">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtComentario" runat="server" Width="300px" TabIndex="17" />
                                                        </td>
                                                        <td align="center" style="width: 2%;">
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btnEnviar" CssClass="button" Text="Enviar" OnClick="btnEnviar_Click"
                                                                Style="color: White; background: url(../../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" />
                                                            <ajax:ConfirmButtonExtender ID="cbeAprobar" runat="server" TargetControlID="btnEnviar"
                                                                ConfirmText="¿Está seguro que desea Registrar estos Articulos?">
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
               <%-- </asp:Panel>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:HiddenField ID="hdnRutaTemp" runat="server" />
</asp:Content>

