$(document).ready(function () {
    $('#tabelaContatos').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.11.5/i18n/pt-BR.json"
        }
    });

    $('#tabelaUsuarios').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.11.5/i18n/pt-BR.json"
        }
    });

    for (let i = 0; i < 1000; i++) {
        console.log(i);
    }

    $('.btn-total-contatos').click(() => {
        console.log("clique");
        $('#modalTotalContatos').modal('show');
    })

    $('.close-alert').click(() => {
        $('.alert').hide();
    })

    /*let btn = document.querySelector('.close-alert')
    let alert = document.querySelector('.alert')
    if (btn && alert) {
        btn.addEventListener("click", () => {
            alert.classList.add('d-none');
        })
    }*/
});