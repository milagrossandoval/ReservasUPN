<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="MisReservas.aspx.cs" Inherits="ReservasUPN.Web.Secure.MisReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Mis Reservas</h3>
            </div>
        </div>
        <div class="row" id="rowSede">
            <div class="col-lg-3">
                Sede
            </div>
            <div class="col-lg-9">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="300" DataValueField="id" />
            </div>
        </div>
        <div class="row">
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
            <div class="col-lg-3">
                Fecha
            </div>
            <div class="col-lg-3">
                <telerik:RadDatePicker ID="DpFecha" runat="server" 
                    onselecteddatechanged="DpFecha_SelectedDateChanged" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <telerik:RadGrid ID="RgHorario" runat="server" GridLines="None" AutoGenerateColumns="False"
                    DataSourceID="ObjectDataSource1" OnDataBound="RgHorario_DataBound" 
                    onitemcommand="RgHorario_ItemCommand" 
                    onitemcreated="RgHorario_ItemCreated" >
                    <ClientSettings>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    </ClientSettings>
                    <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" DataKeyNames="n_hor_codigo">
                        <Columns>
                            <telerik:GridBoundColumn DataField="s_hor_descripcion" HeaderText="Hora" UniqueName="Hora">
                                <HeaderStyle Width="12.5%" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Lunes" UniqueName="Lunes">
                                <HeaderStyle Width="12.5%" />
                                <ItemTemplate/>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Martes" UniqueName="Martes">
                                <HeaderStyle Width="12.5%" />
                                <ItemTemplate/>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Miércoles" UniqueName="Miercoles">
                                <HeaderStyle Width="12.5%" />
                                <ItemTemplate/>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Jueves" UniqueName="Jueves">
                                <HeaderStyle Width="12.5%" />
                                <ItemTemplate/>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Viernes" UniqueName="Viernes">
                                <HeaderStyle Width="12.5%" />
                                <ItemTemplate />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Sábado" UniqueName="Sabado">
                                <HeaderStyle Width="12.5%" />
                                <ItemTemplate/>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Domingo" UniqueName="Domingo">
                                <HeaderStyle Width="12.5%" />
                                <ItemTemplate/>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <NoRecordsTemplate>
                            No se encontraron datos.
                        </NoRecordsTemplate>
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Listar"
                    TypeName="ReservasUPN.BL.HoraBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HfTipoHora" Name="tipohora" PropertyName="Value"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="CmbTiposRecurso" />
                    <telerik:AjaxUpdatedControl ControlID="HfTipoHora" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbTiposRecurso">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="HfTipoHora" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="DpFecha">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RgHorario">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
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

            function BtnCancelar_OnClientClicking(event,arguments){
                if(!confirm("¿Seguro de cancelar la reserva?")){
                    arguments.set_cancel(true);
                }
            }

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
