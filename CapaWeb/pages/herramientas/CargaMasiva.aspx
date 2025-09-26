<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="CargaMasiva.aspx.cs" Inherits="CapaWeb.pages.herramientas.CargaMasiva" %>

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
                        <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px">Carga Masiva de Archivos</asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ajax:RoundedCornersExtender ID="rceProgreso" runat="server" TargetControlID="panProgreso"
            Corners="All" Radius="3">
        </ajax:RoundedCornersExtender>
<%--        <asp:UpdatePanel ID="upaEdicion" runat="server">--%>
            <ContentTemplate>
                <br />
                <asp:Panel runat="server" ID="pnlBusqueda">
                    <asp:Table ID="Table1" Width="99%" runat="server" BorderColor="#e6e6fa" BorderWidth="1"
                        Height="40px">
                        <asp:TableRow>
                            <asp:TableCell ID="Contenedor1" HorizontalAlign="Right" VerticalAlign="Middle" CssClass="header"
                                Width="5%">
                                <asp:Label ID="lblEmpresaSearch" runat="server" Text="Empresa :" />&nbsp;
                            </asp:TableCell><asp:TableCell ID="Contenedor2" VerticalAlign="Middle" Width="11%">
                                &nbsp;<asp:DropDownList ID="ddlEmpresaSearch" runat="server" AutoPostBack="True"
                                    Width="94%">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="MIMSA">MIMSA</asp:ListItem>
                                    <asp:ListItem Value="MEGA">MEGA</asp:ListItem>
                                    <asp:ListItem Value="RUMI">RUMI</asp:ListItem>
                                    <asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem>
                                    <asp:ListItem Value="POSTES">POSTES</asp:ListItem>
                                    <asp:ListItem Value="Steel Form">Steel Form</asp:ListItem>
                                    <asp:ListItem Value="DOBLE RR">DOBLE RR</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell><asp:TableCell ID="Contenedor3" HorizontalAlign="Right" VerticalAlign="Middle"
                                CssClass="header" Width="6%">
                                <asp:Label ID="lblSearch" runat="server" Text="Buscar :" />&nbsp;
                            </asp:TableCell><asp:TableCell ID="Contenedor4" VerticalAlign="Middle" Width="19%">
                                &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="96%" />
                            </asp:TableCell><asp:TableCell ID="Contenedor5" VerticalAlign="Middle" Width="3%">
        <%--                        &nbsp;<asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnBuscar_Click" />--%>
                            </asp:TableCell><asp:TableCell ID="Contenedor6" HorizontalAlign="Right" VerticalAlign="Middle"
                                CssClass="header" Width="11%">
<%--                               <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="True"
                                    Width="94%" OnSelectedIndexChanged="ddlTipoBusqueda_SelectedIndexChanged">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem>
                                    <asp:ListItem Value="1">Cargo</asp:ListItem>
                                    <asp:ListItem Value="2">Fecha Envío</asp:ListItem>
                                    <asp:ListItem Value="3">Id Documento</asp:ListItem>
                                    <asp:ListItem Value="4">Nr. Orden</asp:ListItem>
                                    <asp:ListItem Value="5">Nr. Documento</asp:ListItem>
                                    <asp:ListItem Value="6">Busqueda Masiva Id Documento</asp:ListItem>                                          
                               </asp:DropDownList>--%>
                            </asp:TableCell><asp:TableCell ID="Contenedor7" VerticalAlign="Middle" Width="19%">
                                &nbsp;<asp:TextBox ID="txtTipoBusqueda" runat="server" Width="96%" />
                            </asp:TableCell><asp:TableCell VerticalAlign="Middle" Width="3%">
<%--                                &nbsp;<asp:ImageButton runat="server" ID="btnTipoBusqueda" ImageUrl="~/images/buscar.png"
                                    ToolTip="Buscar" OnClick="btnTipoBusqueda_Click" />--%>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" Width="20%">
