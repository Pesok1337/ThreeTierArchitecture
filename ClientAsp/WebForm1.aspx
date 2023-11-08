<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ClientAsp.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Управление пользователями</title>
    <style>
    table {
        border-collapse: collapse;
        max-width: 80%; /* Максимальная ширина таблицы */
        max-height: 400px; /* Максимальная высота таблицы */
        overflow: auto; /* Добавление прокрутки при необходимости */
    }

    th, td {
        border: 1px solid black;
        padding: 8px;
        text-align: left;
    }

    th {
        background-color: #f2f2f2; /* Цвет фона заголовков */
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Заголовок для добавления пользователя -->
            <asp:Label ID="LabelCustInfo" runat="server" Text="Добавьте пользователя:"></asp:Label>
            <br />

            <!-- Поле для ввода имени пользователя -->
            <asp:Label ID="LblCust" runat="server" Text="Пользователь:"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />

            <!-- Поле для ввода названия компании -->
            <asp:Label ID="LblComp" runat="server" Text="Компания:"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />

            <!-- Кнопки для добавления и удаления пользователя -->
            <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click"></asp:Button>
            <asp:Button ID="ButtonDel" runat="server" Text="Удалить" OnClick="ButtonDel_Click"></asp:Button>
            <br />
            <br />
            <br />

            <!-- Заголовок для отображения информации о месте работы пользователя -->
            <asp:Label ID="LblOutput" runat="server" Text="Показать где человек работает:"></asp:Label>
            <br />

            <!-- Кнопка для отображения информации -->
            <asp:Button ID="ButtonShow" runat="server" Text="Показать" OnClick="ButtonShow_Click" />
            <br />

            <!-- Место для вывода информации о месте работы пользователя -->
            <asp:Label ID="LabelOut" runat="server" Text=""></asp:Label><br />
             <asp:Table ID="DataTable" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Имя сотрудника</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Название компании</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
