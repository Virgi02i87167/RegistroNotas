<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Prrsentacion.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro Notas</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="../index.aspx">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="../Cuentas/index.aspx">Credenciales</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Registro/registro.aspx">Registrar Notas</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>

        <div class="container">
            <div class="card m-auto mt-5 p-3" style="width: 1300px;">
                <div class="row">
                    <div class="col-md-4">
                        <h1>Registro de Notas</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
                            Agregar Nota
                        </button>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="gvRegistro" runat="server" CssClass="table table-striped mt-3"
                            DataKeyNames="id"
                            AutoGenerateColumns="false" OnRowDeleting="gvRegistro_RowDeleting"
                            OnRowEditing="gvRegistro_RowEditing" OnRowCancelingEdit="gvRegistro_RowCancelingEdit"
                            OnRowUpdating="gvRegistro_RowUpdating">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Id" />
                                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                                <asp:BoundField DataField="Hora" HeaderText="Hora" DataFormatString="{0:HH:mm:ss}" HtmlEncode="false" />
                                <asp:CommandField ShowEditButton="true" EditText="Editar" />
                                <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <!-- Modal de Agregar Nota-->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Agregar Nota</h5>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label runat="server">Titulo:</asp:Label>
                                    <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server">Descripcion:</asp:Label>
                                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label runat="server" AssociatedControlID="txtFecha">Fecha:</asp:Label>
                                    <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" AssociatedControlID="txtHora">Hora:</asp:Label>
                                    <asp:TextBox runat="server" ID="txtHora" CssClass="form-control" TextMode="Time"></asp:TextBox>
                                </div>
                            </div>
                            >
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <asp:LinkButton runat="server" ID="btnAgregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" Text="Guardar" />
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
