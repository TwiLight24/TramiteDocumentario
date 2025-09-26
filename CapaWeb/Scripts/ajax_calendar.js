function DesactivaDiasNoLaborables(sender, args) {

    var idCelda;
    var filagrilla;
    
    //strValorCelda = "ContentPlaceHolder1_gvwRegHoras_cldFecha_0_day_5_0"
    for (var i = 0; i < sender._days.all.length; i++) {
        for (var j = 0; j < 6; j++) {

            idCelda = sender._days.all[i].id;
            idCelda = idCelda.substring(32, 52)
            if (idCelda.substring(0, 9) == "cldFecha_") {

                if (idCelda.indexOf('_da') == 10)
                { filagrilla = idCelda.substring(9, 10); }
                if (idCelda.indexOf('_da') == 11)
                { filagrilla = idCelda.substring(9, 11); }
                if (idCelda.indexOf('_da') == 12)
                { filagrilla = idCelda.substring(9, 12); }               
                                
                //Desactiva Domingos (0) y Sabados (6)
                if ((idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_0") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_6")) {
                    sender._days.all[i].disabled = true;
                    sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                }
                //Para el resto de días, la desactivación es de acuerdo a Arreglo
                if ((idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_1") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_2") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_3") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_4") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_5")) {
                    
                    sender._days.all[i].disabled = false;
                    for (var k = 0; k < arrayDiasFeriados.length; k++) {
                        if (Number(sender._days.all[i].innerText) == Number(arrayDiasFeriados[k].substring(6, 8))) {
                            if (Number(arrayDiasFeriados[k].substring(9, 10)) == 1) {
                                sender._days.all[i].style.color = "#FF6600"; //.setAttribute("style", "color: #FF6600;");
                                break;
                            }
                            else {
                                sender._days.all[i].disabled = true;
                                sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                                break;
                            }
                        }
                    }
                }

            }


        }
    }
}

function DesactivaDiasNoLaborablesDetalle(sender, args) {

    var idCelda;
    var filagrilla;
    var long;
   
    //strValorCelda = "ContentPlaceHolder1_gvwRegHoras_cldFecha_0_day_5_0"
    for (var i = 0; i < sender._days.all.length; i++) {
        for (var j = 0; j < 6; j++) {

            idCelda = sender._days.all[i].id;
            long = idCelda.length;

            if (long == 63 || long == 65) // ejm 63: cldFecha_0_day_0_0  ---  ejm 65: cldFecha_0_daysTable
            { idCelda = idCelda.substring(45, 65); }
            if (long == 64 || long == 66) // ejm 64: cldFecha_11_day_0_0  ---  ejm 66: cldFecha_11_daysTable
            { idCelda = idCelda.substring(46, 66); }

            if (idCelda.substring(0, 9) == "cldFecha_") {

                if (idCelda.indexOf('_da') == 10)
                    { filagrilla = idCelda.substring(9, 10); }
                if (idCelda.indexOf('_da') == 11)
                    { filagrilla = idCelda.substring(9, 11); }
                if (idCelda.indexOf('_da') == 12)
                    { filagrilla = idCelda.substring(9, 12); }

                //Desactiva Domingos (0) y Sabados (6)
                if ((idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_0") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_6")) {
                    sender._days.all[i].disabled = true;
                    sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                }
                //Para el resto de días, la desactivación es de acuerdo a Arreglo
                if ((idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_1") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_2") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_3") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_4") ||
                    (idCelda == "cldFecha_" + filagrilla + "_day_" + j + "_5")) {

                    sender._days.all[i].disabled = false;
                    for (var k = 0; k < arrayDiasFeriados.length; k++) {
                        if (Number(sender._days.all[i].innerText) == Number(arrayDiasFeriados[k].substring(6, 8))) {
                            if (Number(arrayDiasFeriados[k].substring(9, 10)) == 1) {
                                sender._days.all[i].style.color = "#FF6600"; // .setAttribute("style", "color: #FF6600;");
                                break;
                            }
                            else {
                                sender._days.all[i].disabled = true;
                                sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                                break;
                            }
                        }
                    }
                }

            }


        }
    }
}