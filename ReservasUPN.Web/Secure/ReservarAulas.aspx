<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="ReservarAulas.aspx.cs" Inherits="ReservasUPN.Web.Secure.ReservarAulas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Reservar Aulas</h3>
            </div>
        </div>
        <div class="row" id="rowSede">
            <div class="col-lg-4">
                Sede
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="200" DataValueField="id" CausesValidation="false" />
            </div>
            <div class="col-lg-4">
                <h5>
                    Aula
                </h5>
                <telerik:RadComboBox ID="CmbAulas" runat="server" AutoPostBack="True" Width="200px"
                    CausesValidation="False" DataSourceID="OdsAula"
                    OnDataBound="CmbAulas_DataBound" 
                    OnSelectedIndexChanged="CmbAulas_SelectedIndexChanged" />
                <asp:ObjectDataSource ID="OdsAula" runat="server" SelectMethod="Listar" TypeName="ReservasUPN.BL.AulaBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbSedes" Name="idSede" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div class="col-lg-4">
                Fecha
                <telerik:RadDatePicker ID="DpFecha" runat="server" AutoPostBack="true" OnSelectedDateChanged="DpFecha_SelectedDateChanged">
                    <Calendar ID="Calendar1" runat="server" FirstDayOfWeek="Monday" ShowOtherMonthsDays="false" />
                </telerik:RadDatePicker>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <telerik:RadGrid ID="RgHorario" runat="server" GridLines="None" AutoGenerateColumns="False"
                        DataSourceID="ObjectDataSource1" OnDataBound="RgHorario_DataBound">
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" DataKeyNames="hora,HoraInicio,HoraFinal,DesHora">
                            <Columns>
                                <telerik:GridBoundColumn DataField="DesHora" HeaderText="Hora" UniqueName="Hora">
                                    <HeaderStyle Width="12.5%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Lunes" UniqueName="Lunes">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkLunes" CssClass="ChkLunes" runat="server" Visible='<%# Eval("lunes") %>' />
                                        <asp:Label ID="LblLunes" runat="server" Visible="false" ForeColor="Blue" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Martes" UniqueName="Martes">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkMartes" runat="server" Visible='<%# Eval("martes") %>' />
                                        <asp:Label ID="LblMartes" runat="server" Visible="false" ForeColor="Blue" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Miércoles" UniqueName="Miercoles">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkMiercoles" runat="server" Visible='<%# Eval("miercoles") %>' />
                                        <asp:Label ID="LblMiercoles" runat="server" Visible="false" ForeColor="Blue" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Jueves" UniqueName="Jueves">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkJueves" runat="server" Visible='<%# Eval("jueves") %>' />
                                        <asp:Label ID="LblJueves" runat="server" Visible="false" ForeColor="Blue" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Viernes" UniqueName="Viernes">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkViernes" runat="server" Visible='<%# Eval("viernes") %>' />
                                        <asp:Label ID="LblViernes" runat="server" Visible="false" ForeColor="Blue" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Sábado" UniqueName="Sabado">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkSabado" runat="server" Visible='<%# Eval("sabado") %>' />
                                        <asp:Label ID="LblSabado" runat="server" Visible="false" ForeColor="Blue" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Domingo" UniqueName="Domingo">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkDomingo" runat="server" Visible='<%# Eval("domingo") %>' />
                                        <asp:Label ID="LblDomingo" runat="server" Visible="false" ForeColor="Blue" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                No se encontraron datos.
                            </NoRecordsTemplate>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Buscar"
                        TypeName="ReservasUPN.BL.HorarioBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="CmbAulas" Name="idrecurso" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <telerik:RadButton ID="BtnGuardar" runat="server" Text="Guardar" Enabled="false"
                        OnClick="BtnGuardar_Click" CausesValidation="false" />
                </div>
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
                    <telerik:AjaxUpdatedControl ControlID="CmbRecursos" />
                    <telerik:AjaxUpdatedControl ControlID="TxtCaracteristicas" />
                    <telerik:AjaxUpdatedControl ControlID="LblDisponibles" />
                    <telerik:AjaxUpdatedControl ControlID="LblMesActual" />
                    <telerik:AjaxUpdatedControl ControlID="LblUsadas" />
                    <telerik:AjaxUpdatedControl ControlID="HfDisponibles" />
                    <telerik:AjaxUpdatedControl ControlID="HfMesActual" />
                    <telerik:AjaxUpdatedControl ControlID="HfUsadas" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="BtnBuscar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="LblUsuario" />
                    <telerik:AjaxUpdatedControl ControlID="ImgFoto" />
                    <telerik:AjaxUpdatedControl ControlID="HfUsuario" />
                    <telerik:AjaxUpdatedControl ControlID="HfTipoUsuario" />
                    <telerik:AjaxUpdatedControl ControlID="PnlReserva" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbTiposRecurso">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="HfTipoHora" />
                    <telerik:AjaxUpdatedControl ControlID="CmbRecursos" />
                    <telerik:AjaxUpdatedControl ControlID="TxtCaracteristicas" />
                    <telerik:AjaxUpdatedControl ControlID="LblDisponibles" />
                    <telerik:AjaxUpdatedControl ControlID="LblMesActual" />
                    <telerik:AjaxUpdatedControl ControlID="LblUsadas" />
                    <telerik:AjaxUpdatedControl ControlID="HfDisponibles" />
                    <telerik:AjaxUpdatedControl ControlID="HfMesActual" />
                    <telerik:AjaxUpdatedControl ControlID="HfUsadas" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbRecursos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="TxtCaracteristicas" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RgHorario">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="BtnGuardar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="LblDisponibles" />
                    <telerik:AjaxUpdatedControl ControlID="LblMesActual" />
                    <telerik:AjaxUpdatedControl ControlID="LblUsadas" />
                    <telerik:AjaxUpdatedControl ControlID="HfDisponibles" />
                    <telerik:AjaxUpdatedControl ControlID="HfMesActual" />
                    <telerik:AjaxUpdatedControl ControlID="HfUsadas" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
