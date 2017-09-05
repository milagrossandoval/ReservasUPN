<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true" CodeBehind="RecursosHorario.aspx.cs" Inherits="ReservasUPN.Web.Secure.RecursosHorario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">Horarios Disponibles del Recurso</h3>
            </div>
         </div>
         <div class="row">
            <div class="col-lg-4">
                <h5>Sede</h5>
            </div>
            <div class="col-lg-4">
                <h5>Tipo de Recurso</h5>
            </div>
            <div class="col-lg-4">
                <h5>Recurso</h5>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <telerik:RadComboBox ID="CmbSedes" runat="server" AutoPostBack="true" DataTextField="descripcion"
                    Width="300" DataValueField="id" 
                    onselectedindexchanged="CmbSedes_SelectedIndexChanged" />
            </div>
            <div class="col-lg-4">
                <telerik:RadComboBox ID="CmbTiposRecurso" runat="server" AutoPostBack="True"
                    Width="200px" DataValueField="id" DataTextField="descripcion" DataSourceID="OdsRecursoTipo" 
                    ondatabound="CmbTiposRecurso_DataBound" 
                    onselectedindexchanged="CmbTiposRecurso_SelectedIndexChanged" />
                <asp:CheckBox ID="ChkDefault" runat="server" 
                    Text="Grabar como horario por defecto" AutoPostBack="true" 
                    oncheckedchanged="ChkDefault_CheckedChanged" />
                <asp:ObjectDataSource ID="OdsRecursoTipo" runat="server" SelectMethod="Listar" 
                    TypeName="ReservasUPN.BL.RecursoTipoBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbSedes" Name="idSede" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div class="col-lg-4">
                <telerik:RadComboBox ID="CmbRecursos" runat="server" AutoPostBack="True"
                    Width="200px" DataValueField="id" DataTextField="descripcion" DataSourceID="OdsRecurso" 
                    ondatabound="CmbRecursos_DataBound" 
                    onselectedindexchanged="CmbRecursos_SelectedIndexChanged" />
                <asp:ObjectDataSource ID="OdsRecurso" runat="server" SelectMethod="Listar" 
                    TypeName="ReservasUPN.BL.RecursoBL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CmbTiposRecurso" Name="idtiporecurso" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    
    <div class="row">
        <div class="col-lg-12">
           <div class="panel panel-default">
                    <telerik:RadGrid ID="RgHorario" runat="server" GridLines="None" 
                        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                        ondatabound="RgHorario_DataBound" >
                        <ClientSettings>
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>
                        <MasterTableView DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" DataKeyNames="hora">
                            <Columns>

                                <telerik:GridBoundColumn DataField="DesHora" HeaderText="Hora" UniqueName="Hora">
                                    <HeaderStyle Width="12.5%" />
                                </telerik:GridBoundColumn>

                                <telerik:GridTemplateColumn UniqueName="Lunes">
                                    <HeaderStyle Width="12.5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkLunes" runat="server" Text="Lunes" onclick="javascript:return CheckedChange(this,'Lunes')" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkLunes" CssClass="ChkLunes" runat="server" Checked='<%# Eval("lunes") %>'/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Martes">
                                    <HeaderStyle Width="12.5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkMartes" runat="server" Text="Martes" onclick="javascript:return CheckedChange(this,'Martes')" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkMartes" runat="server" Checked='<%# Eval("martes") %>'/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Miercoles">
                                    <HeaderStyle Width="12.5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkMiercoles" runat="server" Text="Miércoles" onclick="javascript:return CheckedChange(this,'Miercoles')"/>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkMiercoles" runat="server" Checked='<%# Eval("miercoles") %>'/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Jueves">
                                    <HeaderStyle Width="12.5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkJueves" runat="server" Text="Jueves"  onclick="javascript:return CheckedChange(this,'Jueves')"/>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkJueves" runat="server" Checked='<%# Eval("jueves") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Viernes">
                                    <HeaderStyle Width="12.5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkViernes" runat="server" Text="Viernes"  onclick="javascript:return CheckedChange(this,'Viernes')"/>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkViernes" runat="server" Checked='<%# Eval("viernes") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Sabado">
                                    <HeaderStyle Width="12.5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkSabado" runat="server" Text="Sábado" onclick="javascript:return CheckedChange(this,'Sabado')"/>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkSabado" runat="server" Checked='<%# Eval("sabado") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn UniqueName="Domingo">
                                    <HeaderStyle Width="12.5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkDomingo" runat="server" Text="Domingo" onclick="javascript:return CheckedChange(this,'Domingo')"/>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkDomingo" runat="server" Checked='<%# Eval("domingo") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                            <NoRecordsTemplate>
                                No se encontraron datos.
                            </NoRecordsTemplate>
                        </MasterTableView>

                    </telerik:RadGrid>
   
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="Buscar" TypeName="ReservasUPN.BL.HorarioBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="CmbTiposRecurso" Name="idtiporecurso" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="CmbRecursos" Name="idrecurso" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="ChkDefault" Name="defecto" 
                                PropertyName="Checked" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <telerik:RadButton ID="BtnGuardar" runat="server" Text="Guardar" Enabled="false"
                        onclick="BtnGuardar_Click" />


                </div>
        </div>
    </div>

</div>

   <%-- <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true" >
        <Windows>
            
        </Windows>
    </telerik:RadWindowManager>--%>

    <telerik:RadWindow ID="WinConfirmacion" runat="server" Title="Correcto"  Skin="Windows7"
            VisibleOnPageLoad="false" Modal="true" Width="350" Height="200" >
        <ContentTemplate>
            <center>
                <b>Se registró correctamente el horario para el tipo de recurso: <%= CmbTiposRecurso.Text %>. </b><br />
                ¿Desea aplicar este horario a todo los recursos del mismo tipo?<br />
                <telerik:RadTabStrip ID="TabConfirmacion" runat="server" Orientation="HorizontalBottom" 
                    AutoPostBack="true" OnTabClick="TabConfirmacion_OnTabClick"  > 
                    <Tabs> 
                        <telerik:RadTab Text="Si" PostBack="true" /> 
                        <telerik:RadTab Text="No" />
                    </Tabs> 
                </telerik:RadTabStrip> 
            </center>    
        </ContentTemplate>
    </telerik:RadWindow>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <ClientEvents/>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="CmbSedes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="CmbTiposRecurso"/>
                    <telerik:AjaxUpdatedControl ControlID="CmbRecursos" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ChkDefault">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="CmbRecursos" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbTiposRecurso">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="CmbRecursos" />
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="CmbRecursos">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                    <telerik:AjaxUpdatedControl ControlID="BtnGuardar" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RgHorario">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RgHorario" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="BtnGuardar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="WinConfirmacion" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="WinConfirmacion">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="WinConfirmacion" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript" language="javascript">
        function CheckedChange(objCheckBox, dia) {            
            var masterTable = $find("<%= RgHorario.ClientID %>").get_masterTableView();
            var strChk = "Chk" + dia;
            var dataItems = masterTable.get_dataItems();
            var chkElmt;            
            for (var row = 0; row < dataItems.length; row++) {
                chkElmt = dataItems[row].findElement(strChk);
                $('#' + chkElmt.id).prop("checked", objCheckBox.checked);             
            }
        }
    </script>
    </telerik:RadCodeBlock>
</asp:Content>
