document.addEventListener('DOMContentLoaded', function () {


    createDataTable = (nome) => {
        if (document.getElementById(nome)) {
            new DataTable(nome, {
                language: {
                    url: "//cdn.datatables.net/plug-ins/1.11.5/i18n/pt-BR.json"
                }
            });
        }
    }

    createDataTable('tabelaContatos');
    createDataTable('tabelaUsuarios');


    const botoesAbrirModal = document.querySelectorAll('.btn-total-contatos');
    botoesAbrirModal.forEach(function (botao) {
        botao.addEventListener('click', function () {
            const modal = document.getElementById('modal-contatos-usuario');
            const bootstrapModal = new bootstrap.Modal(modal);

            $.ajax({
                type: 'GET',
                url: "/User/ListarContatoPorUsuarioId", success: function (result) {
                    $("#lista-contatos-id").html(result);
                    bootstrapModal.show();
                }
            });

           
        });
    });

    const botoesFecharAlerta = document.querySelectorAll('.close-alert');
    botoesFecharAlerta.forEach(function (botao) {
        botao.addEventListener('click', function () {
            const alertas = document.querySelectorAll('.alert');
            alertas.forEach(function (alerta) {
                alerta.style.display = 'none';
            });
        });
    });
});