<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Prrsentacion.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Home</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <style>
        body {
            background-color: #f7e6d5;
            color: #5a5a5a;
        }

        .navbar {
            background-color: #ffb6c1 !important;
        }

        .navbar-brand, .nav-link {
            color: #fff !important;
        }

        .container {
            background: #fff;
            border-radius: 15px;
            padding: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .btn-primary {
            background-color: #ffb6c1;
            border: none;
        }

            .btn-primary:hover {
                background-color: #ff8fa3;
            }

        .btn-secondary {
            background-color: #87ceeb;
            border: none;
        }

            .btn-secondary:hover {
                background-color: #6ca6cd;
            }

        .list-group-item {
            background-color: #fff5e1;
            border: none;
            border-radius: 10px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg bg-body-tertiary">
                <div class="container-fluid">
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="index.aspx">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Cuentas/index.aspx">Credenciales</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Registro/registro.aspx">Registrar Notas</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-8 offset-md-2 text-center">
                    <h1 class="mb-4">Bienvenido al Sistema de Notas</h1>
                    <p class="lead">Registra y organiza tus notas y recordatorios de manera sencilla y eficiente.</p>
                    <a href="Registro/registro.aspx" class="btn btn-primary">Agregar Nueva Nota</a>
                </div>
            </div>

            <div class="row mt-5">
                
                <div >
                    <h3>Información Adicional</h3>
                    <p>El sistema permite registrar, modificar y eliminar notas personales para mejorar la organización y gestión de tareas.</p>
                    <p>Puedes acceder a tus notas en cualquier momento y desde cualquier dispositivo.</p>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
