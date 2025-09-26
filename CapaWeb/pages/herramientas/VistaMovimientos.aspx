<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaMovimientos.aspx.cs" Inherits="CapaWeb.pages.herramientas.VistaMovimientos" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../../styles/project.css" type="text/css" />
    <link rel="stylesheet" href="../../styles/Style.css" type="text/css" />
    <link href="../../styles/FileUpload.css" rel="stylesheet" type="text/css" />
    <link href="../../styles/GridViewNewStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery-1.8.2.min.js"></script> 
    <script type="text/javascript" src="../../scripts/jquery-ui-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../scripts/gridviewScroll.min.js"></script> 
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        $(window).resize(function () {
            gridviewScroll();
        });

        function gridviewScroll() {

            var ancho = $(window).width();

            $('#<%=gvwHorasProyEmp.ClientID%>').gridviewScroll({
                width: ancho - 5,
                height: 428,
                freezesize: 0,
                arrowsize: 28,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png",
                startVertical: $("#<%=hfGridView1SV.ClientID%>").val(),
                startHorizontal: $("#<%=hfGridView1SH.ClientID%>").val(),
                onScrollVertical: function (delta) {
                    $("#<%=hfGridView1SV.ClientID%>").val(delta);
                },
                onScrollHorizontal: function (delta) {
                    $("#<%=hfGridView1SH.ClientID%>").val(delta);
                },
                onScrollHorizontal: function (delta) {
                    $("#<%=hfGridView1SH.ClientID%>").val(delta);
                }
            });
        } 
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
        <asp:HiddenField ID="hdfIdEmpleado" runat="server" />
        <asp:HiddenField ID="hdfIdPeriodo" runat="server" />
        <table border="0" cellpadding="1" cellspacing="0" width="100%">
            <tr>
                <td align="center">
                    <table cellspacing="2" cellpadding="5" width="100%" border="0" style="background-color: #0B52A0;">
                        <tr>
                            <td style="vertical-align: middle;" align="center">
                                <asp:Label ID="lblTabGeneral" runat="server" Font-Bold="true" ForeColor="White" Font-Size="13px"
                                    Text="Vista Detalle - Movimientos del Documento" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 20%" align="center">
                                <b>Usuario Ubica el Doc:</b>
                            </td>
                            <td style="width: 80%">
                                <asp:Literal ID="ltlEmpleado" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table><br />
                </td>
            </tr>
            <tr>
                <td >
                        <asp:Panel ID="pnlRegistro" runat="server" Width="100%" >
                        <asp:GridView ID="gvwHorasProyEmp" Width="100%" runat="server" 
                                AutoGenerateColumns="False"  ShowFooter="True"
                            CellPadding="4" ForeColor="#333333" AlternatingRowStyle-CssClass="alt" 
                                BorderStyle="Solid" BorderWidth="1px" BorderColor="#A6C4E0" 
                            CssClass="NewGrid" PagerStyle-CssClass="PagerStyle" EmptyDataText="No se encontraron resultados, para la búsqueda realizada."
                            OnPreRender="gvwHorasProyEmp_PreRender" 
                                OnRowDataBound="gvwHorasProyEmp_RowDataBound">
                            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                            <Columns >
                                <asp:BoundField DataField="IdMovimiento" HeaderText="IdMov.">
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="3%"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" >
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" >
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="4%"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NroDoc" HeaderText="Nro. Doc" >
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="3%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Monto" HeaderText="Monto" >
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="2%"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreUsuarioOrigen" HeaderText="Usuario Origen">
                                    <ItemStyle HorizontalAlign="Center" Wrap="true" VerticalAlign="Middle" width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreUsuarioDestino" HeaderText="Usuario Destino">
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaIni" HeaderText="Fecha Envío" 
                                    DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" width="4%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Estado" HeaderText="Estado">
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="4%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Motivo" HeaderText="Motivo">
                                    <ItemStyle HorizontalAlign="center" Wrap="true" width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate >
                                        <asp:HiddenField ID="hdfIdActividad" runat="server" Value='<%# Bind("IdMovimiento") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                                <EmptyDataRowStyle Width="99%" Height="100px" Font-Bold="true" Font-Size="11px" HorizontalAlign="Center"
                                    BackColor="White" BorderColor="White" VerticalAlign="Middle" ForeColor="Black" />
                                <FooterStyle BackColor="White" BorderColor="White" BorderWidth="0px" 
                                Font-Names="Tahoma" Font-Size="11px" ForeColor="Black" Height="30px" 
                                VerticalAlign="Middle" />
                                <HeaderStyle CssClass="GridviewScrollHeader"  /> 
                            <PagerStyle CssClass="PagerStyle" />
                            <RowStyle BackColor="White" Font-Bold="false" Font-Names="Tahoma" 
                                Font-Size="11px" ForeColor="#717171" Height="26px" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            </table><br /><br />
            <table width="100%">
            <tr>
                <td align="right">
                    <asp:DropDownList runat="server" ID="ddlExportar" Width="150px">
                        <asp:ListItem Value="1">Excel</asp:ListItem>
                         <asp:ListItem Value="2">PDF</asp:ListItem>
                        <asp:ListItem Value="3">Word</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnExportar" runat="server" CssClass="button" OnClick="btnExportar_Click"
                        Text="Exportar" />
                    &nbsp;<asp:Button ID="btnCerrar" runat="server" CssClass="button" OnClick="btnCerrar_Click"
                        Text="Cerrar" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfGridView1SV" runat="server" /> 
        <asp:HiddenField ID="hfGridView1SH" runat="server" /> 
    </div>
    </form>
</body>
</html>
