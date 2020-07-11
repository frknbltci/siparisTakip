
// CARGO İŞLEMLERİ 

function successMessage(title, message) {
    Command: toastr["success"](title, message)

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "1000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

}

function errorMessage(title, message) {

    Command: toastr["error"](title, message)

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }


}

function showUpdateCargo(id) {

    var data = {
        ID: id
    };

    $.ajax({
        url: "/Settings/UpdateInfo",
        data: data,
        type: "Post",
        success: function (e) {
            if (e) {
                $("#showPanelCargo").removeClass("hidden");
                $("#showPanelCargo").addClass("show");
                $('#kargoIsmi').val(e);
                $('#saveCargoNameBtn').attr("onclick", "UpdateCargoName(" + data.ID + ")");
            } else {


            }
        }

    });


};

//KARGO İSMİNİ DÜZENLEMEK İÇİN

function UpdateCargoName(id) {

    var cargoName = $("#kargoIsmi").val();

    var data = {
        ID: id,
        CargoName: cargoName
    };

    $.ajax({
        url: "/Settings/UpdateCargoName",
        data: data,
        type: "Post",
        success: function (e) {
            if (e == "OK") {

                successMessage("Güncellendi", "Başarılı");
                setTimeout(function () {
                    window.location.href = "/Settings/CargoOperations";
                }, 2000);

            } else {
                errorMessage("Güncellenmedi", "Başarısız.")

            }
        }
    });



};

function CargoEkle() {
    $('#showPanelCargoName').removeClass('hidden');
};

$('#ekleInputReset').on('click', () => {

    $('#ekleKargoIsmi').val('');
});

$('#ekleCargoNameBtn').on('click', () => {

    var yeniKargoIsmi = $('#ekleKargoIsmi').val();
    //VERİLERİ SESSİON İLE AL ŞUAN STATİK
    data = {
        CargoName: yeniKargoIsmi,
        UserID: 1,
        IsActive: true,

    };
    $.ajax({
        url: "/Settings/InsertCargoName",
        data: data,
        type: "Post",
        success: function (e) {
            if (e == true) {
                successMessage("Ekleme İşlemi", "Başarılı");
                setInterval(function () {
                    window.location.replace("/Settings/CargoOperations");
                }, 1000);

                //$("#showPanelCargo").removeClass("hidden");
                //$("#showPanelCargo").addClass("show");
            } else {


            }
        }


    });

});

//Aktif olan kargoları getirdiğimiz kısımda pop açıldığında,içeride ki evet buttonun onclick attr'ne id ataması yaptık

function silPopUpShow(id) {

    $('#silKargo').attr("onclick", "inActiveEt(" + id + ")");
}


function inActiveEt(id) {

    var data = {
        ID: id
    };

    console.log(id);
    $.ajax({
        url: "/Settings/InActiveEt",
        data: data,
        type: "Post",
        success: function (e) {

            console.log("YAZDIRDI");


            //if (e == true) {
            //    successMessage("AKTİFLİK DURUMU", "AKTİF DEĞİL");
            //    setInterval(function () {
            //        window.location.replace("/Settings/CargoOperations");
            //    }, 1000);

            //}
            //else {
            //    errorMessage("AKTİFLİK DURUMU", "AKTİF");
            //    setInterval(function () {
            //        window.location.replace("/Settings/CargoOperations");
            //    }, 1000);

            //}
        }
    });






}

function aktifEtPopUpShow(id) {

    $('#aktifEtKargo').attr("onclick", "ActiveEt(" + id + ")");
}


function ActiveEt(id) {
    var data = {
        ID: id
    };

    $.ajax({
        url: "/Settings/ActiveEt",
        data: data,
        type: "Post",
        success: function (e) {
            if (e == true) {
                successmessage('aktiflik durumu', "aktif değil");
            }
            else {
                errormessage("aktiflik durumu", "aktif");
            }
        }
    });
}



//MARKET İŞLEMLERİ

function MarketEkle() {
    $('#showPanelMarket').removeClass('hidden');
};

$('#saveMarketNameBtn').on('click', () => {

    var data = {
        ComissionPrice: $('#komisyonUcreti').val(),
        MarketName: $('#marketIsmi').val(),
        UserID: 1

    };

    $.ajax({
        url: "/Settings/ekleMarket",
        data: data,
        type: "Post",
        success: function (e) {
            if (e == true) {
                successMessage("Ekleme İşlemi", "Başarılı");
                setInterval(function () {
                    window.location.replace("/Settings/MarketOperations");
                }, 2000);

                //$("#showPanelCargo").removeClass("hidden");
                //$("#showPanelCargo").addClass("show");
            } else {
                errorMessage("Ekleme İşlemi", "Başarısız");
                setInterval(2000);

            }
        }


    });



});

function resetMarketInfo() {
    $('#komisyonUcreti').val('');
    $('#marketIsmi').val('');

}

function showUpdateMarket(id) {

    var data = {
        ID: id
    };

    $.ajax({
        url: "/Settings/UpdateMarketName",
        data: data,
        type: "Post",
        success: function (e) {
            if (e) {
                $('#duzenlemeEkrani').removeClass("hidden");
                $('#marketDznIsmi').val(e.MarketName);
                $('#komisyonDznIsmi').val(e.CommisionPrice);
               $('#saveMarketNameBtn').attr("onclick", "UpdateMarketName(" + data.ID + ")");
            } else {


            }
        }

    });

};


function UpdateMarketName(id) {

    $('#marketDznIsmi').val();
    $('#komisyonDznIsmi').val();

    var data = {
        ID: id,
        MarketName: $('#marketDznIsmi').val(),
        CommisionPrice: $('#komisyonDznIsmi').val()
    };

    $.ajax({

        url: "/Settings/EditMarketName",
        data: data,
        type: "Post",
        success: function (e) {
            if (e==true) {
                successMessage("Güncellendi", "Başarılı");
                setTimeout(function () {
                    window.location.href = "/Settings/MarketOperations";
                }, 2000);
                //Toastr'a bak ! 
            } else {
                errorMessage("Güncellenmedi", "Başarısız.")

            }
        }

    });


}

function resetDznMarket() {
    $('#marketDznIsmi').val('');
    $('#komisyonDznIsmi').val('');
}