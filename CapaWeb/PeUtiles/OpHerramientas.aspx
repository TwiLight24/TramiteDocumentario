<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true"
    CodeBehind="OpHerramientas.aspx.cs" Inherits="CapaWeb.PeUtiles.OpHerramientas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/menu_options.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../styles/project.css" type="text/css" />
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
                                                    <span><asp:LinkButton ID="lnkSupervision" runat="server" Text="Supervisión" 
                                                        CssClass="link1" onclick="lnkSupervision_Click" ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbSupervision" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Supervisión" ImageUrl="~/images/buttons/spreadsheet.png" 
                                                    CssClass="imgindent" onclick="imgbSupervision_Click" /><br />
                                                        Permite gestionar los registros de Pedidos de los empleados, permitiendo
                                                        aprobar o rechazar en el Pedido actual.
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
                                                        <asp:LinkButton ID="lnkConsolidacion" runat="server" Text="Consolidación" CssClass="link1"
                                                            OnClick="lnkConsolidacion_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbConsolidacion" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Consolidación" ImageUrl="~/images/buttons/consolidar.png" CssClass="imgindent"
                                                    OnClick="imgbConsolidacion_Click" /><br />
                                                 Permite consolidar todos los registros de Pedidos de los empleados de toda la organización, de tal manera que se pueda finalizar el periodo de trabajo con la respectiva aprobación de los administradores.
                                                <div class="clear">
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
    </div>
    <br />
</asp:Content>
