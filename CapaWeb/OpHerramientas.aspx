<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="OpHerramientas.aspx.cs" Inherits="CapaWeb.OpHerramientas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="styles/menu_options.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="styles/project.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-2 maxheight">
        <div class="box3 maxheight">
            <div class="tail-right maxheight">
                <div class="tail-left maxheight">
                    <div class="tail-top maxheight">
                        <div class="corner-bottom-right maxheight">
                            <div class="corner-bottom-left maxheight">
                                <div class="corner-top-right maxheight">
                                    <div class="corner-top-left maxheight">
                                        <div class="box-indent">
                                            <div class="container2">
                                                <h2 class="title3">
                                                    <span><asp:LinkButton ID="lnkMovimientosDocumentos" runat="server" Text="Movimientos de Documentos" 
                                                        CssClass="link1" onclick="lnkMovimientosDocumentos_Click" ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbMovimientosDocumentos" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Movimientos de Documentos" ImageUrl="~/images/buttons/Movi.png" 
                                                    CssClass="imgindent" onclick="imgbRegistroDocumentos_Click" /><br />
                                                            Permite saber donde se encuentran los Documentos, además de los movimientos de este.
                                                    <div class="clear"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
        <div class="col-2 maxheight">
        <div class="box3 maxheight">
            <div class="tail-right maxheight">
                <div class="tail-left maxheight">
                    <div class="tail-top maxheight">
                        <div class="corner-bottom-right maxheight">
                            <div class="corner-bottom-left maxheight">
                                <div class="corner-top-right maxheight">
                                    <div class="corner-top-left maxheight">
                                        <div class="box-indent">
                                            <div class="container2">
                                                <h2 class="title3">
                                                    <span><asp:LinkButton ID="lnkCargaMasiva" runat="server" Text="Carga Masiva de Documentos" 
                                                        CssClass="link1" onclick="lnkCargaMasiva_Click" ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbCargaMasiva" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Carga Masiva de Documentos" ImageUrl="~/images/buttons/uploadMasiva.png" 
                                                    CssClass="imgindent" onclick="imgbCargaMasiva_Click" /><br />
                                                            Permite Realizar la Carga Masiva Mediante un Excel.
                                                    <div class="clear"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />

            <div class="col-2 maxheight">
        <div class="box3 maxheight">
            <div class="tail-right maxheight">
                <div class="tail-left maxheight">
                    <div class="tail-top maxheight">
                        <div class="corner-bottom-right maxheight">
                            <div class="corner-bottom-left maxheight">
                                <div class="corner-top-right maxheight">
                                    <div class="corner-top-left maxheight">
                                        <div class="box-indent">
                                            <div class="container2">
                                                <h2 class="title3">
                                                    <span><asp:LinkButton ID="lnkEditarCarga" runat="server" Text="Editar Carga Masiva" 
                                                        CssClass="link1" onclick="lnkEditarCarga_Click" ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbEditarCarga" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Editar Carga Masiva de Documentos" ImageUrl="~/images/buttons/spreadsheet.png" 
                                                    CssClass="imgindent" onclick="imgbEditarCarga_Click" /><br />
                                                            Permite Editar los  datos de la Carga Masiva.
                                                    <div class="clear"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />


    <div class="col-2 maxheight" id="divPlanilla" runat="server" visible="false">
        <div class="box3 maxheight">
            <div class="tail-right maxheight">
                <div class="tail-left maxheight">
                    <div class="tail-top maxheight">
                        <div class="corner-bottom-right maxheight">
                            <div class="corner-bottom-left maxheight">
                                <div class="corner-top-right maxheight">
                                    <div class="corner-top-left maxheight">
                                        <div class="box-indent">
                                            <div class="container2">
                                                <h2 class="title3">
                                                    <span><asp:LinkButton ID="lnkAsistentePagosDocumentoAdjuntos" runat="server" Text="Asistente de Pagos Detallados" 
                                                        CssClass="link1" onclick="lnkAsistentePagosDocumentoAdjuntos_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbAsistentePagosDocumentoAdjuntos" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Asistente de Pagos Detallados" ImageUrl="~/images/buttons/Movi.png" 
                                                    CssClass="imgindent" onclick="imgbAsistentePagosDocumentoAdjuntos_Click"/><br />
                                                            Permite visualizar los Pagos realizados y visualizar los Documentos Adjuntados.
                                                    <div class="clear"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />

</asp:Content>
