$(function () {

    $('.list-group-item').on('click', function () {
        $('.fas', this)
          .toggleClass('fas fa-angle-right')
          .toggleClass('fas fa-angle-down');
    });

});