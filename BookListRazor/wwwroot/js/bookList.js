var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  // Load data table via ID.
  dataTable = $('#DT_load').DataTable({
    // Make ajax call to the api.
    "ajax": {
      "url": "/api/book",
      "type": "GET",
      "datatype": "json"
    },
    "columns": [
      { "data": "name", "width": "20%" },
      { "data": "author", "width": "20%" },
      { "data": "isbn", "width": "20%" },
      {
        "data": "id",
        "render": function (data) {
          return `<div class="text-center">
                        <a href="/BookList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a href="/BookList/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:120px;'>
                            Edit(Upsert)
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/api/book?id='+${data})>
                            Delete
                        </a>
                        </div>`;
        }, "width": "40%"
      }
    ],
    "language": {
      "emptyTable": "no data found"
    },
    "width": "100%"
  });
}

function Delete(url) {
  swal({
    title: "Are you sure?",
    text: "Once deleted, you will not be able to undo this.",
    icon: "warning",
    buttons: true,
    dangermode: true
  }).then((willDelete) => {
    if (willDelete) {
      $.ajax({
        type: "DELETE",
        url: url,
        success: function (data) {
          if (data.success) {
            toastr.success(data.message);
            dataTable.ajax.reload();
          }
          else {
            toastr.error(data.message);
          }
        }
      });
    }
  });
}