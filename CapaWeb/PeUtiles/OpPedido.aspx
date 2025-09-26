<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true" CodeBehind="OpPedido.aspx.cs" Inherits="CapaWeb.PeUtiles.OpPedido" %>
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
                                                    <span><asp:LinkButton ID="lnkRegistroPedidos" runat="server" Text="Editar Pedidos" 
                                                        CssClass="link1" onclick="lnkRegistroPedidos_Click" ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbRegistroPedidos" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Editar Pedidos" ImageUrl="~/images/buttons/pedido.png" 
                                                    CssClass="imgindent" onclick="imgbRegistroPedidos_Click" /><br />
                                                            Permite agregar, modificar o eliminar los Artículos de un Pedido.
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
