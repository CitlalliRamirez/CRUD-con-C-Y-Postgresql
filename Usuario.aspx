<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="aplicacion1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insertar, consultar, eliminar, editar con C# y SQl Server</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-md-4" style="text-align:center">
                <div class="well">
                    <h4><i class="glyphicon glyphicon-user"></i> Insertar nuevo registro</h4><hr />
                    <p><asp:Label ID="LblGuardar" runat="server"></asp:Label></p>
                    <p>Nombre:</p>
                    <p><asp:TextBox ID="TxtNombre" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p>Apellido paterno:</p>
                    <p><asp:TextBox ID="ApP" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Apellido materno:</p>
                    <p><asp:TextBox ID="ApM" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Edad:</p>
                    <p><asp:TextBox ID="Ed" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p><asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar Registro" OnClick="BtnGuardar_Click" /></p>
                </div>
            </div>
            <div class="col-md-6" style="text-align:center">
                 <asp:Literal ID="Literal1" runat="server">Consulta de datos</asp:Literal> 
            </div>
            
            <div class="col-md-4" style="text-align:center">
                <h4>Escoge el usuario que desees eliminar</h4><hr />
                <p><asp:Label ID="LblEliminar" runat="server"></asp:Label></p>
                <p><asp:DropDownList ID="CmbRegistro" CssClass="form-control" runat="server"></asp:DropDownList></p>
                <p><asp:Button ID="BtnEliminar" runat="server" CssClass="btn btn-primary" Text="Eliminar usuario" OnClick="BtnEliminar_Click" /></p>
                <p><asp:Button ID="BtnModificar" runat="server" CssClass="btn btn-primary" Text="Modificar Usuario" OnClick="BtnModificar_Click" /></p>
               

        </div>
        <div class="col-md-4" style="text-align:center">
            <div class="well">
             <h4><i class="glyphicon glyphicon-user"></i> Modificar registro</h4><hr />
                    <p><asp:Label ID="LblGuardarM" runat="server"></asp:Label></p>
                    <p>Nombre:</p>
                    <p><asp:TextBox ID="TxtNombre2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p>Apellido paterno:</p>
                    <p><asp:TextBox ID="ApP2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Apellido materno:</p>
                    <p><asp:TextBox ID="ApM2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Edad:</p>
                    <p><asp:TextBox ID="Ed2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <h4>Dirección</h4>
                    <p> Calle:</p>
                    <p><asp:TextBox ID="calle2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Colonia:</p>
                    <p><asp:TextBox ID="colonia2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Delegación</p>
                    <p><asp:TextBox ID="delega2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p> Número:</p>
                    <p><asp:TextBox ID="nume2" runat="server" style="margin:0 auto" CssClass="form-control" Width="200px"></asp:TextBox></p>
                    <p><asp:Button ID="BtnGuardarM" runat="server" CssClass="btn btn-primary" Text="Guardar modificación" onclick="BtnGuardarM_Click"/></p>
              </div>  
        </div>
    </div>
    </div>
    </form>
</body>
</html>
