<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="Seguimiento.aspx.cs" Inherits="ReservasUPN.Web.Secure.Seguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Seguimiento de Reservas</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                Sede
            </div>
            <div class="col-lg-3">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="200" DataValueField="id" />
            </div>
            <div class="col-lg-3">
                Tipo de Recurso
            </div>
            <div class="col-lg-3">
                <telerik:RadComboBox ID="CmbTiposRecurso" runat="server" AutoPostBack="True" Width="200px"
                    DataValueField="id" DataTextField="descripcion" DataSourceID="OdsRecursoTipo"
                    OnDataBound="CmbTiposRecurso_DataBound" OnSelectedIndexChanged="CmbTiposRecurso_SelectedIndexChanged" />
                <asp:ObjectDataSource ID="OdsRecursoTipo" runat="server" SelectMethod="Listar" TypeName="ReservasUPN.BL.RecursoTipoBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbSedes" Name="idSede" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="HfTipoHora" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-7">
                <div class="panel panel-default">
                    <asp:HiddenField ID="HfHoraActual" runat="server" />
                    <asp:Label ID="LblHoraActual" runat="server" />
                    <telerik:RadGrid ID="RgActual" runat="server" 
                        GridLines="None" AutoGenerateColumns="False" OnItemCommand="RgActual_ItemCommand"
                        DataSourceID="OdsActual" onitemdatabound="RgActual_ItemDataBound">
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id,asistencia" OverrideDataSourceControlSorting="true"
                            DataSourceID="OdsActual">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="" ItemStyle-HorizontalAlign="center">
                                    <HeaderStyle Width="15%" />
                                    <ItemTemplate>
                                        <asp:Image ID="ImgFoto" runat="server" ImageUrl='<%# Eval("Foto") %>' 
                                        Width="45" Height="60"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="NombreRecurso"
                                    HeaderText="Recurso" UniqueName="NombreRecurso"
                                    AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="15%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="usuario"
                                    HeaderText="Código" UniqueName="usuario" AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="15%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="nombreUsuario" 
                                    HeaderText="Usuario" UniqueName="nombreUsuario"
                                    AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="25%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn DataField="Continuar" 
                                    HeaderText="Continua" UniqueName="Continuar"
                                    AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="15%" />
                                </telerik:GridCheckBoxColumn>
                                <telerik:GridTemplateColumn HeaderText="" ItemStyle-HorizontalAlign="center">
                                    <FilterTemplate />
                                    <HeaderStyle Width="15%" />
                                    <ItemTemplate>
                                        <telerik:RadButton 
                                        runat="server" ID="BtnAsistir" CommandName="Asistencia" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                No hay datos para mostrar
                            </NoRecordsTemplate>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <asp:ObjectDataSource ID="OdsActual" runat="server" SelectMethod="ListarHoy" TypeName="ReservasUPN.BL.ReservaBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HfHoraActual" Name="hora" PropertyName="Value" Type="Int32" />
                            <asp:ControlParameter ControlID="CmbTiposRecurso" Name="idtiporecurso" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="panel panel-default">
                    <asp:HiddenField ID="HfHoraSiguiente" runat="server" />
                    <asp:Label ID="LblHoraSiguiente" runat="server" />
                    <telerik:RadGrid ID="RgSiguiente" runat="server"
                        GridLines="None" AutoGenerateColumns="False"
                        DataSourceID="OdsSiguiente" >
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="id" OverrideDataSourceControlSorting="true"
                            DataSourceID="OdsSiguiente">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="" ItemStyle-HorizontalAlign="center">
                                    <FilterTemplate />
                                    <HeaderStyle Width="25%" />
                                    <ItemTemplate>
                                        <asp:Image ID="ImgFoto" runat="server" ImageUrl='<%# Eval("Foto") %>' 
                                        Width="45" Height="60"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="NombreRecurso" 
                                    HeaderText="Recurso" UniqueName="NombreRecurso"
                                    AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="25%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="usuario" 
                                    HeaderText="Código" UniqueName="usuario" AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="25%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="nombreUsuario" 
                                    HeaderText="Usuario" UniqueName="nombreUsuario"
                                    AutoPostBackOnFilter="true">
                                    <HeaderStyle Width="25%" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                No hay datos para mostrar
                            </NoRecordsTemplate>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <asp:ObjectDataSource ID="OdsSiguiente" runat="server" SelectMethod="ListarHoy" TypeName="ReservasUPN.BL.ReservaBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HfHoraSiguiente" Name="hora" PropertyName="Value"
                                Type="Int32" />
                            <asp:ControlParameter ControlID="CmbTiposRecurso" Name="idtiporecurso" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
    <asp:Timer ID="Timer1" runat="server" Interval="120000" OnTick="Timer1_Tick" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="CmbTiposRecurso" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbTiposRecurso">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="HfTipoHora" />
                    <telerik:AjaxUpdatedControl ControlID="HfHoraActual" />
                    <telerik:AjaxUpdatedControl ControlID="LblHoraActual" />
                    <telerik:AjaxUpdatedControl ControlID="RgActual" />
                    <telerik:AjaxUpdatedControl ControlID="HfHoraSiguiente" />
                    <telerik:AjaxUpdatedControl ControlID="LblHoraSiguiente" />
                    <telerik:AjaxUpdatedControl ControlID="RgSiguiente" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Timer1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="HfHoraActual" />
                    <telerik:AjaxUpdatedControl ControlID="LblHoraActual" />
                    <telerik:AjaxUpdatedControl ControlID="RgActual" />
                    <telerik:AjaxUpdatedControl ControlID="HfHoraSiguiente" />
                    <telerik:AjaxUpdatedControl ControlID="LblHoraSiguiente" />
                    <telerik:AjaxUpdatedControl ControlID="RgSiguiente" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RgActual">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgActual" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RgSiguiente">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgSiguiente" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
