<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Presentacion.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <!-- Enlace al CDN de Bootstrap 5.3 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Estilo personalizado para mejorar la apariencia */
        body {
            background: #f4f7fa;
            font-family: 'Arial', sans-serif;
        }

        .login-container {
            max-width: 400px;
            margin: 0 auto;
            padding: 40px 20px;
            background-color: white;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            margin-top: 100px;
        }

        .login-container h2 {
            text-align: center;
            margin-bottom: 20px;
            font-size: 1.8rem;
            color: #333;
        }

        .form-control {
            border-radius: 5px;
            height: 45px;
        }

        .btn-primary {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            font-size: 1.1rem;
        }

        .btn-primary:hover {
            background-color: #0062cc;
            border-color: #0062cc;
        }

        .form-group label {
            font-size: 1.1rem;
            color: #333;
        }

        .forgot-password {
            text-align: center;
            margin-top: 10px;
        }

        .forgot-password a {
            color: #007bff;
            text-decoration: none;
        }

        .forgot-password a:hover {
            text-decoration: underline;
        }

        @media (max-width: 576px) {
            .login-container {
                margin-top: 40px;
                padding: 20px;
            }

            .login-container h2 {
                font-size: 1.5rem;
            }
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="login-container">
            <h2>Iniciar sesión</h2>
            <form id="form1" runat="server">
                <div class="form-group mb-3">
                    <label for="txtUsername">Usuario</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Ingresa tu usuario" required=""></asp:TextBox>
                </div>
                <div class="form-group mb-3">
                    <label for="txtPassword">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingresa tu contraseña" required=""></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Iniciar sesión" OnClick="btnLogin_Click" />
                </div>
                <div class="forgot-password">
                    <a href="#">¿Olvidaste tu contraseña?</a>
                </div>
                <div>
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </div>
            </form>
        </div>
    </div>

    <!-- Enlace a los archivos JavaScript de Bootstrap -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js"></script>
</body>
</html>
