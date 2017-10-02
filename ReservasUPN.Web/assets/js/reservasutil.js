function EstiloSubmit(id){
    var btn = $("#"+id);
    btn.removeClass("RadButton RadButton_Default rbSkinnedButton");
    btn.find('[type="submit"]').removeClass("rbDecorated").addClass("btn btn-default");
}

function EstiloButton(id) {
    var btn = $("#" + id);
    btn.removeClass("RadButton RadButton_Default rbSkinnedButton");
    btn.find('[type="button"]').removeClass("rbDecorated").addClass("btn btn-default");
}