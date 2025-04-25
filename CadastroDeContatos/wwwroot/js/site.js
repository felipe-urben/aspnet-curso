document.addEventListener('DOMContentLoaded', function () {

    createDataTable('#tabelaUsuarios');
    createDataTable('#tabelaContatos');
   

    const botoesAbrirModal = document.querySelectorAll('.btn-total-contatos');
    botoesAbrirModal.forEach(function (botao) {
        botao.addEventListener('click', function () {
            const modal = document.getElementById('modal-contatos-usuario');
            const bootstrapModal = new bootstrap.Modal(modal);

            var usuarioId = botao.getAttribute('usuario-id');

            $.ajax({
                type: 'GET',
                url: `/User/ListarContatoPorUsuarioId/${usuarioId}`, success: function (result) {
                    console.log(`/User/ListarContatoPorUsuarioId/${usuarioId}`);
                    $("#listaContatosId").html(result);
                    bootstrapModal.show();

                    /*setTimeout(function () {
                        if ($.fn.DataTable.isDataTable('#tabelaContatos')) {
                            $('#tabelaContatos').DataTable().destroy();
                        }
                        createDataTable('#tabelaContatos');
                    }, 100);*/
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

function createDataTable(id){
    $(id).DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.11.5/i18n/pt-BR.json"
        }
    });
}