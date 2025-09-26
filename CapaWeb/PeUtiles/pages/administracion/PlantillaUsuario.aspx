<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true" CodeBehind="PlantillaUsuario.aspx.cs" Inherits="CapaWeb.PeUtiles.pages.administracion.PlantillaUsuario" %>

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
                <asp:Panel runat="server" ID="pnlProyectosAll" Width="99%">
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
                                        <asp:GridView ID="gvwPlantilla" Width="100%" runat="server" OnRowCommand="gvwPlantilla_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            DataKeyNames="IdPlantilla" GridLines="None" OnPageIndexChanging="gvwPlantilla_PageIndexChanging"
                                            AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                                            OnRowDataBound="gvwPlantilla_DataBound" onload="gvwPlantilla_Load">
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
                                                        <asp:HiddenField ID="hdnIdUsuario" runat="server" Value='<%# Bind("IdUsuario") %>' />
                                                        <asp:HiddenField ID="hdnIdPlantillas" runat="server" Value='<%# Bind("IdPlantilla") %>' />
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
                                                            Height="18px" Width="18px" CommandName="Editar" CommandArgument='<%# Bind("IdPlantilla") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver" Visible="False">
                                                    <HeaderStyle Width="7%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdPlantilla") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="IdUsuario" HeaderText="Id Usuario" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" 
                                                    Wrap="False" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombres" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Area" HeaderText="Area" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                                    ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Lista Plantillas">
                                                    <HeaderStyle Width="20%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                    <asp:DropDownList ID="ddlPlantilla" runat="server" Width="94%" OnSelectedIndexChanged="ddlPlantilla_SelectedIndexChanged">
                                    </asp:DropDownList>
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
                                            </Columns>
                                            <PagerStyle CssClass="PagerStyle" />
                                            <AlternatingRowStyle CssClass="alt" />
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Blue" />
                                           </asp:GridView>
                                          
                                          <br /><table width="99%">
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPaginacion" Text="Registros por Página : " />
                                                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
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
                                                    <b style="font-size: 11px; font-family: Tahoma;">Leyenda :</b>&nbsp;<img src="../../images/circle_silver1.png" /> <asp:Label ID="Label10" runat="server" Text="Ingresado" Font-Size="11px" Font-Names="Tahoma" />
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
                                                            &nbsp;</td>
                                                        <td align="center">
                                                            &nbsp;</td>
                                                        <td align="center" style="width: 2%;">
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;</td>
                                                        <td align="center" style="width: 100px;">
                                                            &nbsp;</td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btnEnviar" CssClass="button" Text="Enviar" OnClick="btnEnviar_Click"
                                                                Style="color: White; background: url(../../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" />
                                                            <ajax:ConfirmButtonExtender ID="cbeAprobar" runat="server" TargetControlID="btnEnviar"
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
