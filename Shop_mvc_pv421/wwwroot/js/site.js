// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function configConfirmModal(dialogId, confirmUrl) {
    var modal = document.getElementById(dialogId)
    var deleteBtn = modal.querySelector('.actionBtn')

    modal.addEventListener('show.bs.modal', function (event) {
        // Button that triggered the modal
        var button = event.relatedTarget

        var id = button.getAttribute('data-bs-id')
        deleteBtn.setAttribute('href', confirmUrl + id)
    })
}