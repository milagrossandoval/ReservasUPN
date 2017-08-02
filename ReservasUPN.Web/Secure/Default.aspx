<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <%--<telerik:radgrid id="rgDemo" runat="server" Culture="es-ES" 
        DataSourceID="ObjectDataSource1">
        <MasterTableView AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <Columns>
                <telerik:GridBoundColumn DataField="idTipoRecurso" DataType="System.Int32" 
                    FilterControlAltText="Filter idTipoRecurso column" HeaderText="idTipoRecurso" 
                    SortExpression="idTipoRecurso" UniqueName="idTipoRecurso">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="idSede" DataType="System.Int32" 
                    FilterControlAltText="Filter idSede column" HeaderText="idSede" 
                    SortExpression="idSede" UniqueName="idSede">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="descripcion" 
                    FilterControlAltText="Filter descripcion column" HeaderText="descripcion" 
                    SortExpression="descripcion" UniqueName="descripcion">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="idTipoHora" DataType="System.Int32" 
                    FilterControlAltText="Filter idTipoHora column" HeaderText="idTipoHora" 
                    SortExpression="idTipoHora" UniqueName="idTipoHora">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:radgrid>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="listar" TypeName="ReservasUPN.BL.TipoRecursoBL">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="sede" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
</asp:Content>
