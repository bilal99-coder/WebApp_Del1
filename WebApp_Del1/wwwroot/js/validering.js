$(function () {
    $("#utreise").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: '2015:2025',
        dateFormat: 'dd/mm/yy',
        minDate: 0,
        defaultDate: null
    }).on('change', function () {
        $(this).valid();  // triggers the validation test
        // '$(this)' refers to '$("#datepicker")'
    });
});
