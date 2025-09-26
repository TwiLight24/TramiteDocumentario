<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="OpConsulta.aspx.cs" Inherits="CapaWeb.OpConsulta" %>


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
                                                    <span>
                                                        <asp:LinkButton ID="lnkTSDetalle" runat="server" Text="Reporte Cargo" CssClass="link1"
                                                            OnClick="lnkTSDetalle_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbTSDetalle" runat="server" Height="110px" Width="110px" ToolTip="Reporte Cargo"
                                                    ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent" OnClick="imgbTSDetalle_Click" /><br />
                                                Permite consultar el Documento de Cargo que se Enviara.
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
                                                        <asp:LinkButton ID="lnkTSTotalizado" runat="server" Text="Reporte Rechazo" CssClass="link1"
                                                            OnClick="lnkTSTotalizado_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbTSTotalizado" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Reporte Rechazo" ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent"
                                                    OnClick="imgbTSTotalizado_Click" /><br />
                                                Permite consultar el Documento de Cargo Rechazo.
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
    <br>
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
                                                        <asp:LinkButton ID="lnkTSConsolidado" runat="server" 
                                                        Text="Reporte Vencimientos" CssClass="link1"
                                                            OnClick="lnkTSConsolidado_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbTSConsolidado" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Reporte Vencimientos" ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent"
                                                    OnClick="imgbTSConsolidado_Click" /><br />
                                                Permite consultar donde se encuentra el documento y los días Vencidos.
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
                                                        <asp:LinkButton ID="LinkButton1" runat="server" 
                                                        Text="Reporte Movimientos" CssClass="link1"
                                                            OnClick="LinkButton1_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="ImageButton1" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Reporte Movimientos" ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent"
                                                    OnClick="ImageButton1_Click" /><br />
                                                Permite consultar Movimeintos y los días Vencidos.
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
                                                        <asp:LinkButton ID="LinkButton2" runat="server" 
                                                        Text="Reporte Promedio" CssClass="link1"
                                                            OnClick="LinkButton2_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="ImageButton2" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Reporte Promedio" ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent"
                                                    OnClick="ImageButton2_Click" /><br />
                                                Ver los Promedios.
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
                                                        <asp:LinkButton ID="lnkReportDiasPorArea" runat="server" 
                                                        Text="Reporte Días Por Área" CssClass="link1"
                                                            OnClick="lnkReportDiasPorArea_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="imgbReportDiasPorArea" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Reporte Días Por Área" ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent"
                                                    OnClick="imgbReportDiasPorArea_Click" /><br />
                                                Ver los Promedios.
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
                                                        <asp:LinkButton ID="LinkButton3" runat="server" 
                                                        Text="Reporte Días Por Usuario" CssClass="link1"
                                                            OnClick="lnkReportDiasPorUsuario_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="ImageButton3" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Reporte Días Por Usuario" ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent"
                                                    OnClick="imgbReportDiasPorUsuario_Click" /><br />
                                                Ver los Promedios.
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
                                                        <asp:LinkButton ID="LinkButton4" runat="server" 
                                                        Text="Reporte Facturas Por Pagar" CssClass="link1"
                                                            OnClick="lnkReportFacturasPorPagar_Click"></asp:LinkButton></span></h2>
                                                <asp:ImageButton ID="ImageButton4" runat="server" Height="110px" Width="110px"
                                                    ToolTip="Reporte Facturas Por Pagar" ImageUrl="~/images/buttons/workspace2.png" CssClass="imgindent"
                                                    OnClick="imgbReportFacturasPorPagar_Click" /><br />
                                                Lista de Facturas por Pagar
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

</asp:Content>

