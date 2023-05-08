$(document).on("click", ".single-modal-btn", function (e) {
    e.preventDefault();

    let url = $(this).attr("href");

    fetch(url)
        .then(response => {

            if (response.ok) {
                return response.text()
            }
            else {
                alert("Xeta bas verdi!")
            }
        })
        .then(data => {
            $("#quickModal .modal-dialog").html(data)
            $("#quickModal").modal('show');
        })
   
})
