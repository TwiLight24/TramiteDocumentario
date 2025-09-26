<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="OpDocumento.aspx.cs" Inherits="CapaWeb.OpDocumento" %>

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
                                                    <span><asp:LinkButton ID="lnkRegistroDocumentos" runat="server" Text="Ingreso de Documentos" 
                                                        CssClass="link1" onclick="lnkRegistroDocumentos_Click" ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbRegistroDocumentos" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Ingreso de Documentos" ImageUrl="~/images/buttons/spreadsheet.png" 
                                                    CssClass="imgindent" onclick="imgbRegistroDocumentos_Click" /><br />
                                                            Permite crear, modificar o eliminar las Documentos.
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
                                                    <span>
                                                    <asp:LinkButton ID="lnkDistribucion" runat="server" Text="Distribución de Documentos" 
                                                        CssClass="link1" onclick="lnkDistribucion_Click" ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbDistribucion" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Distribución de Documentos" ImageUrl="~/images/buttons/consolidar.png" 
                                                    CssClass="imgindent" onclick="imgbDistribucion_Click" /><br />
                                                        Permite gestionar los Documentos del Área Internamente, permitiendo
                                                        una mejor administración.
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

</asp:Content>
