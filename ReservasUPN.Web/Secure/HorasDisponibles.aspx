<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true" CodeBehind="HorasDisponibles.aspx.cs" Inherits="ReservasUPN.Web.Secure.HorasDisponibles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Horas Disponibles por Tipo Recurso</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Horas Disponibles por Tipo Recurso</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-1">
                Sede
            </div>
            <div class="col-lg-4">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                Width="300" DataValueField="id" EmptyMessage=" " HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true"  />
            </div>
            <div class="col-lg-7">                
            </div>
            <%--<div class="col-lg-2">
                <h5>Tipo de Recurso</h5>
            </div>
            <div class="col-lg-3">
                <telerik:RadComboBox ID="CmbTiposRecurso" runat="server" AutoPostBack="True"
                    Width="200px" DataValueField="id" DataTextField="descripcion"  DataSourceID="OdsRecursoTipo" 
                    ondatabound="CmbTiposRecurso_DataBound" />
                <asp:ObjectDataSource ID="OdsRecursoTipo" runat="server" SelectMethod="Listar" 
                    TypeName="ReservasUPN.BL.RecursoTipoBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbSedes" Name="idSede" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>--%>
        </div>
        <h6></h6>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">

                    <telerik:RadGrid ID="RgHoras" runat="server" DataSourceID="ObjectDataSource1" AllowFilteringByColumn="True"
                        AllowPaging="True" AllowSorting="True" GridLines="None" 
                        AutoGenerateColumns="False" ondatabound="RgHoras_DataBound" 
                        ondetailtabledatabind="RgHoras_DetailTableDataBind">
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False"
                            DataKeyNames="id" OverrideDataSourceControlSorting="true">
                            <Columns>
                                <telerik:GridBoundColumn DataField="descripcion" 
                                    ShowFilterIcon="false" ShowSortIcon="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                    HeaderText="Descripción" SortExpression="descripcion" UniqueName="descripcion">
                                    <HeaderStyle Width="50%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="tipoHora" DataType="System.Int32"
                                    ShowFilterIcon="false" ShowSortIcon="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                    HeaderText="Tipo de Hora" SortExpression="tipoHora" UniqueName="tipoHora">
                                    <HeaderStyle Width="30%" />
                                </telerik:GridBoundColumn>
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
//                                                    console.log(valor);
//                                                    console.log(valor == "" ? "NoFilter" : "EqualTo");

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
                            <DetailTables>
                                <telerik:GridTableView AutoGenerateColumns="False" DataKeyNames="usuarioTipo" Name="Detalle" AllowFilteringByColumn="false" AllowPaging="false" AllowSorting="false" >
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="NombreTipoUsuario" HeaderText="Tipo de Usuario" UniqueName="NombreTipoUsuario" >
                                            <HeaderStyle Width="50%" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Horas Disponibles" UniqueName="nroHoras" DataField="nroHoras" >
                                            <HeaderStyle Width="50%" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtNroHoras" runat="server" Text='<%# Eval("nroHoras") %>' />
                                            </ItemTemplate>
                                         </telerik:GridTemplateColumn>
                                    </Columns>    
                                    <NoRecordsTemplate>
                                        No hay datos para mostrar
                                    </NoRecordsTemplate>
                                </telerik:GridTableView>
                            </DetailTables>
                            <NoRecordsTemplate>
                                No hay datos para mostrar
                            </NoRecordsTemplate>
                        </MasterTableView>
                    </telerik:RadGrid>

                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Listar"
                        TypeName="ReservasUPN.BL.RecursoTipoBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="CmbSedes" Name="idSede" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                    <%--<telerik:RadGrid ID="RgHoras" runat="server" DataSourceID="ObjectDataSource1" 
                        GridLines="None" AutoGenerateColumns="False" 
                        ondatabound="RgHoras_DataBound">
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" DataKeyNames="usuarioTipo">
                            <Columns>
                                <telerik:GridBoundColumn DataField="NombreTipoUsuario" HeaderText="Tipo de Usuario" UniqueName="NombreTipoUsuario" >
                                    <HeaderStyle Width="50%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Horas Disponibles" UniqueName="nroHoras" DataField="nroHoras" >
                                    <HeaderStyle Width="50%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtNroHoras" runat="server" Text='<%# Eval("nroHoras") %>' />
                                    </ItemTemplate>
                                 </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                No hay datos para mostrar
                            </NoRecordsTemplate>
                        </MasterTableView>
                    </telerik:RadGrid>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <telerik:RadButton ID="BtnGuardar" runat="server" Text="Guardar" 
                    onclick="BtnGuardar_Click" />
            </div>
        </div>
    </div>
<%--    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Listar"
        TypeName="ReservasUPN.BL.RecursoTipoHoraBL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbTiposRecurso" Name="idrecursotipo" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <%--<telerik:AjaxUpdatedControl ControlID="CmbTiposRecurso"/>--%>
                    <telerik:AjaxUpdatedControl ControlID="RgHoras" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--<telerik:AjaxSetting AjaxControlID="CmbTiposRecurso">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHoras" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
            <telerik:AjaxSetting AjaxControlID="RgHoras">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHoras" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>            
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
