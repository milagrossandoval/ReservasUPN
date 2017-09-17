<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="Historial.aspx.cs" Inherits="ReservasUPN.Web.Secure.Historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Historial</h3>
            </div>
        </div>
        <div class="row" id="rowSede">
            <div class="col-lg-3">
                Sede
            </div>
            <div class="col-lg-9">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="300" DataValueField="id" OnSelectedIndexChanged="CmbSedes_SelectedIndexChanged" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <telerik:RadGrid ID="RgReservas" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                        AllowSorting="True" GridLines="None" AutoGenerateColumns="False">
                        <ExportSettings ExportOnlyData="true" FileName="Reservas" IgnorePaging="true" OpenInNewWindow="true" />
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShowing="MenuShowing" />
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" OverrideDataSourceControlSorting="true">
                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" ShowExportToExcelButton="true"
                                ExportToExcelText="Exportar a Excel" />
                            <Columns>
                                <telerik:GridBoundColumn DataField="NombreRecurso" ShowFilterIcon="false" ShowSortIcon="true"
                                    HeaderText="Recurso" SortExpression="NombreRecurso" UniqueName="NombreRecurso"
                                    AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="25%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridDateTimeColumn DataField="fecha" ShowSortIcon="true" FilterListOptions="VaryByDataType"
                                    HeaderText="Fecha" SortExpression="fecha" UniqueName="fecha" PickerType="DatePicker"
                                    DataFormatString="{0:dd/MM/yyyy}" AutoPostBackOnFilter="true" DataType="System.DateTime">
                                    <HeaderStyle Width="15%" />
                                </telerik:GridDateTimeColumn>
                                <telerik:GridDateTimeColumn DataField="inicio" ShowSortIcon="true" HeaderText="Inicio"
                                    SortExpression="inicio" UniqueName="inicio" PickerType="TimePicker" DataFormatString="{0:hh:mm}"
                                    AutoPostBackOnFilter="true" DataType="System.DateTime">
                                    <HeaderStyle Width="15%" />
                                </telerik:GridDateTimeColumn>
                                <telerik:GridDateTimeColumn DataField="final" ShowSortIcon="true" HeaderText="Final"
                                    SortExpression="final" UniqueName="final" PickerType="TimePicker" DataFormatString="{0:hh:mm}"
                                    AutoPostBackOnFilter="true" DataType="System.DateTime">
                                    <HeaderStyle Width="15%" />
                                </telerik:GridDateTimeColumn>
                                <telerik:GridCheckBoxColumn DataField="asistencia" DataType="System.Boolean" HeaderText="Asistencia"
                                    SortExpression="asistencia" UniqueName="asistencia">
                                    <HeaderStyle Width="15%" />
                                    <FilterTemplate>
                                        <telerik:RadComboBox ID="CmbAsistencia" runat="server" Width="100" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("asistencia").CurrentFilterValue %>'
                                            OnClientSelectedIndexChanged="CmbAsistencia_OnClientSelectedIndexChanged">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="" Text="Todos" />
                                                <telerik:RadComboBoxItem Value="true" Text="Asistió" />
                                                <telerik:RadComboBoxItem Value="false" Text="No Asistió" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                                            <script type="text/javascript">
                                                function CmbAsistencia_OnClientSelectedIndexChanged(sender, eventArgs) {
                                                    var valor = eventArgs._item.get_value();
                                                    var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                                    console.log(valor);
                                                    console.log(valor == "" ? "NoFilter" : "EqualTo");
                                                    switch (valor) {
                                                        case "":
                                                            tableView.filter("asistencia", "", "NoFilter");
                                                            break;
                                                        case "true":
                                                            tableView.filter("asistencia", true, "EqualTo");
                                                            break;
                                                        case "false":
                                                            tableView.filter("asistencia", false, "EqualTo");
                                                            break;
                                                    }
                                                }
                                            </script>
                                        </telerik:RadScriptBlock>
                                    </FilterTemplate>
                                </telerik:GridCheckBoxColumn>
                                <telerik:GridTemplateColumn DataField="estado" HeaderText="estado" SortExpression="estado"
                                    UniqueName="estado">
                                    <HeaderStyle Width="15%" />
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("estado"))?"Activa":"Cancelada" %>
                                    </ItemTemplate>
                                    <FilterTemplate>
                                        <telerik:RadComboBox ID="CmbEstado" runat="server" Width="100" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("estado").CurrentFilterValue %>'
                                            OnClientSelectedIndexChanged="CmbEstado_OnClientSelectedIndexChanged">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="" Text="Todos" />
                                                <telerik:RadComboBoxItem Value="true" Text="Activas" />
                                                <telerik:RadComboBoxItem Value="false" Text="Canceladas" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                                            <script type="text/javascript">
                                                function CmbEstado_OnClientSelectedIndexChanged(sender, eventArgs) {
                                                    var valor = eventArgs._item.get_value();
                                                    var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
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
                                </telerik:GridTemplateColumn>
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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RgReservas">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgReservas" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgReservas" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" language="javascript">
            $(document).ready(function () {
                if (<%= (Usuario.tipoUsuario == 1 ||
                       Usuario.tipoUsuario == 2)?1:0 %> == 1 )
                {
                    $("#rowSede").hide();
                }
            
            });

            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0)
                    args.set_enableAjax(false);
            }

            var column = null;
            function MenuShowing(sender, args) {
                if (column == null) return;
                var menu = sender; var items = menu.get_items();
                if (column.get_dataType() == "System.DateTime") {
                    var i = 0;
                    while (i < items.get_count()) {
                        if (!(items.getItem(i).get_value() in { 'EqualTo': '', 'NoFilter': '','GreaterThan': '', 'LessThan': '' })) {
                            var item = items.getItem(i);
                            if (item != null)
                                item.set_visible(false);
                        }
                        else {
                            var item = items.getItem(i);
                            if (item != null)
                                item.set_visible(true);
                        } i++;
                    }
                }
            
                column = null;
                menu.repaint();
            }

            function filterMenuShowing(sender, eventArgs) {
                column = eventArgs.get_column();
            }

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
