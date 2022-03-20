
$(function () {
    $(document).on("click", ".delete-btn", function (e) {
        e.preventDefault();
        let id = $(this).attr("data-id")
        let name = $(this).attr("data-name")
        Swal.fire({
            title: 'Do you agree?',
            text: "Do you want to delete the data?",
            icon: 'Warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Delete!'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(`/manage/${name}/delete?id=${id}`)
                    .then(Response => Response.text())
                    .then(data => {

                        window.location.reload(true);
                    })
            }
        })
    })


})


