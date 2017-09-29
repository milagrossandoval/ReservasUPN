<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="UsuarioTipos.aspx.cs" Inherits="ReservasUPN.Web.Secure.UsuarioTipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Tipos de Usuario</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    
                    <telerik:RadGrid ID="RgTipos" runat="server" DataSourceID="ObjectDataSource1" AllowFilteringByColumn="True"
                        AllowPaging="True" AllowSorting="True" GridLines="None" PageSize="10" AutoGenerateColumns="false"
                        OnUpdateCommand="RgTipos_UpdateCommand"
                        OnInsertCommand="RgTipos_InsertCommand" >
                        <ExportSettings ExportOnlyData="true" FileName="Tipos de Usuario" IgnorePaging="true" OpenInNewWindow="true"  >
                        </ExportSettings>
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage" DataKeyNames="id" OverrideDataSourceControlSorting ="true" >
                            <CommandItemSettings AddNewRecordText="Agregar" ShowRefreshButton="false" ShowExportToExcelButton="true" ExportToExcelText="Exportar a Excel" />
                             <Columns>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditImageUrl="../assets/images/edit.png" >
                                    <HeaderStyle Width="10%" />
                                </telerik:GridEditCommandColumn>
                                <telerik:GridBoundColumn DataField="nombre" HeaderText="Nombre" SortExpression="nombre"
                                    UniqueName="nombre" ShowFilterIcon="false" ShowSortIcon="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" >
                                    <HeaderStyle Width="60%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn DataField="estado" DataType="System.Boolean" HeaderText="Estado"
                                    SortExpression="estado" UniqueName="estado">
                                    <HeaderStyle Width="30%" />
                                    <FilterTemplate>
                                        <telerik:RadComboBox ID="CmbEstado" runat="server"
                                            SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("estado").CurrentFilterValue %>'
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
                               <%--<telerik:GridButtonColumn ConfirmText="¿Seguro de Desactivar?" ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Desactivar" Text="Desactivar"  CommandName="Delete" >
                                    <HeaderStyle Width="10%" />
                                </telerik:GridButtonColumn>--%>
                            </Columns>
                            <EditFormSettings >
                                <EditColumn ButtonType="ImageButton" UpdateImageUrl="../assets/images/ok.png" UpdateText="Aceptar" CancelImageUrl="../assets/images/cancel.png" CancelText="Cancelar" InsertImageUrl="../assets/images/ok.png" InsertText="Aceptar" />
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
        TypeName="ReservasUPN.BL.UsuarioTipoBL"></asp:ObjectDataSource>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" >
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RgTipos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgTipos" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <script type="text/javascript" language="javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0)
                args.set_enableAjax(false);
        }
    </script>

</asp:Content>
