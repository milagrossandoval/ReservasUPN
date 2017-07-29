<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UsoRecursos.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Uso de Recursos</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <table width="100%">
                    <tr>
                        <td>
                            Sucursal:
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboSucursal" runat="server">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            Tipo de Recurso:
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboTipoRecurso" runat="server">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
                </br> </br>
                <telerik:RadButton ID="btnNuevo" runat="server" Text="Guardar"
                    RenderMode="Lightweight">
                </telerik:RadButton>
            </div>
        </div>
    </div>
</asp:Content>