<%--                                <asp:CheckBox ID="chkEliminados" runat="server" Text="&nbsp;Mostrar Documentos desactivados."
                                    AutoPostBack="True" OnCheckedChanged="chkEliminados_CheckedChanged" />&nbsp;&nbsp;--%>
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle" Width="7%"
                                BackColor="#e6e6fa">
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="ibCargarArchivos" runat="server" ImageUrl="~/images/buttons/upload.png"
                                    Width="30px" Height="30px" OnClick="ibCargarArchivos_Click" ToolTip="Cargar Archivos" />
                            </asp:TableCell></asp:TableRow></asp:Table></asp:Panel><asp:Panel runat="server" ID="pnlProyectosAll" Width="99%">
                    <br />
                     <asp:Panel ID="pnlCarga" Visible="False" runat="server" Width="99%" 
                        HorizontalAlign ="Center"><table id="CabeceraSustentos" class="ContainerWrapper" border="0" cellpadding="4" cellspacing="0" width="100%">

                    <tr class="ContainerHeader" style="vertical-align: middle;">
                                                    <td class="style1">
                                </td>
                        <td  valign="middle"  style="width: 96%">
                            <table class="ContainerMargin" width="100%" style="vertical-align: middle;">
                                <tr>
                                    <td valign="middle" >
                                        Carga de Masiva. </td></tr></table></td><td class="style1">
                                </td></tr><tr>
                                                                        <td class="style1">
                                </td>
                        <td class="ContainerMargin" style="width: 96%">
                            <asp:Panel ID="pnlInput" runat="server">
                            <table class="Container" cellpadding="0" cellspacing="4" width="100%" border="0">
                                <tr>
                                    <td>
                                        <div id="dvUploader">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td valign="middle" style="height: auto;" >
    <table width="100%" >
    <tr>
    <td>
            Empresa &nbsp; </td><td>
             
                                        <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True"
                                    Width="50%">
                                    <asp:ListItem Value="0">---- Seleccionar ----</asp:ListItem><asp:ListItem Value="MIMSA">MIMSA</asp:ListItem><asp:ListItem Value="MEGA">MEGA</asp:ListItem><asp:ListItem Value="RUMI">RUMI</asp:ListItem><asp:ListItem Value="INDUZINC">INDUZINC</asp:ListItem><asp:ListItem Value="POSTES">POSTES</asp:ListItem><asp:ListItem Value="Steel Form">Steel Form</asp:ListItem></asp:DropDownList></td></tr><tr>
        <td style="width: 15%; height: 22px;" align="right" valign="top">
            Archivo &nbsp; </td><td>
            <div id="divFileUpload">
               <%-- <ajax:AsyncFileUpload  ID="fileUpload" runat="server"  Width="492px" /> --%>
                <ajax:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="True" /></div>                        
        </td>
    </tr>
    <tr>
        <td style="width: 15%;" align="right" valign="top">
            Descripción &nbsp; </td><td>
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="255" TextMode="MultiLine" Rows="3" Width="97%" CssClass="textarea" />
        </td>
    </tr>
    </table>
                                                    </td>
                                                    <td valign="middle" align="center" > 
                                                        <%--<input id="upload" type="button" value="Cargar" style="width: 100px;" class="button" />--%>
                                                         <asp:Button id="btnCargar" Text="Cargar" 
                                                                                                                style="width: 100px;" class="button" 
                                                            runat ="server" onclick="btnCargar_Click" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td><br />
                                        <table id="tblMessage" cellpadding="4" cellspacing="4" class="Information" border="0">
                                            <tr>
                                                <td style="text-align: left" colspan="2">
                                                    <div id="dvIcon" class="Information">
                                                        Seleccione un archivo para cargar. </div></td></tr></table></td></tr><tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                                            <tr>
                                                <td style="text-align: right" class="style1">
                                                    Progreso &nbsp; </td><td style="width: auto">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td align="left" class="style2">
                                                                <div id="dvProgressContainer">
                                                                    <div id="dvProgress">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div id="dvProgressPrcent">
                                                                    &nbsp;</div></td></tr></table></td></tr></table></td></tr></table></asp:Panel></td><td class="style1">
                                </td></tr></table></asp:Panel>
                                
                                
                                <asp:Panel ID="pnlMostrarCarga" 
                        Visible="False" runat="server" Width="99%"><table width="99%">
                            <tr>
                                <td class="style1">
                                </td>
                                <td style="width: 96%">

                                        <br />
                                        <asp:Button ID="btnPreparar" runat="server" Text="Preparar" OnClick="btnPreparar_Click" style="width: 100;" class="button" />
                                        <asp:GridView ID="gv1" runat="server" Caption="ba" Visible="true" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="PagerStyle"  CssClass="mGrid">
                                        
                                        </asp:GridView>
                                        </asp:Panel>

                                         <asp:Panel ID="pnlPreparar" runat="server" Width="100%">

                                                                             <asp:Panel ID="pnlCollapsePlanificados" runat="server" CssClass="collapsePanelHeader"
                                        Width="100%">
                                        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                                            <div style="float: left;" class="headerrow">
                                                Documentos Cargados que se encontraron en el sistema</div><div style="float: right; vertical-align: middle;">
                                                <asp:ImageButton ID="imgCollapsePlanificados" runat="server" ImageUrl="~/images/expand_blue.jpg"
                                                    AlternateText="(Ver Detalles)" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                        <br />
                                        <asp:GridView ID="gvwEmpleado" Width="100%" runat="server" OnRowCommand="gvwEmpleado_RowCommand"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt"
                                            DataKeyNames="IdDocumento,IdMovimiento" GridLines="None" OnPageIndexChanging="gvwEmpleado_PageIndexChanging"
                                            AllowPaging="True" CssClass="mGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                                            OnRowDataBound="gvwEmpleado_DataBound">
                                            <Columns>
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
                                                        <asp:ImageButton ID="btnVer" runat="server" CausesValidation="False" ImageUrl="~/images/buttons/plain.png"
                                                            Height="18px" Width="18px" CommandName="Ver" CommandArgument='<%# Bind("IdDocumento") %>'>
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdDocumento" HeaderText="Id Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="22%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="22%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tipodoc" HeaderText="Tipo Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NroDoc" HeaderText="Nr. Documento" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Origen" HeaderText="ID Usuario Origen" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    Visible="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="16%" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaRegistro" HeaderText="FecEnvío" ItemStyle-VerticalAlign="Middle"
                                                    ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    DataFormatString="{0:dd/MM/yyyy}">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" Wrap="False" />
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
                                                    &nbsp; </td></tr></table><ajax:CollapsiblePanelExtender ID="cpePlanificados" runat="Server" TargetControlID="pnlPreparar"
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
                                                        <td align="center">
                                                            <asp:TextBox ID="txtComentario" runat="server" Width="300px" TabIndex="17" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btnRecibir" CssClass="button" Text="Recibir" OnClick="btnRecibir_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" /><ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2"
                                                                    runat="server" TargetControlID="btnrecibir" ConfirmText="¿Está seguro que desea Recibir Estos Documentos?">
                                                                </ajax:ConfirmButtonExtender>
                                                        </td>
                                                        <td align="center" style="width: 2%;">
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btnrechazar" CssClass="button" Text="Rechazar" OnClick="btnRechazar_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
                                                                width: 100px; height: 26px; font: 11px Tahoma;" /><ajax:ConfirmButtonExtender ID="ConfirmButtonExtender1"
                                                                    runat="server" TargetControlID="btnrechazar" ConfirmText="¿Está seguro que desea Rechazar estos Documentos?">
                                                                </ajax:ConfirmButtonExtender>
                                                        </td>
                                                        <td align="center" style="width: 100px;">
                                                            <asp:DropDownList ID="ddlDestino" runat="server" AutoPostBack="True" Style="width: 100px;
                                                                font: 11px Tahoma;">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btnEnviar" CssClass="button" Text="Enviar" OnClick="btnEnviar_Click"
                                                                Style="color: White; background: url(../../images/button_bg.png) center no-repeat;
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
<%--        </asp:UpdatePanel>--%>
    </div>
</asp:Content>
