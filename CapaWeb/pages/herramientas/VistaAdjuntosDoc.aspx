<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaAdjuntosDoc.aspx.cs" Inherits="CapaWeb.pages.herramientas.VistaAdjuntosDoc" %>

<!DOCTYPE html>

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
                                    Text="Vista Adjuntos - Adjuntos del Documento" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellspacing="0" width="100%">
                        <tr>
                            <td style="width:100%" align="center">
                                <b>Seleccionar el Documento Adjunto a mostrar:</b>&nbsp;
                                <asp:DropDownList ID="cmbDocAdjuntos" OnSelectedIndexChanged="Selection_Change" runat="server" AutoPostBack="true"> </asp:DropDownList>
                            </td>
                            <td style="width: 80%">
                                <asp:Literal ID="ltlEmpleado" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table><br />
                </td>
            </tr>
            
        </table>
        <asp:HiddenField ID="hfGridView1SV" runat="server" /> 
        <asp:HiddenField ID="hfGridView1SH" runat="server" /> 
    </div>
    </form>
    <iframe id="pdfViewer" runat="server" style="width: 100%; height: 100%;"></iframe>
</body>
</html>
