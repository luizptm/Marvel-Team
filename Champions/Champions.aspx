<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Champions.aspx.cs" Inherits="Champions.Champions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Luta de Heróis</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <script type="text/javascript" src="/Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Scripts/Main.js"></script>
    <script src="Scripts/angular.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 20px">
            <div class="panel panel-default">
                <div class="panel-heading" style="background-color: #428bca; background-image: none; font-size: medium; color: white;">
                    Luta de Heróis</div>
                <div class="panel-heading" style="background-color: #ffffff; background-image: none;">
                </div>
                <div class="panel-body" style="min-height: 80%">
                    <div class="row">
                        <div class="well">
                            Selecione três integrantes de cada time
                        </div>

                        <br />
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Table ID="Table1" runat="server" CellPadding="10" CellSpacing="2">
                            <asp:TableRow>
                                <asp:TableCell>
                                <span class="label label-default">Time 1</span>
                                </asp:TableCell>
                                <asp:TableCell>
                                <span class="label label-default">Time 2</span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:DataList ID="dlTeam1" runat="server">
                                        <HeaderTemplate>
                                            <div class="well" style="font-weight: bold;">
                                                Integrantes do time 1
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <img src="<%# Eval("Thumbnail.Path") %>.<%# Eval("Thumbnail.Extension") %>" height="50" width="50" />
                                                    <%# Eval("Name") %>
                                                   </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DataList ID="dlTeam2" runat="server">
                                            <HeaderTemplate>
                                                <div class="well" style="font-weight: bold;">
                                                    Integrantes do time 2
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <img src="<%# Eval("Thumbnail.Path") %>.<%# Eval("Thumbnail.Extension") %>" height="50" width="50" />
                                                        <%# Eval("Name") %>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="10" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple" Rows="10" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <asp:Button ID="btnExibir" runat="server" Text="Exibir e Salvar" OnClick="btnExibir_Click" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <div id="winnerCharacters">
                            <strong>Time campeão: <asp:Label ID="lblTime" runat="server" Text=""></asp:Label></strong>
                            <asp:DataList ID="dlWinners" runat="server">
                                <HeaderTemplate>
                                    <div class="well" style="font-weight: bold;">
                                        Integrantes do time campeão
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <img src="<%# Eval("Thumbnail.Path") %>.<%# Eval("Thumbnail.Extension") %>" height="50" width="50" />
                                            <%# Eval("Name") %>
                                            <div class="panel panel-default">
                                                <div class="panel-body">
                                                    <%# Eval("Description") %>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
