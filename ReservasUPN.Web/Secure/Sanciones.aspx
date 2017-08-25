<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="Sanciones.aspx.cs" Inherits="ReservasUPN.Web.Secure.Sanciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Sanciones</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <table width="100%">
                    <tr>
                        <td>
                            Buscar:
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtBuscar" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Rango Fecha:
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="txtRangoFecha" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                </table>
                </br> </br>
                <telerik:RadButton ID="btnNuevo" runat="server" Text="Guardar" RenderMode="Lightweight">
                </telerik:RadButton>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <telerik:RadGrid ID="RgSanciones" runat="server" DataSourceID="ObjectDataSource1"
                        AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" GridLines="None"
                        AutoGenerateColumns="False">
                        <ExportSettings ExportOnlyData="true" FileName="Sanciones" IgnorePaging="true" OpenInNewWindow="true">
                        </ExportSettings>
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" CommandItemDisplay="Top"
                            InsertItemPageIndexAction="ShowItemOnCurrentPage" DataKeyNames="id,codigo" OverrideDataSourceControlSorting="true">
                            <CommandItemSettings AddNewRecordText="Agregar" ShowRefreshButton="false" ShowExportToExcelButton="true"
                                ExportToExcelText="Exportar a Excel" />
                            <Columns>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditImageUrl="../assets/images/edit.png">
                                    <HeaderStyle Width="10%" />
                                </telerik:GridEditCommandColumn>
                                <telerik:GridBoundColumn DataField="usuario" DataType="System.Int32" HeaderText="Usuario"
                                    SortExpression="usuario" UniqueName="usuario">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="motivo" HeaderText="Motivo" SortExpression="motivo"
                                    UniqueName="motivo">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="fechainicio" DataType="System.DateTime" HeaderText="fechainicio"
                                    SortExpression="fechainicio" UniqueName="fechainicio">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="fechafin" DataType="System.DateTime" HeaderText="fechafin"
                                    SortExpression="fechafin" UniqueName="fechafin">
                                </telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn DataField="estado" DataType="System.Boolean" HeaderText="Estado"
                                    SortExpression="estado" UniqueName="estado">
                                </telerik:GridCheckBoxColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn ButtonType="ImageButton" UpdateImageUrl="../assets/images/ok.png" UpdateText="Aceptar"
                                    CancelImageUrl="../assets/images/cancel.png" CancelText="Cancelar" InsertImageUrl="../assets/images/ok.png"
                                    InsertText="Aceptar" />
                            </EditFormSettings>
                            <NoRecordsTemplate>
                                No hay datos para mostrar
                            </NoRecordsTemplate>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Listar"
        TypeName="ReservasUPN.BL.SancionBL"></asp:ObjectDataSource>
</asp:Content>
