$(document).ajaxError(function (xhr, props) {
    if (props.status === 401) {
        location.reload();
    }
});
