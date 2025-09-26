<%@ Page Title="" Language="C#" MasterPageFile="~/PedidoUtiles.Master" AutoEventWireup="true" CodeBehind="OpAdministracion.aspx.cs" Inherits="CapaWeb.PeUtiles.OpAdministracion" %>
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
                                                        <span>
                                                        <asp:LinkButton ID="lnkUsuario" runat="server" Text="Usuario" 
                                                            CssClass="link1" onclick="lnkUsuario_Click" ></asp:LinkButton></span></h2>
                                                    <asp:ImageButton ID="imgbUsuario" runat="server" Height="110px" Width="110px"
                                                        ToolTip="Mantenimiento de Usuarios" ImageUrl="~/images/buttons/user256.png" 
                                                        CssClass="imgindent" onclick="imgbUsuario_Click" /><br />
                                                            Permite Asignar a los Usuarios una Plantilla, permitiendo dar acceso a los Artículos.
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
                                
                                <br/>

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
                                                    <asp:LinkButton ID="lnkPlantillas" runat="server" Text="Plantillas" 
                                                        CssClass="link1" onclick="lnkPlantillas_Click"  ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbPlantillas" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Configurar Plantillas" ImageUrl="~/images/buttons/seguridad.png" 
                                                    CssClass="imgindent" onclick="imgbPlantillas_Click" /><br />
                                                       Permite  generar Plantillas para brindan los permisos a los 
                                                Artículos, para realizar pedidos.
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
                                
                                 <br/>

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
                                                    <asp:LinkButton ID="lnkParametros" runat="server" Text="Parámetros" 
                                                        CssClass="link1" onclick="lnkParametros_Click"  ></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbParametros" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Parámetros" ImageUrl="~/images/buttons/settings1.png" 
                                                    CssClass="imgindent" onclick="imgbParametros_Click" /><br />
                                                        Permite configurar distintos parámetros del sistema.
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
               <br/>

</asp:Content>
