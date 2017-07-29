<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Sanciones.aspx.cs" %>

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
            <div class="col-lg-12">
                <table width="100%">
                    <tr>
                        <td>
                            Buscar:
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtBuscar" runat="server">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            Rango Fecha:
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="txtRangoFecha" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnToggle" runat="server" ToggleType="CheckBox" ButtonType="LinkButton">
                                <ToggleStates>
                                    <telerik:RadButtonToggleState Text="Solo Activos" PrimaryIconCssClass="rbToggleCheckboxChecked" />
                                    <telerik:RadButtonToggleState Text="UnChecked" PrimaryIconCssClass="rbToggleCheckbox" />
                                </ToggleStates>
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
                </br> </br>
                <telerik:RadButton ID="btnNuevo" runat="server" Text="Guardar" RenderMode="Lightweight">
                </telerik:RadButton>
            </div>
        </div>
    </div>
</asp:Content>
