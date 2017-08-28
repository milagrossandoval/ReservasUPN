<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ReservasUPN.Web.Secure.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Usuarios</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <h5>Sede</h5>
            </div>
            <div class="col-lg-8">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true"
                    DataTextField="descripcion" Width="400"
                    DataValueField="nombre"/>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                   <telerik:RadGrid ID="RgUsuarios" runat="server" DataSourceID="ObjectDataSource1" AllowFilteringByColumn="True"
                        AllowPaging="True" AllowSorting="True" GridLines="None" AutoGenerateColumns="False"
                        OnUpdateCommand="RgUsuarios_UpdateCommand"
                        OnInsertCommand="RgUsuarios_InsertCommand" 
                        onitemcommand="RgUsuarios_ItemCommand" >
                        <ExportSettings ExportOnlyData="true" FileName="Usuarios" IgnorePaging="true" OpenInNewWindow="true"  >
                        </ExportSettings>
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage" DataKeyNames="id,codigo" OverrideDataSourceControlSorting ="true" >
                            <CommandItemSettings AddNewRecordText="Agregar" ShowRefreshButton="false" ShowExportToExcelButton="true" ExportToExcelText="Exportar a Excel" />
                             <Columns>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditImageUrl="../assets/images/edit.png">
                                    <HeaderStyle Width="10%" />
                                </telerik:GridEditCommandColumn>
                                <telerik:GridBoundColumn DataField="codigo" HeaderText="Código"
                                     SortExpression="codigo" UniqueName="codigo"
                                     ShowFilterIcon="false" ShowSortIcon="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" >
                                     <HeaderStyle Width="20%" />
                                 </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="nombreCompleto" 
                                     HeaderText="Nombre" ReadOnly="true"
                                     SortExpression="nombreCompleto" UniqueName="nombreCompleto"
                                     ShowFilterIcon="false" ShowSortIcon="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" >
                                     <HeaderStyle Width="30%" />
                                 </telerik:GridBoundColumn>
                                 <%--<telerik:GridBoundColumn DataField="tipoUsuario" DataType="System.Int32" 
                                     FilterControlAltText="Filter tipoUsuario column" HeaderText="Tipo" 
                                     SortExpression="tipoUsuario" UniqueName="tipoUsuario">
                                     <HeaderStyle Width="20%" />
                                 </telerik:GridBoundColumn>--%>
                                 <telerik:GridTemplateColumn HeaderText="Tipo" UniqueName="TipoUsuario" DataField="Tipo.nombre" 
                                 SortExpression="Tipo.nombre"
                                 ShowFilterIcon="false" ShowSortIcon="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="20%" />
                                    <ItemTemplate>
                                        <%# Eval("Tipo.nombre")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="HfTipo" runat="server" Value='<%# Eval("tipoUsuario") %>' />
                                        <telerik:RadComboBox ID="CmbTipos" runat="server" 
                                        DataSourceID="OdsTipo" DataValueField="id" DataTextField="nombre" OnDataBound="CmbTipos_OnDataBound" />
                                    </EditItemTemplate>
                                 </telerik:GridTemplateColumn>
                                <telerik:GridCheckBoxColumn DataField="estado" DataType="System.Boolean" HeaderText="Estado"
                                    SortExpression="estado" UniqueName="estado">
                                    <HeaderStyle Width="20%" />
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
        TypeName="ReservasUPN.BL.UsuarioBL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbSedes" Name="codigoSede" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsTipo" runat="server" SelectMethod="Listar"
        TypeName="ReservasUPN.BL.UsuarioTipoBL">
    </asp:ObjectDataSource>
    
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" >
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RgUsuarios" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgUsuarios" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgUsuarios" LoadingPanelID="RadAjaxLoadingPanel1" />
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

