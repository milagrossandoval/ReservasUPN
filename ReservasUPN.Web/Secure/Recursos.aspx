<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true"
    CodeBehind="Recursos.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Recursos</h3>
            </div>
        </div>
        <div class="row">            
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
                            <td>
                                Descripción:
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtDescripcion" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                    </table>
                    </br>
                    </br>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_RESERVAS_QAConnectionString
        %>" SelectCommand="SELECT [Cod_Usuario], [Nombre], [CodTipo_Usuario] FROM [Table_Usuario]"></asp:SqlDataSource>
                    <telerik:RadGrid RenderMode="Lightweight" ID="gridUsuarios" runat="server" AllowPaging="True"
                        PageSize="5" Skin="Windows7" DataSourceID="SqlDataSource1" GridLines="None">
                        <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="true"></Selecting>
                        </ClientSettings>
                        <MasterTableView Width="100%" AutoGenerateColumns="False" DataKeyNames="Cod_Usuario"
                            DataSourceID="SqlDataSource1">
                            <ItemTemplate>
                                Item 1
                            </ItemTemplate>
                            <CommandItemSettings ExportToPdfText="Export
        to Pdf"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter
        RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter
        ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Cod_Usuario" Display="true" DataField="Cod_Usuario"
                                    DataType="System.Int32" FilterControlAltText="Filter Cod_Usuario column" ReadOnly="True"
                                    SortExpression="Cod_Usuario" UniqueName="Cod_Usuario">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Nombre" Display="true" DataField="Nombre" FilterControlAltText="Filter Nombre column"
                                    SortExpression="Nombre" UniqueName="Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="CodTipo_Usuario" Display="true" DataField="CodTipo_Usuario"
                                    DataType="System.Int32" FilterControlAltText="Filter
        CodTipo_Usuario column" SortExpression="CodTipo_Usuario" UniqueName="CodTipo_Usuario">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter
        EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    </br>
                    </br>
                    <telerik:RadButton ID="btnNuevo" runat="server" Text="Sincronizar" Skin="Windows7"
                        RenderMode="Lightweight">
                    </telerik:RadButton>
    
        </div>
    </div>
</asp:Content>
