<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="CapaWeb.pages.util.FileUpload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- saved from url=(0014)about:internet -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=nombreSistema%> - Carga de Sustentos</title>
    <link href="../../styles/FileUpload.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        //Enumeration for messages status
        MessageStatus = {
            Success: 1,
            Information: 2,
            Warning: 3,
            Error: 4
        }

        //Enumeration for messages status class
        MessageCSS = {
            Success: "Success",
            Information: "Information",
            Warning: "Warning",
            Error: "Error"
        }

        //Global variables
        var intervalID = 0;
        var subintervalID = 0;
        var fileUpload;
        var form;
        var txtDescripcion;
        var previousClass = '';

        //Attach to the upload click event and grab a reference to the progress bar
        function pageLoad() {
            $addHandler($get('upload'), 'click', onUploadClick);
        }

        //Register the form
        function register(form, fileUpload, txtDescripcion) {
            this.form = form;
            this.fileUpload = fileUpload;
            this.txtDescripcion = txtDescripcion;
        }

        //Start upload process
        function onUploadClick() {

            if (fileUpload.value.length > 0) {
                if (txtDescripcion.value == '') {
                    onComplete(MessageStatus.Warning, 'No ha ingresado una descripción para el archivo.', '', '0 de 0 Bytes');
                    setProgress(0);
                }
                else {

                    var filename = fileExists();
                    if (filename == '') {

                        //Update the message
                        updateMessage(MessageStatus.Information, 'Cargando ...', '', '0 de 0 Bytes');
                        //Submit the form containing the fileupload control
                        form.submit();
                        //Set transparancy 20% to the frame and upload button
                        Sys.UI.DomElement.addCssClass($get('dvUploader'), 'StartUpload');
                        //Initialize progressbar
                        setProgress(0);
                        //Start polling to check on the progress ...
                        startProgress();
                        intervalID = window.setInterval(function () {
                            PageMethods.GetUploadStatus(function (result) {
                                if (result) {
                                    setProgress(result.percentComplete);
                                    //Upadte the message every 500 milisecond
                                    updateMessage(MessageStatus.Information, result.message, result.fileName, result.downloadBytes);
                                    if (result == 100) {
                                        //clear the interval
                                        window.clearInterval(intervalID);
                                        clearTimeout(subintervalID);
                                    }
                                }
                            });
                        }, 500);

                    }
                    else
                        onComplete(MessageStatus.Warning, "El archivo '<b>" + filename + "'</b> ya existe en la lista.", '', '0 de 0 Bytes');
                }
            }
            else
                onComplete(MessageStatus.Warning, 'No ha seleccionado un archivo para ser cargado.', '', '0 de 0 Bytes');

        }

        function getFileSize(inputFile) {
            var files = inputFile.files;

            if (!files) {
                //for IE
                try {
                    var fs = new ActiveXObject('Scripting.FileSystemObject');
                    var file = fs.getFile(inputFile.value);
                    return file.size;
                } catch (ex) {
                    return -1;
                }

            } else if (files.length > 0) {
                //for rest of the world
                return files[0].size;
            }
        }


        //Stop progrss when file was successfully uploaded
        function onComplete(type, msg, filename, downloadBytes) {
            window.clearInterval(intervalID);
            clearTimeout(subintervalID);
            updateMessage(type, msg, filename, downloadBytes);
            if (type == MessageStatus.Error) {
                setProgress(0); Sys.UI.DomElement.removeCssClass($get('dvUploader'), 'Error');
                Sys.UI.DomElement.removeCssClass($get('dvUploader'), 'StartUpload');
                window.clearInterval(intervalID);
                clearTimeout(subintervalID);
            }
            if (type == MessageStatus.Warning) {
                setProgress(0); Sys.UI.DomElement.removeCssClass($get('dvUploader'), 'Warning');
                Sys.UI.DomElement.removeCssClass($get('dvUploader'), 'StartUpload');
                window.clearInterval(intervalID);
                clearTimeout(subintervalID);
            }
            if (type == MessageStatus.Success)
            { setProgress(100); Sys.UI.DomElement.removeCssClass($get('dvUploader'), 'StartUpload'); }

            //Refresh uploaded files list.
            refreshFileList('<%=hdRefereshGrid.ClientID %>');
        }

        //Update message based on status
        function updateMessage(type, message, filename, downloadBytes) {
            var _className = MessageCSS.Error;
            var _messageTemplate = $get('tblMessage');
            var _icon = $get('dvIcon');
            _icon.innerHTML = message;

            switch (type) {
                case MessageStatus.Success:
                    _className = MessageCSS.Success;
                    break;
                case MessageStatus.Information:
                    _className = MessageCSS.Information;
                    break;
                case MessageStatus.Warning:
                    _className = MessageCSS.Warning;
                    setProgress(0);
                    window.clearInterval(subintervalID);
                    clearTimeout(subintervalID);
                    break;
                default:
                    _className = MessageCSS.Error;
                    setProgress(0);
                    break;
            }
            _icon.className = '';
            _messageTemplate.className = '';
            Sys.UI.DomElement.addCssClass(_icon, _className);
            Sys.UI.DomElement.addCssClass(_messageTemplate, _className);
        }

        //Refresh uploaded file list when new file was uploaded successfully
        function refreshFileList(hiddenFieldID) {
            var hiddenField = $get(hiddenFieldID);
            if (hiddenField) {
                hiddenField.value = (new Date()).getTime();
                __doPostBack(hiddenFieldID, '');
            }
        }

        //Set progressbar based on completion value
        function setProgress(completed) {
            $get('dvProgressPrcent').innerHTML = completed + '%';
            $get('dvProgress').style.width = completed + '%';
        }

        //Display mouse over and out effect of file upload list
        function eventMouseOver(_this) {
            previousClass = _this.className;
            _this.className = 'GridHoverRow';
        }
        function eventMouseOut(_this) {
            _this.className = previousClass;
        }

        //This will call every 200 milisecnd and update the progress based on value
        function startProgress() {
            var increase = $get('dvProgressPrcent').innerHTML.replace('%', '');
            increase = Number(increase) + 1;
            if (increase <= 100) {
                setProgress(increase);
                subintervalID = setTimeout("startProgress()", 200);
            }
            else {
                window.clearInterval(subintervalID);
                clearTimeout(subintervalID);
            }
        }

        //This will check whether will was already exist on the server, 
        //if file was already exists it will return file name else empty string.
        function fileExists() {
            var selectedFile = fileUpload.value.split('\\');
            var file = $get('gvNewFiles').getElementsByTagName('a');
            for (var f = 0; f < file.length; f++) {
                if (file[f].innerHTML == selectedFile[selectedFile.length - 1]) {
                    return file[f].innerHTML;
                }
            }
            return '';
        }
    </script>

    <script language="javascript" type="text/javascript">
        window.onbeforeunload = Exit;
        function Exit() {
            var borrar = document.getElementById('<%=hdnKM.ClientID %>');

            if (borrar.value == 'NO') {
                var Accion = document.getElementById('<%=hdnAccion.ClientID %>');
                var Grilla = document.getElementById('<%=gvNewFiles.ClientID %>');
                var SustentoInicial = document.getElementById('<%=hdnSustentoInicial.ClientID %>');
                var TotalSustentos = document.getElementById('<%=hdnTotalSustentos.ClientID %>');

                if (Accion.value == 'SI' && SustentoInicial.value != TotalSustentos.value)
                    opener.location.reload();
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function Validar() {
            document.getElementById('<%=hdnKM.ClientID %>').value = 'SI';
        }

        function CerrarVentana() {
            window.close();
        }
        </script>

    <style type="text/css">
        .style1
        {
            width: 90px;
        }
        #uploadFrame
        {
            width: 600px;
        }
        .style2
        {
            width: 600px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
  
    <table width="800px" cellpadding="5" cellspacing="5" border="0">
        <tr>
            <td>
                    <table id="CabeceraSustentos" class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr class="ContainerHeader" style="vertical-align: middle;">
                        <td  valign="middle" >
                            <table class="ContainerMargin" width="100%" style="vertical-align: middle;">
                                <tr>
                                    <td valign="middle" >
                                        Carga de Masiva.
                                    </td>
                                </tr>    
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContainerMargin">
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
                                                    </td>
                                                    <td valign="middle" align="center" > 
                                                        <input id="upload" type="button" value="Cargar" style="width: 100px;" class="button" />
                                                         <asp:Button id="btnCargar" Text="Cargar" style="width: 100px;" class="button" 
                                                            runat ="server" onclick="btnCargar_Click1" />
                                                    </td>
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
                                                        Seleccione un archivo para cargar.
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="2" width="100%" border="0">
                                            <tr>
                                                <td style="text-align: right" class="style1">
                                                    Progreso &nbsp;
                                                </td>
                                                <td style="width: auto">
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
                                                                    &nbsp;</div>
                                                            </td>
                                                        </tr>
                                                    </table>
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
            </td>
        </tr>
        <tr>
            <td>
                <table class="ContainerWrapper" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr class="ContainerHeader">
                        <td>
                            Lista de archivos cargados
                        </td>
                    </tr>
                    <tr>
                        <td class="ContainerMargin">
                            <asp:UpdatePanel runat="server" ID="upFiles" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:HiddenField ID="hdRefereshGrid" runat="server" OnValueChanged="hdRefereshGrid_ValueChanged" />
                                    <table class="Container" cellpadding="0" cellspacing="0" width="100%" border="0">
                                        <tr class="GridHeader">
                                            <td class="Separator" style="width: 3%;">
                                                #
                                            </td>
                                            <td class="Separator" style="width: 7%;" align="center">
                                            </td>
                                            <td class="Separator" style="width:55%">
                                                &nbsp;Nombre del Sustento</td>
                                            <td class="Separator" align="center" style="width:23%">
                                                Tipo de Archivo </td>
                                            <td class="Separator" style="width: 12%" align="right">
                                                <asp:Label ID="lblTamComprimido" runat="server" Font-Size="10px">Tamaño Comprimido</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <div id="dvSustentos" style="height: 170px; overflow: auto;">
                                                    <asp:GridView DataKeyNames="Name" ID="gvNewFiles" AllowPaging="false" runat="server"
                                                        PagerStyle-HorizontalAlign="Center" AutoGenerateColumns="false" Width="100%" 
                                                        CellPadding="0" BorderWidth="0" GridLines="None" ShowHeader="false"
                                                        OnRowDataBound="gvNewFiles_RowDataBound">
                                                        <AlternatingRowStyle CssClass="GridAlternate" />
                                                        <RowStyle CssClass="GridNormalRow" />
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="GridNumberRow" style="width: 3%;" align="center">
                                                                                <%# string.Format("{0}",Container.DataItemIndex + 1 +".") %>
                                                                            </td>
                                                                            <td style="width: 7%" align="center" colspan="2">
                                                                                <asp:ImageButton Width="11px" Height="11px" runat="server" ImageUrl="~/Images/Grid_ActionDelete.gif" OnClientClick = "Validar();"
                                                                                    ID="imgBtnDel" OnClick="imgBtnDel_Click" AlternateText="Delete" ToolTip="Eliminar Sustento" />&nbsp;
                                                                                <ajax:ConfirmButtonExtender ID="cbeQuitar" runat="server" TargetControlID="imgBtnDel"
                                                                                    ConfirmText='<%# "¿Está seguro(a) que desea eliminar el sustento seleccionado?" %>'>
                                                                                </ajax:ConfirmButtonExtender>
                                                                                <asp:ImageButton ID="imgbDownload" runat="server" ToolTip='<%# String.Format("Descargar {0}",Eval("Name")) %>' OnClick="imgbDownload_Click"
                                                                                      Width="12px" Height="12px" ImageUrl="~/images/expand_blue.jpg" />
                                                                            </td>
                                                                            <td style="width: 51%; padding-left: 2px;" align="left">
                                                                                &nbsp;<asp:Label ID="lblArchivo" runat="server" Text='<%#Eval("Name") %>' ToolTip='<%#Eval("Descripcion") %>' />
                                                                                <asp:HiddenField ID="hdnRutaArchivo" runat="server" Value='<%# Bind("RutaArchivo") %>' />
                                                                                <asp:HiddenField ID="hdnArchivoSistema" runat="server" Value='<%# Bind("NameSys") %>' />
                                                                                <asp:HiddenField ID="hdnIndicadorRegSustento" runat="server" Value='<%# Bind("IndicadorRegSustento") %>' />
                                                                            </td>
                                                                            <td style="width: 26%; padding-left: 2px;" align="center">
                                                                                <asp:Label ID="lblTipoArchivo" runat="server" Text='<%#Bind("TipoArchivo") %>' />
                                                                            </td>
                                                                            <td style="width: 10%" align="right" colspan="2">
                                                                                <%#Eval("ConvertedSize")%> &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="GridEmptyRow" />
                                                        <EmptyDataTemplate>
                                                            <span>No hay archivos para mostrar.</span>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr class="GridFooter">
                                            <td colspan="5">
                                                <div style="float: left">
                                                    Total de archivos:
                                                    <%= gvNewFiles.Rows.Count  %>
                                                </div>
                                                <asp:HiddenField ID="hdnContArchivos" runat="server" />
                                                <asp:hiddenfield ID="hdnAccion" runat="server"></asp:hiddenfield>
                                                <asp:hiddenfield ID="hdnKM" runat="server"></asp:hiddenfield>
                                                <asp:hiddenfield ID="hdnTotalSustentos" runat="server"></asp:hiddenfield>
                                                <div style="float: right">
                                                    Tamaño total:
                                                    <asp:Label runat="server" ID="lblTotalSize" Text="0 KB"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="gvNewFiles" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                            <table width="100%" style="background-color: transparent;">
                                <tr>
                                    <td align="left">
                                        <asp:Label runat="server" ID="lblMaxSize" Font-Size="10px" />
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="Button1" runat="server" Text="Cerrar" CssClass="button" OnClientClick = "CerrarVentana();" />
                                    </td>
                                </tr>
                            </table>
            </td>
        </tr>
    </table>    
    
    
    <asp:hiddenfield ID="hdnSustentoInicial" runat="server"></asp:hiddenfield>
    </form>
</body>
</html>


