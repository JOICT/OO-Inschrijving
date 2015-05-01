
$(function () {
    // init Isotope

    var qsRegex;
    var $container = $('.isotope').isotope({
        itemSelector: '.element-item',
        layoutMode: 'fitRows'

    });

    function searchFilter() {
        qsRegex = new RegExp($quicksearch.val(), 'gi');
        $container.isotope({
            filter: function () {
                return qsRegex ? $(this).text().match(qsRegex) : true;
            }
        });
    }


    var $quicksearch = $('#quicksearch').keyup(debounce(searchFilter));


    // bind filter button click
    $('#filters').on('click', 'button', function () {
        var filterValue = $(this).attr('data-filter');

        // use filterFn if matches value

        $container.isotope({ filter: filterValue });
    });
    // change is-checked class on buttons
    $('.button-group').each(function (i, buttonGroup) {
        var $buttonGroup = $(buttonGroup);
        $buttonGroup.on('click', 'button', function () {
            $buttonGroup.find('.is-checked').removeClass('is-checked');

            $(this).addClass('is-checked');
        });
    });

});

function debounce(fn, threshold) {
    var timeout;
    return function debounced() {
        if (timeout) {
            clearTimeout(timeout);
        }
        function delayed() {
            fn();
            timeout = null;
        }
        timeout = setTimeout(delayed, threshold || 100);
    }
}