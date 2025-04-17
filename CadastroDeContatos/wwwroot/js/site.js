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


    let btn = document.querySelector('.close-alert')
    let alert = document.querySelector('.alert')
    if (btn && alert) {
        btn.addEventListener("click", () => {
            alert.classList.add('d-none');
        })
    }
});