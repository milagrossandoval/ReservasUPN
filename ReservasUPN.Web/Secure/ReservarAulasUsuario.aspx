<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true" CodeBehind="ReservarAulasUsuario.aspx.cs" Inherits="ReservasUPN.Web.Secure.ReservarAulasUsuario" %>
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
                Sede<br />
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="200" DataValueField="id" CausesValidation="false" />
            </div>
            <div class="col-lg-4">
                Usuario
                <table border="0" cellpadding="5" >
                    <tr>
                        <td style="width:80%">
                            <telerik:RadTextBox ID="TxtUsuario" runat="server" Width="180" />
                            <asp:RequiredFieldValidator ID="RfvUsuario" runat="server" 
                                ErrorMessage="*" ControlToValidate="TxtUsuario" ForeColor="Red" Display="Dynamic" />
                        </td>
                        <td style="width:20%">
                            <asp:ImageButton ID="BtnBuscar" runat="server" 
                                ImageUrl="~/assets/images/search.png" Width="23" Height="23" 
                                onclick="BtnBuscar_Click" />
                        </td>
                    </tr>
                </table>               
                
            </div>
            <div class="col-lg-4">
                <asp:HiddenField ID="HfUsuario" runat="server" />
                <asp:HiddenField ID="HfTipoUsuario" runat="server" />
                <center>
                <asp:Label ID="LblUsuario" runat="server" />
                </center>
            </div>
        </div>
        <br />
        <asp:Panel ID="PnlReserva" runat="server" Visible="false" BorderColor="Gray" BorderWidth="1"  >
        <div class="row">
            <div class="col-lg-4">
                <h5>
                    Aula
                </h5>
                <telerik:RadComboBox ID="CmbAulas" runat="server" AutoPostBack="True" Width="200px"
                    DataValueField="id" DataTextField="descripcion" CausesValidation="false" DataSourceID="OdsAulas"
                    OnDataBound="CmbAulas_DataBound" OnSelectedIndexChanged="CmbAulas_SelectedIndexChanged" />
                <asp:ObjectDataSource ID="OdsAulas" runat="server" SelectMethod="Listar" TypeName="ReservasUPN.BL.AulaBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbSedes" Name="idSede" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <h5>
                    Recurso</h5>
                <telerik:RadComboBox ID="CmbRecursos" runat="server" AutoPostBack="True" Width="200px" CausesValidation="false"
                    DataValueField="id" DataTextField="descripcion" DataSourceID="OdsRecurso" OnDataBound="CmbRecursos_DataBound"
                    OnSelectedIndexChanged="CmbRecursos_SelectedIndexChanged" />
                <asp:ObjectDataSource ID="OdsRecurso" runat="server" SelectMethod="Listar" TypeName="ReservasUPN.BL.RecursoBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbTiposRecurso" Name="idtiporecurso" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="HfTipoHora" runat="server" />
            </div>
            <div class="col-lg-4">
                <h5>
                    Características</h5>
                <asp:TextBox ID="TxtCaracteristicas" runat="server" TextMode="MultiLine" Height="80"
                    ReadOnly="true" /><br />
            </div>
            <div class="col-lg-4">
                Fecha
                <telerik:RadDatePicker ID="DpFecha" runat="server" AutoPostBack="true"   
                    onselecteddatechanged="DpFecha_SelectedDateChanged" >
                    <Calendar ID="Calendar1" runat="server" FirstDayOfWeek="Monday" ShowOtherMonthsDays="false"/>
                    </telerik:RadDatePicker>
                <br />
                <br />
                
                <asp:Label ID="LblDisponibles" runat="server" ForeColor="Green" />
                <asp:Label ID="LblUsadas" runat="server" ForeColor="Red" />
                <asp:Label ID="LblMesActual" runat="server" ForeColor="Black" />
                <asp:HiddenField ID="HfDisponibles" runat="server" />
                <asp:HiddenField ID="HfUsadas" runat="server" />
                <asp:HiddenField ID="HfMesActual" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <telerik:RadGrid ID="RgHorario" runat="server" 
                        GridLines="None"
                        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                        OnDataBound="RgHorario_DataBound">
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
                                        <asp:Label ID="LblLunes" runat="server" Visible="false" ForeColor="Blue"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Martes" UniqueName="Martes">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkMartes" runat="server" Visible='<%# Eval("martes") %>' />
                                        <asp:Label ID="LblMartes" runat="server" Visible="false" ForeColor="Blue"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Miércoles" UniqueName="Miercoles">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkMiercoles" runat="server" Visible='<%# Eval("miercoles") %>' />
                                        <asp:Label ID="LblMiercoles" runat="server" Visible="false" ForeColor="Blue"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Jueves" UniqueName="Jueves">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkJueves" runat="server" Visible='<%# Eval("jueves") %>' />
                                        <asp:Label ID="LblJueves" runat="server" Visible="false" ForeColor="Blue"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Viernes" UniqueName="Viernes">
                                    <HeaderStyle Width="12.5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkViernes" runat="server" Visible='<%# Eval("viernes") %>' />
                                        <asp:Label ID="LblViernes" runat="server" Visible="false" ForeColor="Blue"/>
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
                            <asp:ControlParameter ControlID="CmbRecursos" Name="idrecurso" PropertyName="SelectedValue"
                                Type="Int32" />
                            <asp:ControlParameter ControlID="HfTipoHora" Name="idtipohora" PropertyName="Value"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <telerik:RadButton ID="BtnGuardar" runat="server" Text="Guardar" 
                        Enabled="false" onclick="BtnGuardar_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
        </asp:Panel>
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
