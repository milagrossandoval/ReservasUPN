<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true" CodeBehind="RecursoTipoHora.aspx.cs" Inherits="ReservasUPN.Web.Secure.RecursoTipoHora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Configuración de Horas por Tipo de Recurso</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
                <h5>Sede</h5>
            </div>
            <div class="col-lg-5">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="300" DataValueField="id" />
            </div>
            <div class="col-lg-2">
                <h5>Tipo de Recurso</h5>
            </div>
            <div class="col-lg-3">
                <telerik:RadComboBox ID="CmbTiposRecurso" runat="server" AutoPostBack="True" DataTextField="descripcion"
                    Width="200px" DataValueField="id" DataSourceID="OdsRecursoTipo" 
                    ondatabound="CmbTiposRecurso_DataBound" />
                <asp:ObjectDataSource ID="OdsRecursoTipo" runat="server" SelectMethod="Listar" 
                    TypeName="ReservasUPN.BL.RecursoTipoBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbSedes" Name="idSede" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
                <telerik:RadButton ID="BtnGuardar" runat="server" Text="Guardar" onclick="BtnGuardar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <telerik:RadGrid ID="RgHoras" runat="server" DataSourceID="ObjectDataSource1" 
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
                    </telerik:RadGrid>
                </div>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Listar"
        TypeName="ReservasUPN.BL.RecursoTipoHoraBL">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbTiposRecurso" Name="idrecursotipo" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="CmbTiposRecurso"/>
                    <%--<telerik:AjaxUpdatedControl ControlID="RgHoras" LoadingPanelID="RadAjaxLoadingPanel1" />--%>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbTiposRecurso">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHoras" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RgHoras">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHoras" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>            
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
