$(function () {

    function WireUpDatePicker() {

        const addMonths = 12;
        var currDate = new Date();

        $('.datepicker').datepicker(
            {
                dateFormat: 'yy-mm-dd',
                minDate: currDate,
                maxDate: AddSubtractMonths(currDate, addMonths)

            }
        );

    }

    WireUpDatePicker();


});