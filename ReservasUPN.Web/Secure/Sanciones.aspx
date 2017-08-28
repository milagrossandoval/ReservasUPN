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

                <telerik:RadButton ID="btnNuevo" runat="server" Text="Guardar" RenderMode="Lightweight">
                </telerik:RadButton>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <telerik:RadGrid ID="RgSanciones" runat="server" DataSourceID="ObjectDataSource1"
                        AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" GridLines="None"
                        AutoGenerateColumns="False" OnInsertCommand="RgSanciones_InsertCommand" 
                        onupdatecommand="RgSanciones_UpdateCommand">
                        <ExportSettings ExportOnlyData="true" FileName="Sanciones" IgnorePaging="true" OpenInNewWindow="true">
                        </ExportSettings>
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" CommandItemDisplay="Top"
                            InsertItemPageIndexAction="ShowItemOnCurrentPage" DataKeyNames="id,usuario" OverrideDataSourceControlSorting="true">
                            <CommandItemSettings AddNewRecordText="Agregar" ShowRefreshButton="false" ShowExportToExcelButton="true"
                                ExportToExcelText="Exportar a Excel" />
                            <Columns>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditImageUrl="../assets/images/edit.png">
                                    <HeaderStyle Width="10%" />
                                </telerik:GridEditCommandColumn>
                                <telerik:GridBoundColumn DataField="usuario" DataType="System.Int32" HeaderText="Usuario"
                                    ShowFilterIcon="false" ShowSortIcon="true" SortExpression="usuario" AutoPostBackOnFilter="true"
                                    UniqueName="usuario" CurrentFilterFunction="Contains">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="motivo" HeaderText="Motivo" SortExpression="Motivo"
                                    ShowFilterIcon="false" ShowSortIcon="true" UniqueName="motivo">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="fechainicio" HeaderText="Fecha Inicio" UniqueName="fechainicio" 
                                    SortExpression="fechaInicio" ShowFilterIcon="false" ShowSortIcon="true" AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="20%" />
                                    <FilterTemplate>
                                        <telerik:RadDatePicker ID="txtFechaInicio" runat="server">
                                        </telerik:RadDatePicker>
                                    </FilterTemplate>
                                    <ItemTemplate>
                                        <%# Eval("fechainicio", "{0:dd/MM/yyyy}")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadDatePicker ID="txtFechaInicio2" runat="server"  DbSelectedDate='<%# Eval("fechainicio") %>' DateInput-DateFormat="dd/MM/yyyy">
                                        </telerik:RadDatePicker>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="fechafin" HeaderText="Fecha Fin" UniqueName="fechafin"
                                    SortExpression="fechafin" ShowFilterIcon="false" ShowSortIcon="true" AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="20%" />
                                    <FilterTemplate>
                                        <telerik:RadDatePicker ID="txtFechaFin" runat="server">
                                        </telerik:RadDatePicker>
                                    </FilterTemplate>
                                    <ItemTemplate>
                                        <%# Eval("fechafin", "{0:dd/MM/yyyy}")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadDatePicker ID="txtFechaFin2" runat="server" DbSelectedDate='<%# Eval("fechafin") %>' DateInput-DateFormat="dd/MM/yyyy">
                                        </telerik:RadDatePicker>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridCheckBoxColumn DataField="estado" DataType="System.Boolean" HeaderText="Estado"
                                    SortExpression="estado" UniqueName="estado">
                                    <HeaderStyle Width="20%" />
                                    <FilterTemplate>
                                        <telerik:RadComboBox ID="CmbEstado" runat="server" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("estado").CurrentFilterValue %>'
                                            OnClientSelectedIndexChanged="CmbEstado_OnClientSelectedIndexChanged">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="" Text="Todos" />
                                                <telerik:RadComboBoxItem Value="true" Text="Activos" />
                                                <telerik:RadComboBoxItem Value="false" Text="Inactivos" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                                            <script type="text/javascript">
                                                function CmbEstado_OnClientSelectedIndexChanged(sender, eventArgs) {
                                                    var valor = eventArgs._item.get_value();
                                                    var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                                    console.log(valor);
                                                    console.log(valor == "" ? "NoFilter" : "EqualTo");
                                                    switch (valor) {
                                                        case "":
                                                            tableView.filter("estado", "", "NoFilter");
                                                            break;
                                                        case "true":
                                                            tableView.filter("estado", true, "EqualTo");
                                                            break;
                                                        case "false":
                                                            tableView.filter("estado", false, "EqualTo");
                                                            break;
                                                    }
                                                }
                                            </script>
                                        </telerik:RadScriptBlock>
                                    </FilterTemplate>
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
    <script type="text/javascript" language="javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0)
                args.set_enableAjax(false);
        }
    </script>
</asp:Content>
