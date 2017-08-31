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
            <div class="col-lg-2">
                <h5>Sede</h5>
            </div>
            <div class="col-lg-5">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="300" DataValueField="nombre" />
            </div>
            <div class="col-lg-2">
                <h5>Inactivos</h5>
            </div>
            <div class="col-lg-3">
                <asp:CheckBox runat="server" AutoPostBack="true" ID="ChkInactivos" Text="Mostrar" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <telerik:RadGrid ID="RgSanciones" runat="server" DataSourceID="ObjectDataSource1"
                        AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" GridLines="None"
                        AutoGenerateColumns="False" 
                        OnInsertCommand="RgSanciones_InsertCommand" 
                        onupdatecommand="RgSanciones_UpdateCommand"
                        OnDeleteCommand="RgSanciones_DeleteCommand" 
                        onitemcommand="RgSanciones_ItemCommand" 
                        onitemdatabound="RgSanciones_ItemDataBound" >
                        <ExportSettings ExportOnlyData="true" FileName="Sanciones" IgnorePaging="true" OpenInNewWindow="true">
                        </ExportSettings>
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" CommandItemDisplay="Top"
                            InsertItemPageIndexAction="ShowItemOnCurrentPage" DataKeyNames="id,usuario" OverrideDataSourceControlSorting="true">
                            <CommandItemSettings AddNewRecordText="Agregar" ShowRefreshButton="false" ShowExportToExcelButton="true"
                                ExportToExcelText="Exportar a Excel" />
                            <Columns>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditImageUrl="../assets/images/edit.png">
                                    <HeaderStyle Width="4%" />
                                </telerik:GridEditCommandColumn>
                                <telerik:GridBoundColumn DataField="usuario" HeaderText="Usuario"
                                    ShowFilterIcon="false" ShowSortIcon="true" SortExpression="usuario" AutoPostBackOnFilter="true"
                                    UniqueName="usuario" CurrentFilterFunction="Contains">
                                    <HeaderStyle Width="10%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreUsuario" HeaderText="Nombre"
                                    ShowFilterIcon="false" ShowSortIcon="true" SortExpression="NombreUsuario" AutoPostBackOnFilter="true"
                                    UniqueName="NombreUsuario" CurrentFilterFunction="Contains" ReadOnly="true" >
                                    <HeaderStyle Width="17%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="motivo" HeaderText="Motivo" 
                                    SortExpression="motivo" ShowFilterIcon="false" ShowSortIcon="true"  AutoPostBackOnFilter="true"
                                    UniqueName="motivo" CurrentFilterFunction="Contains">
                                    <HeaderStyle Width="17%" />
                                </telerik:GridBoundColumn>

                                <telerik:GridDateTimeColumn DataField="fechainicio" HeaderText="Fecha Inicio" DataFormatString="{0:dd/MM/yyyy}"
	                                SortExpression="fechainicio" UniqueName="fechainicio" PickerType="DatePicker" 
                                    ShowFilterIcon="false" ShowSortIcon="true" AutoPostBackOnFilter="true" >
                                    <HeaderStyle Width="15%" />
                                </telerik:GridDateTimeColumn>

                                <telerik:GridDateTimeColumn DataField="fechafin" HeaderText="Fecha Inicio" DataFormatString="{0:dd/MM/yyyy}"
	                                SortExpression="fechafin" UniqueName="fechafin" PickerType="DatePicker" 
                                    ShowFilterIcon="false" ShowSortIcon="true" AutoPostBackOnFilter="true" >
                                    <HeaderStyle Width="15%" />
                                </telerik:GridDateTimeColumn>

                                <telerik:GridTemplateColumn HeaderText="Tipos de Recurso" 
                                ShowFilterIcon="false" ShowSortIcon="false" CurrentFilterFunction="NoFilter" Reorderable="false" >
                                <HeaderStyle Width="18%" />
                                <FilterTemplate></FilterTemplate>
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="CmbTipos" runat="server"  AccessibilityMode="false" Filter="None"
                                        DataTextField="descripcion" DataValueField="id" MarkFirstMatch="true" >                                            
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="HfIdSancion" runat="server" Value='<%# Eval("id") %>' />
                                        <asp:CheckBoxList Width="100%" ID="ChblTiposRecurso" runat="server"
                                        DataTextField="descripcion" DataValueField="id" OnDataBound="ChblTiposRecurso_DataBound"
                                        RepeatDirection="Horizontal" RepeatColumns="4" DataSourceID="OdsTipos" >
                                        </asp:CheckBoxList>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>

                                 <telerik:GridButtonColumn ConfirmText="¿Seguro de Eliminar?" ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Eliminar" CommandName="Delete" ButtonType="ImageButton" ImageUrl="../assets/images/delete.png" >
                                    <HeaderStyle Width="4%" />
                                 </telerik:GridButtonColumn>
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
        TypeName="ReservasUPN.BL.SancionBL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbSedes" Name="sede" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ChkInactivos" DefaultValue="false" 
                Name="inactivos" PropertyName="Checked" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsTipos" runat="server" SelectMethod="ListarTodos"
        TypeName="ReservasUPN.BL.RecursoTipoBL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbSedes" Name="codSede" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" >
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RgSanciones" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgSanciones" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgSanciones" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ChkInactivos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgSanciones" LoadingPanelID="RadAjaxLoadingPanel1" />
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
