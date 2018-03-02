<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="Relatorio.Relatorio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #form1{background-color:Black;color:white;font-size:30px}
        body{background-color:black}
        h1{color:white;}
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <center>
           <h1>Relatório</h1>
    <font color="white">
        <asp:GridView ID="dgListaClientes" runat="server">
        </asp:GridView>
    </font>
           </center>
    </div>
    </form>
</body>
</html>
