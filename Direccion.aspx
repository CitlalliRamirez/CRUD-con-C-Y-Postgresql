<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Direccion.aspx.cs" Inherits="aplicacion1.Direccion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

 <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <title>Direcciones</title>
</head>
<body>
    <form id="form2" runat="server">
        <div class="container">

        <div class="row">
            <div class="col-md-4" style="text-align:center">
                <div class="well">
                    <h4><i class="glyphicon glyphicon-user"></i> Insertar nueva direccion</h4><hr />
                    <p><asp:Label ID="LblGuardar2" runat="server"></asp:Label></p>
                    <p>Calle:</p>
                    <p><asp:TextBox ID="TxtCalle" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p>Colonia:</p>
                    <p><asp:TextBox ID="Colon" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p>Delegacion:</p>
                    <p><asp:TextBox ID="Dele" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Numero:</p>
                    <p><asp:TextBox ID="Nume" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p><asp:Button ID="BtnGuardar2" runat="server" CssClass="btn btn-primary" Text="Guardar Direccion" OnClick="BtnGuardar2_Click" /></p>
                </div>
            </div>
           
        </div>
    </div>
    </form>
</body>
</html>
