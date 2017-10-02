<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="RptReservas.aspx.cs" Inherits="ReservasUPN.Web.Secure.RptReservas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reporte de Reservas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Reporte de Reservas</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Filtros del Reporte
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <h5>
                                    Sede</h5>
                                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                                    DataValueField="id" />
                            </div>
                            <div class="col-lg-6">
                                <h5>
                                    Tipo de Recurso</h5>
                                <asp:CheckBoxList ID="CblTipos" runat="server" DataSourceID="OdsTipos" DataTextField="descripcion"
                                    DataValueField="id" RepeatDirection="Horizontal" 
                                    RepeatColumns="5" ondatabound="CblTipos_DataBound" />
                                <asp:ObjectDataSource ID="OdsTipos" runat="server" SelectMethod="Listar" TypeName="ReservasUPN.BL.RecursoTipoBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CmbSedes" Name="idSede" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                            <div class="col-lg-3">
                                <h5>
                                    Recurso</h5>
                                <telerik:RadTextBox ID="TxtRecurso" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <h5>
                                    Fecha Inicio</h5>
                                <telerik:RadDatePicker ID="DpInicio" runat="server" />
                                <asp:RequiredFieldValidator ID="RfvDpInicio" ControlToValidate="DpInicio" runat="server"
                                    Text="*" Display="Dynamic" />
                            </div>
                            <div class="col-lg-3">
                                <h5>
                                    Fecha Fin</h5>
                                <telerik:RadDatePicker ID="DpFin" runat="server" />
                                <asp:RequiredFieldValidator ID="RfvDpFin" ControlToValidate="DpFin" runat="server"
                                    Text="*" Display="Dynamic" />
                            </div>
                            <div class="col-lg-3">
                                <h5>
                                    Asistencia</h5>
                                <telerik:RadComboBox ID="CmbAsistencia" runat="server">
                                    <Items>
                                        <telerik:RadComboBoxItem Value="T" Text="Todos" />
                                        <telerik:RadComboBoxItem Value="A" Text="Asistió" />
                                        <telerik:RadComboBoxItem Value="N" Text="No Asistió" />
                                    </Items>
                                </telerik:RadComboBox>
                            </div>
                            <div class="col-lg-3">
                                <h5>
                                    Estado</h5>
                                <telerik:RadComboBox ID="CmbEstado" runat="server">
                                    <Items>
                                        <telerik:RadComboBoxItem Value="T" Text="Todos" />
                                        <telerik:RadComboBoxItem Value="A" Text="Activas" />
                                        <telerik:RadComboBoxItem Value="C" Text="Canceladas" />
                                    </Items>
                                </telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <h5>
                                    Usuario</h5>
                                <telerik:RadTextBox ID="TxtCodUsuario" runat="server" />
                            </div>
                            <div class="col-lg-3">
                                <h5>
                                    Nombre de Usuario</h5>
                                <telerik:RadTextBox ID="TxtNomUsuario" runat="server" />
                            </div>
                            <div class="col-lg-3">
                                <h5>
                                    Usuario Reserva</h5>
                                <telerik:RadTextBox ID="TxtCodUsuarioRes" runat="server" />
                            </div>
                            <div class="col-lg-3">
                                <h5>
                                    Nombre de Usuario Reserva</h5>
                                <telerik:RadTextBox ID="TxtNomUsuarioRes" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <h5></h5>
                                <telerik:RadButton ID="BtnReporte" runat="server" Text="Generar" OnClick="BtnReporte_Click" />
                            </div>
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Font-Names="Verdana"
                        Font-Size="8pt" Height="600px" Visible="false" />
                </div>
            </div>
        </div>
    </div>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" language="javascript">
            $(document).ready(function () {
                EstiloButton('<%= BtnReporte.ClientID %>');
            });
        </script>
    </telerik:RadCodeBlock>

</asp:Content>
