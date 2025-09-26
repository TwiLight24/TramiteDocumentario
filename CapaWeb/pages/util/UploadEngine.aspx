<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadEngine.aspx.cs" Inherits="CapaWeb.pages.util.UploadEngine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../styles/FileUpload.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #divFileUpload input
        {
        	background-color: transparent;
            border-color: #0489B1;
            border-style: solid;
            border-width: 1px;
        }
        .textarea, select, input
        {
            font: 11px Tahoma;
            vertical-align:middle;
            margin-left: 0px;
            resize: none;  
        }
    </style>
</head>
<body>
    <form id="form" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <table width="100%" >
    <tr>
        <td style="width: 15%; height: 22px;" align="right" valign="top">
            Archivo &nbsp;
        </td>
        <td>
            <div id="divFileUpload">
               <%-- <ajax:AsyncFileUpload  ID="fileUpload" runat="server"  Width="492px" /> --%>
                <ajax:AsyncFileUpload  ID="fileUp" runat="server"  Width="492px" PersistFile ="true"/> 
            </div>        
        </td>
    </tr>
    <tr>
        <td style="width: 15%;" align="right" valign="top">
            Descripción &nbsp;
        </td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="255" TextMode="MultiLine" Rows="3" Width="97%" CssClass="textarea" />
        </td>
    </tr>
    </table>
    </form>
</body>
</html>