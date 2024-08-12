window.ShowToastr = (type, message) => {
    if(type === "success")
    {
        toastr.success(message, "Operacion Correcta", { timeOut: 10000 });
    }
    if (type === "error") {
        toastr.error(message, "Operacion Fallida", { timeOut: 10000 });
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire('Success Notification', message, 'success');
    }
    if (type === "error") {
        Swal.fire('Error Notification', message, 'error');
    }
}

function MostrarModalConfirmacionBorrado() {
    $('#ModalConfirmacionBorrado').modal('show');
}

function OcultarModalConfirmacionBorrado() {
    $('#ModalConfirmacionBorrado').modal('hide');
}